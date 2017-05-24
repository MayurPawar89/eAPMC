using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using eAPMC.UserControls;

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

        PincodeFinder ucPincodeFinder = null;
        private void txtPincode_TextChanged(object sender, EventArgs e)
        {
            string sSearchText = txtPincode.Text.ToString();
            if (sSearchText != "")
            {
                if (pnlPincodeDetails.Visible == false)
                {
                    ucPincodeFinder = new PincodeFinder();
                    ucPincodeFinder.dgvPincodes.SelectionChanged += dgvPincodes_SelectionChanged;
                    pnlPincodeDetails.BringToFront();
                    pnlPincodeDetails.Visible = true;
                    pnlPincodeDetails.Controls.Add(ucPincodeFinder);

                    //ucPincodeFinder.SearchPincode(sSearchText);
                }
                else
                {
                    ucPincodeFinder.dgvPincodes.SelectionChanged -= dgvPincodes_SelectionChanged;
                    ucPincodeFinder.SearchPincode(sSearchText);
                    ucPincodeFinder.dgvPincodes.SelectionChanged += dgvPincodes_SelectionChanged;
                }

            }
        }

        void dgvPincodes_SelectionChanged(object sender, EventArgs e)
        {
            if (ucPincodeFinder.oPincode.bIsPincodeSelected)
            {
                txtPincode.Text = ucPincodeFinder.oPincode.AreaPincode;
                txtArea.Text = ucPincodeFinder.oPincode.Area;
                txtTaluka.Text = ucPincodeFinder.oPincode.Taluka;
                txtDistrict.Text = ucPincodeFinder.oPincode.District;
                txtState.Text = ucPincodeFinder.oPincode.State;
                pnlPincodeDetails.Visible = false;
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex rEmail = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            if (txtEmail.Text.Length > 0)
            {
                if (!rEmail.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.SelectAll();
                }
            }
        }

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnPreviewNSave_Click(object sender, EventArgs e)
        {
            frmViewPersonDetails ofrmViewPersonDetails = new frmViewPersonDetails();
            ofrmViewPersonDetails.PersonEntityType = PersonEntityType;
            ofrmViewPersonDetails.ShowDialog(this);
            ofrmViewPersonDetails.Dispose();
            ofrmViewPersonDetails = null;
        }
    }
}
