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

namespace eAPMC.Forms
{
    public partial class frmView_AllUsers : Form
    {
        int nUserType = -1;
        public frmView_AllUsers()
        {
            InitializeComponent();
        }

        private void frmView_AllUsers_Load(object sender, EventArgs e)
        {
            rdAllUsers.Checked = true;
            FillUsersList(nUserType);
        }

        private void FillUsersList(int nUserType)
        {
            DataTable dtUsersList = GetUsersDetails(nUserType);
            dgvUsersList.DataSource = dtUsersList;
        }

        private DataTable GetUsersDetails(int UsersType)
        {
            DBAccess dbAccess = null;
            DataTable dtPincodedetails = null;
            try
            {
                dbAccess = new DBAccess();
                dtPincodedetails = dbAccess.GetUsersDetails(UsersType);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (dbAccess != null)
                {
                    dbAccess = null;
                }
            }
            return dtPincodedetails;
        }

        private void rdAllUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAllUsers.Checked)
            {
                nUserType = 0;
                FillUsersList(nUserType);
            }
        }

        private void rdActiveUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdActiveUsers.Checked)
            {
                nUserType = 1;
                FillUsersList(nUserType);
            }
        }

        private void rdBlockedUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBlockedUsers.Checked)
            {
                nUserType = 2;
                FillUsersList(nUserType);
            }
        }
    }
}
