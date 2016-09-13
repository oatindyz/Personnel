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
    public partial class adduser_admin : System.Web.UI.Page
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
            DatabaseManager.BindDropDownNon(ddlUniv, "SELECT * FROM REF_UNIV ORDER BY UNIV_ID", "UNIV_NAME_TH", "UNIV_ID");
            DatabaseManager.BindDropDownNon(ddlPrefixName, "SELECT * FROM REF_PREFIX_NAME ORDER BY PREFIX_NAME_ID", "FULLNAME", "PREFIX_NAME_ID");
            DatabaseManager.BindDropDownNon(ddlGender, "SELECT * FROM REF_GENDER ORDER BY GENDER_ID", "GENDER_NAME", "GENDER_ID");
            DatabaseManager.BindDropDown(ddlProvince, "SELECT * FROM REF_PROVINCE", "PROVINCE_NAME_TH", "PROVINCE_ID", "--กรุณาเลือก จังหวัด--");
            ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
            ddlSubDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
            DatabaseManager.BindDropDownNon(ddlNation, "SELECT * FROM REF_NATION ORDER BY NATION_NAME_ENG", "NATION_NAME_ENG", "NATION_ID");

            DatabaseManager.BindDropDownNon(ddlStafftype, "SELECT * FROM REF_STAFFTYPE ORDER BY STAFFTYPE_ID", "STAFFTYPE_NAME", "STAFFTYPE_ID");
            DatabaseManager.BindDropDownNon(ddlTimeContact, "SELECT * FROM REF_TIME_CONTACT ORDER BY TIME_CONTACT_ID", "TIME_CONTACT_NAME", "TIME_CONTACT_ID");
            DatabaseManager.BindDropDownNon(ddlBudget, "SELECT * FROM REF_BUDGET ORDER BY BUDGET_ID", "BUDGET_NAME", "BUDGET_ID");
            DatabaseManager.BindDropDownNon(ddlSubStafftype, "SELECT * FROM REF_SUBSTAFFTYPE ORDER BY SUBSTAFFTYPE_ID", "SUBSTAFFTYPE_NAME", "SUBSTAFFTYPE_ID");
            DatabaseManager.BindDropDownNon(ddlAdminPosition, "SELECT * FROM REF_ADMIN ORDER BY ADMIN_ID", "ADMIN_NAME", "ADMIN_ID");
            DatabaseManager.BindDropDownNon(ddlPosition, "SELECT * FROM REF_POSITION ORDER BY POSITION_ID", "POSITION_NAME_TH", "POSITION_ID");
            DatabaseManager.BindDropDownNon(ddlDepartment, "SELECT * FROM REF_FAC ORDER BY FAC_ID", "FAC_NAME", "FAC_ID");
            DatabaseManager.BindDropDownNon(ddlTeachISCED, "SELECT * FROM REF_ISCED  ORDER BY ISCED_ID", "ISCED_NAME", "ISCED_ID");
            DatabaseManager.BindDropDownNon(ddlGradLev, "SELECT * FROM REF_LEV ORDER BY LEV_ID", "LEV_NAME_TH", "LEV_ID");
            DatabaseManager.BindDropDownNon(ddlGradISCED, "SELECT * FROM REF_ISCED ORDER BY ISCED_ID", "ISCED_NAME", "ISCED_ID");
            DatabaseManager.BindDropDown(ddlGradProg, "SELECT * FROM REF_PROGRAM ORDER BY PROGRAM_ID_NEW", "PROGRAM_NAME", "PROGRAM_ID_NEW", "ไม่มี / ไม่ระบุ (ในกรณีที่นักศึกษาเข้าใหม่ยังไม่ได้เลือกสาขาวิชา)");
            DatabaseManager.BindDropDownNon(ddlGradCountry, "SELECT * FROM REF_NATION ORDER BY NATION_ID", "NATION_NAME_ENG", "NATION_ID");

            DatabaseManager.BindDropDownNon(ddlDeform, "SELECT * FROM REF_DEFORM ORDER BY DEFORM_ID", "DEFORM_NAME", "DEFORM_ID");
            DatabaseManager.BindDropDownNon(ddlReligion, "SELECT * FROM REF_RELIGION ORDER BY RELIGION_ID", "RELIGION_NAME", "RELIGION_ID");
            DatabaseManager.BindDropDownNon(ddlMovementType, "SELECT * FROM REF_MOVEMENT_TYPE ORDER BY MOVEMENT_TYPE_ID", "MOVEMENT_TYPE_NAME", "MOVEMENT_TYPE_ID");
        }

        private void ChangeNotification(string type)
        {
            switch (type)
            {
                case "info": notification.Attributes["class"] = "alert alert_info"; break;
                case "success": notification.Attributes["class"] = "alert alert_success"; break;
                case "warning": notification.Attributes["class"] = "alert alert_warning"; break;
                case "danger": notification.Attributes["class"] = "alert alert_danger"; break;
                default: notification.Attributes["class"] = null; break;
            }
        }

        private void ChangeNotification(string type, string text)
        {
            switch (type)
            {
                case "info": notification.Attributes["class"] = "alert alert_info"; break;
                case "success": notification.Attributes["class"] = "alert alert_success"; break;
                case "warning": notification.Attributes["class"] = "alert alert_warning"; break;
                case "danger": notification.Attributes["class"] = "alert alert_danger"; break;
                default: notification.Attributes["class"] = null; break;
            }
            notification.InnerHtml = text;
        }

        private void ClearNotification()
        {
            notification.Attributes["class"] = null;
            notification.InnerHtml = "";
        }

        private void AddNotification(string text)
        {
            notification.InnerHtml += text;
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

        protected void ValidationViewZero()
        {
            if (string.IsNullOrEmpty(tbCitizenID.Text))
            {
                ChangeNotification("danger", "กรุณากรอกรหัสประจำตัวประชาชน");
                return;
            }
            if (string.IsNullOrEmpty(tbName.Text))
            {
                ChangeNotification("danger", "กรุณากรอกชื่อ");
                return;
            }
            if (string.IsNullOrEmpty(tbLastName.Text))
            {
                ChangeNotification("danger", "กรุณากรอกนามสกุล");
                return;
            }
            if (string.IsNullOrEmpty(tbBirthday.Text))
            {
                ChangeNotification("danger", "กรุณากรอกวันเกิด");
                return;
            }
            if (string.IsNullOrEmpty(tbHomeAdd.Text))
            {
                ChangeNotification("danger", "กรุณากรอกบ้านเลขที่");
                return;
            }
            if (string.IsNullOrEmpty(ddlProvince.SelectedValue))
            {
                ChangeNotification("danger", "กรุณาเลือกจังหวัด");
                return;
            }
            if (string.IsNullOrEmpty(ddlDistrict.SelectedValue))
            {
                ChangeNotification("danger", "กรุณาเลือกอำเภอ");
                return;
            }
            if (string.IsNullOrEmpty(ddlSubDistrict.SelectedValue))
            {
                ChangeNotification("danger", "กรุณาเลือกตำบล");
                return;
            }
            if (string.IsNullOrEmpty(tbZipcode.Text))
            {
                ChangeNotification("danger", "กรุณากรอกรหัสไปรษณีย์");
                return;
            }
        }
        protected void ValidationViewOne()
        {
            if (string.IsNullOrEmpty(ddlStafftype.SelectedValue))
            {
                ChangeNotification("danger", "กรุณาเลือกจังหวัด");
                return;
            }
            if (string.IsNullOrEmpty(ddlDistrict.SelectedValue))
            {
                ChangeNotification("danger", "กรุณาเลือกอำเภอ");
                return;
            }
            if (string.IsNullOrEmpty(ddlSubDistrict.SelectedValue))
            {
                ChangeNotification("danger", "กรุณาเลือกตำบล");
                return;
            }
        }

        protected void lbuNextToView1_Click(object sender, EventArgs e)
        {
            string CheckCitizen = DatabaseManager.ExecuteString("SELECT CITIZEN_ID FROM UOC_STAFF WHERE CITIZEN_ID = '" + tbCitizenID.Text + "'");
            if (tbCitizenID.Text == CheckCitizen)
            {
                notification.Attributes["class"] = "alert alert-danger";
                notification.InnerHtml += "<div><strong>รหัสบัตรประชาชนซ้ำ</strong></div>";
                return;
            }
            else
            {
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuNextToView2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuAddPerson_Click(object sender, EventArgs e)
        {
            string CheckCitizen = DatabaseManager.ExecuteString("SELECT CITIZEN_ID FROM UOC_STAFF WHERE CITIZEN_ID = '" + tbCitizenID.Text + "'");
            if (tbCitizenID.Text == CheckCitizen)
            {
                notification.Attributes["class"] = "alert alert-danger";
                notification.InnerHtml += "<div><strong>รหัสบัตรประชาชนซ้ำ</strong></div>";
                return;
            }

            PS_PERSON ps = new PS_PERSON();
            int LastID = DatabaseManager.ExecuteInt("SELECT * FROM (SELECT UOC_ID +1 UOC_ID FROM UOC_STAFF ORDER BY UOC_ID DESC) WHERE ROWNUM = 1");
            ps.UOC_ID = LastID;
            ps.YEAR = DateTime.Now.Year.ToString();
            ps.UNIV_ID = ddlUniv.SelectedValue;
            ps.CITIZEN_ID = tbCitizenID.Text;
            ps.PREFIX_NAME = ddlPrefixName.SelectedValue;
            ps.STF_FNAME = tbName.Text;
            ps.STF_LNAME = tbLastName.Text;
            ps.GENDER_ID = ddlGender.SelectedValue;
            ps.BIRTHDAY = tbBirthday.Text;
            ps.HOMEADD = tbHomeAdd.Text;
            ps.MOO = tbMoo.Text;
            ps.STREET = tbStreet.Text;
            ps.SUB_DISTRICT_ID = ddlSubDistrict.SelectedValue;
            ps.DISTRICT_ID = ddlDistrict.SelectedValue;
            ps.PROVINCE_ID = ddlProvince.SelectedValue;
            ps.TELEPHONE = tbTelephone.Text;
            ps.ZIPCODE = tbZipcode.Text;
            ps.NATION_ID = ddlNation.SelectedValue;
            ps.STAFFTYPE_ID = ddlStafftype.SelectedValue;
            ps.TIME_CONTACT_ID = ddlTimeContact.SelectedValue;
            ps.BUDGET_ID = ddlBudget.SelectedValue;
            ps.SUBSTAFFTYPE_ID = ddlSubStafftype.SelectedValue;
            ps.ADMIN_POSITION_ID = ddlAdminPosition.SelectedValue;
            ps.POSITION_ID = ddlPosition.SelectedValue;
            ps.POSITION_WORK = tbPositionWork.Text;
            ps.DEPARTMENT_ID = ddlDepartment.SelectedValue;
            ps.DATE_INWORK = tbDateInwork.Text;
            ps.DATE_START_THIS_U = tbDateStartThisU.Text;
            ps.SPECIAL_NAME = tbSpecialName.Text;
            ps.TEACH_ISCED_ID = ddlTeachISCED.SelectedValue;
            ps.GRAD_LEV_ID = ddlGradLev.SelectedValue;
            ps.GRAD_CURR = tbGradCURR.Text;
            ps.GRAD_ISCED_ID = ddlGradISCED.SelectedValue;
            ps.GRAD_PROG = ddlGradProg.SelectedValue;
            ps.GRAD_UNIV = tbGradUniv.Text;
            ps.GRAD_COUNTRY_ID = ddlGradCountry.SelectedValue;
            ps.DEFORM_ID = ddlDeform.SelectedValue;
            ps.SIT_NO = tbSitNo.Text;
            ps.SALARY = tbSalary.Text;
            ps.POSITION_SALARY = tbPositionSalary.Text;
            ps.RELIGION_ID = ddlReligion.SelectedValue;
            ps.MOVEMENT_TYPE_ID = ddlMovementType.SelectedValue;
            ps.MOVEMENT_DATE = tbMovementDate.Text;
            ps.DECORATION = tbDecoration.Text;
            ps.RESULT1 = tbResult1.Text;
            ps.PERCENT_SALARY1 = tbPercentSalary1.Text;
            ps.RESULT2 = tbResult2.Text;
            ps.PERCENT_SALARY2 = tbPercentSalary2.Text;

            ps.INSERT_PERSON();
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