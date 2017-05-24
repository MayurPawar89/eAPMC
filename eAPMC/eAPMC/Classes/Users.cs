using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAPMC.Classes
{
    class Users
    {
        #region "Personal Details"
        public Int64 UserID { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string UserFirstName { get; set; }

        public string UserMiddleName { get; set; }

        public string UserLastName { get; set; }

        public int UserGender { get; set; }

        public DateTime UserDOB { get; set; }

        public DateTime UserRegistrationDate { get; set; }

        public string UserPhone { get; set; }

        public string UserMobile { get; set; }

        public string UserMobile1 { get; set; }

        public string UserEmail { get; set; }
        #endregion

        #region "Address Details"
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
        #endregion
    }
}
