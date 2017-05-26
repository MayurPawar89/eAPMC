using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using eAPMC.Classes;
using eAPMC.UserControls;

namespace eAPMC.Forms
{
    public partial class frmPersonRegistration : Form
    {
        public eGlobal.PersonType PersonType { get; set; }
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
            switch (PersonType)
            {
                case eGlobal.PersonType.Farmer://Farmer
                    {
                        lblRegistration.Text = "Farmer Registration";
                        break;
                    }
                case eGlobal.PersonType.Driver://Driver
                    {
                        lblRegistration.Text = "Driver Registration";
                        break;
                    }
                case eGlobal.PersonType.Sellar://Saller
                    {
                        lblRegistration.Text = "Saller Registration";
                        grpbOrganizationDetails.Visible = true;
                        break;
                    }
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
                    if (ucPincodeFinder!=null)
                    {
                        ucPincodeFinder.Dispose();
                        ucPincodeFinder = null;
                    }
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
            Person oPerson = null;

            if (validateControls())
            {
                oPerson = new Person();
                oPerson.PersonFirstName = txtPersonFName.Text.Trim();
                oPerson.PersonMiddleName = txtPersonMName.Text.Trim();
                oPerson.PersonLastName = txtPersonLName.Text.Trim();
                oPerson.PersonDOB = Convert.ToDateTime(mskPersonDOB.Text.Trim());
                int nGender = -1;
                if (rdPersonMale.Checked)
                {
                    nGender = 1;
                }
                else if (rdPersonFemale.Checked)
                {
                    nGender = 2;
                }
                else if (rdPersonOthers.Checked)
                {
                    nGender = 0;
                }
                oPerson.PersonEntityTypeCode = eGlobal.EntityType.Individual.GetHashCode();
                oPerson.PersonEntityTypeDesc = eGlobal.EntityType.Individual.ToString();

                oPerson.PersonGender = nGender;
                oPerson.PersonTypeCode = PersonType.GetHashCode();
                oPerson.personTypeDesc = PersonType.ToString();
                oPerson.AddressType = 1;
                oPerson.AddressLine1 = txtAddressLine1.Text.Trim();
                oPerson.AddressLine2 = txtAddressLine2.Text.Trim();
                oPerson.City = txtArea.Text.Trim();
                oPerson.Taluka = txtTaluka.Text.Trim();
                oPerson.District = txtDistrict.Text.Trim();
                oPerson.State = txtState.Text.Trim();
                oPerson.ZipCode = txtPincode.Text.Trim();

                List<ContactDetails> lstContactDetails = new List<ContactDetails>();
                ContactDetails oContact = new ContactDetails();

                oContact.ContactNo = txtMobileNo.Text.Trim();
                oContact.ContactTypeCode = eGlobal.ContactType.MobileNo.GetHashCode().ToString();
                oContact.ContactTypeDesc = eGlobal.ContactType.MobileNo.ToString();// "MobileNo";
                //oPerson.ContactDetails.Add(oContact);
                lstContactDetails.Add(oContact);
                oContact = null;
                
                oContact = new ContactDetails();
                oContact.ContactNo = txtFaxNo.Text.Trim();
                oContact.ContactTypeCode = eGlobal.ContactType.FaxNo.GetHashCode().ToString();
                oContact.ContactTypeDesc = eGlobal.ContactType.FaxNo.ToString();// "FaxNo";
                //oPerson.ContactDetails.Add(oContact);
                lstContactDetails.Add(oContact);
                oContact = null;

                oContact = new ContactDetails();
                oContact.ContactNo = txtEmail.Text.Trim();
                oContact.ContactTypeCode = eGlobal.ContactType.EmailID.GetHashCode().ToString();
                oContact.ContactTypeDesc = eGlobal.ContactType.EmailID.ToString();// "EmailID";
                //oPerson.ContactDetails.Add(oContact);
                lstContactDetails.Add(oContact);

                oPerson.ContactDetails = lstContactDetails;
                oPerson.AadhaarCardNo = txtAadhaarNo.Text.Trim();
                oPerson.DrivingLicenceNo = txtDrivingLicenceNo.Text.Trim();
                oPerson.PANCardNo = txtPANNo.Text.Trim();
                oPerson.OtherIdCardDocumentNo = txtOtherDocumentID.Text.Trim();
                oPerson.OtherIdCardDocumentName = txtOtherDocumentName.Text.Trim();

                //oPerson.iPhoto=

                if (oPerson!=null)
                {
                    frmViewPersonDetails ofrmViewPersonDetails = new frmViewPersonDetails();
                    ofrmViewPersonDetails.PersonType = PersonType;
                    ofrmViewPersonDetails.PersonDetails = oPerson;
                    ofrmViewPersonDetails.ShowDialog(this);
                    ofrmViewPersonDetails.Dispose();
                    ofrmViewPersonDetails = null;  
                }
            }
        }

        private bool validateControls()
        {
            return true;
        }
    }
}
