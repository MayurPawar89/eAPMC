using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Configuration;

namespace DBLayer
{
    public class DBAccess
    {
        private SqlDatabase sqlDb = null;
        private string databaseConnectionString = string.Empty;

        public DBAccess()
        {
            databaseConnectionString = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["eAPMC"]); ;
            sqlDb = new SqlDatabase(databaseConnectionString);
        }

        public DataTable GetGender()
        {
            DataSet ds = null;
            DataTable dt = null;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_GetGender";
                ds = sqlDb.ExecuteDataSet(CommandType.StoredProcedure, query_procedure_name);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    dt.TableName = "Gender";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null) { if (ds.Tables != null) { ds.Tables.Clear(); } ds.Dispose(); ds = null; }
            }

            return dt;
        }

        public DataTable GetTehsil()
        {
            DataSet ds = null;
            DataTable dt = null;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_GetTehsil";
                ds = sqlDb.ExecuteDataSet(CommandType.StoredProcedure, query_procedure_name);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    dt.TableName = "Tehsil";
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null) { if (ds.Tables != null) { ds.Tables.Clear(); } ds.Dispose(); ds = null; }
            }

            return dt;
        }

        public DataTable GetGrampanchayat(string tehsilName)
        {
            DataSet ds = null;
            DataTable dt = null;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_GetGRAMPANCHAYAT";

                using (DbCommand dbCommand = sqlDb.GetStoredProcCommand(query_procedure_name))
                {
                    sqlDb.AddInParameter(dbCommand, "@TEHSILNAME", DbType.String, tehsilName);
                    ds = sqlDb.ExecuteDataSet(dbCommand);

                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        dt.TableName = "Grampanchayat";
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null) { if (ds.Tables != null) { ds.Tables.Clear(); } ds.Dispose(); ds = null; }
            }

            return dt;
        }

        public DataTable GetTown(string tehsilName, string grampanchayatName)
        {
            DataSet ds = null;
            DataTable dt = null;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_GetTown";

                using (DbCommand dbCommand = sqlDb.GetStoredProcCommand(query_procedure_name))
                {
                    sqlDb.AddInParameter(dbCommand, "@TEHSILNAME", DbType.String, tehsilName);
                    sqlDb.AddInParameter(dbCommand, "@GRAMPANCHAYATNAME", DbType.String, grampanchayatName);
                    
                    ds = sqlDb.ExecuteDataSet(dbCommand);

                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        dt.TableName = "Town";
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null) { if (ds.Tables != null) { ds.Tables.Clear(); } ds.Dispose(); ds = null; }
            }

            return dt;
        }

        public DataTable SearchPerson(string tehsilName, string grampanchayatName, string townName, string gender, string namesearchString, string namesearchString_P2, string namesearchString_P3, string fathernamesearchString, string mothernamesearchString, string ahl_tintextsearchString,string searchWith)
        {
            DataSet ds = null;
            DataTable dt = null;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_Search";

                using (DbCommand dbCommand = sqlDb.GetStoredProcCommand(query_procedure_name))
                {

                    //@TEHSILNAME  NVARCHAR(255) = NULL,
                    //@GRAMPANCHAYATNAME  NVARCHAR(255) = NULL,
                    //@TOWNNAME  NVARCHAR(255) = NULL,
                    //@GENDERID  NVARCHAR(255) = NULL,
                    //@NameSearchString  VARCHAR(255) = NULL,
                    //@NameSearchString_P2  VARCHAR(255) = NULL,
                    //@NameSearchString_P3  VARCHAR(255) = NULL,
                    //@FatherNameSearchString  VARCHAR(255) = NULL,
                    //@MotherNameSearchString  VARCHAR(255) = NULL

                    sqlDb.AddInParameter(dbCommand, "@TEHSILNAME", DbType.String, tehsilName);
                    sqlDb.AddInParameter(dbCommand, "@GRAMPANCHAYATNAME", DbType.String, grampanchayatName);
                    sqlDb.AddInParameter(dbCommand, "@TOWNNAME", DbType.String, townName);
                    sqlDb.AddInParameter(dbCommand, "@GENDERID", DbType.String, gender);
                    sqlDb.AddInParameter(dbCommand, "@NameSearchString", DbType.String, namesearchString);
                    sqlDb.AddInParameter(dbCommand, "@NameSearchString_P2", DbType.String, namesearchString_P2);
                    sqlDb.AddInParameter(dbCommand, "@NameSearchString_P3", DbType.String, namesearchString_P3);
                    sqlDb.AddInParameter(dbCommand, "@FatherNameSearchString", DbType.String, fathernamesearchString);
                    sqlDb.AddInParameter(dbCommand, "@MotherNameSearchString", DbType.String, mothernamesearchString);
                    sqlDb.AddInParameter(dbCommand, "@AHL_TINSearchString", DbType.String, ahl_tintextsearchString);
                    //sqlDb.AddInParameter(dbCommand, "@NPR_TINSearchString", DbType.String, npr_tinsearchString);
                    sqlDb.AddInParameter(dbCommand, "@SearchWith", DbType.String, searchWith);

                    ds = sqlDb.ExecuteDataSet(dbCommand);

                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        dt.TableName = "SearchResult";
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null) { if (ds.Tables != null) { ds.Tables.Clear(); } ds.Dispose(); ds = null; }
            }

            return dt;
        }

        public DataTable GetPersonDetails(string tehsilName, string ahl_tin)
        {
            DataSet ds = null;
            DataTable dt = null;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_GetPeronDetails";

                using (DbCommand dbCommand = sqlDb.GetStoredProcCommand(query_procedure_name))
                {
                    sqlDb.AddInParameter(dbCommand, "@TEHSILNAME", DbType.String, tehsilName);
                    sqlDb.AddInParameter(dbCommand, "@AHL_TIN", DbType.String, ahl_tin);

                    ds = sqlDb.ExecuteDataSet(dbCommand);

                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        dt.TableName = "PersonDetail";
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null) { if (ds.Tables != null) { ds.Tables.Clear(); } ds.Dispose(); ds = null; }
            }

            return dt;
        }

        public DataTable GetProductKey()
        {
            DataSet ds = null;
            DataTable dt = null;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_GetProductKey";
                ds = sqlDb.ExecuteDataSet(CommandType.StoredProcedure, query_procedure_name);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    dt.TableName = "Key";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null) { if (ds.Tables != null) { ds.Tables.Clear(); } ds.Dispose(); ds = null; }
            }

            return dt;
        }
        public bool InsertProductKey(string sProductKey)
        {
            bool _result = false;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_InsertProductKey";
                
                using (DbCommand dbCommand = sqlDb.GetStoredProcCommand(query_procedure_name))
                {
                    sqlDb.AddInParameter(dbCommand, "@ProductKey", DbType.String, sProductKey);
                    //ds = sqlDb.ExecuteDataSet(dbCommand);
                    int n =sqlDb.ExecuteNonQuery(dbCommand);

                    if (n > 0)
                        _result = true;
                    else
                        _result = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return _result;
        }


        public DataTable GetUserDetails()
        {
            DataSet ds = null;
            DataTable dt = null;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_GetUserDetails";
                ds = sqlDb.ExecuteDataSet(CommandType.StoredProcedure, query_procedure_name);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    dt.TableName = "AllUsers";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null) { if (ds.Tables != null) { ds.Tables.Clear(); } ds.Dispose(); ds = null; }
            }

            return dt;
        }

        public DataTable GetUserDetails(string sUserLoginName)
        {
            DataSet ds = null;
            DataTable dt = null;
            string query_procedure_name = string.Empty;

            try
            {
                query_procedure_name = "gsp_GetUserDetails";
                
                using (DbCommand dbCommand = sqlDb.GetStoredProcCommand(query_procedure_name))
                {
                    sqlDb.AddInParameter(dbCommand, "@sLoginName", DbType.String, sUserLoginName);
                    ds = sqlDb.ExecuteDataSet(dbCommand);

                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        dt.TableName = "User";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (ds != null) { if (ds.Tables != null) { ds.Tables.Clear(); } ds.Dispose(); ds = null; }
            }

            return dt;
        }
    }
}
