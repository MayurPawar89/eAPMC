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
using DBLayer;
using eAPMC.Classes;
using eAPMC.UserControls;

namespace eAPMC.Forms
{
    public partial class frmUserRegistration : Form
    {
        public frmUserRegistration()
        {
            InitializeComponent();
        }
        DataTable dtPincode;
        private void frmUserRegistration_Load(object sender, EventArgs e)
        {
            FillRoles();
        }

        private void FillRoles()
        {
            bool _result = false;
            DBAccess dbAccess = null;
            DataTable dtRoles = null;
            try
            {
                dbAccess = new DBAccess();
                dtRoles = dbAccess.GetRoles();
                if (dtRoles != null && dtRoles.Rows.Count > 0)
                {
                    cmbRolesMst.DataSource = dtRoles;
                    cmbRolesMst.DisplayMember = "RoleName";
                    cmbRolesMst.ValueMember = "RoleId";

                    cmbRolesMst.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            DBAccess dbAccess = null;
            DataTable dtUser = null;
            try
            {
                if (ValidateControl())
                {
                    return;
                }
                
                dbAccess = new DBAccess();
                Int64 nUserID = 0;
                string sLoginName = txtLoginName.Text.ToString();
                string sPassword = Encryption.EncryptToBase64String(txtConfirmPassword.Text.Trim());
                string sFirstName = txtPersonFName.Text.Trim();
                string sMiddleName = txtPersonMName.Text.Trim();
                string sLastName = txtPersonLName.Text.Trim();
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

                DateTime dtDOB = Convert.ToDateTime(mskPersonDOB.Text);
                DateTime dtRegistrationDate = DateTime.Now;
                string sPhone = txtPhoneNo.Text.Trim();
                string sMobile = txtMobileNo.Text.Trim();
                string sMobile1 = txtMobileNo1.Text.Trim();
                string seMail = txtEmail.Text.Trim();
                string sAddressLine1 = txtAddressLine1.Text.Trim();
                string sAddressLine2 = txtAddressLine2.Text.Trim();
                string sCity = txtArea.Text.Trim();
                string sState = txtState.Text.Trim();
                string sZip = txtPincode.Text.Trim();
                bool bIsBlocked = false;
                if (chkIsActiveUser.Checked)
                {
                    bIsBlocked = false;
                }
                else
                {
                    bIsBlocked = true;
                }
                nUserID = dbAccess.InsertUpdateUserMaster(0, sLoginName, sPassword, sFirstName, sMiddleName, sLastName, nGender, dtDOB, dtRegistrationDate, sPhone, sMobile, sMobile1, seMail, sAddressLine1, sAddressLine2, sCity, sState, sZip, bIsBlocked);
                if (nUserID > 0)
                {
                    MessageBox.Show("User register successfully.");
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        private bool ValidateControl()
        {
            bool result = false;
            if (txtPersonFName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter user first name.");
                txtPersonFName.Focus();
                result = true;
            }
            else if (txtPersonLName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter user last name.");
                txtPersonLName.Focus();
                result = true;
            }
            else if (mskPersonDOB.MaskCompleted == false)
            {
                MessageBox.Show("Please enter user date of birth.");
                mskPersonDOB.Focus();
                result = true;
            }
            else if (cmbRolesMst.SelectedText == "")
            {
                MessageBox.Show("Please select user role.");
                cmbRolesMst.Focus();
                result = true;
            }
            else if (txtPincode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter pincode.");
                txtPincode.Focus();
                result = true;
            }
            else if (txtMobileNo.Text.Trim()=="")
            {
                MessageBox.Show("Please enter Mobile no.");
                txtMobileNo.Focus();
                result = true;
            }
            else if (txtLoginName.Text.Trim()=="")
            {
                MessageBox.Show("Please enter user name.");
                txtLoginName.Focus();
                result = true;
            }
            else if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter password.");
                txtPassword.Focus();
                result = true;
            }
            else if (txtConfirmPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter confirm password.");
                txtConfirmPassword.Focus();
                result = true;
            }
            else if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Password and Confirm password should be match.");
                result = true;
            }


            return result;
        }
        //private void dgvPincodes_SelectionChanged(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewRow row in dgvPincodes.SelectedRows)
        //    {
        //        txtArea.Text = row.Cells[1].Value.ToString();
        //        txtTaluka.Text = row.Cells[2].Value.ToString();
        //        txtDistrict.Text = row.Cells[3].Value.ToString();
        //        txtState.Text = row.Cells[4].Value.ToString();
        //        pnlPincodeDetails.Visible = false;
        //    }
        //}
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
