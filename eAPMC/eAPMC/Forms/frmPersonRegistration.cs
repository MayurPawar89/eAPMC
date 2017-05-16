using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAPMC.Forms
{
    public partial class frmPersonRegistration : Form
    {
        public int PersonEntityType { get; set; }
        public frmPersonRegistration()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pnlVerificationDoc.BringToFront();
            pnlPersonDetails.SendToBack();
            if (pnlVerificationDoc.Visible)
            {
                btnPreviewNSave.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlVerificationDoc.SendToBack();
            pnlPersonDetails.BringToFront();
            if (pnlVerificationDoc.Visible)
            {
                btnPreviewNSave.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonRegistration_Load(object sender, EventArgs e)
        {
            switch (PersonEntityType)
            {
                case 0://Farmer
                    {
                        lblRegistration.Text = "Farmer Registration";
                        break;
                    }
                case 1://Driver
                    {
                        lblRegistration.Text = "Driver Registration";
                        break;
                    }
                case 2://Saller
                    {
                        lblRegistration.Text = "Saller Registration";
                        grpbOrganizationDetails.Visible = true;
                        break;
                    }
                case 3://Other person
                    { break; }
            }
        }

        private void chkAadhaarNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAadhaarNo.Checked)
            {
                txtAadhaarNo.Enabled = true;
            }
            else
            {
                txtAadhaarNo.Enabled = false;
            }
        }

        private void chkDrivingLicenceNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrivingLicenceNo.Checked)
            {
                txtDrivingLicenceNo.Enabled = true;
            }
            else
            {
                txtDrivingLicenceNo.Enabled = false;
            }
        }

        private void chkPANNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPANNo.Checked)
            {
                txtPANNo.Enabled = true;
            }
            else
            {
                txtPANNo.Enabled = false;
            }
        }

        private void chkOtherID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherID.Checked)
            {
                pnlOtherDocumentDetails.Visible = true;
            }
            else
            {
                pnlOtherDocumentDetails.Visible = false;
            }
        }

        
    }
}
