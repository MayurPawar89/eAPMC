using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eAPMC.Forms
{
    public partial class Dashbaord : Form
    {
        public Dashbaord()
        {
            InitializeComponent();
        }

        private void btnRegisterFarmer_Click(object sender, EventArgs e)
        {
            frmPersonRegistration ofrmPersonRegistration = new frmPersonRegistration();
            ofrmPersonRegistration.PersonEntityType =0;
            ofrmPersonRegistration.ShowDialog(this);
            ofrmPersonRegistration.Dispose();
            ofrmPersonRegistration = null;
        }

        private void btnRegisterDrive_Click(object sender, EventArgs e)
        {
            frmPersonRegistration ofrmPersonRegistration = new frmPersonRegistration();
            ofrmPersonRegistration.PersonEntityType = 1;
            ofrmPersonRegistration.ShowDialog(this);
            ofrmPersonRegistration.Dispose();
            ofrmPersonRegistration = null;
        }

        private void btnRegisterSaller_Click(object sender, EventArgs e)
        {
            frmPersonRegistration ofrmPersonRegistration = new frmPersonRegistration();
            ofrmPersonRegistration.PersonEntityType = 2;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUserRegistration frm = new frmUserRegistration();
            frm.ShowDialog(this);

        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            frmUserRegistration frm = new frmUserRegistration();
            frm.ShowDialog(this);
        }
    }
}
