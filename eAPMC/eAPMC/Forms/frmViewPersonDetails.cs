using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using DBLayer;
using eAPMC.Classes;

namespace eAPMC.Forms
{
    public partial class frmViewPersonDetails : Form
    {
        public frmViewPersonDetails()
        {
            InitializeComponent();
        }
        public eGlobal.PersonType PersonType { get; set; }
        public Person PersonDetails { get; set; }
        private void frmViewPersonDetails_Load(object sender, EventArgs e)
        {
            switch (PersonType)
            {
                case eGlobal.PersonType.Farmer://Farmer
                    {
                        lblRegistration.Text = "Farmer Registration";
                        break;
                    }
                case eGlobal.PersonType.Driver://Driver
                    {
                        lblRegistration.Text = "Driver Registration";
                        break;
                    }
                case eGlobal.PersonType.Sellar://Saller
                    {
                        lblRegistration.Text = "Saller Registration";
                        grpbOrganizationDetails.Visible = true;
                        break;
                    }
            }
            if (PersonDetails!=null)
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(Person));
                var subReq = new Person();
                var xml = "";

                TextWriter tw = new StreamWriter(@"c:\Person.xml");
                xsSubmit.Serialize(tw, PersonDetails);

                //txtPersonFName.Text = PersonDetails.PersonFirstName;
                //txtPersonMName.Text = PersonDetails.PersonMiddleName;
                //txtPersonLName.Text = PersonDetails.PersonLastName;
                //mskPersonDOB.Text = Convert.ToString(PersonDetails.PersonDOB);
                //switch (PersonDetails.PersonGender)
                //{
                //    case 0:
                //        {
                //            rdPersonOthers.Checked = true;
                //            break;
                //        }
                //    case 1:
                //        {
                //            rdPersonMale.Checked = true;
                //            break; 
                //        }
                //    case 2:
                //        {
                //            rdPersonFemale.Checked = true;
                //            break;
                //        }
                //}

                //txtAddressLine1.Text = PersonDetails.AddressLine1;
                //txtAddressLine2.Text = PersonDetails.AddressLine2;
                //txtPincode.Text = PersonDetails.ZipCode;
                //txtArea.Text = PersonDetails.City;
                //txtTaluka.Text = PersonDetails.Taluka;
                //txtDistrict.Text = PersonDetails.District;
                //txtState.Text = PersonDetails.State;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pnlVerificationDoc.BringToFront();
            pnlPersonDetails.SendToBack();
            if (pnlVerificationDoc.Visible)
            {
                btnSave.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlVerificationDoc.SendToBack();
            pnlPersonDetails.BringToFront();
            if (pnlVerificationDoc.Visible)
            {
                btnSave.Enabled = false;
            }
        }

        private void chkOtherID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherID.Checked)
            {
                pnlOtherDocumentDetails.Visible = true;
            }
            else
            {
                pnlOtherDocumentDetails.Visible = false;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PersonDetails!=null)
            {
                DBAccess dbAccess = null;
                DataTable dtUser = null;
                try
                {
                    dbAccess = new DBAccess();
                    Int64 nUserID = 0;
                    string sLoginName = PersonDetails.LoginName;
                    string sPassword = Encryption.EncryptToBase64String(PersonDetails.Password);
                    string sFirstName = PersonDetails.PersonFirstName;
                    string sMiddleName = PersonDetails.PersonMiddleName;
                    string sLastName = PersonDetails.PersonLastName;
                    int nGender = PersonDetails.PersonGender;

                    DateTime dtDOB = PersonDetails.PersonDOB;
                    DateTime dtRegistrationDate = DateTime.Now;
                    List<ContactDetails> ContactDetails = PersonDetails.ContactDetails;
                    
                    string sAddressLine1 = PersonDetails.AddressLine1;
                    string sAddressLine2 = PersonDetails.AddressLine2;
                    string sCity = PersonDetails.City;
                    string sTaluka = PersonDetails.Taluka;
                    string sDistrict = PersonDetails.District;
                    string sState = PersonDetails.State;
                    string sZip = PersonDetails.ZipCode;

                    string sAadhaarCardNo = PersonDetails.AddressLine2;
                    string sDrivingLicienceNo = PersonDetails.City;
                    string sPanCardNo = PersonDetails.Taluka;
                    string sOtherIdCardDocumentNo = PersonDetails.District;
                    string sOtherIdCardDocumentName = PersonDetails.State;


                    nUserID = dbAccess.InsertUpdateUserMaster(0, sLoginName, sPassword, sFirstName, sMiddleName, sLastName, nGender, dtDOB, dtRegistrationDate, sPhone, sMobile, sMobile1, seMail, sAddressLine1, sAddressLine2, sCity, sState, sZip, bIsBlocked);
                    if (nUserID > 0)
                    {
                        MessageBox.Show("User register successfully.");
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
