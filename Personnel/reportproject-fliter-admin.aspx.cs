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
    public partial class reportproject_fliter_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
                ddlYear.Items.Insert(0, new ListItem("--กรุณาเลือก", ""));
                for (int i = 2550; i < 2600; ++i)
                {
                    ddlYear.Items.Add(new System.Web.UI.WebControls.ListItem("" + i, "" + i));
                }
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlDepartment, "SELECT * FROM REF_FAC ORDER BY FAC_ID", "FAC_NAME", "FAC_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlCategory, "SELECT * FROM TB_PROJECT_CATEGORY ORDER BY CATEGORY_ID", "CATEGORY_NAME", "CATEGORY_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlCountry, "SELECT * FROM TB_PROJECT_COUNTRY ORDER BY COUNTRY_ID", "COUNTRY_NAME", "COUNTRY_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlSubCountry, "SELECT * FROM TB_PROJECT_COUNTRY_SUB ORDER BY SUB_COUNTRY_ID", "SUB_COUNTRY_NAME", "SUB_COUNTRY_ID", "--กรุณาเลือก--");
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
   
            if(ddlDepartment.SelectedValue == "")
            {
                {
                    TableHeaderRow row = new TableHeaderRow();
                    { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สรุปข้อมูลอบรม/สัมมนา/ดูงาน"; cell.ColumnSpan = 19; row.Cells.Add(cell); }
                    table.Rows.Add(row);
                }
            }
            else
            {
                {
                    string departname = DatabaseManager.ExecuteString("SELECT (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + ddlDepartment.SelectedValue + "'");
                    TableHeaderRow row = new TableHeaderRow();
                    { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สรุปข้อมูลอบรม/สัมมนา/ดูงาน ของ" + departname; cell.ColumnSpan = 19; row.Cells.Add(cell); }
                    table.Rows.Add(row);
                }
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = ""; cell.ColumnSpan = 6; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ประเภท"; cell.ColumnSpan = 5; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ประเภท"; cell.ColumnSpan = 5; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = ""; cell.ColumnSpan = 3; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = ""; cell.ColumnSpan = 6; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ในประเทศ"; cell.ColumnSpan = 5; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ต่างประเทศ"; cell.ColumnSpan = 5; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = ""; cell.ColumnSpan = 3; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลำดับ"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ชื่อ-สกุล"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วุฒิการศึกษา"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ตำแหน่งทางวิชาการ"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "จำนวน"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "เรื่อง"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "อบรม"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ประชุม"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สัมมนา"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ดูงาน"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "อื่นๆ"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "อบรม"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ประชุม"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สัมมนา"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ดูงาน"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "อื่นๆ"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สถานที่"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วัน/เดือน/ปี ที่เข้าร่วม"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "จำนวนเงินที่ใช้ในการ"; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }
            List<string> PRO_ID = new List<string>();
            List<string> UOC_ID = new List<string>();
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string sql;
                string where = "";
                if (ddlYear.SelectedValue != "")
                {
                    where += " AND EXTRACT(YEAR FROM START_DATE) = '" + ddlYear.SelectedValue + "'-543";
                }
                if (ddlDepartment.SelectedValue != "")
                {
                    where += " AND DEPARTMENT_ID = '" + ddlDepartment.SelectedValue + "'";
                }
                if (ddlCategory.SelectedValue != "")
                {
                    where += " AND CATEGORY_ID = '" + ddlCategory.SelectedValue + "'";
                }
                if (ddlCountry.SelectedValue != "")
                {
                    where += " AND COUNTRY_ID = '" + ddlCountry.SelectedValue + "'";
                }
                if (ddlSubCountry.SelectedValue != "")
                {
                    where += " AND SUB_COUNTRY_ID = '" + ddlSubCountry.SelectedValue + "'";
                }
                if (tbStartDate.Text != "" && tbEndDate.Text != "")
                {
                    where += " AND START_DATE >= TO_DATE('" + tbStartDate.Text + "', 'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') AND END_DATE <= TO_DATE('" + tbEndDate.Text + "', 'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI')";
                }

                using (OracleCommand com = new OracleCommand("SELECT TB_PROJECT.PRO_ID,TB_PROJECT.UOC_ID,TB_PROJECT.CATEGORY_ID FROM TB_PROJECT,UOC_STAFF WHERE TB_PROJECT.UOC_ID = UOC_STAFF.UOC_ID" + where, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PRO_ID.Add(reader.GetInt32(0).ToString());
                            UOC_ID.Add(reader.GetInt32(1).ToString());
                        }
                    }
                }

                for (int i = 0; i < PRO_ID.Count; i++)
                {
                    string pro_id = PRO_ID[i];
                    string uoc_id = UOC_ID[i];
                    TableRow row = new TableRow();
                    {
                        TableCell cell = new TableCell();
                        cell.Text = "" + (i + 1);
                        row.Cells.Add(cell);
                    }
                    {
                        TableCell cell = new TableCell();
                        using (OracleCommand com = new OracleCommand("SELECT STF_FNAME || ' ' || STF_LNAME NAME FROM UOC_STAFF WHERE UOC_ID = '" + uoc_id + "'", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cell.Text = reader.GetString(0);
                                }
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    {
                        TableCell cell = new TableCell();
                        using (OracleCommand com = new OracleCommand("SELECT GRAD_CURR FROM UOC_STAFF WHERE UOC_ID = '" + uoc_id + "'", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cell.Text = reader.GetString(0);
                                }
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    {
                        TableCell cell = new TableCell();
                        using (OracleCommand com = new OracleCommand("SELECT (SELECT POSITION_NAME_TH FROM REF_POSITION WHERE REF_POSITION.POSITION_ID = UOC_STAFF.POSITION_ID) POSITION_NAME FROM UOC_STAFF WHERE UOC_ID = '" + uoc_id + "'", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cell.Text = reader.GetString(0);
                                }
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    {
                        TableCell cell = new TableCell();
                        using (OracleCommand com = new OracleCommand("SELECT COUNT(CASE WHEN UOC_ID = '" + uoc_id + "' THEN 1 END) FROM TB_PROJECT", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                int a = 1;
                                while (reader.Read())
                                {
                                    cell.Text = reader.GetInt32(0).ToString();
                                    //cell.Text = a.ToString(); a++;
                                }
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    {
                        TableCell cell = new TableCell();
                        using (OracleCommand com = new OracleCommand("SELECT PROJECT_NAME FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "'", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cell.Text = reader.GetString(0);
                                }
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    {
                        using (OracleCommand com = new OracleCommand(
                            "SELECT" +
                            " (SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 1 AND SUB_COUNTRY_ID = 1)" +
                            ",(SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 1 AND SUB_COUNTRY_ID = 2)" +
                            ",(SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 1 AND SUB_COUNTRY_ID = 3)" +
                            ",(SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 1 AND SUB_COUNTRY_ID = 4)" +
                            ",(SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 1 AND SUB_COUNTRY_ID = 5)" +
                            " FROM DUAL",
                            con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    TableCell cell;
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell);
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell);
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell);
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell);
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell);
                                }
                            }
                        }
                    }
                    {
                        using (OracleCommand com = new OracleCommand(
                            "SELECT" +
                            " (SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 2 AND SUB_COUNTRY_ID = 1)" +
                            ",(SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 2 AND SUB_COUNTRY_ID = 2)" +
                            ",(SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 2 AND SUB_COUNTRY_ID = 3)" +
                            ",(SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 2 AND SUB_COUNTRY_ID = 4)" +
                            ",(SELECT NVL(COUNT(PRO_ID),0) FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "' AND UOC_ID = '" + uoc_id + "' AND COUNTRY_ID = 2 AND SUB_COUNTRY_ID = 5)" +
                            " FROM DUAL",
                            con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    TableCell cell;
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell);
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell);
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell);
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell);
                                    cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell);
                                }
                            }
                        }
                    }
                    {
                        TableCell cell = new TableCell();
                        using (OracleCommand com = new OracleCommand("SELECT ADDRESS_PROJECT FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "'", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cell.Text = reader.GetString(0);
                                }
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    {
                        TableCell cell = new TableCell();
                        using (OracleCommand com = new OracleCommand("SELECT START_DATE,END_DATE FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "'", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cell.Text = reader.GetDateTime(0).ToString("dd/MM/yyyy") + " - " + reader.GetDateTime(1).ToString("dd/MM/yyyy");
                                }
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    {
                        TableCell cell = new TableCell();
                        using (OracleCommand com = new OracleCommand("SELECT EXPENSES FROM TB_PROJECT WHERE PRO_ID = '" + pro_id + "'", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cell.Text = reader.GetInt32(0).ToString("#,###");
                                }
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    table.Rows.Add(row);
                }

            }

            if (PRO_ID.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
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

            if(ddlYear.SelectedValue != "")
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
            }
            
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
            if(tbStartDate.Text != "" && tbEndDate.Text == "")
            {
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbEndDate);
                ChangeNotification("danger", "กรุณากรอกวันที่เข้าร่วม - วันสิ้นสุดโครงการให้ถูกต้อง");
                return;
            }
            else if(tbStartDate.Text == "" && tbEndDate.Text != "")
            {
                ScriptManager.GetCurrent(this.Page).SetFocus(this.tbStartDate);
                ChangeNotification("danger", "กรุณากรอกวันที่เข้าร่วม - วันสิ้นสุดโครงการให้ถูกต้อง");
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