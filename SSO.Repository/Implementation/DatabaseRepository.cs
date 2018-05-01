using SSO.Repository.Interface;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SSO.Repository.Implementation
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public void CloseConnection()
        {
            try
            {
                if (GetSSOdbConnection() != null && GetSSOdbConnection().State == ConnectionState.Open)
                    GetSSOdbConnection().Close();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public SqlConnection GetSSOdbConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["SSODBContext"].ConnectionString);
        }
    }
}
