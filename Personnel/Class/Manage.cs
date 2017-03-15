using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace Personnel.Class
{
    public class ClassInsig
    {
        public int INSIG_ID { get; set; }
        public int UOC_ID { get; set; }
        public string INSIG_ITEM_ID { get; set; }
        public string INSIG_GET_DATE { get; set; }

        public ClassInsig() { }
        public ClassInsig(int INSIG_ID, int TIME_CONTACT_NAME, string INSIG_ITEM_ID, string INSIG_GET_DATE)
        {
            this.INSIG_ID = INSIG_ID;
            this.UOC_ID = UOC_ID;
            this.INSIG_ITEM_ID = INSIG_ITEM_ID;
            this.INSIG_GET_DATE = INSIG_GET_DATE;
        }

        public DataTable SELECT_ManageInsig(string INSIG_ID, string UOC_ID)
        {
            DataTable dt = new DataTable();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT INSIG_ID, UOC_ID, (SELECT INSIG_NAME || ' | ' || INSIG_NAME_FULL FROM TB_INSIG_ITEM WHERE TB_INSIG_ITEM.INSIG_ITEM_ID = TB_INSIG.INSIG_ITEM_ID ) INSIG_ITEM_ID, TO_CHAR(INSIG_GET_DATE,'dd/MM/yyyy') INSIG_GET_DATE FROM TB_INSIG ";
                if (!string.IsNullOrEmpty(INSIG_ID) || !string.IsNullOrEmpty(UOC_ID))
                {
                    query += "where 1=1";
                    if (!string.IsNullOrEmpty(INSIG_ID))
                    {
                        query += " and INSIG_ID like :INSIG_ID";
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        query += " and UOC_ID like :UOC_ID";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(INSIG_ID))
                    {
                        com.Parameters.Add(new OracleParameter("INSIG_ID", INSIG_ID));
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    }
                    using (OracleDataAdapter sd = new OracleDataAdapter(com))
                    {
                        sd.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }

    public class ClassLeave
    {
        public int LEAVE_ID { get; set; }
        public string LEAVE_TYPE_NAME { get; set; }
        public string REQ_DATE { get; set; }
        public string DATE_LEAVE { get; set; }
        public string UOC_ID { get; set; }

        public ClassLeave() { }
        public ClassLeave(int LEAVE_ID, string LEAVE_TYPE_NAME, string REQ_DATE, string DATE_LEAVE, string UOC_ID)
        {
            this.LEAVE_ID = LEAVE_ID;
            this.LEAVE_TYPE_NAME = LEAVE_TYPE_NAME;
            this.REQ_DATE = REQ_DATE;
            this.DATE_LEAVE = DATE_LEAVE;
            this.UOC_ID = UOC_ID;
        }

        public DataTable SELECT_Leave(string LEAVE_ID, string UOC_ID)
        {
            DataTable dt = new DataTable();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT LEAVE_ID,UOC_ID,(SELECT LEAVE_TYPE_NAME FROM TB_LEAVE_TYPE WHERE TB_LEAVE.LEAVE_TYPE_ID = TB_LEAVE_TYPE.LEAVE_TYPE_ID) LEAVE_TYPE_NAME, TO_CHAR(REQ_DATE, 'dd MON yyyy', ' NLS_DATE_LANGUAGE=THAI') REQ_DATE, FROM_DATE || ' - ' || TO_DATE DATE_LEAVE FROM TB_LEAVE ";
                if (!string.IsNullOrEmpty(LEAVE_ID) || !string.IsNullOrEmpty(UOC_ID))
                {
                    query += "where 1=1";
                    if (!string.IsNullOrEmpty(LEAVE_ID))
                    {
                        query += " and LEAVE_ID like :LEAVE_ID";
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        query += " and UOC_ID like :UOC_ID";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(LEAVE_ID))
                    {
                        com.Parameters.Add(new OracleParameter("LEAVE_ID", LEAVE_ID));
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    }
                    using (OracleDataAdapter sd = new OracleDataAdapter(com))
                    {
                        sd.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool DELETE_LEAVE()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("DELETE TB_LEAVE WHERE LEAVE_ID = :LEAVE_ID", con))
                {
                    com.Parameters.Add(new OracleParameter("LEAVE_ID", LEAVE_ID));
                    if (com.ExecuteNonQuery() >= 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}