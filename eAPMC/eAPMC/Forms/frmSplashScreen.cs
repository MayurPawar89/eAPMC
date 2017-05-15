using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBLayer;


namespace eAPMC.Forms
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sLoginName = string.Empty;
            string sPaasword = string.Empty;

            sLoginName = txtUserName.Text.Trim();
            sPaasword = txtPassword.Text.Trim();

            if (Login(sLoginName,sPaasword))
            {
                Dashbaord frmDashboard = new Dashbaord();
                frmDashboard.ShowDialog(this);
                frmDashboard.Dispose();
                frmDashboard = null;
            }
        }

        private bool Login(string LoginName, string Password)
        {
            bool _result = false;
            DBAccess dbAccess = null;
            DataTable dtUser = null;
            try
            {
                dbAccess = new DBAccess();
                dtUser= dbAccess.GetUserDetails(LoginName);
                if (dtUser!=null&&dtUser.Rows.Count>0)
                {
                    foreach (DataRow dr in dtUser.Rows)
                    {
                        string sEncryptedPassword = Convert.ToString(dr["Password"]);
                        string sDecryptedPassword = Encryption.DecryptFromBase64String(sEncryptedPassword);
                        if (sDecryptedPassword==Password)
                        {
                            _result = true;
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return _result;
        }
    }
}
