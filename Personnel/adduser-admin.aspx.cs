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
                if (MultiView1.ActiveViewIndex == 0)
                {
                    btnSelectView0.CssClass = "btn btn-info";
                    btnSelectView1.CssClass = "btn btn-primary";
                    btnSelectView2.CssClass = "btn btn-primary";
                }
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

            if (ddlProvince.SelectedIndex == 1)
            {
                tbZipcode.Enabled = false;
                spZip.InnerText = "";
                spZip.Attributes.Add("class", "ps-lb-red");
                spZip.Attributes["style"] = "";
                tbZipcode.Attributes.Add("required", "true");
                ddlNation.Items[211].Attributes["disabled"] = "disabled";
                tbZipcode.Text = "";
                ddlNation.SelectedIndex = 0;
            }
            else
            {
                tbZipcode.Enabled = true;
                spZip.InnerText = "*";
                spZip.Attributes.Add("class", "");
                spZip.Attributes["style"] = "color:red;";
                tbZipcode.Attributes.Add("required", "false");
                ddlNation.Items[211].Attributes["enabled"] = "enabled";
            }
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

            if (ddlProvince.SelectedIndex == 1 && ddlDistrict.SelectedIndex == 1)
            {
                tbZipcode.Enabled = false;
                spZip.InnerText = "";
                spZip.Attributes.Add("class", "ps-lb-red");
                spZip.Attributes["style"] = "";
                tbZipcode.Attributes.Add("required", "true");
                ddlNation.Items[211].Attributes["disabled"] = "disabled";
            }
            else
            {
                tbZipcode.Enabled = true;
                spZip.InnerText = "*";
                spZip.Attributes.Add("class", "");
                spZip.Attributes["style"] = "color:red;";
                tbZipcode.Attributes.Add("required", "false");
                ddlNation.Items[211].Attributes["enabled"] = "enabled";
            }
        }

        protected void lbuSelectView0_Click(object sender, EventArgs e)
        {
            ClearNotification();
            if (ddlProvince.SelectedIndex == 1)
            {
                tbZipcode.Enabled = false;
                spZip.InnerText = "";
                spZip.Attributes.Add("class", "ps-lb-red");
                spZip.Attributes["style"] = "";
                tbZipcode.Attributes.Add("required", "true");
                ddlNation.Items[211].Attributes["disabled"] = "disabled";
                tbZipcode.Text = "";
            }
            else if (ddlProvince.SelectedIndex == 1 && ddlDistrict.SelectedIndex == 1)
            {
                tbZipcode.Enabled = false;
                spZip.InnerText = "";
                spZip.Attributes.Add("class", "ps-lb-red");
                spZip.Attributes["style"] = "";
                tbZipcode.Attributes.Add("required", "true");
                ddlNation.Items[211].Attributes["disabled"] = "disabled";
                tbZipcode.Text = "";
            }
            else
            {
                tbZipcode.Enabled = true;
                spZip.InnerText = "*";
                spZip.Attributes.Add("class", "");
                spZip.Attributes["style"] = "color:red;";
                tbZipcode.Attributes.Add("required", "false");
                ddlNation.Items[211].Attributes["enabled"] = "enabled";
            }
            MultiView1.ActiveViewIndex = 0;
            if (MultiView1.ActiveViewIndex == 0)
            {
                btnSelectView0.CssClass = "btn btn-info";
                btnSelectView1.CssClass = "btn btn-primary";
                btnSelectView2.CssClass = "btn btn-primary";
            }
        }

        protected void lbuSelectView1_Click(object sender, EventArgs e)
        {
            ClearNotification();
            if (ddlGradLev.SelectedIndex == 1)
            {
                ddlGradISCED.Enabled = false;
                spGradISCED.InnerText = "";
                spGradISCED.Attributes.Add("class", "ps-lb-red");
                spGradISCED.Attributes["style"] = "";

                ddlGradProg.Enabled = false;
                spGradProg.InnerText = "";
                spGradProg.Attributes.Add("class", "ps-lb-red");
                spGradProg.Attributes["style"] = "";
            }
            else
            {
                ddlGradISCED.Enabled = true;
                spGradISCED.InnerText = "*";
                spGradISCED.Attributes.Add("class", "");
                spGradISCED.Attributes["style"] = "color:red;";

                ddlGradProg.Enabled = true;
                spGradProg.InnerText = "*";
                spGradProg.Attributes.Add("class", "");
                spGradProg.Attributes["style"] = "color:red;";
            }
            MultiView1.ActiveViewIndex = 1;
            if (MultiView1.ActiveViewIndex == 1)
            {
                btnSelectView0.CssClass = "btn btn-primary";
                btnSelectView1.CssClass = "btn btn-info";
                btnSelectView2.CssClass = "btn btn-primary";
            }
        }

        protected void lbuSelectView2_Click(object sender, EventArgs e)
        {
            ClearNotification();
            MultiView1.ActiveViewIndex = 2;
            if (MultiView1.ActiveViewIndex == 2)
            {
                btnSelectView0.CssClass = "btn btn-primary";
                btnSelectView1.CssClass = "btn btn-primary";
                btnSelectView2.CssClass = "btn btn-info";
            }
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
            //

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

            //
            if (tbBirthday.Text != "")
            {
                DateTime birthday = DateTime.Parse(tbBirthday.Text);
                DateTime today1 = DateTime.Now;

                if (birthday > today1)
                {
                    MultiView1.ActiveViewIndex = 0;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbBirthday);
                    ChangeNotification("danger", "วันเกิดต้องไม่มากกว่าวันปัจจุบัน");
                    return;
                }

                DateTime BirthYear = DateTime.Parse(tbBirthday.Text);
                DateTime CurrDateNow = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
                int totalDays2 = (int)(CurrDateNow - BirthYear).TotalDays + 0;
                if (totalDays2 < 6570)
                {
                    MultiView1.ActiveViewIndex = 0;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbBirthday);
                    ChangeNotification("danger", "อายุต้องไม่ต่ำกว่า 18 ปี");
                    return;
                }
            }

            if (tbBirthday.Text != "" && tbDateInwork.Text != "")
            {
                DateTime birthday = DateTime.Parse(tbBirthday.Text);
                DateTime DateInwork = DateTime.Parse(tbDateInwork.Text);
                int totalDays3 = (int)(birthday - DateInwork).TotalDays + 0;
                int totalDays4 = (int)(DateInwork - birthday).TotalDays + 0;

                if (totalDays3 > 0)
                {
                    MultiView1.ActiveViewIndex = 1;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateInwork);
                    ChangeNotification("danger", "วันที่เข้าทำงานครั้งแรก ต้องไม่ต่ำกว่าวันเกิด");
                    return;
                }
                else if (totalDays4 <= 6574)
                {
                    MultiView1.ActiveViewIndex = 1;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateInwork);
                    ChangeNotification("danger", "วันที่เข้าทำงานครั้งแรก ต้องไม่ต่ำกว่าวันเกิด 18 ปี");
                    return;
                }
            }

            if (tbBirthday.Text != "" && tbDateStartThisU.Text != "")
            {
                DateTime birthday = DateTime.Parse(tbBirthday.Text);
                DateTime DateStartThisU = DateTime.Parse(tbDateStartThisU.Text);
                int totalDays3 = (int)(birthday - DateStartThisU).TotalDays + 0;
                int totalDays4 = (int)(DateStartThisU - birthday).TotalDays + 0;

                if (totalDays3 > 0)
                {
                    MultiView1.ActiveViewIndex = 1;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateStartThisU);
                    ChangeNotification("danger", "วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน ต้องไม่ต่ำกว่าวันเกิด");
                    return;
                }
                else if (totalDays4 <= 6574)
                {
                    MultiView1.ActiveViewIndex = 1;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateStartThisU);
                    ChangeNotification("danger", "วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน ต้องไม่ต่ำกว่าวันเกิด 18 ปี");
                    return;
                }
            }

            if (tbDateInwork.Text != "" && tbDateStartThisU.Text != "")
            {
                DateTime DateInwork = DateTime.Parse(tbDateInwork.Text);
                DateTime DateStartThisU = DateTime.Parse(tbDateStartThisU.Text);
                int totalDays3 = (int)(DateStartThisU - DateInwork).TotalDays + 0;

                if (totalDays3 < 0)
                {
                    MultiView1.ActiveViewIndex = 1;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbDateStartThisU);
                    ChangeNotification("danger", "วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน ต้องไม่น้อยกว่าวันที่เข้าทำงานครั้งแรก");
                    return;
                }
            }

            INSERT_PERSON();
            ClearNotification();
            MultiView1.ActiveViewIndex = 3;
            

            btnSelectView0.Visible = false;
            btnSelectView1.Visible = false;
            btnSelectView2.Visible = false;
            btnAddPerson.Visible = false;

        }

        protected void ddlSubStafftype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubStafftype.SelectedIndex == 2)
            {
                ddlTeachISCED.SelectedIndex = 0;
                ddlTeachISCED.Enabled = false;
                spTeachISCED.InnerText = "";
                spTeachISCED.Attributes.Add("class","ps-lb-red");
                spTeachISCED.Attributes["style"] = "";
            } else {
                ddlTeachISCED.Enabled = true;
                spTeachISCED.InnerText = "*";
                spTeachISCED.Attributes.Add("class", "");
                spTeachISCED.Attributes["style"] = "color:red;";
            }
        }

        protected void ddlGradLev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGradLev.SelectedIndex == 1)
            {
                ddlGradISCED.SelectedIndex = 0;
                ddlGradISCED.Enabled = false;
                spGradISCED.InnerText = "";
                spGradISCED.Attributes.Add("class", "ps-lb-red");
                spGradISCED.Attributes["style"] = "";

                ddlGradProg.SelectedIndex = 0;
                ddlGradProg.Enabled = false;
                spGradProg.InnerText = "";
                spGradProg.Attributes.Add("class", "ps-lb-red");
                spGradProg.Attributes["style"] = "";
            } else {
                ddlGradISCED.Enabled = true;
                spGradISCED.InnerText = "*";
                spGradISCED.Attributes.Add("class", "");
                spGradISCED.Attributes["style"] = "color:red;";

                ddlGradProg.Enabled = true;
                spGradProg.InnerText = "*";
                spGradProg.Attributes.Add("class", "");
                spGradProg.Attributes["style"] = "color:red;";
            }
        }

        public int INSERT_PERSON()
        {
            int id = 0;
            DateTime CurrentBudda = DateTime.Now.AddYears(0);

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO UOC_STAFF (YEAR,UNIV_ID,CITIZEN_ID,PREFIX_NAME,STF_FNAME,STF_LNAME,GENDER_ID,BIRTHDAY,HOMEADD,MOO,STREET,SUB_DISTRICT_ID,DISTRICT_ID,PROVINCE_ID,TELEPHONE,ZIPCODE,NATION_ID,STAFFTYPE_ID,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_ID,POSITION_WORK,DEPARTMENT_ID,DATE_INWORK,DATE_START_THIS_U,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_LEV_ID,GRAD_CURR,GRAD_ISCED_ID,GRAD_PROG,GRAD_UNIV,GRAD_COUNTRY_ID,DEFORM_ID,SIT_NO,SALARY,POSITION_SALARY,RELIGION_ID,MOVEMENT_TYPE_ID,MOVEMENT_DATE,DECORATION,RESULT1,PERCENT_SALARY1,RESULT2,PERCENT_SALARY2,ST_LOGIN_ID,PERSON_ROLE_ID) VALUES (:YEAR,:UNIV_ID,:CITIZEN_ID,:PREFIX_NAME,:STF_FNAME,:STF_LNAME,:GENDER_ID,:BIRTHDAY,:HOMEADD,:MOO,:STREET,:SUB_DISTRICT_ID,:DISTRICT_ID,:PROVINCE_ID,:TELEPHONE,:ZIPCODE,:NATION_ID,:STAFFTYPE_ID,:TIME_CONTACT_ID,:BUDGET_ID,:SUBSTAFFTYPE_ID,:ADMIN_POSITION_ID,:POSITION_ID,:POSITION_WORK,:DEPARTMENT_ID,:DATE_INWORK,:DATE_START_THIS_U,:SPECIAL_NAME,:TEACH_ISCED_ID,:GRAD_LEV_ID,:GRAD_CURR,:GRAD_ISCED_ID,:GRAD_PROG,:GRAD_UNIV,:GRAD_COUNTRY_ID,:DEFORM_ID,:SIT_NO,:SALARY,:POSITION_SALARY,:RELIGION_ID,:MOVEMENT_TYPE_ID,:MOVEMENT_DATE,:DECORATION,:RESULT1,:PERCENT_SALARY1,:RESULT2,:PERCENT_SALARY2,:ST_LOGIN_ID,:PERSON_ROLE_ID)", con))
                {
                    com.Parameters.Add(new OracleParameter("YEAR", CurrentBudda.ToString("yyyy")));
                    com.Parameters.Add(new OracleParameter("UNIV_ID", ddlUniv.SelectedValue));
                    com.Parameters.Add(new OracleParameter("CITIZEN_ID", tbCitizenID.Text));
                    com.Parameters.Add(new OracleParameter("PREFIX_NAME", ddlPrefixName.SelectedValue));
                    com.Parameters.Add(new OracleParameter("STF_FNAME", tbName.Text));
                    com.Parameters.Add(new OracleParameter("STF_LNAME", tbLastName.Text));
                    com.Parameters.Add(new OracleParameter("GENDER_ID", ddlGender.SelectedValue));
                    com.Parameters.Add(new OracleParameter("BIRTHDAY", DateTime.Parse(tbBirthday.Text)));
                    com.Parameters.Add(new OracleParameter("HOMEADD", tbHomeAdd.Text));
                    com.Parameters.Add(new OracleParameter("MOO", tbMoo.Text));
                    com.Parameters.Add(new OracleParameter("STREET", tbStreet.Text));
                    com.Parameters.Add(new OracleParameter("SUB_DISTRICT_ID", ddlSubDistrict.SelectedValue));
                    com.Parameters.Add(new OracleParameter("DISTRICT_ID", ddlDistrict.SelectedValue));
                    com.Parameters.Add(new OracleParameter("PROVINCE_ID", ddlProvince.SelectedValue));
                    com.Parameters.Add(new OracleParameter("TELEPHONE", tbTelephone.Text));
                    com.Parameters.Add(new OracleParameter("ZIPCODE", tbZipcode.Text));
                    com.Parameters.Add(new OracleParameter("NATION_ID", ddlNation.SelectedValue));
                    com.Parameters.Add(new OracleParameter("STAFFTYPE_ID", ddlStafftype.SelectedValue));
                    com.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", ddlTimeContact.SelectedValue));
                    com.Parameters.Add(new OracleParameter("BUDGET_ID", ddlBudget.SelectedValue));
                    com.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", ddlSubStafftype.SelectedValue));
                    com.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ddlAdminPosition.SelectedValue));
                    com.Parameters.Add(new OracleParameter("POSITION_ID", ddlPosition.SelectedValue));
                    com.Parameters.Add(new OracleParameter("POSITION_WORK", tbPositionWork.Text));
                    com.Parameters.Add(new OracleParameter("DEPARTMENT_ID", ddlDepartment.SelectedValue));
                    com.Parameters.Add(new OracleParameter("DATE_INWORK", DateTime.Parse(tbDateInwork.Text)));
                    com.Parameters.Add(new OracleParameter("DATE_START_THIS_U", DateTime.Parse(tbDateStartThisU.Text)));
                    com.Parameters.Add(new OracleParameter("SPECIAL_NAME", tbSpecialName.Text));
                    com.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", ddlTeachISCED.SelectedValue));
                    com.Parameters.Add(new OracleParameter("GRAD_LEV_ID", ddlGradLev.SelectedValue));
                    com.Parameters.Add(new OracleParameter("GRAD_CURR", tbGradCURR.Text));
                    com.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", ddlGradISCED.SelectedValue));
                    com.Parameters.Add(new OracleParameter("GRAD_PROG", ddlGradProg.SelectedValue));
                    com.Parameters.Add(new OracleParameter("GRAD_UNIV", tbGradUniv.Text));
                    com.Parameters.Add(new OracleParameter("GRAD_COUNTRY_ID", ddlGradCountry.SelectedValue));
                    com.Parameters.Add(new OracleParameter("DEFORM_ID", ddlDeform.SelectedValue));
                    com.Parameters.Add(new OracleParameter("SIT_NO", tbSitNo.Text));
                    com.Parameters.Add(new OracleParameter("SALARY", tbSalary.Text));
                    com.Parameters.Add(new OracleParameter("POSITION_SALARY", tbPositionSalary.Text));
                    com.Parameters.Add(new OracleParameter("RELIGION_ID", ddlReligion.SelectedValue));
                    com.Parameters.Add(new OracleParameter("MOVEMENT_TYPE_ID", ddlMovementType.SelectedValue));
                    if (tbMovementDate.Text == ""){com.Parameters.Add(new OracleParameter("MOVEMENT_DATE", DBNull.Value));}
                    else{com.Parameters.Add(new OracleParameter("MOVEMENT_DATE", DateTime.Parse(tbMovementDate.Text)));}
                    com.Parameters.Add(new OracleParameter("DECORATION", tbDecoration.Text));
                    com.Parameters.Add(new OracleParameter("RESULT1", tbResult1.Text));
                    com.Parameters.Add(new OracleParameter("PERCENT_SALARY1", tbPercentSalary1.Text));
                    com.Parameters.Add(new OracleParameter("RESULT2", tbResult2.Text));
                    com.Parameters.Add(new OracleParameter("PERCENT_SALARY2", tbPercentSalary2.Text));
                    com.Parameters.Add(new OracleParameter("ST_LOGIN_ID", "0"));
                    com.Parameters.Add(new OracleParameter("PERSON_ROLE_ID", "1"));
                    id = com.ExecuteNonQuery();

                }
            }
            return id;
        }


    }
}