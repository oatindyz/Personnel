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
        private string p;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (hfuocID.Value != "")
            {
                p = hfuocID.Value;
            }
            if (p == null)
            {
                MultiView1.Visible = false;
                if (CreateSelectPersonPageLoad(this, "edituser-admin.aspx"))
                {
                    return;
                }
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
            MultiView1.Visible = true;
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lbuNextToView2_Click(object sender, EventArgs e)
        {
            MultiView1.Visible = true;
            MultiView1.ActiveViewIndex = 2;
        }

        protected void lbuUpdatePerson_Click(object sender, EventArgs e)
        {
            PS_PERSON ps = new PS_PERSON();

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
            ps.UOC_ID = Convert.ToInt32(p);

            ps.UPDATE_PERSON();

            MultiView1.Visible = true;
            MultiView1.ActiveViewIndex = 3;

        }

        protected void lbuBackToView0_Click(object sender, EventArgs e)
        {
            MultiView1.Visible = true;
            MultiView1.ActiveViewIndex = 0;
        }

        protected void lbuBackToView1_Click(object sender, EventArgs e)
        {
            MultiView1.Visible = true;
            MultiView1.ActiveViewIndex = 1;
        }

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID,UNIV_ID,PREFIX_NAME,STF_FNAME,STF_LNAME,GENDER_ID,BIRTHDAY,HOMEADD,MOO,STREET,PROVINCE_ID,DISTRICT_ID,SUB_DISTRICT_ID,TELEPHONE,ZIPCODE,NATION_ID,STAFFTYPE_ID,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_ID,POSITION_WORK,DEPARTMENT_ID,DATE_INWORK,DATE_START_THIS_U,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_LEV_ID,GRAD_CURR,GRAD_ISCED_ID,GRAD_PROG,GRAD_UNIV,GRAD_COUNTRY_ID,DEFORM_ID,SIT_NO,SALARY,POSITION_SALARY,RELIGION_ID,MOVEMENT_TYPE_ID,MOVEMENT_DATE,DECORATION,RESULT1,PERCENT_SALARY1,RESULT2,PERCENT_SALARY2 FROM UOC_STAFF WHERE UOC_ID = '" + p + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            tbCitizenID.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
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

        public bool CreateSelectPersonPageLoad(Page page, string pageURL)
        {

            string ps = null;

            if (page.Request.QueryString["ps"] != null)
            {
                ps = page.Request.QueryString["ps"];
            }

            if (ps != null)
            {
                CreateSelectPersonPanel(page, pageURL, ps);
                return true;
            }
            if (p == null)
            {
                CreateSelectPersonPanel(page, pageURL);
                return true;
            }
            return false;
        }

        public void CreateSelectPersonPanel(Page page, string pageURL)
        {
            CreateSelectPersonPanel(page, pageURL, null);
        }

        public void CreateSelectPersonPanel(Page page, string pageURL, string ps)
        {
            {
                Table1.Rows.Clear();
                TableRow row = new TableRow();

                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ลำดับ";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ชื่อ - นามสกุล";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "ประเภทบุคลากร";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "คณะ/หน่วยงาน";
                    row.Cells.Add(cell);
                }
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = "แก้ไขข้อมูล";
                    row.Cells.Add(cell);
                }

                Table1.Rows.Add(row);
            }

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT UOC_ID,STF_FNAME || ' ' || STF_LNAME NAME,(SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE UOC_STAFF.STAFFTYPE_ID = REF_STAFFTYPE.STAFFTYPE_ID) STAFF_NAME, (SELECT FAC_NAME FROM REF_FAC WHERE UOC_STAFF.DEPARTMENT_ID = REF_FAC.FAC_ID) FAC_NAME FROM UOC_STAFF ORDER BY UOC_ID", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();
                            int uoc_id = reader.GetInt32(0);

                            {
                                Label lblID = new Label();
                                lblID.Text = reader.IsDBNull(0) ? "-" : uoc_id.ToString();
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblID);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblName = new Label();
                                lblName.Text = reader.IsDBNull(1) ? "-" : reader.GetString(1); //name
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblName);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblStaffName = new Label();
                                lblStaffName.Text = reader.IsDBNull(2) ? "-" : reader.GetString(2); //staffname
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblStaffName);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblFacName = new Label();
                                lblFacName.Text = reader.IsDBNull(3) ? "-" : reader.GetString(3); //FacName
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblFacName);
                                row.Cells.Add(cell);
                            }

                            {
                                LinkButton lbuEdit = new LinkButton();
                                lbuEdit.Text = "เลือก";
                                lbuEdit.Click += (e2, e3) =>
                                {
                                    p = uoc_id.ToString();
                                    BindDDL();
                                    ReadSelectID();
                                    divLoad.Visible = false;
                                    divTitle.Visible = false;
                                    MultiView1.Visible = true;
                                    MultiView1.ActiveViewIndex = 0;
                                    hfuocID.Value = p;
                                };
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lbuEdit);
                                row.Cells.Add(cell);
                            }

                            Table1.Rows.Add(row);
                        }
                    }
                }
            }
        }


    }
}