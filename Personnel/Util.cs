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
        public static string RandomFileName()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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