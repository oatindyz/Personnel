using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace Personnel.Class
{
    public class PROJECT
    {
        public int PRO_ID { get; set; }
        public int UOC_ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public string PROJECT_NAME { get; set; }
        public string ADDRESS_PROJECT { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public int EXPENSES { get; set; }
        public string FUNDING { get; set; }
        public string CERTIFICATE { get; set; }
        public string SUMMARIZE_PROJECT { get; set; }
        public string RESULT_TEACHING { get; set; }
        public string RESULT_ACADEMIC { get; set; }
        public string DIFFICULTY_PROJECT { get; set; }
        public string RESULT_PROJECT { get; set; }
        public string RESULT_RESEARCHING { get; set; }
        public string RESULT_OTHER { get; set; }
        public string COUNSEL { get; set; }
        public int ST_APPROVE_ID { get; set; }

        public PROJECT() { }
        public PROJECT(
            int PRO_ID,
            int UOC_ID,
            int CATEGORY_ID,
            string PROJECT_NAME,
            string ADDRESS_PROJECT,
            DateTime START_DATE,
            DateTime END_DATE,
            int EXPENSES,
            string FUNDING,
            string CERTIFICATE,
            string SUMMARIZE_PROJECT,
            string RESULT_TEACHING,
            string RESULT_ACADEMIC,
            string DIFFICULTY_PROJECT,
            string RESULT_PROJECT,
            string RESULT_RESEARCHING,
            string RESULT_OTHER,
            string COUNSEL,
            int ST_APPROVE_ID
            )
        {
            this.PRO_ID = UOC_ID;
            this.UOC_ID = UOC_ID;
            this.CATEGORY_ID = CATEGORY_ID;
            this.PROJECT_NAME = PROJECT_NAME;
            this.ADDRESS_PROJECT = ADDRESS_PROJECT;
            this.START_DATE = START_DATE;
            this.END_DATE = END_DATE;
            this.EXPENSES = EXPENSES;
            this.FUNDING = FUNDING;
            this.CERTIFICATE = CERTIFICATE;
            this.SUMMARIZE_PROJECT = SUMMARIZE_PROJECT;
            this.RESULT_TEACHING = RESULT_TEACHING;
            this.RESULT_ACADEMIC = RESULT_ACADEMIC;
            this.DIFFICULTY_PROJECT = DIFFICULTY_PROJECT;
            this.RESULT_PROJECT = RESULT_PROJECT;
            this.RESULT_RESEARCHING = RESULT_RESEARCHING;
            this.RESULT_OTHER = RESULT_OTHER;
            this.COUNSEL = COUNSEL;
            this.ST_APPROVE_ID = ST_APPROVE_ID;
        }

        public DataTable GetDataProject(string PRO_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT * FROM TB_PROJECT";
                if (!string.IsNullOrEmpty(PRO_ID))
                {
                    query += "where 1=1";
                    if (!string.IsNullOrEmpty(PRO_ID))
                    {
                        query += " and PRO_ID :PRO_ID";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(PRO_ID))
                    {
                        com.Parameters.Add(new OracleParameter("PRO_ID", PRO_ID));
                    }
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    {
                        da.Fill(dt);
                    }
                }

            }

            return dt;
        }

        public int INSERT_PROJECT()
        {
            int id = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO TB_PROJECT (UOC_ID,CATEGORY_ID,PROJECT_NAME,ADDRESS_PROJECT,START_DATE,END_DATE,EXPENSES,FUNDING,CERTIFICATE,SUMMARIZE_PROJECT,RESULT_TEACHING,RESULT_ACADEMIC,DIFFICULTY_PROJECT,RESULT_PROJECT,RESULT_RESEARCHING,RESULT_OTHER,COUNSEL,ST_APPROVE_ID) VALUES (:UOC_ID,:CATEGORY_ID,:PROJECT_NAME,:ADDRESS_PROJECT,:START_DATE,:END_DATE,:EXPENSES,:FUNDING,:CERTIFICATE,:SUMMARIZE_PROJECT,:RESULT_TEACHING,:RESULT_ACADEMIC,:DIFFICULTY_PROJECT,:RESULT_PROJECT,:RESULT_RESEARCHING,:RESULT_OTHER,:COUNSEL,:ST_APPROVE_ID)", con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("CATEGORY_ID", CATEGORY_ID));
                    com.Parameters.Add(new OracleParameter("PROJECT_NAME", PROJECT_NAME));
                    com.Parameters.Add(new OracleParameter("ADDRESS_PROJECT", ADDRESS_PROJECT));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    com.Parameters.Add(new OracleParameter("END_DATE", END_DATE));
                    com.Parameters.Add(new OracleParameter("EXPENSES", EXPENSES));
                    com.Parameters.Add(new OracleParameter("FUNDING", FUNDING));
                    com.Parameters.Add(new OracleParameter("CERTIFICATE", CERTIFICATE));
                    com.Parameters.Add(new OracleParameter("SUMMARIZE_PROJECT", SUMMARIZE_PROJECT));
                    com.Parameters.Add(new OracleParameter("RESULT_TEACHING", RESULT_TEACHING));
                    com.Parameters.Add(new OracleParameter("RESULT_ACADEMIC", RESULT_ACADEMIC));
                    com.Parameters.Add(new OracleParameter("DIFFICULTY_PROJECT", DIFFICULTY_PROJECT));
                    com.Parameters.Add(new OracleParameter("RESULT_PROJECT", RESULT_PROJECT));
                    com.Parameters.Add(new OracleParameter("RESULT_RESEARCHING", RESULT_RESEARCHING));
                    com.Parameters.Add(new OracleParameter("RESULT_OTHER", RESULT_OTHER));
                    com.Parameters.Add(new OracleParameter("COUNSEL", COUNSEL));
                    com.Parameters.Add(new OracleParameter("ST_APPROVE_ID", ST_APPROVE_ID));
                    id = com.ExecuteNonQuery();
                }
            }
            return id;
        }

        public bool UPDATE_PROJECT()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update TB_PROJECT Set";
                query += " CATEGORY_ID = :CATEGORY_ID ,";
                query += " PROJECT_NAME = :PROJECT_NAME ,";
                query += " ADDRESS_PROJECT = :ADDRESS_PROJECT ,";
                query += " START_DATE = :START_DATE ,";
                query += " END_DATE = :END_DATE ,";
                query += " EXPENSES = :EXPENSES ,";
                query += " FUNDING = :FUNDING ,";
                query += " CERTIFICATE = :CERTIFICATE ,";
                query += " SUMMARIZE_PROJECT = :SUMMARIZE_PROJECT ,";
                query += " RESULT_TEACHING = :RESULT_TEACHING ,";
                query += " RESULT_ACADEMIC = :RESULT_ACADEMIC ,";
                query += " DIFFICULTY_PROJECT = :DIFFICULTY_PROJECT ,";
                query += " RESULT_PROJECT = :RESULT_PROJECT ,";
                query += " RESULT_RESEARCHING = :RESULT_RESEARCHING ,";
                query += " RESULT_OTHER = :RESULT_OTHER ,";
                query += " COUNSEL = :COUNSEL ";
                query += " where PRO_ID = :PRO_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("CATEGORY_ID", CATEGORY_ID));
                    com.Parameters.Add(new OracleParameter("PROJECT_NAME", PROJECT_NAME));
                    com.Parameters.Add(new OracleParameter("ADDRESS_PROJECT", ADDRESS_PROJECT));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    com.Parameters.Add(new OracleParameter("END_DATE", END_DATE));
                    com.Parameters.Add(new OracleParameter("EXPENSES", EXPENSES));
                    com.Parameters.Add(new OracleParameter("FUNDING", FUNDING));
                    com.Parameters.Add(new OracleParameter("CERTIFICATE", CERTIFICATE));
                    com.Parameters.Add(new OracleParameter("SUMMARIZE_PROJECT", SUMMARIZE_PROJECT));
                    com.Parameters.Add(new OracleParameter("RESULT_TEACHING", RESULT_TEACHING));
                    com.Parameters.Add(new OracleParameter("RESULT_ACADEMIC", RESULT_ACADEMIC));
                    com.Parameters.Add(new OracleParameter("DIFFICULTY_PROJECT", DIFFICULTY_PROJECT));
                    com.Parameters.Add(new OracleParameter("RESULT_PROJECT", RESULT_PROJECT));
                    com.Parameters.Add(new OracleParameter("RESULT_RESEARCHING", RESULT_RESEARCHING));
                    com.Parameters.Add(new OracleParameter("RESULT_OTHER", RESULT_OTHER));
                    com.Parameters.Add(new OracleParameter("COUNSEL", COUNSEL));
                    com.Parameters.Add(new OracleParameter("PRO_ID", PRO_ID));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }


    }
}