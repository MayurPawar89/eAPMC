using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAPMC.Classes
{
    public class Person
    {
        #region "Personal Details"
        public Int64 PersonID { get; set; }

        public string PersonCode { get; set; }

        public string PersonFirstName { get; set; }

        public string PersonMiddleName { get; set; }

        public string PersonLastName { get; set; }

        public string OrganizationName { get; set; }

        public int PersonGender { get; set; }

        public DateTime PersonDOB { get; set; }

        public int PersonEntityTypeCode { get; set; }

        public string PersonEntityTypeDesc { get; set; }

        public int PersonTypeCode { get; set; }

        public string personTypeDesc { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }
        #endregion

        #region "Address Details"
        public AddressDetails AddressDetails { get; set; }
        
        #endregion

        #region "Contact Details"
        public DataTable ContactDetails { get; set; }
        #endregion  

        #region "Varification Details"
        public VerificationDetails VerificationDetails { get; set; }
        #endregion

        #region "Photo Details"
        public PhotoDetails PhotoDetails { get; set; }
        #endregion

        #region "Card Details"
        public DataTable CardDetails { get; set; }
        #endregion

    }

    public class ContactDetails
    {
        public ContactDetails()
        {
        }
        public Int64 ContactID { get; set; }

        public string ContactNo { get; set; }

        public string ContactTypeCode { get; set; }

        public string ContactTypeDesc { get; set; } 
    }

    public class AddressDetails
    {
        public AddressDetails()
        { }
        public Int64 AddressID { get; set; }

        public int AddressType { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string Taluka { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

    }

    public class VerificationDetails
    {
        public Int64 DrivingLicenceID { get; set; }

        public string DrivingLicenceNo { get; set; }

        public Int64 PANID { get; set; }

        public string PANCardNo { get; set; }

        public Int64 AadhaarCardID { get; set; }

        public string AadhaarCardNo { get; set; }

        public Int64 OtherIdCardDocumentID { get; set; }

        public string OtherIdCardDocumentNo { get; set; }

        public string OtherIdCardDocumentName { get; set; }
        
    }

    public class PhotoDetails
    {
        public Int64 PhotoID { get; set; }

        public byte[] iPhoto { get; set; }

        public string FileExtension { get; set; }

        public string MIMEType { get; set; }

        public long FileSize { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public byte[] Thumbnail { get; set; } 
    }

    public class CardDetails
    {
        public Int64 CardID { get; set; }

        public Int64 ReferenceID { get; set; }

        public int IDTypeCode { get; set; }

        public string IDTypeDescription { get; set; }

        public byte[] iPhoto { get; set; } 
    }
}
