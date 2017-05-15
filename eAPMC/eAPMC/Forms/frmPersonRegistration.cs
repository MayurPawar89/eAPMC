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
        public frmPersonRegistration()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pnlVerificationDoc.BringToFront();
            pnlPersonDetails.SendToBack();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlVerificationDoc.SendToBack();
            pnlPersonDetails.BringToFront();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
