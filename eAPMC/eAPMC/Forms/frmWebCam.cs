using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace eAPMC.Forms
{
    public partial class frmWebCam : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
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
        }

        private void btnStart_Click(object sender, EventArgs e)
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
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                string path = Application.ExecutablePath.ToString() + DateTime.Now.ToString("yyyyMMdd_hhmm");
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                Bitmap newImg = new Bitmap(bmpImage);
                bmpImage.Save(path, ImageFormat.Png);
                bmpImage.Dispose();
                bmpImage = null;
            }
            else
            {
                MessageBox.Show("No image is present");
            }
        }
    }
}
