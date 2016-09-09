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
    public partial class adduser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDownNon(ddlUniv, "SELECT * FROM REF_UNIV", "UNIV_NAME_TH", "UNIV_ID");
            DatabaseManager.BindDropDownNon(ddlPrefixName, "SELECT * FROM REF_PREFIX_NAME", "FULLNAME", "PREFIX_NAME_ID");
            DatabaseManager.BindDropDownNon(ddlGender, "SELECT * FROM REF_GENDER", "GENDER_NAME", "GENDER_ID");
            DatabaseManager.BindDropDown(ddlProvince, "SELECT * FROM REF_PROVINCE", "PROVINCE_NAME_TH", "PROVINCE_ID", "--กรุณาเลือก จังหวัด--");
            ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
            ddlSubDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
            DatabaseManager.BindDropDownNon(ddlNation, "SELECT * FROM REF_NATION", "NATION_NAME_ENG", "NATION_ID");

            DatabaseManager.BindDropDownNon(ddlStafftype, "SELECT * FROM REF_STAFFTYPE", "STAFFTYPE_NAME", "STAFFTYPE_ID");
            DatabaseManager.BindDropDownNon(ddlTimeContact, "SELECT * FROM REF_TIME_CONTACT", "TIME_CONTACT_NAME", "TIME_CONTACT_ID");
            DatabaseManager.BindDropDownNon(ddlBudget, "SELECT * FROM REF_BUDGET", "BUDGET_NAME", "BUDGET_ID");
            DatabaseManager.BindDropDownNon(ddlSubStafftype, "SELECT * FROM REF_SUBSTAFFTYPE", "SUBSTAFFTYPE_NAME", "SUBSTAFFTYPE_ID");
            DatabaseManager.BindDropDownNon(ddlAdminPosition, "SELECT * FROM REF_ADMIN", "ADMIN_NAME", "ADMIN_ID");
            DatabaseManager.BindDropDownNon(ddlPosition, "SELECT * FROM REF_POSITION", "POSITION_NAME_TH", "POSITION_ID");
            DatabaseManager.BindDropDownNon(ddlDepartment, "SELECT * FROM REF_FAC", "FAC_NAME", "FAC_ID");
            DatabaseManager.BindDropDownNon(ddlTeachISCED, "SELECT * FROM REF_ISCED", "ISCED_NAME", "ISCED_ID");
            DatabaseManager.BindDropDownNon(ddlGradLev, "SELECT * FROM REF_LEV", "LEV_NAME_TH", "LEV_ID");
            DatabaseManager.BindDropDownNon(ddlGradISCED, "SELECT * FROM REF_ISCED", "ISCED_NAME", "ISCED_ID");
            DatabaseManager.BindDropDown(ddlGradProg, "SELECT * FROM REF_PROGRAM", "PROGRAM_NAME", "PROGRAM_ID_NEW", "ไม่มี / ไม่ระบุ (ในกรณีที่นักศึกษาเข้าใหม่ยังไม่ได้เลือกสาขาวิชา)");
            DatabaseManager.BindDropDownNon(ddlGradCountry, "SELECT * FROM REF_NATION", "NATION_NAME_ENG", "NATION_ID");

            DatabaseManager.BindDropDownNon(ddlDeform, "SELECT * FROM REF_DEFORM", "DEFORM_NAME", "DEFORM_ID");
            DatabaseManager.BindDropDownNon(ddlReligion, "SELECT * FROM REF_RELIGION", "RELIGION_NAME", "RELIGION_ID");
            DatabaseManager.BindDropDownNon(ddlMovementType, "SELECT * FROM REF_MOVEMENT_TYPE", "MOVEMENT_TYPE_NAME", "MOVEMENT_TYPE_ID");
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from REF_DISTRICT where PROVINCE_ID=:PROVINCE_ID";
                        sqlCmd.Parameters.Add(":PROVINCE_ID", ddlProvince.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDistrict.DataSource = dt;
                        ddlDistrict.DataValueField = "DISTRICT_ID";
                        ddlDistrict.DataTextField = "DISTRICT_NAME_TH";
                        ddlDistrict.DataBind();
                        sqlConn.Close();

                        ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
                        ddlSubDistrict.Items.Clear();
                        ddlSubDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
                    }
                }
            }
            catch { }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from REF_SUB_DISTRICT where DISTRICT_ID=:REF_SUB_DISTRICT";
                        sqlCmd.Parameters.Add(":REF_SUB_DISTRICT", ddlDistrict.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlSubDistrict.DataSource = dt;
                        ddlSubDistrict.DataValueField = "SUB_DISTRICT_ID";
                        ddlSubDistrict.DataTextField = "SUB_DISTRICT_NAME_TH";
                        ddlSubDistrict.DataBind();
                        sqlConn.Close();

                        ddlSubDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));

                    }
                }
            }
            catch { }
        }

        protected void lbuNextToView1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuNextToView2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuAddPerson_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void lbuBackToView0_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuBackToView1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

    }
}