using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAPMC.Classes
{
    class Person
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
        #endregion

        #region "Address Details"
        public int AddressType { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; } 
        #endregion

        #region "Contact Details"
        public string ContactNo { get; set; }

        public string ContactTypeCode { get; set; }

        public string ContactTypeDesc { get; set; } 
        #endregion

        #region "Varification Details"
        public string DrivingLicenceNo { get; set; }

        public string PANCardNo { get; set; }

        public string AadhaarCardNo { get; set; }

        public string OtherIdCardNo { get; set; }

        public Int64 IDReferenceNo { get; set; }

        public int IDCardTypeCode { get; set; }

        public string IDCardTypeDesc { get; set; }

        public byte[] IDCard { get; set; } 
        #endregion

        #region "Photo Details"
        public byte[] iPhoto { get; set; }

        public string FileExtension { get; set; }

        public string MIMEType { get; set; }

        public int FileSize { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public byte[] Thumbnail { get; set; } 
        #endregion

    }
}
