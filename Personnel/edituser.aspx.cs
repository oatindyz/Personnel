﻿using System;
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
                BindDDL();
                ReadSelectID();
                BindLabel();
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlUniv, "SELECT * FROM REF_UNIV ORDER BY UNIV_ID", "UNIV_NAME_TH", "UNIV_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlPrefixName, "SELECT * FROM REF_PREFIX_NAME ORDER BY PREFIX_NAME_ID", "FULLNAME", "PREFIX_NAME_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM REF_GENDER ORDER BY GENDER_ID", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlProvince, "SELECT * FROM REF_PROVINCE", "PROVINCE_NAME_TH", "PROVINCE_ID", "--กรุณาเลือก จังหวัด--");
            ddlDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก อำเภอ--", "0"));
            ddlSubDistrict.Items.Insert(0, new ListItem("--กรุณาเลือก ตำบล--", "0"));
            DatabaseManager.BindDropDown(ddlNation, "SELECT * FROM REF_NATION ORDER BY NATION_NAME_ENG", "NATION_NAME_ENG", "NATION_ID", "--กรุณาเลือก--");
        }

        protected void BindLabel()
        {
            lbCitizenID.Text = loginPerson.CITIZEN_ID;
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
            lbSpecialName.Text = loginPerson.SPECIAL_NAME;
            lbTeachISCED.Text = loginPerson.TEACH_ISCED_NAME;
            lbGradLev.Text = loginPerson.GRAD_LEV_NAME;
            lbGradCURR.Text = loginPerson.GRAD_CURR;
            lbGradISCED.Text = loginPerson.GRAD_ISCED_NAME;
            lbGradProg.Text = loginPerson.GRAD_PROG;
            lbGradUniv.Text = loginPerson.GRAD_UNIV;
            lbGradCountry.Text = loginPerson.GRAD_COUNTRY_NAME;
            lbDeform.Text = loginPerson.DEFORM_ID;
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

        private void ReadSelectID()
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT UNIV_ID,PREFIX_NAME,STF_FNAME,STF_LNAME,GENDER_ID,BIRTHDAY,HOMEADD,MOO,STREET,PROVINCE_ID,DISTRICT_ID,SUB_DISTRICT_ID,TELEPHONE,ZIPCODE,NATION_ID FROM UOC_STAFF WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;

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
                        }
                    }
                }
            }
        }

        protected void lbuSelectView0_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuSelectView1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuSelectView2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuUpdatePerson_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;
            PS_PERSON person = new PS_PERSON();

            person.UNIV_ID = ddlUniv.SelectedValue;
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
            person.UOC_ID = loginPerson.UOC_ID;

            person.UPDATE_PERSON_USER();

            MultiView1.ActiveViewIndex = 3;

            lbuSelectView0.Visible = false;
            lbuSelectView1.Visible = false;
            lbuSelectView2.Visible = false;
            lbuUpdatePerson.Visible = false;

        }

    }
}