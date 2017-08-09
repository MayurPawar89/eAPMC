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
    public partial class frmView_AllPersons : Form
    {
        int nPersonType = -1;
        public frmView_AllPersons()
        {
            InitializeComponent();
        }

        private void rdAllPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAllPerson.Checked)
            {
                nPersonType = -1;
                FillpersonList(nPersonType);
            }
        }

        private void FillpersonList(int nPersonType)
        {
            DataTable dtPerson = GetPersonList(nPersonType);
            dgvPersonList.DataSource = dtPerson;
        }

        private DataTable GetPersonList(int nPersonType)
        {
            DBAccess dbAccess = null;
            DataTable dtPersondetails = null;
            try
            {
                dbAccess = new DBAccess();
                dtPersondetails = dbAccess.GetPersonDetails(nPersonType);
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
            return dtPersondetails;
        }

        private void rdFarmer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFarmer.Checked)
            {
                nPersonType = eGlobal.PersonType.Farmer.GetHashCode();
                FillpersonList(nPersonType);
            }
        }

        private void rdDriver_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDriver.Checked)
            {
                nPersonType = eGlobal.PersonType.Driver.GetHashCode();
                FillpersonList(nPersonType);
            }
        }

        private void rdSellar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSellar.Checked)
            {
                nPersonType = eGlobal.PersonType.Sellar.GetHashCode();
                FillpersonList(nPersonType);
            }
        }

        private void frmView_AllPersons_Load(object sender, EventArgs e)
        {
            rdAllPerson.Checked = true;
            FillpersonList(nPersonType);
            TabIndexing.TabScheme oTabScheme = TabIndexing.TabScheme.AcrossFirst;
            TabIndexing oTabIndex = new TabIndexing(this);
            oTabIndex.SetTabOrder(oTabScheme);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvPersonList != null)
            {
                int rowindex = dgvPersonList.CurrentCell.RowIndex;
                int colindex = 0;

                Int64 PersonID = Convert.ToInt64(dgvPersonList.Rows[rowindex].Cells[colindex].Value);
                DataSet ds = GetPersonDetails(PersonID);

                if (ds != null && ds.Tables.Count > 0)
                {
                    AddressDetails oAddress = new AddressDetails();
                    Person oPerson = new Person();
                    PhotoDetails oPhoto = new PhotoDetails();
                    VerificationDetails oVerification = new VerificationDetails();
                    List<ContactDetails> lstContact = new List<ContactDetails>();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        oAddress.AddressID = Convert.ToInt64(dr["AddressId"]);
                        oAddress.AddressType = Convert.ToInt16(dr["AddressType"]);
                        oAddress.AddressLine1 = Convert.ToString(dr["AddressLine1"]);
                        oAddress.AddressLine2 = Convert.ToString(dr["AddressLine2"]);
                        oAddress.City = Convert.ToString(dr["City"]);
                        oAddress.Taluka = Convert.ToString(dr["Taluka"]);
                        oAddress.District = Convert.ToString(dr["District"]);
                        oAddress.State = Convert.ToString(dr["State"]);
                        oAddress.ZipCode = Convert.ToString(dr["ZipCode"]);
                    }

                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        ContactDetails oContact = new ContactDetails();
                        oContact.ContactID = Convert.ToInt64(dr["ContactId"]);
                        oContact.ContactNo = Convert.ToString(dr["ContactNo"]);
                        oContact.ContactTypeCode = Convert.ToString(dr["ContactTypeCode"]);
                        oContact.ContactTypeDesc = Convert.ToString(dr["ContactTypeDesc"]);

                        lstContact.Add(oContact);
                        oContact = null;
                    }

                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        oPhoto.PhotoID = Convert.ToInt64(dr["PhotoID"]);
                        //oPhoto.iPhoto = Convert.(dr[""]);
                        oPhoto.FileExtension = Convert.ToString(dr["FileExtension"]);
                        oPhoto.MIMEType = Convert.ToString(dr["MIMEType"]);
                        oPhoto.FileSize = Convert.ToInt64(dr["FileSize"]);
                        oPhoto.Width = Convert.ToInt16(dr["Width"]);
                        oPhoto.Height = Convert.ToInt16(dr["Height"]);
                        //oPhoto.Thumbnail = Convert.(dr[""]);
                    }

                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        switch (Convert.ToString(dr["TypeCode"]))
                        {
                            case "0":
                                {
                                    oVerification.AadhaarCardID = Convert.ToInt64(dr["ID"]);
                                    oVerification.AadhaarCardNo = Convert.ToString(dr["No"]);
                                }
                                break;
                            case "1":
                                {
                                    oVerification.PANID = Convert.ToInt64(dr["ID"]);
                                    oVerification.PANCardNo = Convert.ToString(dr["No"]);
                                }
                                break;
                            case "2":
                                {
                                    oVerification.DrivingLicenceID = Convert.ToInt64(dr["ID"]);
                                    oVerification.DrivingLicenceNo = Convert.ToString(dr["No"]);
                                }
                                break;
                            case "3":
                                {
                                    oVerification.OtherIdCardDocumentID = Convert.ToInt64(dr["ID"]);
                                    oVerification.OtherIdCardDocumentNo = Convert.ToString(dr["No"]);
                                    oVerification.OtherIdCardDocumentName = Convert.ToString(dr["Name"]);
                                }
                                break;
                        }
                    }

                    foreach (DataRow dr in ds.Tables[4].Rows)
                    {
                        oPerson.PersonID = Convert.ToInt64(dr["PersonID"]); ;
                        oPerson.PersonCode = Convert.ToString(dr["Code"]);
                        oPerson.PersonFirstName = Convert.ToString(dr["FirstName"]);
                        oPerson.PersonMiddleName = Convert.ToString(dr["MiddleName"]);
                        oPerson.PersonLastName = Convert.ToString(dr["LastName"]);
                        oPerson.OrganizationName = Convert.ToString(dr["OrganizationName"]);
                        oPerson.PersonDOB = Convert.ToDateTime(dr["DOB"]);
                        oPerson.PersonEntityTypeCode = Convert.ToInt32(dr["EntityTypeCode"]); ;
                        oPerson.PersonEntityTypeDesc = Convert.ToString(dr["EntityTypeDesc"]);
                        oPerson.PersonGender = Convert.ToInt32(dr["Gender"]);
                        oPerson.PersonTypeCode = Convert.ToInt32(dr["PersonTypeCode"]);
                        oPerson.personTypeDesc = Convert.ToString(dr["personTypeDesc"]);
                    }

                    frmViewPersonDetails_Confirm ofrmViewPersonDetails_Confirm = new frmViewPersonDetails_Confirm();
                    //ofrmViewPersonDetails_Confirm.PersonType = PersonType;
                    ofrmViewPersonDetails_Confirm.PersonDetails = oPerson;
                    ofrmViewPersonDetails_Confirm.oAddress = oAddress;
                    ofrmViewPersonDetails_Confirm.lstCard = new List<CardDetails>();
                    ofrmViewPersonDetails_Confirm.lstContact = lstContact;
                    ofrmViewPersonDetails_Confirm.oPhoto = oPhoto;
                    ofrmViewPersonDetails_Confirm.oVerification = oVerification;
                    ofrmViewPersonDetails_Confirm.btnSave.Visible = false;
                    ofrmViewPersonDetails_Confirm.ShowDialog(this);
                    ofrmViewPersonDetails_Confirm.Dispose();
                    ofrmViewPersonDetails_Confirm = null;
                }


            }
        }

        private DataSet GetPersonDetails(long PersonID)
        {
            DataSet dsReturn = new DataSet();
            DBAccess dbAccess = null;
            try
            {
                dbAccess = new DBAccess();
                dsReturn = dbAccess.GetPersonFullDetails(PersonID);
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
    }
}
