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
            DatabaseManager.BindDropDown(ddlUniv, "SELECT * FROM REF_UNIV ORDER BY UNIV_ID", "UNIV_NAME_TH", "UNIV_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlPrefixName, "SELECT * FROM REF_PREFIX_NAME ORDER BY PREFIX_NAME_ID", "FULLNAME", "PREFIX_NAME_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM REF_GENDER ORDER BY GENDER_ID", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlProvince, "SELECT * FROM REF_PROVINCE", "PROVINCE_NAME_TH", "PROVINCE_ID", "--กรุณาเลือก จังหวัด--");
            ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", ""));
            ddlSubDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", ""));
            DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM REF_NATION ORDER BY NATION_NAME_ENG", "NATION_NAME_ENG", "NATION_ID", "--กรุณาเลือก--");

            DatabaseManager.BindDropDown(ddlStafftype, "SELECT * FROM REF_STAFFTYPE ORDER BY STAFFTYPE_ID", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlTimeContact, "SELECT * FROM REF_TIME_CONTACT ORDER BY TIME_CONTACT_ID", "TIME_CONTACT_NAME", "TIME_CONTACT_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlBudget, "SELECT * FROM REF_BUDGET ORDER BY BUDGET_ID", "BUDGET_NAME", "BUDGET_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlSubStafftype, "SELECT * FROM REF_SUBSTAFFTYPE ORDER BY SUBSTAFFTYPE_ID", "SUBSTAFFTYPE_NAME", "SUBSTAFFTYPE_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlAdminPosition, "SELECT * FROM REF_ADMIN ORDER BY ADMIN_ID", "ADMIN_NAME", "ADMIN_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlPosition, "SELECT * FROM REF_POSITION ORDER BY POSITION_ID", "POSITION_NAME_TH", "POSITION_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlDepartment, "SELECT * FROM REF_FAC ORDER BY FAC_ID", "FAC_NAME", "FAC_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlTeachISCED, "SELECT * FROM REF_ISCED  ORDER BY ISCED_ID", "ISCED_NAME", "ISCED_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGradLev, "SELECT * FROM REF_LEV ORDER BY LEV_ID", "LEV_NAME_TH", "LEV_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGradISCED, "SELECT * FROM REF_ISCED ORDER BY ISCED_ID", "ISCED_NAME", "ISCED_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGradProg, "SELECT * FROM REF_PROGRAM ORDER BY PROGRAM_ID_NEW", "PROGRAM_NAME", "PROGRAM_ID_NEW", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGradCountry, "SELECT * FROM REF_NATION ORDER BY NATION_ID", "NATION_NAME_ENG", "NATION_ID", "--กรุณาเลือก--");

            DatabaseManager.BindDropDown(ddlDeform, "SELECT * FROM REF_DEFORM ORDER BY DEFORM_ID", "DEFORM_NAME", "DEFORM_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM REF_RELIGION ORDER BY RELIGION_ID", "RELIGION_NAME", "RELIGION_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlMovementType, "SELECT * FROM REF_MOVEMENT_TYPE ORDER BY MOVEMENT_TYPE_ID", "MOVEMENT_TYPE_NAME", "MOVEMENT_TYPE_ID", "--กรุณาเลือก--");
        }

        public void ChangeNotification(string type)
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

        public void ChangeNotification(string type, string text)
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

            tbCitizenID.CssClass = "form-control input-sm";
            tbName.CssClass = "form-control input-sm";
            tbLastName.CssClass = "form-control input-sm";
            tbBirthday.CssClass = "form-control input-sm";
            ddlProvince.CssClass = "form-control input-sm select2";
            ddlDistrict.CssClass = "form-control input-sm select2";
            ddlSubDistrict.CssClass = "form-control input-sm select2";
            tbZipcode.CssClass = "form-control input-sm";
            ddlNation.CssClass = "form-control input-sm select2";

            ddlStafftype.CssClass = "form-control input-sm select2";
            ddlTimeContact.CssClass = "form-control input-sm select2";
            ddlBudget.CssClass = "form-control input-sm select2";
            ddlSubStafftype.CssClass = "form-control input-sm select2";
            ddlAdminPosition.CssClass = "form-control input-sm select2";
            ddlPosition.CssClass = "form-control input-sm select2";
            ddlDepartment.CssClass = "form-control input-sm select2";
            tbDateInwork.CssClass = "form-control input-sm";
            tbDateStartThisU.CssClass = "form-control input-sm";
            ddlGradLev.CssClass = "form-control input-sm select2";
            tbGradCURR.CssClass = "form-control input-sm";
            ddlGradISCED.CssClass = "form-control input-sm select2";
            ddlGradProg.CssClass = "form-control input-sm select2";
            tbGradUniv.CssClass = "form-control input-sm";
            ddlGradCountry.CssClass = "form-control input-sm select2";

            ddlDeform.CssClass = "form-control input-sm select2";
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

                        ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", ""));
                        ddlSubDistrict.Items.Clear();
                        ddlSubDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", ""));
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

                        ddlSubDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", ""));

                    }
                }
            }
            catch { }
        }

        protected void lbuSelectView0_Click(object sender, EventArgs e)
        {
            ClearNotification();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuSelectView1_Click(object sender, EventArgs e)
        {
            ClearNotification();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuSelectView2_Click(object sender, EventArgs e)
        {
            ClearNotification();
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuAddPerson_Click(object sender, EventArgs e)
        {
            if (tbCitizenID.Text.Length != 13)
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbCitizenID);
                ChangeNotification("danger", "กรุณากรอกรหัสประชาชนให้ครบ 13 หลัก");
                return;
            }
            
            string CheckCitizen = DatabaseManager.ExecuteString("SELECT CITIZEN_ID FROM UOC_STAFF WHERE CITIZEN_ID = '" + tbCitizenID.Text + "'");
            if (tbCitizenID.Text == CheckCitizen)
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbCitizenID);
                ChangeNotification("danger", "รหัสบัตรประชาชนซ้ำ");
                return;
            }
            ///

            if (tbCitizenID.Text == "")
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbCitizenID);
                return;
            }
            if (tbName.Text == "")
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbName);
                return;
            }
            if (tbLastName.Text == "")
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbLastName);
                return;
            }
            if (ddlProvince.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlProvince);
                return;
            }
            if (ddlDistrict.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlDistrict);
                return;
            }
            if (ddlSubDistrict.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlSubDistrict);
                return;
            }
            if (tbZipcode.Text == "")
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbZipcode);
                return;
            }
            if (ddlNation.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlNation);
                return;
            }

            if (ddlStafftype.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlStafftype);
                return;
            }
            if (ddlTimeContact.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlTimeContact);
                return;
            }
            if (ddlBudget.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlBudget);
                return;
            }
            if (ddlSubStafftype.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlSubStafftype);
                return;
            }
            if (ddlPosition.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlPosition);
                return;
            }
            if (ddlDepartment.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlDepartment);
                return;
            }
            if (tbDateInwork.Text == "")
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateInwork);
                return;
            }
            if (tbDateStartThisU.Text == "")
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateStartThisU);
                return;
            }
            if (ddlGradLev.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlGradLev);
                return;
            }
            if (tbGradCURR.Text == "")
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbGradCURR);
                return;
            }
            if (ddlGradISCED.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlGradISCED);
                return;
            }
            if (ddlGradProg.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.ddlGradProg);
                return;
            }

            ///
            if (tbBirthday.Text != "")
            {
                DateTime birthday = DateTime.Parse(tbBirthday.Text);
                DateTime today1 = DateTime.Now;
                if (birthday > today1)
                {
                    MultiView1.ActiveViewIndex = 0;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbBirthday);
                    ChangeNotification("danger", "อายุต้องไม่มากกว่าวันปัจจุบัน");
                    return;
                }

                DateTime BirthYear = DateTime.Parse(tbBirthday.Text);
                DateTime YearNow = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                int totalDays2 = (int)(YearNow - BirthYear).TotalDays + 0;
                if (totalDays2 < 8030)
                {
                    MultiView1.ActiveViewIndex = 0;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbBirthday);
                    ChangeNotification("danger", "อายุต้องไม่ต่ำกว่า22ปี");
                    return;
                }
            }

            if (tbBirthday.Text != "" && tbDateInwork.Text != "")
            {
                DateTime birthday = DateTime.Parse(tbBirthday.Text);
                DateTime DateInwork = DateTime.Parse(tbDateInwork.Text);
                int totalDays3 = (int)(DateInwork - birthday).TotalDays + 0;

                if (totalDays3 < 0)
                {
                    MultiView1.ActiveViewIndex = 1;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateInwork);
                    ChangeNotification("danger", "วันที่เข้าทำงานครั้งแรกต้องไม่น้อยกว่าวันเกิด");
                    return;
                }
            }

            if (tbBirthday.Text != "" && tbDateStartThisU.Text != "")
            {
                DateTime birthday = DateTime.Parse(tbBirthday.Text);
                DateTime DateStartThisU = DateTime.Parse(tbDateStartThisU.Text);
                int totalDays3 = (int)(DateStartThisU - birthday).TotalDays + 0;

                if (totalDays3 < 0)
                {
                    MultiView1.ActiveViewIndex = 1;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateStartThisU);
                    ChangeNotification("danger", "วันที่เข้าทำงาน ณ สถานที่ปัจจุบันต้องไม่น้อยกว่าวันเกิด");
                    return;
                }
            }
            if (tbDateInwork.Text != "" && tbDateStartThisU.Text != "")
            {
                DateTime DateInwork = DateTime.Parse(tbDateInwork.Text);
                DateTime DateStartThisU = DateTime.Parse(tbDateStartThisU.Text);
                int totalDays3 = (int)(DateStartThisU - DateInwork).TotalDays + 0;

                if (totalDays3 > 0)
                {
                    MultiView1.ActiveViewIndex = 1;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateStartThisU);
                    ChangeNotification("danger", "วันที่เข้าทำงาน ณ สถานที่ปัจจุบันต้องไม่มากกว่าวันที่เข้าทำงานครั้งแรก");
                    return;
                }
            }

            PS_PERSON person = new PS_PERSON();
            int LastID = DatabaseManager.ExecuteInt("SELECT * FROM (SELECT UOC_ID +1 UOC_ID FROM UOC_STAFF ORDER BY UOC_ID DESC) WHERE ROWNUM = 1");

            DateTime CurrentBudda = DateTime.Now.AddYears(0);

            person.UOC_ID = LastID;
            person.YEAR = CurrentBudda.ToString("yyyy");
            person.UNIV_ID = ddlUniv.SelectedValue;
            person.CITIZEN_ID = tbCitizenID.Text;
            person.PREFIX_NAME = ddlPrefixName.SelectedValue;
            person.STF_FNAME = tbName.Text;
            person.STF_LNAME = tbLastName.Text;
            person.GENDER_ID = ddlGender.SelectedValue;
            person.BIRTHDAY = tbBirthday.Text;
            person.HOMEADD = tbHomeAdd.Text;
            person.MOO = tbMoo.Text;
            person.STREET = tbStreet.Text;
            person.SUB_DISTRICT_ID = ddlSubDistrict.SelectedValue;
            person.DISTRICT_ID = ddlDistrict.SelectedValue;
            person.PROVINCE_ID = ddlProvince.SelectedValue;
            person.TELEPHONE = tbTelephone.Text;
            person.ZIPCODE = tbZipcode.Text;
            person.NATION_ID = ddlNation.SelectedValue;
            person.STAFFTYPE_ID = ddlStafftype.SelectedValue;
            person.TIME_CONTACT_ID = ddlTimeContact.SelectedValue;
            person.BUDGET_ID = ddlBudget.SelectedValue;
            person.SUBSTAFFTYPE_ID = ddlSubStafftype.SelectedValue;
            person.ADMIN_POSITION_ID = ddlAdminPosition.SelectedValue;
            person.POSITION_ID = ddlPosition.SelectedValue;
            person.POSITION_WORK = tbPositionWork.Text;
            person.DEPARTMENT_ID = ddlDepartment.SelectedValue;
            person.DATE_INWORK = tbDateInwork.Text;
            person.DATE_START_THIS_U = tbDateStartThisU.Text;
            person.SPECIAL_NAME = tbSpecialName.Text;
            person.TEACH_ISCED_ID = ddlTeachISCED.SelectedValue;
            person.GRAD_LEV_ID = ddlGradLev.SelectedValue;
            person.GRAD_CURR = tbGradCURR.Text;
            person.GRAD_ISCED_ID = ddlGradISCED.SelectedValue;
            person.GRAD_PROG = ddlGradProg.SelectedValue;
            person.GRAD_UNIV = tbGradUniv.Text;
            person.GRAD_COUNTRY_ID = ddlGradCountry.SelectedValue;
            person.DEFORM_ID = ddlDeform.SelectedValue;
            person.SIT_NO = tbSitNo.Text;
            person.SALARY = tbSalary.Text;
            person.POSITION_SALARY = tbPositionSalary.Text;
            person.RELIGION_ID = ddlReligion.SelectedValue;
            person.MOVEMENT_TYPE_ID = ddlMovementType.SelectedValue;
            person.MOVEMENT_DATE = tbMovementDate.Text;
            person.DECORATION = tbDecoration.Text;
            person.RESULT1 = tbResult1.Text;
            person.PERCENT_SALARY1 = tbPercentSalary1.Text;
            person.RESULT2 = tbResult2.Text;
            person.PERCENT_SALARY2 = tbPercentSalary2.Text;
            person.ST_LOGIN_ID = 0;
            person.PERSON_ROLE_ID = 1;

            person.INSERT_PERSON();
            ClearNotification();
            MultiView1.ActiveViewIndex = 3;

            btnSelectView0.Visible = false;
            btnSelectView1.Visible = false;
            btnSelectView2.Visible = false;
            btnAddPerson.Visible = false;

        }

    }
}