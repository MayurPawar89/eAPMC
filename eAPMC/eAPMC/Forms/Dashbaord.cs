using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eAPMC.Classes;

namespace eAPMC.Forms
{
    public partial class Dashbaord : Form
    {
        public Dashbaord()
        {
            InitializeComponent();
        }
        public string UserName { get; set; }
        public Int64 UserType { get; set; }
        public Int64 UserID { get; set; }
        public Boolean IsDefaultPassword { get; set; }

        private void btnRegisterFarmer_Click(object sender, EventArgs e)
        {
            frmPersonRegistration ofrmPersonRegistration = new frmPersonRegistration();
            ofrmPersonRegistration.PersonType =eGlobal.PersonType.Farmer;
            ofrmPersonRegistration.ShowDialog(this);
            ofrmPersonRegistration.Dispose();
            ofrmPersonRegistration = null;
        }

        private void btnRegisterDrive_Click(object sender, EventArgs e)
        {
            frmPersonRegistration ofrmPersonRegistration = new frmPersonRegistration();
            ofrmPersonRegistration.PersonType = eGlobal.PersonType.Driver;
            ofrmPersonRegistration.ShowDialog(this);
            ofrmPersonRegistration.Dispose();
            ofrmPersonRegistration = null;
        }

        private void btnRegisterSaller_Click(object sender, EventArgs e)
        {
            frmPersonRegistration ofrmPersonRegistration = new frmPersonRegistration();
            ofrmPersonRegistration.PersonType = eGlobal.PersonType.Sellar;
            ofrmPersonRegistration.ShowDialog(this);
            ofrmPersonRegistration.Dispose();
            ofrmPersonRegistration = null;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisterOrganization_Click(object sender, EventArgs e)
        {

        }

        private void btnChallan_Click(object sender, EventArgs e)
        {
            frmChallan ofrmChallan = new frmChallan();
            ofrmChallan.ShowDialog(this);
            ofrmChallan.Dispose();
            ofrmChallan = null;
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            frmUserRegistration ofrmUserRegistration = new frmUserRegistration();
            ofrmUserRegistration.ShowDialog(this);
            ofrmUserRegistration.Dispose();
            ofrmUserRegistration = null;
        }

        private void Dashbaord_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Dashbaord_Load(object sender, EventArgs e)
        {
            if (IsDefaultPassword)
            {
                frmChangePassword ofrmChangePassword = new frmChangePassword();
                ofrmChangePassword.ShowDialog(this);
                ofrmChangePassword.Dispose();
                ofrmChangePassword = null;
            }
        }

        private void tmnuTools_ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword ofrmChangePassword = new frmChangePassword();
            ofrmChangePassword.ShowDialog(this);
            ofrmChangePassword.Dispose();
            ofrmChangePassword = null;
        }

        private void tmnuView_Users_Click(object sender, EventArgs e)
        {
            frmView_AllUsers ofrmView_AllUsers = new frmView_AllUsers();
            ofrmView_AllUsers.ShowDialog(this);
            ofrmView_AllUsers.Dispose();
            ofrmView_AllUsers = null;
        }
    }
}
