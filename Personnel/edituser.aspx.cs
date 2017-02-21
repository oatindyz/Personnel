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

            DatabaseManager.BindDropDown(ddlUniv, "SELECT * FROM REF_UNIV ORDER BY ABS(UNIV_ID) ASC", "UNIV_NAME_TH", "UNIV_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlPrefixName, "SELECT * FROM REF_PREFIX_NAME WHERE STATUS_ID = 1 ORDER BY ABS(PREFIX_NAME_ID) ASC", "FULLNAME", "PREFIX_NAME_ID", "--กรุณาเลือก--");
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
        }

        private void AddNotification(string text)
        {
            notification.InnerHtml += text;
        }

        protected void BindLabel()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand(
                "SELECT CITIZEN_ID," +
                "(SELECT UNIV_NAME_TH FROM REF_UNIV WHERE REF_UNIV.UNIV_ID = UOC_STAFF.UNIV_ID) UNIV_NAME," +
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
                "(SELECT ISCED_NAME FROM REF_ISCED WHERE REF_ISCED.ISCED_ID = UOC_STAFF.TEACH_ISCED_ID) TEACH_ISCED_NAME," +
                "(SELECT LEV_NAME_TH FROM REF_LEV WHERE REF_LEV.LEV_ID = UOC_STAFF.GRAD_LEV_ID) GRAD_LEV_NAME," +
                "GRAD_CURR," +
                "(SELECT ISCED_NAME FROM REF_ISCED WHERE REF_ISCED.ISCED_ID = UOC_STAFF.GRAD_ISCED_ID) GRAD_ISCED_NAME," +
                "(SELECT PROGRAM_NAME FROM REF_PROGRAM WHERE REF_PROGRAM.PROGRAM_ID_NEW = UOC_STAFF.GRAD_PROG) GRAD_PROG," +
                "GRAD_UNIV," +
                "(SELECT NATION_NAME_ENG FROM REF_NATION WHERE REF_NATION.NATION_ID = UOC_STAFF.GRAD_COUNTRY_ID) GRAD_COUNTRY_NAME," +
                "(SELECT DEFORM_NAME FROM REF_DEFORM WHERE REF_DEFORM.DEFORM_ID = UOC_STAFF.DEFORM_ID) DEFORM_NAME," +
                "SIT_NO," +
                "SALARY," +
                "POSITION_SALARY," +
                "(SELECT RELIGION_NAME_TH FROM REF_RELIGION WHERE REF_RELIGION.RELIGION_ID = UOC_STAFF.RELIGION_ID) RELIGION_NAME_TH," +
                "(SELECT MOVEMENT_TYPE_NAME FROM REF_MOVEMENT_TYPE WHERE REF_MOVEMENT_TYPE.MOVEMENT_TYPE_ID = UOC_STAFF.MOVEMENT_TYPE_ID) MOVEMENT_TYPE_NAME," +
                "MOVEMENT_DATE," +
                "DECORATION," +
                "RESULT1," +
                "PERCENT_SALARY1," +
                "RESULT2," +
                "PERCENT_SALARY2" +
                " FROM UOC_STAFF WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            lbCitizenID.Text = reader.GetValue(i).ToString(); ++i;
                            lbUniv.Text = reader.GetValue(i).ToString(); ++i;
                            lbPrefixName.Text = reader.GetValue(i).ToString(); ++i;
                            lbName.Text = reader.GetValue(i).ToString(); ++i;
                            lbLastName.Text = reader.GetValue(i).ToString(); ++i;
                            lbGender.Text = reader.GetValue(i).ToString(); ++i;
                            lbBirthday.Text = reader.IsDBNull(i) ? DBNull.Value.ToString() : Convert.ToDateTime(reader["BIRTHDAY"]).ToString("dd/MM/yyyy"); ++i;
                            lbStaffType.Text = reader.GetValue(i).ToString(); ++i;
                            lbTimeContact.Text = reader.GetValue(i).ToString(); ++i;
                            lbBudget.Text = reader.GetValue(i).ToString(); ++i;
                            lbSubStafftype.Text = reader.GetValue(i).ToString(); ++i;
                            lbAdminPosition.Text = reader.GetValue(i).ToString(); ++i;
                            lbPosition.Text = reader.GetValue(i).ToString(); ++i;
                            lbPositionWork.Text = reader.GetValue(i).ToString(); ++i;
                            lbDepartment.Text = reader.GetValue(i).ToString(); ++i;
                            lbDateInwork.Text = reader.IsDBNull(i) ? DBNull.Value.ToString() : Convert.ToDateTime(reader["DATE_INWORK"]).ToString("dd/MM/yyyy"); ++i;
                            lbDateStartThisU.Text = reader.IsDBNull(i) ? DBNull.Value.ToString() : Convert.ToDateTime(reader["DATE_START_THIS_U"]).ToString("dd/MM/yyyy"); ++i;
                            lbTeachISCED.Text = reader.GetValue(i).ToString(); ++i;
                            lbGradLev.Text = reader.GetValue(i).ToString(); ++i;
                            lbGradCURR.Text = reader.GetValue(i).ToString(); ++i;
                            lbGradISCED.Text = reader.GetValue(i).ToString(); ++i;
                            lbGradProg.Text = reader.GetValue(i).ToString(); ++i;
                            lbGradUniv.Text = reader.GetValue(i).ToString(); ++i;
                            lbGradCountry.Text = reader.GetValue(i).ToString(); ++i;
                            lbDeform.Text = reader.GetValue(i).ToString(); ++i;
                            lbSitNo.Text = reader.GetValue(i).ToString(); ++i;
                            lbSalary.Text = reader.GetValue(i).ToString(); ++i;
                            lbPositionSalary.Text = reader.GetValue(i).ToString(); ++i;
                            lbReligion.Text = reader.GetValue(i).ToString(); ++i;
                            lbMovementType.Text = reader.GetValue(i).ToString(); ++i;
                            lbMovementDate.Text = reader.GetValue(i).ToString(); ++i;
                            lbDecoration.Text = reader.GetValue(i).ToString(); ++i;
                            lbResult1.Text = reader.GetValue(i).ToString(); ++i;
                            lbPercentSalary1.Text = reader.GetValue(i).ToString(); ++i;
                            lbResult2.Text = reader.GetValue(i).ToString(); ++i;
                            lbPercentSalary2.Text = reader.GetValue(i).ToString(); ++i;
                        }
                    }
                }
            }
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
                using (OracleCommand com = new OracleCommand("SELECT HOMEADD,MOO,STREET,PROVINCE_ID,DISTRICT_ID,SUB_DISTRICT_ID,TELEPHONE,ZIPCODE,NATION_ID,SPECIAL_NAME,TEACH_ISCED_ID,UNIV_ID,PREFIX_NAME,STF_FNAME,STF_LNAME FROM UOC_STAFF WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;

                            tbHomeAdd.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbMoo.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbStreet.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                            ddlProvince.SelectedValue = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                            ddlDistrict.Items.Clear();
                            string s1 = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            DatabaseManager.BindDropDown(ddlDistrict, "SELECT * FROM REF_DISTRICT WHERE PROVINCE_ID = " + ddlProvince.SelectedValue, "DISTRICT_NAME_TH", "DISTRICT_ID", "--กรุณาเลือกอำเภอ--");
                            ddlDistrict.SelectedValue = s1;

                            ddlSubDistrict.Items.Clear();
                            string s2 = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            DatabaseManager.BindDropDown(ddlSubDistrict, "SELECT * FROM REF_SUB_DISTRICT WHERE DISTRICT_ID = " + ddlDistrict.SelectedValue, "SUB_DISTRICT_NAME_TH", "SUB_DISTRICT_ID", "--กรุณาเลือกตำบล--");
                            ddlSubDistrict.SelectedValue = s2;

                            tbTelephone.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbZipcode.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlNation.SelectedValue = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            lbSpecialName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbTeachISCED.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                            //
                            ddlUniv.SelectedValue = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlPrefixName.SelectedValue = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbLastName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
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

        public int INSERT_REQUEST()
        {
            int id = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO TB_REQUEST (UOC_ID,STATUS_ID,DATE_START,UNIV_ID,PREFIX_NAME,STF_FNAME,STF_LNAME) VALUES (:UOC_ID,:STATUS_ID,:DATE_START,:UNIV_ID,:PREFIX_NAME,:STF_FNAME,:STF_LNAME)", con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", loginPerson.UOC_ID));
                    com.Parameters.Add(new OracleParameter("STATUS_ID", "0"));
                    com.Parameters.Add(new OracleParameter("DATE_START", DateTime.Today));
                    if (cbUniv.Checked) { com.Parameters.Add(new OracleParameter("UNIV_ID", ddlUniv.SelectedValue)); } else { com.Parameters.Add(new OracleParameter("UNIV_ID", DBNull.Value)); }
                    if (cbPrefixName.Checked) { com.Parameters.Add(new OracleParameter("PREFIX_NAME", ddlPrefixName.SelectedValue)); } else { com.Parameters.Add(new OracleParameter("PREFIX_NAME", DBNull.Value)); }
                    if (cbName.Checked) { com.Parameters.Add(new OracleParameter("STF_FNAME", tbName.Text)); } else { com.Parameters.Add(new OracleParameter("STF_FNAME", DBNull.Value)); }
                    if (cbLastName.Checked) { com.Parameters.Add(new OracleParameter("STF_LNAME", tbLastName.Text)); } else { com.Parameters.Add(new OracleParameter("STF_LNAME", DBNull.Value)); }
                    id = com.ExecuteNonQuery();
                }
            }
            return id;
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

            person.UOC_ID = loginPerson.UOC_ID;

            person.UPDATE_PERSON_USER();
            INSERT_REQUEST();

            MultiView1.ActiveViewIndex = 3;   
            btnSelectView0.Visible = false;
            btnSelectView1.Visible = false;
            btnSelectView2.Visible = false;
            btnUpdatePerson.Visible = false;
        }

        protected void cbUniv_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUniv.Checked)
            {
                lbUniv.Visible = false;
                ddlUniv.Visible = true;
            }
            else
            {
                lbUniv.Visible = true;
                ddlUniv.Visible = false;
            }
        }

        protected void cbPrefixName_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPrefixName.Checked)
            {
                lbPrefixName.Visible = false;
                ddlPrefixName.Visible = true;
            }
            else
            {
                lbPrefixName.Visible = true;
                ddlPrefixName.Visible = false;
            }
        }

        protected void cbName_CheckedChanged(object sender, EventArgs e)
        {
            if (cbName.Checked)
            {
                lbName.Visible = false;
                tbName.Visible = true;
            }
            else
            {
                lbName.Visible = true;
                tbName.Visible = false;
            }
        }

        protected void cbLastName_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLastName.Checked)
            {
                lbLastName.Visible = false;
                tbLastName.Visible = true;
            }
            else
            {
                lbLastName.Visible = true;
                tbLastName.Visible = false;
            }
        }
    }
}