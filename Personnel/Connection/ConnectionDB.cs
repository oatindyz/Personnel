using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace Rmutto.Connection
{
    public static class ConnectionDB
    {
        private static OracleConnection conn;
        static ConnectionDB()
        {
            //
            // TODO: Add constructor logic here
            //
            string connectionString = ConfigurationManager.ConnectionStrings["ORCL_RMUTTO"].ToString();
            conn = new OracleConnection(connectionString);
        }

        public static OracleConnection GetOracleConnection()
        {
            return conn;
        }


    }
}