using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using Personnel.Class;
using System.IO;

namespace Personnel
{
    public partial class reportproject_admin : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
                    ReadSelectID();
                }
                else { Response.Redirect("listproject-admin.aspx"); }

                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT START_DATE,END_DATE FROM TB_PROJECT WHERE PRO_ID = '" + id + "'", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;
                                string start = reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                                string end = reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                                if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                                {
                                    DateTime df = DateTime.Parse(start);
                                    DateTime dt = DateTime.Parse(end);
                                    int day = (int)(dt - df).TotalDays + 1;

                                    int year = (day / 365);
                                    int month = (day % 365) / 30;
                                    day = (day % 365) % 30;

                                    lbcalYear.Text = "" + year;
                                    lbcalMonth.Text = "" + month;
                                    lbcalDay.Text = "" + day;
                                }

                            }
                        }
                    }
                }
            }          
        }

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT (SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) || ' ' || STF_FNAME || ' ' || STF_LNAME FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) NAME, (SELECT (SELECT POSITION_NAME_TH FROM REF_POSITION WHERE REF_POSITION.POSITION_ID = UOC_STAFF.POSITION_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) POSITION_NAME,(SELECT (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) DEPART_NAME, PROJECT_NAME, ADDRESS_PROJECT, START_DATE, END_DATE, EXPENSES, FUNDING, CERTIFICATE, SUMMARIZE_PROJECT, RESULT_TEACHING, RESULT_ACADEMIC, DIFFICULTY_PROJECT, RESULT_PROJECT, RESULT_RESEARCHING, RESULT_OTHER, COUNSEL FROM TB_PROJECT WHERE PRO_ID = '" + id + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            lbName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPosition.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDepartment.Text = reader.IsDBNull(i) ? "" : reader.GetString(i) + " มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก"; ++i;
                            lbNameProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbAddressProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDateStart.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            lbDateEnd.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            lbExpense.Text = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString("#,###"); ++i;
                            lbFunding.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbCertificate.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbSummaryProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbResultTeaching.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbResultAcademic.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDifficultyProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbResultProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbResultResearching.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbResultOther.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbCounsel.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                        }
                    }
                }
            }
        }

        protected void lbuExport_Click(object sender, EventArgs e)
        {
            string strBody = string.Empty;
            strBody = @"<html xmlns:o='urn:schemas-microsoft-com:office:office' " +
            "xmlns:w='urn:schemas-microsoft-com:office:word'" +
            "xmlns='http://www.w3.org/TR/REC-html40'>";

            strBody = strBody + "<!--[if gte mso 9]>" +
            "<xml>" +
            "<w:WordDocument>" +
            "<w:View>Print</w:View>" +
            "<w:Zoom>100</w:Zoom>" +
            "</w:WordDocument>" +
            "</xml>" +
            "<![endif]-->";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/vnd.ms-word";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=แบบรายงานการฝึกอบรม/สัมมนา/ดูงาน.doc");

            StringBuilder htmlCode = new StringBuilder();
            htmlCode.Append("<html>");
            htmlCode.Append("<head>" + strBody + " <style type=\"text/css\">body {font-family:TH Sarabun New;font-size:16;}</style></head>");
            htmlCode.Append("<body>");

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            tb.RenderControl(hw);

            htmlCode.Append("</body></html>");
            HttpContext.Current.Response.Write(htmlCode.ToString() + sw);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }

    }
}