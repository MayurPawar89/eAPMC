using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

        public enum CardType
        {
            AadhaarCard,
            PanCard,
            DrivingLicenceID,
            OtherIDCard
         
        }
        
        public static string UserName { get; set; }

        public static Int64 UserID { get; set; }

        public static Int64 LoginSessionID { get; set; }

        public static Int64 UserType { get; set; }

        public static string LoginName { get; set; }

        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

    }
}
