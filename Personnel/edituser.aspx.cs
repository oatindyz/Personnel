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
    public partial class edituser : System.Web.UI.Page
    {
        UOC_STAFF loginPerson;
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            loginPerson = ps.LoginPerson;

            if (!IsPostBack)
            {
                if (MultiView1.ActiveViewIndex == 0)
                {
                    btnSelectView0.CssClass = "btn btn-info";
                    btnSelectView1.CssClass = "btn btn-primary";
                    btnSelectView2.CssClass = "btn btn-primary";
                }

                if (loginPerson.SUBSTAFFTYPE_ID == "2")
                {
                    lbTeachISCED.Visible = true;
                    ddlTeachISCED.Visible = false;
                }
                else
                {
                    ddlTeachISCED.Visible = true;
                    lbTeachISCED.Visible = false;
                }
                BindDDL();
                ReadSelectID();
                BindLabel();
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlProvince, "SELECT * FROM REF_PROVINCE", "PROVINCE_NAME_TH", "PROVINCE_ID", "--กรุณาเลือก จังหวัด--");
            ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", ""));
            ddlSubDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", ""));
            DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM REF_NATION ORDER BY NATION_NAME_ENG", "NATION_NAME_ENG", "NATION_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlTeachISCED, "SELECT * FROM REF_ISCED  ORDER BY ISCED_ID", "ISCED_NAME", "ISCED_ID", "--กรุณาเลือก--");
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

            ddlProvince.CssClass = "form-control input-sm select2";
            ddlDistrict.CssClass = "form-control input-sm select2";
            ddlSubDistrict.CssClass = "form-control input-sm select2";
            tbZipcode.CssClass = "form-control input-sm";
            ddlNation.CssClass = "form-control input-sm select2";

            tbSpecialName.CssClass = "form-control input-sm";
            ddlTeachISCED.CssClass = "form-control input-sm select2";
        }

        private void AddNotification(string text)
        {
            notification.InnerHtml += text;
        }

        protected void BindLabel()
        {
            lbCitizenID.Text = loginPerson.CITIZEN_ID;
            lbUniv.Text = loginPerson.UNIV_NAME;
            lbPrefixName.Text = loginPerson.PREFIX_NAME;
            lbName.Text = loginPerson.STF_FNAME;
            lbLastName.Text = loginPerson.STF_LNAME;
            lbGender.Text = loginPerson.GENDER_NAME;
            lbBirthday.Text = loginPerson.BIRTHDAY;
            lbStaffType.Text = loginPerson.STAFFTYPE_NAME;
            lbTimeContact.Text = loginPerson.TIME_CONTACT_NAME;
            lbBudget.Text = loginPerson.BUDGET_NAME;
            lbSubStafftype.Text = loginPerson.SUBSTAFFTYPE_NAME;
            lbAdminPosition.Text = loginPerson.ADMIN_POSITION_NAME;
            lbPosition.Text = loginPerson.POSITION_NAME;
            lbPositionWork.Text = loginPerson.POSITION_WORK;
            lbDepartment.Text = loginPerson.DEPARTMENT_NAME;
            lbDateInwork.Text = loginPerson.DATE_INWORK;
            lbDateStartThisU.Text = loginPerson.DATE_START_THIS_U;
            lbTeachISCED.Text = loginPerson.TEACH_ISCED_NAME;
            lbGradLev.Text = loginPerson.GRAD_LEV_NAME;
            lbGradCURR.Text = loginPerson.GRAD_CURR;
            lbGradISCED.Text = loginPerson.GRAD_ISCED_NAME;
            lbGradProg.Text = loginPerson.GRAD_PROG;
            lbGradUniv.Text = loginPerson.GRAD_UNIV;
            lbGradCountry.Text = loginPerson.GRAD_COUNTRY_NAME;
            lbDeform.Text = loginPerson.DEFORM_NAME;
            lbSitNo.Text = loginPerson.SIT_NO;
            lbSalary.Text = loginPerson.SALARY;
            lbPositionSalary.Text = loginPerson.POSITION_SALARY;
            lbReligion.Text = loginPerson.RELIGION_NAME;
            lbMovementType.Text = loginPerson.MOVEMENT_TYPE_NAME;
            lbMovementDate.Text = loginPerson.MOVEMENT_DATE;
            lbDecoration.Text = loginPerson.DECORATION;
            lbResult1.Text = loginPerson.RESULT1;
            lbPercentSalary1.Text = loginPerson.PERCENT_SALARY1;
            lbResult2.Text = loginPerson.RESULT2;
            lbPercentSalary2.Text = loginPerson.PERCENT_SALARY2;
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

        private void ReadSelectID()
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT HOMEADD,MOO,STREET,PROVINCE_ID,DISTRICT_ID,SUB_DISTRICT_ID,TELEPHONE,ZIPCODE,NATION_ID,SPECIAL_NAME,TEACH_ISCED_ID FROM UOC_STAFF WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;

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

                            tbSpecialName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlTeachISCED.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                        }
                    }
                }
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

        protected void lbuUpdatePerson_Click(object sender, EventArgs e)
        {
            if (tbZipcode.Text.Length != 5)
            {
                MultiView1.ActiveViewIndex = 0;
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbZipcode);
                ChangeNotification("danger", "กรุณากรอกรหัสไปรษณีย์ให้ครบ 5 หลัก");
                return;
            }

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;
            PS_PERSON person = new PS_PERSON();

            person.HOMEADD = tbHomeAdd.Text;
            person.MOO = tbMoo.Text;
            person.STREET = tbStreet.Text;
            person.SUB_DISTRICT_ID = ddlSubDistrict.SelectedValue;
            person.DISTRICT_ID = ddlDistrict.SelectedValue;
            person.PROVINCE_ID = ddlProvince.SelectedValue;
            person.TELEPHONE = tbTelephone.Text;
            person.ZIPCODE = tbZipcode.Text;
            person.NATION_ID = ddlNation.SelectedValue;

            person.SPECIAL_NAME = tbSpecialName.Text;
            
            if(loginPerson.SUBSTAFFTYPE_ID == "2")
            {
                person.TEACH_ISCED_ID = "(null)";
            }
            else
            {
                person.TEACH_ISCED_ID = ddlTeachISCED.SelectedValue;
            }

            person.UOC_ID = loginPerson.UOC_ID;

            person.UPDATE_PERSON_USER();

            MultiView1.ActiveViewIndex = 3;

            btnSelectView0.Visible = false;
            btnSelectView1.Visible = false;
            btnSelectView2.Visible = false;
            btnUpdatePerson.Visible = false;

        }

    }
}