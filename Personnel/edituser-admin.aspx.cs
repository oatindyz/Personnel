using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Text;
using Personnel.Class;

namespace Personnel
{
    public partial class edituser_admin : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                if(Request.QueryString["id"] != null)
                {
                    int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
                    BindDDL();
                    ReadSelectID();
                } else { Response.Redirect("listuser-admin.aspx"); }
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
            DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM REF_RELIGION ORDER BY RELIGION_ID", "RELIGION_NAME_TH", "RELIGION_ID", "--กรุณาเลือก--");
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

        private void ReadSelectID()
        {          
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID,UNIV_ID,PREFIX_NAME,STF_FNAME,STF_LNAME,GENDER_ID,BIRTHDAY,HOMEADD,MOO,STREET,PROVINCE_ID,DISTRICT_ID,SUB_DISTRICT_ID,TELEPHONE,ZIPCODE,NATION_ID,STAFFTYPE_ID,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_ID,POSITION_WORK,DEPARTMENT_ID,DATE_INWORK,DATE_START_THIS_U,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_LEV_ID,GRAD_CURR,GRAD_ISCED_ID,GRAD_PROG,GRAD_UNIV,GRAD_COUNTRY_ID,DEFORM_ID,SIT_NO,SALARY,POSITION_SALARY,RELIGION_ID,MOVEMENT_TYPE_ID,MOVEMENT_DATE,DECORATION,RESULT1,PERCENT_SALARY1,RESULT2,PERCENT_SALARY2 FROM UOC_STAFF WHERE UOC_ID = '" + id + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            lbCitizenID.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlUniv.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i; 
                            ddlPrefixName.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            tbName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbLastName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlGender.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            tbBirthday.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbHomeAdd.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbMoo.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbStreet.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                            ddlProvince.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetString(i); ++i;

                            ddlDistrict.Items.Clear();
                            string s1 = reader.IsDBNull(i) ? "0" : reader.GetString(i); ++i;
                            DatabaseManager.BindDropDown(ddlDistrict, "SELECT * FROM REF_DISTRICT WHERE PROVINCE_ID = " + ddlProvince.SelectedValue, "DISTRICT_NAME_TH", "DISTRICT_ID", "--กรุณาเลือกอำเภอ--");
                            ddlDistrict.SelectedValue = s1;

                            ddlSubDistrict.Items.Clear();
                            string s2 = reader.IsDBNull(i) ? "0" : reader.GetString(i); ++i;
                            DatabaseManager.BindDropDown(ddlSubDistrict, "SELECT * FROM REF_SUB_DISTRICT WHERE DISTRICT_ID = " + ddlDistrict.SelectedValue, "SUB_DISTRICT_NAME_TH", "SUB_DISTRICT_ID", "--กรุณาเลือกตำบล--");
                            ddlSubDistrict.SelectedValue = s2;

                            tbTelephone.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbZipcode.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlNation.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            ddlStafftype.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            ddlTimeContact.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            ddlBudget.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            ddlSubStafftype.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            ddlAdminPosition.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            ddlPosition.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            tbPositionWork.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlDepartment.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            tbDateInwork.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbDateStartThisU.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbSpecialName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlTeachISCED.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            ddlGradLev.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            tbGradCURR.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            
                            ddlGradISCED.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;//
                            ddlGradProg.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;//

                            tbGradUniv.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                            ddlGradCountry.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;//
                            ddlDeform.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;//

                            tbSitNo.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbSalary.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbPositionSalary.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlReligion.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            ddlMovementType.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            tbMovementDate.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbDecoration.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResult1.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbPercentSalary1.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResult2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbPercentSalary2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            
                        }
                    }
                }
            }
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

        protected void lbuUpdatePerson_Click(object sender, EventArgs e)
        {
            DateTime birthday = DateTime.Parse(tbBirthday.Text);
            DateTime today1 = DateTime.Now;

            if (birthday > today1)
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbBirthday);
                ChangeNotification("danger", "วันเกิด ต้องไม่มากกว่า วันปัจจุบัน");
                return;
            }

            if (tbZipcode.Text.Length != 5)
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbZipcode);
                ChangeNotification("danger", "กรุณากรอกรหัสไปรษณีย์ให้ครบ 5 หลัก");
                return;
            }

            PS_PERSON person = new PS_PERSON();
            person.UNIV_ID = ddlUniv.SelectedValue;
            person.CITIZEN_ID = lbCitizenID.Text;
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
            person.UOC_ID = int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));

            person.UPDATE_PERSON();
            
            MultiView1.ActiveViewIndex = 3;

            btnSelectView0.Visible = false;
            btnSelectView1.Visible = false;
            btnSelectView2.Visible = false;
            btnUpdatePerson.Visible = false;
        }


    }
}