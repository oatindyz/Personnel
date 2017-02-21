using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Personnel.Class;
using System.Data.OracleClient;

namespace Personnel
{
    public partial class managerequestlist : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
            }
            else { Response.Redirect("listrequest-admin.aspx"); }

            if (!IsPostBack)
            {
                BindDDL();
                ReadSelectID();
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlUniv, "SELECT * FROM REF_UNIV ORDER BY ABS(UNIV_ID) ASC", "UNIV_NAME_TH", "UNIV_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlPrefixName, "SELECT * FROM REF_PREFIX_NAME WHERE STATUS_ID = 1 ORDER BY ABS(PREFIX_NAME_ID) ASC", "FULLNAME", "PREFIX_NAME_ID", "--กรุณาเลือก--");
        }

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT (SELECT UNIV_NAME_TH FROM REF_UNIV WHERE REF_UNIV.UNIV_ID = TB_REQUEST.UNIV_ID) FROM TB_REQUEST WHERE TB_REQUEST.UOC_ID = TB_REQUEST.UOC_ID) UNIV_NAME, (SELECT (SELECT FULLNAME FROM REF_PREFIX_NAME WHERE TB_REQUEST.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) FROM TB_REQUEST WHERE TB_REQUEST.UOC_ID = TB_REQUEST.UOC_ID) PRE_NAME, STF_FNAME, STF_LNAME, UNIV_ID, PREFIX_NAME FROM TB_REQUEST WHERE R_ID = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            if (!reader.IsDBNull(0))
                            {
                                tr4_lb4Univ.Visible = true;
                                lb4Univ2.Text = reader.GetValue(i).ToString(); ++i;
                            }
                            if (!reader.IsDBNull(1))
                            {
                                tr4_lb4PrefixName.Visible = true;
                                lb4PrefixName2.Text = reader.GetValue(i).ToString(); ++i;
                            }
                            if (!reader.IsDBNull(2))
                            {
                                tr4_lb4Name.Visible = true;
                                lb4Name2.Text = reader.GetValue(i).ToString(); ++i;
                            }
                            if (!reader.IsDBNull(3))
                            {
                                tr4_lb4LastName.Visible = true;
                                lb4LastName2.Text = reader.GetValue(i).ToString(); ++i;
                            }
                            ddlUniv.SelectedValue = reader.GetValue(4).ToString(); ++i;
                            ddlPrefixName.SelectedValue = reader.GetValue(5).ToString(); ++i;
                        }
                    }
                }
                int uoc_id = DatabaseManager.ExecuteInt("SELECT UOC_ID FROM TB_REQUEST WHERE R_ID = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "'");
                using (OracleCommand com = new OracleCommand("SELECT (SELECT UNIV_NAME_TH FROM REF_UNIV WHERE REF_UNIV.UNIV_ID = UOC_STAFF.UNIV_ID) UNIV_NAME," +
                    "(SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) PREFIX_NAME," +
                    "STF_FNAME," +
                    "STF_LNAME" +
                    " FROM UOC_STAFF WHERE UOC_ID = '" + uoc_id + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            lb4Univ.Text = reader.GetValue(i).ToString(); ++i;
                            lb4PrefixName.Text = reader.GetValue(i).ToString(); ++i;
                            lb4Name.Text = reader.GetValue(i).ToString(); ++i;
                            lb4LastName.Text = reader.GetValue(i).ToString(); ++i;
                            
                        }
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("listrequest-admin.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            UPDATE_REQUEST();
            MultiView1.ActiveViewIndex = 1;
        }

        public int UPDATE_REQUEST()
        {
            int r_id = DatabaseManager.ExecuteInt("SELECT R_ID FROM TB_REQUEST WHERE R_ID = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "'");
            int uoc_id = DatabaseManager.ExecuteInt("SELECT UOC_ID FROM TB_REQUEST WHERE R_ID = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "'");
            int id = 0;

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE TB_REQUEST SET STATUS_ID = :STATUS_ID, DATE_END = :DATE_END WHERE R_ID = '" + r_id + "'", con))
                {
                    com.Parameters.Add(new OracleParameter("STATUS_ID", "1"));
                    com.Parameters.Add(new OracleParameter("DATE_END", DateTime.Today));

                    id = com.ExecuteNonQuery();
                }
            }

            if (tr4_lb4Univ.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET UNIV_ID = '" + ddlUniv.SelectedValue + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4PrefixName.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET PREFIX_NAME = '" + ddlPrefixName.SelectedValue + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4Name.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET STF_FNAME = '" + lb4Name2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4LastName.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET STF_LNAME = '" + lb4LastName2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }

            return id;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            /*int uoc_id = DatabaseManager.ExecuteInt("SELECT UOC_ID FROM TB_EDIT WHERE ID_EDIT = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "'");
            int id = 0;

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE TB_EDIT SET STATUS_ID = :STATUS_ID, DATE_END = :DATE_END WHERE UOC_ID = '" + uoc_id + "'", con))
                {
                    com.Parameters.Add(new OracleParameter("STATUS_ID", "2"));
                    com.Parameters.Add(new OracleParameter("DATE_END", DateTime.Today));

                    id = com.ExecuteNonQuery();
                }
            }
            MultiView1.ActiveViewIndex = 2;
            */
        }

    }
}
