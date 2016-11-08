using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using Personnel.Class;
using System.Text;
using System.IO;
using System.Data;

namespace Personnel
{
    public partial class reportleave_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
                ddlYear.Items.Insert(0, new ListItem("--กรุณาเลือก--", ""));
                for (int i = 2550; i < 2600; ++i)
                {
                    ddlYear.Items.Add(new System.Web.UI.WebControls.ListItem("" + i, "" + i));
                }
                ddlMonth.Items.Insert(0, new ListItem("--กรุณาเลือก--", ""));
                ddlMonth.Items.Insert(1, new ListItem("มกราคม", "01"));
                ddlMonth.Items.Insert(2, new ListItem("กุมภาพันธ์", "02"));
                ddlMonth.Items.Insert(3, new ListItem("มีนาคม", "03"));
                ddlMonth.Items.Insert(4, new ListItem("เมษายน", "04"));
                ddlMonth.Items.Insert(5, new ListItem("พฤษภาคม", "05"));
                ddlMonth.Items.Insert(6, new ListItem("มิถุนายน", "06"));
                ddlMonth.Items.Insert(7, new ListItem("กรกฎาคม", "07"));
                ddlMonth.Items.Insert(8, new ListItem("สิงหาคม", "08"));
                ddlMonth.Items.Insert(9, new ListItem("กันยายน", "09"));
                ddlMonth.Items.Insert(10, new ListItem("ตุลาคม", "10"));
                ddlMonth.Items.Insert(11, new ListItem("พฤศจิกายน", "11"));
                ddlMonth.Items.Insert(12, new ListItem("ธันวาคม", "12"));
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlStafftype, "SELECT * FROM REF_STAFFTYPE ORDER BY STAFFTYPE_ID", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlDepartment, "SELECT * FROM REF_FAC ORDER BY FAC_ID", "FAC_NAME", "FAC_ID", "--กรุณาเลือก--");
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

        private Table BindToTable()
        {
            Table table = new Table();
            table.CssClass = "ps-table-1";

            if (ddlDepartment.SelectedValue == "")
            {
                {
                    TableHeaderRow row = new TableHeaderRow();
                    { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สรุปข้อมูลการลาออก"; cell.ColumnSpan = 6; row.Cells.Add(cell); }
                    table.Rows.Add(row);
                }
            }
            else
            {
                {
                    string departname = DatabaseManager.ExecuteString("SELECT (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + ddlDepartment.SelectedValue + "'");
                    TableHeaderRow row = new TableHeaderRow();
                    { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สรุปข้อมูลการลาออก ของ" + departname; cell.ColumnSpan = 6; row.Cells.Add(cell); }
                    table.Rows.Add(row);
                }
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลำดับ"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ชื่อ-สกุล"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ประเภทบุคลากร"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "คณะ/หน่วยงานที่สังกัด"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ประเภทการดำรงตำแหน่งปัจจุบัน"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วันที่มีผลบังคับใช้ตามข้อมูล'การเข้าสู่ตำแหน่งปัจจุบัน'"; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string sql;
                string where = "";
                if (ddlStafftype.SelectedValue != "")
                {
                    where += " AND STAFFTYPE_ID = '" + ddlStafftype.SelectedValue + "'";
                }
                if (ddlDepartment.SelectedValue != "")
                {
                    where += " AND DEPARTMENT_ID = '" + ddlDepartment.SelectedValue + "'";
                }
                if (ddlMovementType.SelectedValue != "")
                {
                    where += " AND MOVEMENT_TYPE_ID = '" + ddlMovementType.SelectedValue + "'";
                }
                if (tbStartDate.Text != "" && tbEndDate.Text != "")
                {
                    where += " AND MOVEMENT_DATE >= TO_DATE('" + tbStartDate.Text + "', 'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') AND MOVEMENT_DATE <= TO_DATE('" + tbEndDate.Text + "', 'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI')";
                }
                if (ddlMonth.SelectedValue != "")
                {
                    where += " AND EXTRACT(MONTH FROM MOVEMENT_DATE) = '" + ddlMonth.SelectedValue + "'";
                }
                if (ddlYear.SelectedValue != "")
                {
                    where += " AND EXTRACT(YEAR FROM MOVEMENT_DATE) = '" + ddlYear.SelectedValue + "'-543";
                }

                using (OracleCommand com = new OracleCommand("SELECT STF_FNAME || ' ' || STF_LNAME NAME, (SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE REF_STAFFTYPE.STAFFTYPE_ID = UOC_STAFF.STAFFTYPE_ID) STAFFTYPE_NAME, (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME, (SELECT MOVEMENT_TYPE_NAME FROM REF_MOVEMENT_TYPE WHERE REF_MOVEMENT_TYPE.MOVEMENT_TYPE_ID = UOC_STAFF.MOVEMENT_TYPE_ID) MOVEMENT_TYPE_NAME, MOVEMENT_DATE FROM UOC_STAFF WHERE 1=1" + where, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        int j = 1;
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();

                            {
                                TableCell cell = new TableCell();
                                cell.Text = "" + j;
                                row.Cells.Add(cell);
                            }
                            {
                                Label lblName = new Label();
                                lblName.Text = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblName);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblStaffName = new Label();
                                lblStaffName.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblStaffName);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblDepartment = new Label();
                                lblDepartment.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblDepartment);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblmovementType = new Label();
                                lblmovementType.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblmovementType);
                                row.Cells.Add(cell);
                            }

                            {
                                Label lblmovementDate = new Label();
                                lblmovementDate.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                                TableCell cell = new TableCell();
                                cell.Controls.Add(lblmovementDate);
                                row.Cells.Add(cell);
                            }

                            table.Rows.Add(row);
                            ++j;
                        }
                    
                    }
                    }
                }
               
            return table;
        }

        protected void lbuExport_Click(object sender, EventArgs e)
        {
            Table table;
            table = BindToTable();
            if (table == null)
            {
                return;
            }

            Response.ContentType = "application/x-msexcel";

            /*if (ddlYear.SelectedValue != "")
            {
                Response.AddHeader("Content-Disposition", "attachment;filename=สรุปข้อมูลอบรม/สัมมนา/ดูงาน " + ddlYear.SelectedValue + ".xls");
            }
            else if (ddlDepartment.SelectedValue != "")
            {
                string name = DatabaseManager.ExecuteString("SELECT (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + ddlDepartment.SelectedValue + "'");
                Response.AddHeader("Content-Disposition", "attachment;filename=สรุปข้อมูลอบรม/สัมมนา/ดูงาน " + name + ".xls");
            }
            else if (ddlCategory.SelectedValue != "")
            {
                string name = DatabaseManager.ExecuteString("SELECT (SELECT CATEGORY_NAME FROM TB_PROJECT_CATEGORY WHERE TB_PROJECT_CATEGORY.CATEGORY_ID = TB_PROJECT.CATEGORY_ID) NAME FROM TB_PROJECT WHERE CATEGORY_ID = '" + ddlCategory.SelectedValue + "'");
                Response.AddHeader("Content-Disposition", "attachment;filename=สรุปข้อมูลอบรม/สัมมนา/ดูงาน " + name + ".xls");
            }
            else if (ddlCountry.SelectedValue != "")
            {
                string name = DatabaseManager.ExecuteString("SELECT (SELECT COUNTRY_NAME FROM TB_PROJECT_COUNTRY WHERE TB_PROJECT_COUNTRY.COUNTRY_ID = TB_PROJECT.COUNTRY_ID) NAME FROM TB_PROJECT WHERE COUNTRY_ID = '" + ddlCountry.SelectedValue + "'");
                Response.AddHeader("Content-Disposition", "attachment;filename=สรุปข้อมูลอบรม/สัมมนา/ดูงาน " + name + ".xls");
            }
            else if (ddlSubCountry.SelectedValue != "")
            {
                string name = DatabaseManager.ExecuteString("SELECT (SELECT SUB_COUNTRY_NAME FROM TB_PROJECT_COUNTRY_SUB WHERE TB_PROJECT_COUNTRY_SUB.SUB_COUNTRY_ID = TB_PROJECT.SUB_COUNTRY_ID) NAME FROM TB_PROJECT WHERE SUB_COUNTRY_ID = '" + ddlSubCountry.SelectedValue + "'");
                Response.AddHeader("Content-Disposition", "attachment;filename=สรุปข้อมูลอบรม/สัมมนา/ดูงาน " + name + ".xls");
            }
            else if (tbStartDate.Text != "" && tbEndDate.Text != "")
            {
                Response.AddHeader("Content-Disposition", "attachment;filename=สรุปข้อมูลอบรม/สัมมนา/ดูงาน " + tbStartDate.Text + " - " + tbEndDate.Text + ".xls");
            }
            else
            {
                Response.AddHeader("Content-Disposition", "attachment;filename=สรุปข้อมูลอบรม/สัมมนา/ดูงาน.xls");
            }*/

            Response.ContentEncoding = Encoding.UTF8;

            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tw.WriteLine("<html>");
            tw.WriteLine("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />");
            tw.WriteLine("<style>");
            tw.WriteLine("table { border-collapse:collapse; }");
            tw.WriteLine("td { border-collapse:collapse; border: thin solid black; }");
            tw.WriteLine("</style>");

            table.RenderControl(hw);

            tw.WriteLine("</html>");
            Response.Write(tw.ToString());
            Response.End();


        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (tbStartDate.Text != "" && tbEndDate.Text == "")
            {
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbEndDate);
                ChangeNotification("danger", "กรุณากรอกวันที่มีผลบังคับใช้ตามข้อมูล'การเข้าสู่ตำแหน่งปัจจุบัน'ให้ถูกต้อง");
                return;
            }
            else if (tbStartDate.Text == "" && tbEndDate.Text != "")
            {
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbStartDate);
                ChangeNotification("danger", "กรุณากรอกวันที่มีผลบังคับใช้ตามข้อมูล'การเข้าสู่ตำแหน่งปัจจุบัน'ให้ถูกต้อง");
                return;
            }
            else
            {
                ChangeNotification("", "");
            }

            Table table;
            table = BindToTable();
            if (table == null)
            {
                return;
            }

            Panel1.Controls.Clear();
            Panel1.Controls.Add(table);
        }

    }
}