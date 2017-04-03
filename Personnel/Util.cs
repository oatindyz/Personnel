using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;
using Personnel.Class;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data.OracleClient;

namespace Personnel
{
    public class Util
    {
        public static string ToThaiMonth(int month)
        {
            switch (month)
            {
                case 1: return "มกราคม";
                case 2: return "กุมภาพันธ์";
                case 3: return "มีนาคม";
                case 4: return "เมษายน";
                case 5: return "พฤษภาคม";
                case 6: return "มิถุนายน";
                case 7: return "กรกฎาคม";
                case 8: return "สิงหาคม";
                case 9: return "กันยายน";
                case 10: return "ตุลาคม";
                case 11: return "พฤศจิกายน";
                case 12: return "ธันวาคม";
                default: return "[ERROR]";
            }
        }
        public static string ToThaiMonth(string s)
        {
            return ToThaiMonth(int.Parse(s));
        }
        public static string PureDatabaseToThaiDate(string s)
        {
            if (s == null)
            {
                return "";
            }
            string[] ss = s.Split('/');
            if (ss.Length != 3)
                return "";
            switch (int.Parse(ss[1]))
            {
                case 1: ss[1] = "ม.ค."; break;
                case 2: ss[1] = "ก.พ."; break;
                case 3: ss[1] = "มี.ค."; break;
                case 4: ss[1] = "เม.ย."; break;
                case 5: ss[1] = "พ.ค."; break;
                case 6: ss[1] = "มิ.ย."; break;
                case 7: ss[1] = "ก.ค."; break;
                case 8: ss[1] = "ส.ค."; break;
                case 9: ss[1] = "ก.ย."; break;
                case 10: ss[1] = "ต.ค."; break;
                case 11: ss[1] = "พ.ย."; break;
                case 12: ss[1] = "ธ.ค."; break;
            }
            return int.Parse(ss[0]).ToString("00") + " " + ss[1] + " " + ss[2].Substring(0, 4);
        }
        public static string ToThaiMonthShort(string monthNum)
        {
            switch (int.Parse(monthNum))
            {
                case 1: return "ม.ค.";
                case 2: return "ก.พ.";
                case 3: return "มี.ค.";
                case 4: return "เม.ย.";
                case 5: return "พ.ค.";
                case 6: return "มิ.ย.";
                case 7: return "ก.ค.";
                case 8: return "ส.ค.";
                case 9: return "ก.ย.";
                case 10: return "ต.ค.";
                case 11: return "พ.ย.";
                case 12: return "ธ.ค.";
                default: return "[error]";
            }
        }
        public static void NormalizeGridViewDate(GridView gv, int rowIndex)
        {
            for (int i = 0; i < gv.Rows.Count; ++i)
            {
                string s = gv.Rows[i].Cells[rowIndex].Text;
                string[] ss = s.Split('/');
                gv.Rows[i].Cells[rowIndex].Text = PureDatabaseToThaiDate(s);
            }
        }
        public static void NormalizeGridViewDate7D(GridView gv, int rowIndex)
        {
            for (int i = 0; i < gv.Rows.Count; ++i)
            {
                string s = gv.Rows[i].Cells[rowIndex].Text;
                string[] ss1 = s.Split(' ');
                string[] ss2 = ss1[0].Split('-');
                string year = ss2[0];
                string month = ToThaiMonthShort(ss2[1]);
                string day = ss2[2];
                string day7 = ss1[2];
                switch (day7)
                {
                    case "1": day7 = "อาทิตย์"; break;
                    case "2": day7 = "จันทร์"; break;
                    case "3": day7 = "อังคาร"; break;
                    case "4": day7 = "พุธ"; break;
                    case "5": day7 = "พฤหัสบดี"; break;
                    case "6": day7 = "ศุกร์"; break;
                    case "7": day7 = "เสาร์"; break;
                    default: day = "[error]"; break;
                }
                gv.Rows[i].Cells[rowIndex].Text = day + " " + month + " " + year + " " + day7;
            }
        }
        public static void NormalizeGridViewDate(GridView gv, int[] rowIndex)
        {
            for (int i = 0; i < gv.Rows.Count; ++i)
            {
                for (int j = 0; j < rowIndex.Length; ++j)
                {
                    string s = gv.Rows[i].Cells[rowIndex[j]].Text;
                    string[] ss = s.Split('/');
                    gv.Rows[i].Cells[rowIndex[j]].Text = PureDatabaseToThaiDate(s);
                }

            }
        }
        public static void GridViewAddCheckBox(GridView gv)
        {
            TableHeaderCell headerFrontCell = new TableHeaderCell();
            headerFrontCell.Text = "เลือก";
            gv.HeaderRow.Cells.AddAt(0, headerFrontCell);

            for (int i = 0; i < gv.Rows.Count; ++i)
            {
                TableCell frontCell = new TableCell();
                CheckBox cb = new CheckBox();
                frontCell.Controls.Add(cb);
                gv.Rows[i].Cells.AddAt(0, frontCell);
            }


        }

        public static bool IsDateValid(string date)
        {
            try
            {
                string[] split = date.Split(' ');

                if (split.Length != 3)
                {
                    return false;
                }

                string day = split[0];
                string month = split[1];
                string year = split[2];

                int iDay = int.Parse(day);
                if (iDay < 1 || iDay > 31)
                {
                    return false;
                }
                switch (month)
                {
                    case "01":
                    case "02":
                    case "03":
                    case "04":
                    case "05":
                    case "06":
                    case "07":
                    case "08":
                    case "09":
                    case "10":
                    case "11":
                    case "12":
                        break;
                    default: return false;
                }
                int iYear = int.Parse(year);
                if (iYear < 0 || iYear > 9999)
                {
                    return false;
                }


                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsBlank(string str)
        {
            if (str == null || str == "")
            {
                return true;
            }
            return false;
        }
        public static void Alert(Control control, string message)
        {
            string script2 = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(control, control.GetType(), "ServerControlScript", script2, true);
        }

        public static string RandomFileName()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static bool StringEqual(string source, string[] target)
        {
            for (int i = 0; i < target.Length; ++i)
            {
                if (source == target[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static string DatabaseToDateSearch(string v1)
        {
            string[] v2 = v1.Split('/');
            return "TO_DATE('" + v2[0] + "/" + v2[1] + "/" + (int.Parse(v2[2]) - 543) + "', 'DD/MM/YYYY')";
        }

        public static int BudgetYear()
        {
            DateTime dtToday = DateTime.Today;
            int budgetYear = dtToday.Year;
            if (dtToday.Month >= 10)
            {
                ++budgetYear;
            }
            return budgetYear;
        }
    }
}