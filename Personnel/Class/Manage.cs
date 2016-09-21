using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace Personnel.Class
{
    public class Manage
    {
        public string TIME_CONTACT_ID { get; set; }
        public string TIME_CONTACT_NAME { get; set; }

        public Manage() { }
        public Manage(string TIME_CONTACT_ID, string TIME_CONTACT_NAME)
        {
            this.TIME_CONTACT_ID = TIME_CONTACT_ID;
            this.TIME_CONTACT_NAME = TIME_CONTACT_NAME;
        }

        public DataTable Get_Timecontact(string TIME_CONTACT_ID, string TIME_CONTACT_NAME)
        {
            DataTable dt = new DataTable();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT * FROM REF_TIME_CONTACT ";
                if (!string.IsNullOrEmpty(TIME_CONTACT_ID) || !string.IsNullOrEmpty(TIME_CONTACT_NAME))
                {
                    query += " where 1=1 ";
                    if (!string.IsNullOrEmpty(TIME_CONTACT_ID))
                    {
                        query += " and TIME_CONTACT_ID like :TIME_CONTACT_ID ";
                    }
                    if (!string.IsNullOrEmpty(TIME_CONTACT_NAME))
                    {
                        query += " and TIME_CONTACT_NAME like :TIME_CONTACT_NAME ";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(TIME_CONTACT_ID))
                    {
                        com.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID + "%"));
                    }
                    if (!string.IsNullOrEmpty(TIME_CONTACT_NAME))
                    {
                        com.Parameters.Add(new OracleParameter("TIME_CONTACT_NAME", TIME_CONTACT_NAME + "%"));
                    }
                    using (OracleDataAdapter sd = new OracleDataAdapter(com))
                    {
                        sd.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public int Insert_Timecontact()
        {
            int id = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO REF_TIME_CONTACT (TIME_CONTACT_ID,TIME_CONTACT_NAME) VALUES (:TIME_CONTACT_ID,:TIME_CONTACT_NAME)", con))
                {
                    com.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
                    com.Parameters.Add(new OracleParameter("TIME_CONTACT_NAME", TIME_CONTACT_NAME));
                    id = com.ExecuteNonQuery();
                }
            }
            return id;
        }

        public bool Update_Timecontact()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update REF_TIME_CONTACT Set";
                query += " TIME_CONTACT_ID = :TIME_CONTACT_ID ,";
                query += " TIME_CONTACT_NAME = :TIME_CONTACT_NAME ,";
                query += " where TIME_CONTACT_ID = :TIME_CONTACT_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
                    com.Parameters.Add(new OracleParameter("TIME_CONTACT_NAME", TIME_CONTACT_NAME));
                    if (com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }
                return result;
            }
        }

        public bool Delete_Timecontact()
        {
            bool result = false;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("delete REF_TIME_CONTACT where TIME_CONTACT_ID = :TIME_CONTACT_ID", con))
                {
                    com.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
                    if (com.ExecuteNonQuery() >= 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public bool Check_Timecontact()
        {
            bool result = true;
            OracleConnection.ClearAllPools();

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT count(TIME_CONTACT_NAME) FROM REF_TIME_CONTACT WHERE TIME_CONTACT_NAME =: TIME_CONTACT_NAME", con))
                {
                    com.Parameters.Add(new OracleParameter("TIME_CONTACT_NAME", TIME_CONTACT_NAME));
                    int count = (int)(decimal)com.ExecuteScalar();
                    if (count >= 1)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }


    }
}