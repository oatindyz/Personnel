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
                ReadSelectID();
            }
        }

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT UNIV_ID,PREFIX_NAME,STF_FNAME,STF_LNAME,GENDER_ID,BIRTHDAY,STAFFTYPE_ID,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_ID,POSITION_WORK,DEPARTMENT_ID,DATE_INWORK,DATE_START_THIS_U,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_LEV_ID,GRAD_CURR,GRAD_ISCED_ID,GRAD_PROG,GRAD_UNIV,GRAD_COUNTRY_ID,RELIGION_ID FROM TB_REQUEST WHERE R_ID = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;

                            if (!reader.IsDBNull(0))
                            {
                                tr4_lb4Univ.Visible = true;
                                lb4Univ2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(1))
                            {
                                tr4_lb4PrefixName.Visible = true;
                                lb4PrefixName2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                tr4_lb4Name.Visible = true;
                                lb4Name2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                tr4_lb4LastName.Visible = true;
                                lb4LastName2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                tr4_lb4Gender.Visible = true;
                                lb4Gender2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                tr4_lb4Birthday.Visible = true;
                                lb4Birthday2.Text = reader.GetDateTime(i).ToString("dd/MM/yyyy");
                            }
                            if (!reader.IsDBNull(6))
                            {
                                tr4_lb4Stafftype.Visible = true;
                                lb4Stafftype2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                tr4_lb4TimeContact.Visible = true;
                                lb4TimeContact2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                tr4_lb4Budget.Visible = true;
                                lb4Budget2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                tr4_lb4SubStafftype.Visible = true;
                                lb4SubStafftype2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                tr4_lb4AdminPosition.Visible = true;
                                lb4AdminPosition2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                tr4_lb4Position.Visible = true;
                                lb4Position2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                tr4_lb4PositionWork.Visible = true;
                                lb4PositionWork2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                tr4_lb4Department.Visible = true;
                                lb4Department2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                tr4_lb4DateInwork.Visible = true;
                                lb4DateInwork2.Text = reader.GetDateTime(i).ToString("dd/MM/yyyy");
                            }
                            if (!reader.IsDBNull(15))
                            {
                                tr4_lb4DateStartThisU.Visible = true;
                                lb4DateStartThisU2.Text = reader.GetDateTime(i).ToString("dd/MM/yyyy");
                            }
                            if (!reader.IsDBNull(16))
                            {
                                tr4_lb4SpecialName.Visible = true;
                                lb4SpecialName2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(17))
                            {
                                tr4_lb4TeachISCED.Visible = true;
                                lb4TeachISCED2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(18))
                            {
                                tr4_lb4GradLev.Visible = true;
                                lb4GradLev2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(19))
                            {
                                tr4_lb4GradCURR.Visible = true;
                                lb4GradCURR2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(20))
                            {
                                tr4_lb4GradISCED.Visible = true;
                                lb4GradISCED2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(21))
                            {
                                tr4_lb4GradProg.Visible = true;
                                lb4GradProg2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(22))
                            {
                                tr4_lb4GradUniv.Visible = true;
                                lb4GradUniv2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(23))
                            {
                                tr4_lb4GradCountry.Visible = true;
                                lb4GradCountry2.Text = reader.GetString(i);
                            }
                            if (!reader.IsDBNull(24))
                            {
                                tr4_lb4Religion.Visible = true;
                                lb4Religion2.Text = reader.GetString(i);
                            }

                        }
                    }
                }
                int uoc_id = DatabaseManager.ExecuteInt("SELECT UOC_ID FROM TB_REQUEST WHERE R_ID = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "'");
                using (OracleCommand com = new OracleCommand("SELECT (SELECT UNIV_NAME_TH FROM REF_UNIV WHERE REF_UNIV.UNIV_ID = UOC_STAFF.UNIV_ID) UNIV_NAME," +
                    "(SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) PREFIX_NAME," +
                    "STF_FNAME," +
                    "STF_LNAME," +
                    "(SELECT GENDER_NAME FROM REF_GENDER WHERE REF_GENDER.GENDER_ID = UOC_STAFF.GENDER_ID) GENDER_NAME," +
                    "BIRTHDAY," +
                    "(SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE REF_STAFFTYPE.STAFFTYPE_ID = UOC_STAFF.STAFFTYPE_ID) STAFFTYPE_NAME," +
                    "(SELECT TIME_CONTACT_NAME FROM REF_TIME_CONTACT WHERE REF_TIME_CONTACT.TIME_CONTACT_ID = UOC_STAFF.TIME_CONTACT_ID) TIME_CONTACT_NAME," +
                    "(SELECT BUDGET_NAME FROM REF_BUDGET WHERE REF_BUDGET.BUDGET_ID = UOC_STAFF.BUDGET_ID) BUDGET_NAME," +
                    "(SELECT SUBSTAFFTYPE_NAME FROM REF_SUBSTAFFTYPE WHERE REF_SUBSTAFFTYPE.SUBSTAFFTYPE_ID = UOC_STAFF.SUBSTAFFTYPE_ID) SUBSTAFFTYPE_NAME," +
                    "(SELECT ADMIN_NAME FROM REF_ADMIN WHERE REF_ADMIN.ADMIN_ID = UOC_STAFF.ADMIN_POSITION_ID) ADMIN_POSITION_NAME," +
                    "(SELECT POSITION_NAME_TH FROM REF_POSITION WHERE REF_POSITION.POSITION_ID = UOC_STAFF.POSITION_ID) POSITION_NAME," +
                    "POSITION_WORK," +
                    "(SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME," +
                    "DATE_INWORK," +
                    "DATE_START_THIS_U," +
                    "SPECIAL_NAME," +
                    "(SELECT ISCED_NAME FROM REF_ISCED WHERE REF_ISCED.ISCED_ID = UOC_STAFF.TEACH_ISCED_ID) TEACH_ISCED_NAME," +
                    "(SELECT LEV_NAME_TH FROM REF_LEV WHERE REF_LEV.LEV_ID = UOC_STAFF.GRAD_LEV_ID) GRAD_LEV_NAME," +
                    "(SELECT ISCED_NAME FROM REF_ISCED WHERE REF_ISCED.ISCED_ID = UOC_STAFF.GRAD_ISCED_ID) GRAD_ISCED_NAME," +
                    "(SELECT PROGRAM_NAME FROM REF_PROGRAM WHERE REF_PROGRAM.PROGRAM_ID_NEW = UOC_STAFF.GRAD_PROG) GRAD_PROG," +
                    "GRAD_CURR," +
                    "GRAD_UNIV," +
                    "(SELECT NATION_NAME_ENG FROM REF_NATION WHERE REF_NATION.NATION_ID = UOC_STAFF.GRAD_COUNTRY_ID) GRAD_COUNTRY_NAME," +
                    "(SELECT RELIGION_NAME_TH FROM REF_RELIGION WHERE REF_RELIGION.RELIGION_ID = UOC_STAFF.RELIGION_ID) RELIGION_NAME_TH" +
                    " FROM UOC_STAFF WHERE UOC_ID = '" + uoc_id + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            lb4Univ.Text = reader.GetString(i); ++i;
                            lb4PrefixName.Text = reader.GetString(i); ++i;
                            lb4Name.Text = reader.GetString(i); ++i;
                            lb4LastName.Text = reader.GetString(i); ++i;
                            lb4Gender.Text = reader.GetString(i); ++i;
                            lb4Birthday.Text = reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;

                            lb4Stafftype.Text = reader.GetString(i); ++i;
                            lb4TimeContact.Text = reader.GetString(i); ++i;
                            lb4Budget.Text = reader.GetString(i); ++i;
                            lb4SubStafftype.Text = reader.GetString(i); ++i;
                            lb4AdminPosition.Text = reader.GetString(i); ++i;
                            lb4Position.Text = reader.GetString(i); ++i;
                            lb4PositionWork.Text = reader.GetString(i); ++i;
                            lb4Department.Text = reader.GetString(i); ++i;
                            lb4DateInwork.Text = reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            lb4DateStartThisU.Text = reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            lb4SpecialName.Text = reader.GetString(i); ++i;
                            lb4TeachISCED.Text = reader.GetString(i); ++i;
                            lb4GradLev.Text = reader.GetString(i); ++i;
                            lb4GradCURR.Text = reader.GetString(i); ++i;

                            lb4GradISCED.Text = reader.GetString(i); ++i;
                            lb4GradProg.Text = reader.GetString(i); ++i;

                            lb4GradUniv.Text = reader.GetString(i); ++i;
                            lb4GradCountry.Text = reader.GetString(i); ++i;
                            lb4Religion.Text = reader.GetString(i); ++i;

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
            int uoc_id = DatabaseManager.ExecuteInt("SELECT UOC_ID FROM TB_REQUEST WHERE R_ID = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "'");
            int id = 0;

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE TB_REQUEST SET STATUS_ID = :STATUS_ID, DATE_END = :DATE_END WHERE UOC_ID = '" + uoc_id + "'", con))
                {
                    com.Parameters.Add(new OracleParameter("STATUS_ID", "1"));
                    com.Parameters.Add(new OracleParameter("DATE_END", DateTime.Today));

                    id = com.ExecuteNonQuery();
                }
            }

            if (tr4_lb4Univ.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET UNIV_ID = '" + lb4GradUniv2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4PrefixName.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET PREFIX_NAME = '" + lb4PrefixName2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4Name.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET STF_FNAME = '" + lb4Name2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4LastName.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET STF_LNAME = '" + lb4LastName2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4Gender.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET GENDER_ID = '" + lb4Gender2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4Birthday.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET BIRTHDAY = '" + lb4Birthday2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4Stafftype.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET STAFFTYPE_ID = '" + lb4Stafftype2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4TimeContact.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET TIME_CONTACT_ID = '" + lb4TimeContact2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4Budget.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET BUDGET_ID = '" + lb4Budget2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4SubStafftype.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET SUBSTAFFTYPE_ID = '" + lb4SubStafftype2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4AdminPosition.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET ADMIN_POSITION_ID = '" + lb4AdminPosition2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4Position.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET POSITION_ID = '" + lb4Position2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4PositionWork.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET POSITION_WORK = '" + lb4PositionWork2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4Department.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET DEPARTMENT_ID = '" + lb4Department2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4DateInwork.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET DATE_INWORK = '" + lb4DateInwork2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4DateStartThisU.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET DATE_START_THIS_U = '" + lb4DateStartThisU2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4SpecialName.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET SPECIAL_NAME = '" + lb4SpecialName2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4TeachISCED.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET TEACH_ISCED_ID = '" + lb4TeachISCED2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4GradLev.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET GRAD_LEV_ID = '" + lb4GradLev2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4GradCURR.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET GRAD_CURR = '" + lb4GradCURR2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4GradISCED.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET GRAD_ISCED_ID = '" + lb4GradISCED2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4GradProg.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET GRAD_PROG = '" + lb4GradProg2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4GradUniv.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET GRAD_UNIV = '" + lb4GradUniv2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4GradCountry.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET GRAD_COUNTRY_ID = '" + lb4GradCountry2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
            }
            if (tr4_lb4Religion.Visible == true)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET RELIGION_ID = '" + lb4Religion2.Text + "' WHERE UOC_ID = '" + uoc_id + "'");
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
