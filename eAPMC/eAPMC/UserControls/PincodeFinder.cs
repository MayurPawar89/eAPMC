using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eAPMC.Classes;
using DBLayer;

namespace eAPMC.UserControls
{
    public partial class PincodeFinder : UserControl
    {
        DataTable dtPincodes = null;
        public PincodeFinder()
        {
            InitializeComponent();
        }

        
        public Pincode oPincode = null;
        private void dgvPincodes_SelectionChanged(object sender, EventArgs e)
        {
            oPincode = new Pincode();
            foreach (DataGridViewRow row in dgvPincodes.SelectedRows)
            {
                oPincode.AreaPincode = row.Cells[0].Value.ToString();
                oPincode.Area = row.Cells[1].Value.ToString();
                oPincode.Taluka = row.Cells[2].Value.ToString();
                oPincode.District = row.Cells[3].Value.ToString();
                oPincode.State = row.Cells[4].Value.ToString();
                oPincode.bIsPincodeSelected = true;
            }
        }

        private void PincodeFinder_Load(object sender, EventArgs e)
        {
            try
            {
                dtPincodes = getPincodeDetails();
                dgvPincodes.DataSource = dtPincodes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.InnerException);
            }
        }

        private DataTable getPincodeDetails()
        {
            DBAccess dbAccess = null;
            DataTable dtPincodedetails = null;
            try
            {
                dbAccess = new DBAccess();
                dtPincodedetails = dbAccess.GetPincodeDetails();
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

        public void SearchPincode(string sSearchText)
        {
            DataView dv = dtPincodes.DefaultView;
            dgvPincodes.SelectionChanged -= dgvPincodes_SelectionChanged;
            dv.RowFilter = "PinCode Like '%" + sSearchText + "%'";

            dgvPincodes.DataSource = dv;
            dgvPincodes.SelectionChanged += dgvPincodes_SelectionChanged;
            Application.DoEvents(); 
        }
    }
    
}
