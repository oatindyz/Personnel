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
    public partial class ReportAcademic_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlView.Items.Add(new ListItem("แสดงจำนวนบุคลารสายวิชาการ จำแนกตามประเภทบุคลากร คณะ และตำแหน่งทางวิชาการ", "1"));
                ddlView.Items.Add(new ListItem("แสดงจำนวนบุคลารสายวิชาการ จำแนกตามประเภทบุคลากร คณะ และวุฒิการศึกษา", "2"));
            }

            //Bindจำนวนบุคลารสายวิชาการจำแนกตามประเภทบุคลากรคณะและวุฒิการศึกษา();
            if (ddlView.SelectedValue == "1")
            {
                Bindจำนวนบุคลารสายวิชาการจำแนกตามประเภทบุคลากรคณะและตำแหน่งทางวิชาการ();
            }
            else if (ddlView.SelectedValue == "2")
            {
                Bindจำนวนบุคลารสายวิชาการจำแนกตามประเภทบุคลากรคณะและวุฒิการศึกษา();
            }
        }

        private Table Bindจำนวนบุคลารสายวิชาการจำแนกตามประเภทบุคลากรคณะและตำแหน่งทางวิชาการ()
        {
            Table table = new Table();
            table.CssClass = "ps-table-1";

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สรุปข้อมูลจำนวนบุคลากรสายวิชาการ จำแนกตามประเภทบุคลากร คณะ และตำแหน่งทางวิชาการ ปี 2559 (ข้อมูล ณ เดือนพฤศจิกายน 2559)"; cell.Style["text-align"] = "center"; cell.ColumnSpan = 26; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "คณะ"; cell.RowSpan = 2; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ข้าราชการพลเรือน"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "พนักงานในสถาบันฯ"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "พนักงานราชการ"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลูกจ้างชั่วคราว"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวมทั้งสิ้น"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ผศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "อ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ผศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "อ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ผศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "อ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ผศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "อ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ผศ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "อ."; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }

            //0วิทยาเขตบางพระ
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วิทยาเขตบางพระ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //บางพระข้าราชการ
                                if (reader.GetInt32(0) != 0) { { Session["วิทยาเขตบางพระ0"] = reader.GetInt32(0); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { Session["วิทยาเขตบางพระ1"] = reader.GetInt32(1); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { Session["วิทยาเขตบางพระ2"] = reader.GetInt32(2); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { Session["วิทยาเขตบางพระ3"] = reader.GetInt32(3); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { Session["วิทยาเขตบางพระ4"] = reader.GetInt32(4); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { Session["วิทยาเขตบางพระ5"] = reader.GetInt32(5); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { Session["วิทยาเขตบางพระ6"] = reader.GetInt32(6); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { Session["วิทยาเขตบางพระ7"] = reader.GetInt32(7); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { Session["วิทยาเขตบางพระ8"] = reader.GetInt32(8); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { Session["วิทยาเขตบางพระ9"] = reader.GetInt32(9); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { Session["วิทยาเขตบางพระ10"] = reader.GetInt32(10); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { Session["วิทยาเขตบางพระ11"] = reader.GetInt32(11); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { Session["วิทยาเขตบางพระ12"] = reader.GetInt32(12); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { Session["วิทยาเขตบางพระ13"] = reader.GetInt32(13); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { Session["วิทยาเขตบางพระ14"] = reader.GetInt32(14); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { Session["วิทยาเขตบางพระ15"] = reader.GetInt32(15); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { Session["วิทยาเขตบางพระ16"] = reader.GetInt32(16); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { Session["วิทยาเขตบางพระ17"] = reader.GetInt32(17); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { Session["วิทยาเขตบางพระ18"] = reader.GetInt32(18); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { Session["วิทยาเขตบางพระ19"] = reader.GetInt32(19); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { Session["วิทยาเขตบางพระ20"] = reader.GetInt32(20); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { Session["วิทยาเขตบางพระ21"] = reader.GetInt32(21); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { Session["วิทยาเขตบางพระ22"] = reader.GetInt32(22); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { Session["วิทยาเขตบางพระ23"] = reader.GetInt32(23); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { Session["วิทยาเขตบางพระ24"] = reader.GetInt32(24); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //1คณะเกษตรศาสตร์และทรัพยากรธรรมชาติ
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะเกษตรศาสตร์และทรัพยากรธรรมชาติ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //บางพระคณะเกษตรศาสตร์และทรัพยากรธรรมชาติข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะเกษตรศาสตร์และทรัพยากรธรรมชาติพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะเกษตรศาสตร์และทรัพยากรธรรมชาติพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะเกษตรศาสตร์และทรัพยากรธรรมชาติลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะเกษตรศาสตร์และทรัพยากรธรรมชาติรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //2คณะวิทยาศาสตร์และเทคโนโลยี
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะวิทยาศาสตร์และเทคโนโลยี"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //บางพระคณะวิทยาศาสตร์และเทคโนโลยีข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะวิทยาศาสตร์และเทคโนโลยีพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะวิทยาศาสตร์และเทคโนโลยีพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะวิทยาศาสตร์และเทคโนโลยีลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะวิทยาศาสตร์และเทคโนโลยีรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //3คณะมนุษยศาสตร์และสังคมศาสตร์
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะมนุษยศาสตร์และสังคมศาสตร์"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //บางพระคณะมนุษยศาสตร์และสังคมศาสตร์ข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะมนุษยศาสตร์และสังคมศาสตร์พนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะมนุษยศาสตร์และสังคมศาสตร์พนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะมนุษยศาสตร์และสังคมศาสตร์ลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะมนุษยศาสตร์และสังคมศาสตร์รวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //4คณะสัตวแพทยศาสตร์
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะสัตวแพทยศาสตร์"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //บางพระคณะสัตวแพทยศาสตร์ข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะสัตวแพทยศาสตร์พนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะสัตวแพทยศาสตร์พนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะสัตวแพทยศาสตร์ลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระคณะสัตวแพทยศาสตร์รวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //5สถาบันเทคโนโลยีการบิน
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "สถาบันเทคโนโลยีการบิน"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //บางพระสถาบันเทคโนโลยีการบินข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระสถาบันเทคโนโลยีการบินพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระสถาบันเทคโนโลยีการบินพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระสถาบันเทคโนโลยีการบินลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //บางพระสถาบันเทคโนโลยีการบินรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //6วิทยาเขตจันทบุรี
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วิทยาเขตจันทบุรี"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //จันทบุรีข้าราชการ
                                if (reader.GetInt32(0) != 0) { { Session["วิทยาเขตจันทบุรี0"] = reader.GetInt32(0); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { Session["วิทยาเขตจันทบุรี1"] = reader.GetInt32(1); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { Session["วิทยาเขตจันทบุรี2"] = reader.GetInt32(2); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { Session["วิทยาเขตจันทบุรี3"] = reader.GetInt32(3); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { Session["วิทยาเขตจันทบุรี4"] = reader.GetInt32(4); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { Session["วิทยาเขตจันทบุรี5"] = reader.GetInt32(5); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { Session["วิทยาเขตจันทบุรี6"] = reader.GetInt32(6); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { Session["วิทยาเขตจันทบุรี7"] = reader.GetInt32(7); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { Session["วิทยาเขตจันทบุรี8"] = reader.GetInt32(8); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { Session["วิทยาเขตจันทบุรี9"] = reader.GetInt32(9); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { Session["วิทยาเขตจันทบุรี10"] = reader.GetInt32(10); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { Session["วิทยาเขตจันทบุรี11"] = reader.GetInt32(11); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { Session["วิทยาเขตจันทบุรี12"] = reader.GetInt32(12); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { Session["วิทยาเขตจันทบุรี13"] = reader.GetInt32(13); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { Session["วิทยาเขตจันทบุรี14"] = reader.GetInt32(14); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { Session["วิทยาเขตจันทบุรี15"] = reader.GetInt32(15); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { Session["วิทยาเขตจันทบุรี16"] = reader.GetInt32(16); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { Session["วิทยาเขตจันทบุรี17"] = reader.GetInt32(17); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { Session["วิทยาเขตจันทบุรี18"] = reader.GetInt32(18); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { Session["วิทยาเขตจันทบุรี19"] = reader.GetInt32(19); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { Session["วิทยาเขตจันทบุรี20"] = reader.GetInt32(20); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { Session["วิทยาเขตจันทบุรี21"] = reader.GetInt32(21); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { Session["วิทยาเขตจันทบุรี22"] = reader.GetInt32(22); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { Session["วิทยาเขตจันทบุรี23"] = reader.GetInt32(23); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { Session["วิทยาเขตจันทบุรี24"] = reader.GetInt32(24); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //7คณะเทคโนโลยีอุตสาหกรรมการเกษตร
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะเทคโนโลยีอุตสาหกรรมการเกษตร"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //จันทบุรีคณะเทคโนโลยีอุตสาหกรรมการเกษตรข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีคณะเทคโนโลยีอุตสาหกรรมการเกษตรพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีคณะเทคโนโลยีอุตสาหกรรมการเกษตรพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีคณะเทคโนโลยีอุตสาหกรรมการเกษตรลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีคณะเทคโนโลยีอุตสาหกรรมการเกษตรรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //8คณะเทคโนโลยีสังคม
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะเทคโนโลยีสังคม"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //จันทบุรีคณะเทคโนโลยีสังคมข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีคณะเทคโนโลยีสังคมพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีคณะเทคโนโลยีสังคมพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีคณะเทคโนโลยีสังคมลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จันทบุรีคณะเทคโนโลยีสังคมรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //9วิทยาเขตจักรพงษภูวนารถ
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วิทยาเขตจักรพงษภูวนารถ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //จักรพงษภูวนารถข้าราชการ
                                if (reader.GetInt32(0) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ0"] = reader.GetInt32(0); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ1"] = reader.GetInt32(1); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ2"] = reader.GetInt32(2); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ3"] = reader.GetInt32(3); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ4"] = reader.GetInt32(4); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ5"] = reader.GetInt32(5); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ6"] = reader.GetInt32(6); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ7"] = reader.GetInt32(7); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ8"] = reader.GetInt32(8); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ9"] = reader.GetInt32(9); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ10"] = reader.GetInt32(10); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ11"] = reader.GetInt32(11); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ12"] = reader.GetInt32(12); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ13"] = reader.GetInt32(13); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ14"] = reader.GetInt32(14); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ15"] = reader.GetInt32(15); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ16"] = reader.GetInt32(16); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ17"] = reader.GetInt32(17); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ18"] = reader.GetInt32(18); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ19"] = reader.GetInt32(19); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ20"] = reader.GetInt32(20); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ21"] = reader.GetInt32(21); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ22"] = reader.GetInt32(22); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ23"] = reader.GetInt32(23); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { Session["วิทยาเขตจักรพงษภูวนารถ24"] = reader.GetInt32(24); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //10คณะบริหารธุรกิจและเทคโนโลยีสารสนเทศ
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะบริหารธุรกิจและเทคโนโลยีสารสนเทศ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //จักรพงษภูวนารถคณะบริหารธุรกิจและเทคโนโลยีสารสนเทศข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถคณะบริหารธุรกิจและเทคโนโลยีสารสนเทศพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถคณะบริหารธุรกิจและเทคโนโลยีสารสนเทศพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถคณะบริหารธุรกิจและเทคโนโลยีสารสนเทศลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถคณะบริหารธุรกิจและเทคโนโลยีสารสนเทศรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //11คณะศิลปศาสตร์
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะบริหารธุรกิจและเทคโนโลยีสารสนเทศ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //จักรพงษภูวนารถคณะศิลปศาสตร์ข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถคณะศิลปศาสตร์พนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถคณะศิลปศาสตร์พนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถคณะศิลปศาสตร์ลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //จักรพงษภูวนารถคณะศิลปศาสตร์รวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //12วิทยาเขตอุเทนถวาย
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วิทยาเขตอุเทนถวาย"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //วิทยาเขตอุเทนถวายข้าราชการ
                                if (reader.GetInt32(0) != 0) { { Session["วิทยาเขตอุเทนถวาย0"] = reader.GetInt32(0); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { Session["วิทยาเขตอุเทนถวาย1"] = reader.GetInt32(1); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { Session["วิทยาเขตอุเทนถวาย2"] = reader.GetInt32(2); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { Session["วิทยาเขตอุเทนถวาย3"] = reader.GetInt32(3); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { Session["วิทยาเขตอุเทนถวาย4"] = reader.GetInt32(4); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //วิทยาเขตอุเทนถวายพนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { Session["วิทยาเขตอุเทนถวาย5"] = reader.GetInt32(5); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { Session["วิทยาเขตอุเทนถวาย6"] = reader.GetInt32(6); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { Session["วิทยาเขตอุเทนถวาย7"] = reader.GetInt32(7); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { Session["วิทยาเขตอุเทนถวาย8"] = reader.GetInt32(8); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { Session["วิทยาเขตอุเทนถวาย9"] = reader.GetInt32(9); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //วิทยาเขตอุเทนถวายพนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { Session["วิทยาเขตอุเทนถวาย10"] = reader.GetInt32(10); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { Session["วิทยาเขตอุเทนถวาย11"] = reader.GetInt32(11); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { Session["วิทยาเขตอุเทนถวาย12"] = reader.GetInt32(12); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { Session["วิทยาเขตอุเทนถวาย13"] = reader.GetInt32(13); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { Session["วิทยาเขตอุเทนถวาย14"] = reader.GetInt32(14); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //วิทยาเขตอุเทนถวายลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { Session["วิทยาเขตอุเทนถวาย15"] = reader.GetInt32(15); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { Session["วิทยาเขตอุเทนถวาย16"] = reader.GetInt32(16); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { Session["วิทยาเขตอุเทนถวาย17"] = reader.GetInt32(17); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { Session["วิทยาเขตอุเทนถวาย18"] = reader.GetInt32(18); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { Session["วิทยาเขตอุเทนถวาย19"] = reader.GetInt32(19); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //วิทยาเขตอุเทนถวายรวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { Session["วิทยาเขตอุเทนถวาย20"] = reader.GetInt32(20); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { Session["วิทยาเขตอุเทนถวาย21"] = reader.GetInt32(21); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { Session["วิทยาเขตอุเทนถวาย22"] = reader.GetInt32(22); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { Session["วิทยาเขตอุเทนถวาย23"] = reader.GetInt32(23); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { Session["วิทยาเขตอุเทนถวาย24"] = reader.GetInt32(24); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //13คณะวิศวกรรมศาสตร์และสถาปัตยกรรมศาสตร์
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะวิศวกรรมศาสตร์และสถาปัตยกรรมศาสตร์"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //อุเทนถวายคณะวิศวกรรมศาสตร์และสถาปัตยกรรมศาสตร์ข้าราชการ
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //อุเทนถวายคณะวิศวกรรมศาสตร์และสถาปัตยกรรมศาสตร์พนักงานในสถาบัน
                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //อุเทนถวายคณะวิศวกรรมศาสตร์และสถาปัตยกรรมศาสตร์พนักงานราชการ
                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //อุเทนถวายคณะวิศวกรรมศาสตร์และสถาปัตยกรรมศาสตร์ลูกจ้างชั่วคราว
                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                //อุเทนถวายคณะวิศวกรรมศาสตร์และสถาปัตยกรรมศาสตร์รวมทั้งสิ้น
                                if (reader.GetInt32(20) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(20); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(21) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(21); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(22) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(22); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(23) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(23); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(24) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(24); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //14รวมทั้งสิ้น
            {
                int total0 = ((int?)Session["วิทยาเขตบางพระ0"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี0"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ0"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย0"] ?? 0);
                int total1 = ((int?)Session["วิทยาเขตบางพระ1"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี1"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ1"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย1"] ?? 0);
                int total2 = ((int?)Session["วิทยาเขตบางพระ2"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี2"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ2"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย2"] ?? 0);
                int total3 = ((int?)Session["วิทยาเขตบางพระ3"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี3"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ3"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย3"] ?? 0);
                int total4 = ((int?)Session["วิทยาเขตบางพระ4"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี4"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ4"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย4"] ?? 0);
                int total5 = ((int?)Session["วิทยาเขตบางพระ5"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี5"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ5"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย5"] ?? 0);
                int total6 = ((int?)Session["วิทยาเขตบางพระ6"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี6"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ6"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย6"] ?? 0);
                int total7 = ((int?)Session["วิทยาเขตบางพระ7"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี7"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ7"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย7"] ?? 0);
                int total8 = ((int?)Session["วิทยาเขตบางพระ8"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี8"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ8"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย8"] ?? 0);
                int total9 = ((int?)Session["วิทยาเขตบางพระ9"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี9"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ9"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย9"] ?? 0);
                int total10 = ((int?)Session["วิทยาเขตบางพระ10"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี10"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ10"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย10"] ?? 0);
                int total11 = ((int?)Session["วิทยาเขตบางพระ11"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี11"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ11"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย11"] ?? 0);
                int total12 = ((int?)Session["วิทยาเขตบางพระ12"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี12"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ12"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย12"] ?? 0);
                int total13 = ((int?)Session["วิทยาเขตบางพระ13"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี13"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ13"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย13"] ?? 0);
                int total14 = ((int?)Session["วิทยาเขตบางพระ14"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี14"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ14"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย14"] ?? 0);
                int total15 = ((int?)Session["วิทยาเขตบางพระ15"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี15"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ15"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย15"] ?? 0);
                int total16 = ((int?)Session["วิทยาเขตบางพระ16"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี16"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ16"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย16"] ?? 0);
                int total17 = ((int?)Session["วิทยาเขตบางพระ17"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี17"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ17"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย17"] ?? 0);
                int total18 = ((int?)Session["วิทยาเขตบางพระ18"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี18"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ18"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย18"] ?? 0);
                int total19 = ((int?)Session["วิทยาเขตบางพระ19"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี19"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ19"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย19"] ?? 0);
                int total20 = ((int?)Session["วิทยาเขตบางพระ20"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี20"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ20"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย20"] ?? 0);
                int total21 = ((int?)Session["วิทยาเขตบางพระ21"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี21"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ21"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย21"] ?? 0);
                int total22 = ((int?)Session["วิทยาเขตบางพระ22"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี22"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ22"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย22"] ?? 0);
                int total23 = ((int?)Session["วิทยาเขตบางพระ23"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี23"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ23"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย23"] ?? 0);
                int total24 = ((int?)Session["วิทยาเขตบางพระ24"] ?? 0) + ((int?)Session["วิทยาเขตจันทบุรี24"] ?? 0) + ((int?)Session["วิทยาเขตจักรพงษภูวนารถ24"] ?? 0) + ((int?)Session["วิทยาเขตอุเทนถวาย24"] ?? 0);

                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวมทั้งสิ้น"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total0 ; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total1 ; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total2; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total3; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total4; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total6; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total7; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total8; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total9; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total10; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total11; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total12; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total13; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total14; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total15; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total16; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total17; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total18; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total19; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total20; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total21; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total22; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total23; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total24; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                table.Rows.Add(row);
            }

            Panel1.Controls.Clear();
            Panel1.Controls.Add(table);
            return table;
        }

        private Table Bindจำนวนบุคลารสายวิชาการจำแนกตามประเภทบุคลากรคณะและวุฒิการศึกษา()
        {
            Table table = new Table();
            table.CssClass = "ps-table-1";

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สรุปข้อมูลจำนวนบุคลากรสายวิชาการ จำแนกตามประเภทบุคลากร คณะ และวุฒิการศึกษา ปี 2559 (ข้อมูล ณ เดือนพฤศจิกายน 2559)"; cell.Style["text-align"] = "center"; cell.ColumnSpan = 21; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "คณะ"; cell.RowSpan = 2; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ข้าราชการพลเรือน"; cell.ColumnSpan = 4; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "พนักงานในสถาบันฯ"; cell.ColumnSpan = 4; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "พนักงานราชการ"; cell.ColumnSpan = 4; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลูกจ้างชั่วคราว"; cell.ColumnSpan = 4; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวมทั้งสิ้น"; cell.ColumnSpan = 4; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.เอก"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.โท"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.ตรี"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.เอก"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.โท"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.ตรี"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.เอก"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.โท"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.ตรี"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.เอก"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.โท"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.ตรี"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.เอก"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.โท"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ป.ตรี"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวม"; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                table.Rows.Add(row);
            }
            //0วิทยาเขตบางพระ
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วิทยาเขตบางพระ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID IN('00005','00083','00064','00112','01624') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { Session["1วิทยาเขตบางพระ0"] = reader.GetInt32(0); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { Session["1วิทยาเขตบางพระ1"] = reader.GetInt32(1); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { Session["1วิทยาเขตบางพระ2"] = reader.GetInt32(2); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { Session["1วิทยาเขตบางพระ3"] = reader.GetInt32(3); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { Session["1วิทยาเขตบางพระ4"] = reader.GetInt32(4); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { Session["1วิทยาเขตบางพระ5"] = reader.GetInt32(5); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { Session["1วิทยาเขตบางพระ6"] = reader.GetInt32(6); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { Session["1วิทยาเขตบางพระ7"] = reader.GetInt32(7); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { Session["1วิทยาเขตบางพระ8"] = reader.GetInt32(8); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { Session["1วิทยาเขตบางพระ9"] = reader.GetInt32(9); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { Session["1วิทยาเขตบางพระ10"] = reader.GetInt32(10); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { Session["1วิทยาเขตบางพระ11"] = reader.GetInt32(11); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { Session["1วิทยาเขตบางพระ12"] = reader.GetInt32(12); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { Session["1วิทยาเขตบางพระ13"] = reader.GetInt32(13); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { Session["1วิทยาเขตบางพระ14"] = reader.GetInt32(14); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { Session["1วิทยาเขตบางพระ15"] = reader.GetInt32(15); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { Session["1วิทยาเขตบางพระ16"] = reader.GetInt32(16); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { Session["1วิทยาเขตบางพระ17"] = reader.GetInt32(17); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { Session["1วิทยาเขตบางพระ18"] = reader.GetInt32(18); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { Session["1วิทยาเขตบางพระ19"] = reader.GetInt32(19); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }

            //1คณะเกษตรศาสตร์และทรัพยากรธรรมชาติ
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะเกษตรศาสตร์และทรัพยากรธรรมชาติ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00005' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //2คณะวิทยาศาสตร์และเทคโนโลยี
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะวิทยาศาสตร์และเทคโนโลยี"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00083' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //3คณะมนุษยศาสตร์และสังคมศาสตร์
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะมนุษยศาสตร์และสังคมศาสตร์"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00064' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //4คณะสัตวแพทยศาสตร์
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะสัตวแพทยศาสตร์"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '00112' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //5สถาบันเทคโนโลยีการบิน
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "สถาบันเทคโนโลยีการบิน"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19303' AND DEPARTMENT_ID = '01624' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //6วิทยาเขตจันทบุรี
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วิทยาเขตจันทบุรี"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID IN('01128','00827') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { Session["1วิทยาเขตจันทบุรี0"] = reader.GetInt32(0); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { Session["1วิทยาเขตจันทบุรี1"] = reader.GetInt32(1); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { Session["1วิทยาเขตจันทบุรี2"] = reader.GetInt32(2); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { Session["1วิทยาเขตจันทบุรี3"] = reader.GetInt32(3); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { Session["1วิทยาเขตจันทบุรี4"] = reader.GetInt32(4); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { Session["1วิทยาเขตจันทบุรี5"] = reader.GetInt32(5); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { Session["1วิทยาเขตจันทบุรี6"] = reader.GetInt32(6); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { Session["1วิทยาเขตจันทบุรี7"] = reader.GetInt32(7); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { Session["1วิทยาเขตจันทบุรี8"] = reader.GetInt32(8); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { Session["1วิทยาเขตจันทบุรี9"] = reader.GetInt32(9); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { Session["1วิทยาเขตจันทบุรี10"] = reader.GetInt32(10); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { Session["1วิทยาเขตจันทบุรี11"] = reader.GetInt32(11); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { Session["1วิทยาเขตจันทบุรี12"] = reader.GetInt32(12); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { Session["1วิทยาเขตจันทบุรี13"] = reader.GetInt32(13); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { Session["1วิทยาเขตจันทบุรี14"] = reader.GetInt32(14); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { Session["1วิทยาเขตจันทบุรี15"] = reader.GetInt32(15); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { Session["1วิทยาเขตจันทบุรี16"] = reader.GetInt32(16); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { Session["1วิทยาเขตจันทบุรี17"] = reader.GetInt32(17); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { Session["1วิทยาเขตจันทบุรี18"] = reader.GetInt32(18); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { Session["1วิทยาเขตจันทบุรี19"] = reader.GetInt32(19); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //7คณะเทคโนโลยีอุตสาหกรรมการเกษตร
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะเทคโนโลยีอุตสาหกรรมการเกษตร"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '01128' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //8คณะเทคโนโลยีสังคม
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะเทคโนโลยีสังคม"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19304' AND DEPARTMENT_ID = '00827' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //9วิทยาเขตจักรพงษภูวนารถ
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วิทยาเขตจักรพงษภูวนารถ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID IN('00474','00096') AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ0"] = reader.GetInt32(0); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ1"] = reader.GetInt32(1); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ2"] = reader.GetInt32(2); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ3"] = reader.GetInt32(3); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ4"] = reader.GetInt32(4); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ5"] = reader.GetInt32(5); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ6"] = reader.GetInt32(6); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ7"] = reader.GetInt32(7); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ8"] = reader.GetInt32(8); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ9"] = reader.GetInt32(9); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ10"] = reader.GetInt32(10); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ11"] = reader.GetInt32(11); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ12"] = reader.GetInt32(12); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ13"] = reader.GetInt32(13); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ14"] = reader.GetInt32(14); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ15"] = reader.GetInt32(15); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ16"] = reader.GetInt32(16); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ17"] = reader.GetInt32(17); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ18"] = reader.GetInt32(18); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { Session["1วิทยาเขตจักรพงษภูวนารถ19"] = reader.GetInt32(19); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //10คณะบริหารธุรกิจและเทคโนโลยีสารสนเทศ
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะบริหารธุรกิจและเทคโนโลยีสารสนเทศ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00474' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //11คณะศิลปศาสตร์
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะบริหารธุรกิจและเทคโนโลยีสารสนเทศ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19301' AND DEPARTMENT_ID = '00096' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //12วิทยาเขตอุเทนถวาย
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วิทยาเขตอุเทนถวาย"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { Session["1วิทยาเขตอุเทนถวาย0"] = reader.GetInt32(0); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { Session["1วิทยาเขตอุเทนถวาย1"] = reader.GetInt32(1); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { Session["1วิทยาเขตอุเทนถวาย2"] = reader.GetInt32(2); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { Session["1วิทยาเขตอุเทนถวาย3"] = reader.GetInt32(3); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { Session["1วิทยาเขตอุเทนถวาย4"] = reader.GetInt32(4); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { Session["1วิทยาเขตอุเทนถวาย5"] = reader.GetInt32(5); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { Session["1วิทยาเขตอุเทนถวาย6"] = reader.GetInt32(6); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { Session["1วิทยาเขตอุเทนถวาย7"] = reader.GetInt32(7); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { Session["1วิทยาเขตอุเทนถวาย8"] = reader.GetInt32(8); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { Session["1วิทยาเขตอุเทนถวาย9"] = reader.GetInt32(9); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { Session["1วิทยาเขตอุเทนถวาย10"] = reader.GetInt32(10); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { Session["1วิทยาเขตอุเทนถวาย11"] = reader.GetInt32(11); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { Session["1วิทยาเขตอุเทนถวาย12"] = reader.GetInt32(12); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { Session["1วิทยาเขตอุเทนถวาย13"] = reader.GetInt32(13); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { Session["1วิทยาเขตอุเทนถวาย14"] = reader.GetInt32(14); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { Session["1วิทยาเขตอุเทนถวาย15"] = reader.GetInt32(15); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { Session["1วิทยาเขตอุเทนถวาย16"] = reader.GetInt32(16); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { Session["1วิทยาเขตอุเทนถวาย17"] = reader.GetInt32(17); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { Session["1วิทยาเขตอุเทนถวาย18"] = reader.GetInt32(18); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { Session["1วิทยาเขตอุเทนถวาย19"] = reader.GetInt32(19); TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //13คณะวิศวกรรมศาสตร์และสถาปัตยกรรมศาสตร์
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableCell cell = new TableCell(); cell.Text = "คณะวิศวกรรมศาสตร์และสถาปัตยกรรมศาสตร์"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand(
                    "SELECT" +
                    " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '1' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '2' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '5' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID = '4' AND GRAD_LEV_ID IN('80','60','40'))" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '80')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '60')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID = '40')" +
                    ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '19302' AND DEPARTMENT_ID = '00475' AND STAFFTYPE_ID IN('1','2','5','4') AND GRAD_LEV_ID IN('80','60','40'))" +
                    " FROM DUAL", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32(0) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(0); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(1) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(1); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(2) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(2); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(3) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(3); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(4) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(4); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(5) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(5); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(6) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(6); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(7) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(7); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(8) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(8); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(9) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(9); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(10) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(10); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(11) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(11); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(12) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(12); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(13) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(13); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(14) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(14); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }

                                if (reader.GetInt32(15) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(15); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(16) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(16); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(17) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(17); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(18) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(18); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                                if (reader.GetInt32(19) != 0) { { TableCell cell = new TableCell(); cell.Text = "" + reader.GetInt32(19); row.Cells.Add(cell); } } else { TableCell cell = new TableCell(); cell.Text = "-"; row.Cells.Add(cell); }
                            }
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            //14รวมทั้งสิ้น
            {
                int total0 = ((int?)Session["1วิทยาเขตบางพระ0"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี0"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ0"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย0"] ?? 0);
                int total1 = ((int?)Session["1วิทยาเขตบางพระ1"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี1"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ1"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย1"] ?? 0);
                int total2 = ((int?)Session["1วิทยาเขตบางพระ2"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี2"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ2"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย2"] ?? 0);
                int total3 = ((int?)Session["1วิทยาเขตบางพระ3"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี3"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ3"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย3"] ?? 0);
                int total4 = ((int?)Session["1วิทยาเขตบางพระ4"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี4"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ4"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย4"] ?? 0);
                int total5 = ((int?)Session["1วิทยาเขตบางพระ5"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี5"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ5"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย5"] ?? 0);
                int total6 = ((int?)Session["1วิทยาเขตบางพระ6"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี6"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ6"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย6"] ?? 0);
                int total7 = ((int?)Session["1วิทยาเขตบางพระ7"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี7"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ7"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย7"] ?? 0);
                int total8 = ((int?)Session["1วิทยาเขตบางพระ8"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี8"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ8"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย8"] ?? 0);
                int total9 = ((int?)Session["1วิทยาเขตบางพระ9"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี9"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ9"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย9"] ?? 0);
                int total10 = ((int?)Session["1วิทยาเขตบางพระ10"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี10"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ10"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย10"] ?? 0);
                int total11 = ((int?)Session["1วิทยาเขตบางพระ11"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี11"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ11"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย11"] ?? 0);
                int total12 = ((int?)Session["1วิทยาเขตบางพระ12"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี12"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ12"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย12"] ?? 0);
                int total13 = ((int?)Session["1วิทยาเขตบางพระ13"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี13"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ13"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย13"] ?? 0);
                int total14 = ((int?)Session["1วิทยาเขตบางพระ14"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี14"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ14"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย14"] ?? 0);
                int total15 = ((int?)Session["1วิทยาเขตบางพระ15"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี15"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ15"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย15"] ?? 0);
                int total16 = ((int?)Session["1วิทยาเขตบางพระ16"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี16"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ16"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย16"] ?? 0);
                int total17 = ((int?)Session["1วิทยาเขตบางพระ17"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี17"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ17"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย17"] ?? 0);
                int total18 = ((int?)Session["1วิทยาเขตบางพระ18"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี18"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ18"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย18"] ?? 0);
                int total19 = ((int?)Session["1วิทยาเขตบางพระ19"] ?? 0) + ((int?)Session["1วิทยาเขตจันทบุรี19"] ?? 0) + ((int?)Session["1วิทยาเขตจักรพงษภูวนารถ19"] ?? 0) + ((int?)Session["1วิทยาเขตอุเทนถวาย19"] ?? 0);

                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวมทั้งสิ้น"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total0; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total1; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total2; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total3; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total4; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total6; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total7; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total8; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total9; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total10; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total11; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total12; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total13; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total14; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total15; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total16; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total17; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total18; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "" + total19; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }

                table.Rows.Add(row);
            }

            Panel1.Controls.Clear();
            Panel1.Controls.Add(table);
            return table;
        }

        protected void lbuExport_Click(object sender, EventArgs e)
        {
            Table table;
            table = Bindจำนวนบุคลารสายวิชาการจำแนกตามประเภทบุคลากรคณะและตำแหน่งทางวิชาการ();
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

    }
}

