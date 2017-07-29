﻿using DBLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eAPMC.Classes;

namespace eAPMC.Forms
{
    public partial class frmChallan : Form
    {
        public string ChallanNo { get; set; }

        public Int64 SessionID { get; set; }
        public frmChallan()
        {
            InitializeComponent();
        }

        private void frmChallan_Load(object sender, EventArgs e)
        {
            LoadChallanData();
            rdReceiverType_Farmer.Checked = true;
        }

        private void LoadChallanData()
        {
            DataSet ds = GetChallanLoadInfo();

            if (ds != null && ds.Tables.Count > 0)
            {
                Challan oChallan=new Challan();
                if (ds.Tables[0]!=null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lblChallanNo.Text = Convert.ToString(dr["ChallanNo"]);
                        mskChallanDate.Text = Convert.ToDateTime(dr["ChallanDateTime"]).ToString("dd-MM-yyyy");
                        mskChallanTime.Text = Convert.ToDateTime(dr["ChallanDateTime"]).ToString("HH:mm:ss");
                        lblUserName.Text = eGlobal.UserName;
                    }
                }
                if (ds.Tables[1]!=null)
                {
                    DataRow dr =ds.Tables[1].NewRow();
                    dr["PersonID"]="-1";
                    dr["PersonCode"]="-1";
                    dr["PersonName"]="--Select--";
                    ds.Tables[1].Rows.InsertAt(dr, 0);
                    cmbFamersList.DataSource = ds.Tables[1];
                    cmbFamersList.DisplayMember = "PersonName";
                    cmbFamersList.ValueMember = "PersonID";
                }
                if (ds.Tables[2] != null)
                {
                    DataRow dr = ds.Tables[2].NewRow();
                    dr["PersonID"] = "-1";
                    dr["PersonCode"] = "-1";
                    dr["PersonName"] = "--Select--";
                    ds.Tables[2].Rows.InsertAt(dr, 0); 
                    cmbDriversList.DataSource = ds.Tables[2];
                    cmbDriversList.DisplayMember = "PersonName";
                    cmbDriversList.ValueMember = "PersonID";
                }
                if (ds.Tables[3] != null)
                {
                    DataRow dr = ds.Tables[3].NewRow();
                    dr["Code"] = "0";
                    dr["Description"] = "--Select--";
                    ds.Tables[3].Rows.InsertAt(dr, 0);
                    cmbChallanItem.DataSource = ds.Tables[3];
                    cmbChallanItem.DisplayMember = "Description";
                    cmbChallanItem.ValueMember = "Code";
                }
                if (ds.Tables[4] != null)
                {
                    DataRow dr = ds.Tables[4].NewRow();
                    dr["Code"] = "-1";
                    dr["Description"] = "--Select--";
                    ds.Tables[4].Rows.InsertAt(dr, 0);
                    cmbVehicleList.DataSource = ds.Tables[4];
                    cmbVehicleList.DisplayMember = "Description";
                    cmbVehicleList.ValueMember = "Code";
                }
            }
        }

        private DataSet GetChallanLoadInfo()
        {
            DataSet dsReturn = new DataSet();
            DBAccess dbAccess = null;
            try
            {
                dbAccess = new DBAccess();
                dsReturn = dbAccess.GetChallanLoadDetails();
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
            return dsReturn;
        }

        private void grpbLoginDetails_Enter(object sender, EventArgs e)
        {

        }

        private void rdReceiverType_Driver_CheckedChanged(object sender, EventArgs e)
        {
            if (rdReceiverType_Driver.Checked)
            {
                pnlChallanReceiver_Driver.BringToFront();
                pnlChallanReceiver_Farmer.SendToBack();
            }
        }

        private void rdReceiverType_Farmer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdReceiverType_Farmer.Checked)
            {
                pnlChallanReceiver_Driver.SendToBack();
                pnlChallanReceiver_Farmer.BringToFront();
            }
        }
    }
}
