using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAPMC.Classes
{
    public static class eGlobal
    {
        public enum ContactType
        {
            MobileNo,
            FaxNo,
            EmailID
        }

        public enum EntityType
        {
            Individual,
            Organazation
        }

        public enum PersonType
        {
            Farmer,
            Driver,
            Sellar
        }
        
        public static string UserName { get; set; }

        public static Int64 UserID { get; set; }

        public static Int64 UserType { get; set; }

        public static string LoginName { get; set; }

    }
}
