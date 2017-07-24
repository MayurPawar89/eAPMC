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

        public AddressDetails oAddress { get; set; }
        public ContactDetails oContact { get; set; }
        public CardDetails oCard { get; set; }
        public PhotoDetails oPhoto { get; set; }
        public VerificationDetails oVerification { get; set; }

        public List<CardDetails> lstCard { get; set; }
        public List<ContactDetails> lstContact { get; set; }
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
                try
                {
                    dbAccess = new DBAccess();
                    Int64 nPersonID = PersonDetails.PersonID;
                    string sPersonCode = PersonDetails.PersonCode;
                    //string sLoginName = PersonDetails.LoginName;
                    //string sPassword = Encryption.EncryptToBase64String(PersonDetails.Password);
                    string sFirstName = PersonDetails.PersonFirstName;
                    string sMiddleName = PersonDetails.PersonMiddleName;
                    string sLastName = PersonDetails.PersonLastName;
                    int nGender = PersonDetails.PersonGender;

                    DateTime dtDOB = PersonDetails.PersonDOB;
                    int nEntityTypeCode = PersonDetails.PersonEntityTypeCode;
                    string sEntityTypeDesc = PersonDetails.PersonEntityTypeDesc;
                    int nPersonTypeCode = PersonDetails.PersonTypeCode;
                    string sPersonTypeCode = PersonDetails.personTypeDesc;

                    //Int64 nPhotoID = PersonDetails.PhotoDetails.PhotoID;
                    //byte[] iPhoto = PersonDetails.PhotoDetails.iPhoto;
                    //string sFileExtension = PersonDetails.PhotoDetails.FileExtension;
                    //string sMIMEType = PersonDetails.PhotoDetails.MIMEType;
                    //long nFileSize = PersonDetails.PhotoDetails.FileSize;
                    //int nWidth = PersonDetails.PhotoDetails.Width;
                    //int nHeight = PersonDetails.PhotoDetails.Height;
                    //byte[] Thumbnail =PersonDetails.PhotoDetails.Thumbnail;

                    //Int64 nAddressID = PersonDetails.AddressDetails.AddressID;
                    //string sAddressLine1 = PersonDetails.AddressDetails.AddressLine1;
                    //string sAddressLine2 = PersonDetails.AddressDetails.AddressLine2;
                    //string sCity = PersonDetails.AddressDetails.City;
                    //string sTaluka = PersonDetails.AddressDetails.Taluka;
                    //string sDistrict = PersonDetails.AddressDetails.District;
                    //string sState = PersonDetails.AddressDetails.State;
                    //string sZip = PersonDetails.AddressDetails.ZipCode;

                    //DataTable dtContactDetails = oContact;

                    //Int64 nAadhaarCardID = 0, nDrivingLicenceID = 0, nPanCardID = 0, nOtherIdCardDocumentID = 0;
                    //string sAadhaarCardNo = PersonDetails.VerificationDetails.AadhaarCardNo;
                    //nAadhaarCardID = PersonDetails.VerificationDetails.AadhaarCardID;
                    //string sDrivingLicienceNo = PersonDetails.VerificationDetails.DrivingLicenceNo;
                    //nDrivingLicenceID = PersonDetails.VerificationDetails.DrivingLicenceID;
                    //string sPanCardNo = PersonDetails.VerificationDetails.PANCardNo;
                    //nPanCardID = PersonDetails.VerificationDetails.PANID;
                    //string sOtherIdCardDocumentNo = PersonDetails.VerificationDetails.OtherIdCardDocumentNo;
                    //string sOtherIdCardDocumentName = PersonDetails.VerificationDetails.OtherIdCardDocumentName;
                    //nOtherIdCardDocumentID = PersonDetails.VerificationDetails.OtherIdCardDocumentID;

                    //DataTable dtCardDetails = oCard;
                    
                    List<Person> lstPerson = new List<Person>();
                    lstPerson.Add(PersonDetails);
                    DataTable dtPersonDetails = eGlobal.CreateDataTable<Person>(lstPerson);

                    List<VerificationDetails> lstVerificationDetails = new List<VerificationDetails>();
                    lstVerificationDetails.Add(oVerification);
                    DataTable dtVerificationDetails = eGlobal.CreateDataTable<VerificationDetails>(lstVerificationDetails);

                    List<PhotoDetails> lstPhoto = new List<PhotoDetails>();
                    lstPhoto.Add(oPhoto);
                    DataTable dtPhoto = eGlobal.CreateDataTable<PhotoDetails>(lstPhoto);

                    List<AddressDetails> lstAddress = new List<AddressDetails>();
                    lstAddress.Add(oAddress);
                    DataTable dtAddress = eGlobal.CreateDataTable<AddressDetails>(lstAddress);

                    //List<ContactDetails> lstContact = new List<ContactDetails>();
                    //lstContact.Add(oContact);
                    DataTable dtContactDetails = eGlobal.CreateDataTable<ContactDetails>(lstContact);

                    //List<CardDetails> lstCard = new List<CardDetails>();
                    //lstCard.Add(oCard);
                    DataTable dtCardDetails = eGlobal.CreateDataTable<CardDetails>(lstCard);

                    nPersonID = dbAccess.InsertUpdatePerson(dtPersonDetails,dtContactDetails,dtCardDetails,dtVerificationDetails,dtPhoto,dtAddress);
                    //nUserID = dbAccess.InsertUpdateUserMaster(0, sLoginName, sPassword, sFirstName, sMiddleName, sLastName, nGender, dtDOB, dtRegistrationDate, sPhone, sMobile, sMobile1, seMail, sAddressLine1, sAddressLine2, sCity, sState, sZip, bIsBlocked);
                    //if (nUserID > 0)
                    //{
                    //    MessageBox.Show("User register successfully.");
                    //}

                    //dbAccess.InsertUpdatePerson();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
