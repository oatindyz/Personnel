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
    public partial class ReportSummary_admin : System.Web.UI.Page
    {
        private List<Department> dl;
        private List<Campus> cl;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                dl = new List<Department>();
                Session["DEPARTMENTLIST"] = dl;

                cl = new List<Campus>();
                Session["CAMPUSLIST"] = cl;

                BindDDL();
            }
            else
            {
                cl = (List<Campus>)Session["CAMPUSLIST"];
                dl = (List<Department>)Session["DEPARTMENTLIST"];
                CreateTable();
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlCampus, "SELECT * FROM REF_UNIV ORDER BY UNIV_ID", "UNIV_SHORT", "UNIV_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlDepartment, "SELECT * FROM REF_FAC ORDER BY FAC_ID", "FAC_NAME", "FAC_ID", "--กรุณาเลือก--");
        }

        protected void lbuAdd_Click(object sender, EventArgs e)
        {
            string UnivID = DatabaseManager.ExecuteString("SELECT UNIV_ID FROM REF_FAC WHERE FAC_ID = '" + ddlDepartment.SelectedValue + "'");
            dl.Add(new Department(ddlDepartment.SelectedValue, ddlDepartment.SelectedItem.Text, UnivID));
            if (UnivID != "")
            {
                bool HasUnivID = false;
                foreach (Campus icamp in cl)
                {
                    if (icamp.ID == UnivID)
                    {
                        HasUnivID = true;
                        break;
                    }
                }
                if (!HasUnivID)
                {
                    string UnivName = DatabaseManager.ExecuteString("SELECT UNIV_SHORT FROM REF_UNIV WHERE UNIV_ID = '" + UnivID + "'");
                    cl.Add(new Campus(UnivID, UnivName));
                }
            }
            CreateTable();
        }

        private void CreateTable()
        {
            /* List<Department> dlt = new List<Department>();
             foreach (Department di in dl)
             {
                 dlt.Add(di);
             }
             dl.Clear();
             int BangphraCount = 0;
             int JhanCount = 0;
             int JhakCount = 0;
             int TainCount = 0;

             foreach (Department di in dlt)
             {
                 if (di.campusID == "19303")
                 {
                     dl.Add(di);
                     ++BangphraCount;
                 }
             }
             foreach (Department di in dlt)
             {
                 if (di.campusID == "19304")
                 {
                     dl.Add(di);
                     ++JhanCount;
                 }
             }
             foreach (Department di in dlt)
             {
                 if (di.campusID == "19301")
                 {
                     dl.Add(di);
                     ++JhakCount;
                 }
             }
             foreach (Department di in dlt)
             {
                 if (di.campusID == "19302")
                 {
                     dl.Add(di);
                     ++TainCount;
                 }
             }*/
            //dl.Sort(delegate (Department d1, Department d2) { return d1.campusID.CompareTo(d2.campusID); });
            Table1.CssClass = "ps-table-1";
            Table1.Controls.Clear();
            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "สรุปข้อมูลจำนวนบุคลากรสายวิชาการ จำแนกตามประเภทบุคลากร คณะ และตำแหน่งทางวิชาการ ปี 2559 (ข้อมูล ณ เดือนพฤศจิกายน 2559)"; cell.Style["text-align"] = "center"; cell.ColumnSpan = 26; row.Cells.Add(cell); }
                Table1.Rows.Add(row);
            }

            {
                TableHeaderRow row = new TableHeaderRow();
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "คณะ"; cell.RowSpan = 2; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ข้าราชการพลเรือน"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "พนักงานในสถาบันฯ"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "พนักงานราชการ"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "ลูกจ้างชั่วคราว"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                { TableHeaderCell cell = new TableHeaderCell(); cell.Text = "รวมทั้งสิ้น"; cell.ColumnSpan = 5; cell.Style["text-align"] = "center"; row.Cells.Add(cell); }
                Table1.Rows.Add(row);
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
                Table1.Rows.Add(row);
            }

            //
            //0วิทยาเขตบางพระ
            {
                //TableHeaderRow row = new TableHeaderRow();
                //{ TableHeaderCell cell = new TableHeaderCell(); cell.Text = "วิทยาเขตบางพระ"; cell.Style["text-align"] = "left"; cell.Width = 250; row.Cells.Add(cell); }
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    //Department
                    foreach (Department idept in dl)
                    {
                        using (OracleCommand com = new OracleCommand(
                        "SELECT" +
                        " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE DEPARTMENT_ID = '" + idept.ID + "' AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                        " FROM DUAL", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                TableRow row = new TableRow();
                                TableCell Dcell = new TableCell();
                                Dcell.Text = idept.name;
                                row.Cells.Add(Dcell);

                                while (reader.Read())
                                {
                                    for (int i = 0; i < 25; i++)
                                    {
                                        TableCell cell = new TableCell();
                                        cell.Text = reader.GetInt32(i).ToString();
                                        if (cell.Text == "0")
                                        {
                                            cell.Text = "-";
                                        }
                                        row.Cells.Add(cell);
                                    }
                                }
                                Table1.Rows.Add(row);
                            }
                        }
                    }
                    //Campus
                    foreach (Campus icamp in cl)
                    {
                        using (OracleCommand com = new OracleCommand(
                        "SELECT" +
                        " (SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '1' AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '1' AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '1' AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '1' AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '1' AND POSITION_ID IN('04','03','02','01'))" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '2' AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '2' AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '2' AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '2' AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '2' AND POSITION_ID IN('04','03','02','01'))" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '5' AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '5' AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '5' AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '5' AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '5' AND POSITION_ID IN('04','03','02','01'))" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '4' AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '4' AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '4' AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '4' AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID = '4' AND POSITION_ID IN('04','03','02','01'))" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '04')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '03')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '02')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID = '01')" +
                        ",(SELECT NVL(COUNT(UOC_ID),0) FROM UOC_STAFF WHERE univ_id = '" + icamp.ID + "' AND DEPARTMENT_ID IN(" + F1(icamp.ID) + ") AND STAFFTYPE_ID IN('1','2','5','4') AND POSITION_ID IN('04','03','02','01'))" +
                        " FROM DUAL", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                TableRow row = new TableRow();
                                TableHeaderCell Dcell = new TableHeaderCell();
                                Dcell.Text = icamp.name;
                                row.Cells.Add(Dcell);

                                while (reader.Read())
                                {
                                    for (int i = 0; i < 25; i++)
                                    {
                                        TableHeaderCell cell = new TableHeaderCell();
                                        cell.Text = reader.GetInt32(i).ToString();
                                        if (cell.Text == "0")
                                        {
                                            cell.Text = "-";
                                        }
                                        row.Cells.Add(cell);
                                    }
                                }
                                /* int ind = 0;
                                 if (icamp.ID == "19303")
                                 {
                                     ind = 3;
                                 }
                                 else if (icamp.ID == "19304")
                                 {
                                     ind = 3 + BangphraCount + 1;
                                 }
                                 else if (icamp.ID == "19301")
                                 {
                                     ind = 3 + BangphraCount + 1 + JhanCount;
                                 }
                                 else if (icamp.ID == "19302")
                                 {
                                     ind = 3 + BangphraCount + 1 + JhanCount + JhakCount;
                                 }*/
                                //Table1.Rows.AddAt(ind,row);
                                Table1.Rows.Add(row);
                            }
                        }
                    }
                }
            }


        }

        private string F1(string UnivID)
        {
            string temp = "";
            foreach (Department idept in dl)
            {
                if (idept.campusID == UnivID)
                {
                    temp += idept.ID + ",";
                }
            }
            temp = temp.Substring(0, temp.Length - 1);
            return temp;
        }



    }
}