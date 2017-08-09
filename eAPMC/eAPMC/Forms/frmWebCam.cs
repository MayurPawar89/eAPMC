using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using eAPMC.Classes;

namespace eAPMC.Forms
{
    public partial class frmWebCam : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        public PictureBox Picture { get; set; }
        public string PersonDetails { get; set; }
        public string PhotoLocation { get; set; }
        public int PhotoHeight { get; set; }
        public int PhotoWidth { get; set; }
        public string PhotoExtention { get; set; }
        public long PhotoSize { get; set; }
        public frmWebCam()
        {
            InitializeComponent();
        }

        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cmbCameraList.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    cmbCameraList.Items.Add(device.Name);
                }
                cmbCameraList.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                cmbCameraList.Items.Add("No Camera is attached");
            }
        }
        private void frmWebCam_Load(object sender, EventArgs e)
        {
            getCamList();
            TabIndexing.TabScheme oTabScheme = TabIndexing.TabScheme.AcrossFirst;
            TabIndexing oTabIndex = new TabIndexing(this);
            oTabIndex.SetTabOrder(oTabScheme);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStart.Text == "Start")
                {
                    if (DeviceExist)
                    {
                        videoSource = new VideoCaptureDevice(videoDevices[cmbCameraList.SelectedIndex].MonikerString);
                        videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                        CloseVideoSource();
                        videoSource.DesiredFrameSize = new Size(160, 120);
                        videoSource.ProvideSnapshots = true;
                        videoSource.Start();
                        txtCameraStatus.Text = "Camera is running";
                        btnStart.Text = "Stop";
                        timer1.Enabled = true;
                    }
                    else
                    {
                        if (videoSource != null && videoSource.IsRunning)
                        {
                            timer1.Enabled = false;
                            CloseVideoSource();
                            txtCameraStatus.Text = "Camera is stoped";
                            btnStart.Text = "Start";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in staring camera:" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();

            pictureBox1.Image = img;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCameraStatus.Text = "Device running.." + videoSource.FramesReceived.ToString() + " FPS";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getCamList();
        }

        private void frmWebCam_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource();
            Picture = pictureBox1;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    string sLocation = Path.Combine(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\")), "Images", "ProfileImages");
                    if (Directory.Exists(sLocation) == false)
                    {
                        Directory.CreateDirectory(sLocation);
                    }
                    string sImagePath = Path.Combine(sLocation, PersonDetails);

                    string path = sImagePath + "_" + DateTime.Now.ToString("yyyyMMddhhmm") + "." + Convert.ToString(ImageFormat.Png);
                    PhotoLocation = path;
                    Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                    Bitmap newImg = new Bitmap(bmpImage);
                    bmpImage.Save(path, ImageFormat.Png);
                    PhotoExtention = Path.GetExtension(path);
                    PhotoHeight = bmpImage.Height;
                    PhotoWidth = bmpImage.Width;
                    PhotoSize = new FileInfo(path).Length;
                    bmpImage.Dispose();
                    bmpImage = null;
                }
                else
                {
                    MessageBox.Show("No image is present");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in capturing image:" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
