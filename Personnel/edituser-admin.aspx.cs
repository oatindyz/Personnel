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
            //Edit
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

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID, UNIV_ID, PREFIX_NAME FROM UOC_STAFF WHERE UOC_ID = '" + p + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //view1
                            int i = 0;
                            tbCitizenID.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlUniv.SelectedValue = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i; 
                            ddlPrefixName.SelectedValue = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
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

        protected void ddlUniv_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbLastName.Text = ddlUniv.SelectedValue.ToString();
        }
    }
}