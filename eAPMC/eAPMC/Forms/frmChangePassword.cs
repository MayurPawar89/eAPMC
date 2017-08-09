using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;
using eAPMC.Classes;

namespace eAPMC.Forms
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void txtOldPassword_Leave(object sender, EventArgs e)
        {
            if (txtOldPassword.Text.Trim()!="" && ChekcOldPassword(txtOldPassword.Text.Trim())==false)
            {
                MessageBox.Show("Old Password not match. Please enter correct old password.");
            }
        }

        private bool ChekcOldPassword(string sOldPassword)
        {
            bool bIsOldPasswordMatch = false;
            DBAccess dbAccess = null;
            DataTable dtUser = null;
            try
            {
                dbAccess = new DBAccess();
                dtUser = dbAccess.GetUserDetails(sLoginName);
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtUser.Rows)
                    {
                        string sEncryptedPassword = Convert.ToString(dr["Password"]);
                        string sDecryptedPassword = Encryption.DecryptFromBase64String(sEncryptedPassword);
                        if (sDecryptedPassword == sOldPassword)
                        {
                            bIsOldPasswordMatch = true;
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return bIsOldPasswordMatch;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateControl()==false)
            {
                DBAccess dbAccess = null;
                try
                {
                    dbAccess = new DBAccess();
                    Int64 nUserID = 0;
                    string sPassword = Encryption.EncryptToBase64String(txtConfirmPassword.Text.Trim());
                    nUserID = dbAccess.ChangePassword(eGlobal.UserID, sLoginName, sPassword);
                    if (nUserID > 0)
                    {
                        MessageBox.Show("Password change done.");
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private bool validateControl()
        {
            bool result = false;
            if (txtOldPassword.Text.Trim()=="")
            {
                MessageBox.Show("Please enter old password.");
                txtOldPassword.Focus();
                result = true;
            }
            else if (txtNewPassword.Text.Trim()=="")
            {
                MessageBox.Show("Please enter new password.");
                txtNewPassword.Focus();
                result = true;
            }
            else if (txtConfirmPassword.Text.Trim()=="")
            {
                MessageBox.Show("Please enter confirm password.");
                txtConfirmPassword.Focus();
                result = true;
            }
            else if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Password and Confirm password should be match.");
                result = true;
            }

            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string sLoginName = string.Empty;
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            sLoginName = eGlobal.LoginName;
            TabIndexing.TabScheme oTabScheme = TabIndexing.TabScheme.AcrossFirst;
            TabIndexing oTabIndex = new TabIndexing(this);
            oTabIndex.SetTabOrder(oTabScheme);
        }
    }
}
