﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBLayer;
using eAPMC.Classes;


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
            bool bIsDefaultPassword = false;
            if (Login(sLoginName,sPaasword,out bIsDefaultPassword))
            {
                this.Hide();
                Dashbaord frmDashboard = new Dashbaord();
                frmDashboard.IsDefaultPassword = bIsDefaultPassword;
                frmDashboard.Show(this);
                //frmDashboard.Dispose();
                //frmDashboard = null;
                //this.Close();
            }
        }

        private bool Login(string LoginName, string Password, out bool IsDefaultPassword)
        {
            bool _result = false;
            DBAccess dbAccess = null;
            DataTable dtUser = null;
            IsDefaultPassword = false;
            try
            {
                dbAccess = new DBAccess();
                dtUser= dbAccess.GetUserDetails(LoginName);
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtUser.Rows)
                    {
                        string sEncryptedPassword = Convert.ToString(dr["Password"]);
                        string sDecryptedPassword = Encryption.DecryptFromBase64String(sEncryptedPassword);
                        if (sDecryptedPassword == Password)
                        {
                            eGlobal.UserName = Convert.ToString(dr["FirstName"]) + " " + Convert.ToString(dr["LastName"]);
                            eGlobal.UserID = Convert.ToInt64(dr["UserID"]);
                            eGlobal.LoginName = Convert.ToString(dr["LoginName"]);
                            //eGlobal.UserType = Convert.ToInt64(dr["UserType"]);
                            if (Password == "eAPMC")
                            {
                                IsDefaultPassword = true;
                            }
                            eGlobal.LoginSessionID=Convert.ToInt64(AddRemoteLoginSession(Convert.ToString(dr["LoginName"]), true));
                            _result = true;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("User Name or Password not match. Please enter correct information.");
                            _result = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User not exists in system. Please enter correct information.");
                    _result = false;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return _result;
        }
        public Int64 AddRemoteLoginSession(string LoginName, bool _isLogin = true)
        {
            MachineDetails.MachineInfo localMachine = MachineDetails.LocalMachineDetails(_isLogin);
            MachineDetails.MachineInfo remotemachine = MachineDetails.RemoteMachineDetails(_isLogin);
            DBAccess dbAccess = null;
            Int64 LoginSessionID = 0;
            try
            {
                dbAccess = new DBAccess();
                LoginSessionID = dbAccess.InsertUserSession(0, LoginName, localMachine.MachineName, localMachine.MachineIp, localMachine.UserName, remotemachine.MachineName, remotemachine.MachineIp, remotemachine.UserName, remotemachine.DomainName, System.Diagnostics.Process.GetCurrentProcess().Id);
            }
            catch (Exception)
            {
                
                throw;
            }
            return LoginSessionID;
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            TabIndexing.TabScheme oTabScheme = TabIndexing.TabScheme.AcrossFirst;
            TabIndexing oTabIndex = new TabIndexing(this);
            oTabIndex.SetTabOrder(oTabScheme);
        }
    }
}
