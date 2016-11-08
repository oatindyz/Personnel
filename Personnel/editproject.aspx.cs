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
using System.IO;

namespace Personnel
{
    public partial class editproject : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Notsuccess.Visible = true;
            success.Visible = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
                    BindDDL();
                    ReadSelectID();  
                }
                else { Response.Redirect("listproject.aspx"); }

                string CheckIsNull = DatabaseManager.ExecuteString("SELECT COUNT(IMG_FILE) FROM TB_PROJECT WHERE PRO_ID = " + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "");
                if (CheckIsNull == "0")
                {
                    lbFile.Visible = true;
                    FUdocument.Visible = true;
                    spFile.InnerText = "*";
                    spFile.Attributes.Add("class", "ps-lb-red");
                    spFile.Attributes["style"] = "color:red;";
                    FUdocument.Attributes.Add("required", "true");
                }
                else
                {
                    lbFile.Visible = false;
                    FUdocument.Visible = false;
                    spFile.InnerText = "";
                    spFile.Attributes.Add("class", "");
                    spFile.Attributes["style"] = "";
                    FUdocument.Attributes.Add("required", "false");
                }
            }
            ReadFile();
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlCategory, "SELECT * FROM TB_PROJECT_CATEGORY ORDER BY CATEGORY_ID", "CATEGORY_NAME", "CATEGORY_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlCountry, "SELECT * FROM TB_PROJECT_COUNTRY ORDER BY COUNTRY_ID", "COUNTRY_NAME", "COUNTRY_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlSubCountry, "SELECT * FROM TB_PROJECT_COUNTRY_SUB ORDER BY SUB_COUNTRY_ID", "SUB_COUNTRY_NAME", "SUB_COUNTRY_ID", "--กรุณาเลือก--");
        }

        private void ReadFile()
        {
            List<int> pro_id = new List<int>();
            List<string> img_file = new List<string>();

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT PRO_ID, IMG_FILE FROM TB_PROJECT WHERE PRO_ID = " + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())), con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(1))
                            {
                                pro_id.Add(reader.GetInt32(0));
                                img_file.Add(reader.GetString(1));
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < pro_id.Count; i++)
            {
                string path = "Upload/Project/PDF/" + img_file[i];
                int PRO_ID = pro_id[i];
                string IMG_FILE = img_file[i];

                Panel p = new Panel();
                p.Style.Add("display", "inline-block");

                LinkButton lb = new LinkButton();
                lb.Attributes["href"] = path;
                lb.Text = "ดูไฟล์แนบ (รูปภาพ,เอกสาร ประกอบการอบรม)";
                p.Controls.Add(lb);

                LinkButton lbDelete = new LinkButton();
                lbDelete.CssClass = "ps-button";
                lbDelete.Text = "<img src='Image/Small/delete.png' class='icon_left' />ลบ";
                lbDelete.Click += (e1, e2) =>
                {
                    lbDelete.Attributes.Add("onclick", "javascript:if(!confirm('คุณต้องการที่จะลบใช่หรือไม่'))return false;");
                    FileInfo FileIn = new FileInfo(Server.MapPath("Upload/Project/PDF/" + IMG_FILE));
                    if (FileIn.Exists)
                    {
                        FileIn.Delete();
                    }
                    DatabaseManager.ExecuteNonQuery("UPDATE TB_PROJECT SET IMG_FILE = (null) WHERE PRO_ID = " + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())));
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                };

                p.Controls.Add(lbDelete);
                file_pdf.Controls.Add(p);
            }
        }

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT COUNTRY_ID, SUB_COUNTRY_ID, (SELECT (SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) || ' ' || STF_FNAME || ' ' || STF_LNAME FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) NAME, (SELECT (SELECT POSITION_NAME_TH FROM REF_POSITION WHERE REF_POSITION.POSITION_ID = UOC_STAFF.POSITION_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) POSITION_NAME,(SELECT (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) DEPART_NAME , CATEGORY_ID, PROJECT_NAME, ADDRESS_PROJECT, START_DATE, END_DATE, EXPENSES, FUNDING, CERTIFICATE, SUMMARIZE_PROJECT, RESULT_TEACHING, RESULT_ACADEMIC, DIFFICULTY_PROJECT, RESULT_PROJECT, RESULT_RESEARCHING, RESULT_OTHER, COUNSEL FROM TB_PROJECT WHERE PRO_ID = '" + id + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            ddlCountry.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            ddlSubCountry.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            lbName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPosition.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDepartment.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlCategory.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbProjectName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbAddressProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbStartDate.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            tbEndDate.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            tbExpenses.Text = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbFunding.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbCertificate.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbSummarizeProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultTeaching.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultAcademic.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbDifficultyProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultResearching.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultOther.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbCounsel.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                        }
                    }
                }
            }
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

        protected void btnUpdateProject_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string[] validFileTypes = { "pdf" };
                string ext = System.IO.Path.GetExtension(FUdocument.PostedFile.FileName);
                bool isValidFile = false;

                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (!isValidFile)
                {
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.FUdocument);
                    ChangeNotification("danger", "กรุณาแนบไฟล์นามสกุล " + string.Join(",", validFileTypes) + " เท่านั้น");
                    return;
                }

                else if (FUdocument.PostedFile.ContentLength > 26214400)
                {
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.FUdocument);
                    ChangeNotification("danger", "กรุณาแนบไฟล์ไม่เกิน 25 MB");
                    return;
                }
                else
                {
                    ChangeNotification("", "");
                }

                if (tbStartDate.Text != "" && tbEndDate.Text != "")
                {
                    DateTime dtEndDate = DateTime.Parse(tbEndDate.Text);
                    DateTime dtStartDate = DateTime.Parse(tbStartDate.Text);
                    int totalDay = (int)(dtEndDate - dtStartDate).TotalDays + 1;

                    if (totalDay <= 0)
                    {
                        notification.Attributes["class"] = "alert alert_danger";
                        notification.InnerHtml = "";
                        notification.InnerHtml += "<div> <img src='Image/Small/red_alert.png' /> วันที่เริ่มโครงการ - วันที่สิ้นสุดโครงการ : วันที่ไม่ถูกต้อง !</div>";
                        ScriptManager.GetCurrent(this.Page).SetFocus(this.tbStartDate);
                        return;
                    }
                    else
                    {
                        notification.Attributes["class"] = "none";
                        notification.InnerHtml = "";
                    }
                }

                PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                UOC_STAFF loginPerson = ps.LoginPerson;
                PROJECT p = new PROJECT();
                p.CATEGORY_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                p.PROJECT_NAME = tbProjectName.Text;
                p.ADDRESS_PROJECT = tbAddressProject.Text;
                p.START_DATE = DateTime.Parse(tbStartDate.Text);
                p.END_DATE = DateTime.Parse(tbEndDate.Text);
                p.EXPENSES = Convert.ToInt32(tbExpenses.Text);
                p.FUNDING = tbFunding.Text;
                p.CERTIFICATE = tbCertificate.Text;
                p.SUMMARIZE_PROJECT = tbSummarizeProject.Text;
                p.RESULT_TEACHING = tbResultTeaching.Text;
                p.RESULT_ACADEMIC = tbResultAcademic.Text;
                p.DIFFICULTY_PROJECT = tbDifficultyProject.Text;
                p.RESULT_PROJECT = tbResultProject.Text;
                p.RESULT_RESEARCHING = tbResultResearching.Text;
                p.RESULT_OTHER = tbResultOther.Text;
                p.COUNSEL = tbCounsel.Text;
                p.COUNTRY_ID = Convert.ToInt32(ddlCountry.SelectedValue);
                p.SUB_COUNTRY_ID = Convert.ToInt32(ddlSubCountry.SelectedValue);
                if (FUdocument.HasFile)
                {
                    string CountBase = DatabaseManager.ExecuteString("select count(*) from tb_project where uoc_id = '" + loginPerson.UOC_ID + "'");
                    FileInfo fi = new FileInfo(FUdocument.FileName);
                    string imgFile = "UID=" + loginPerson.UOC_ID + "&count=" + CountBase + fi.Extension;
                    FUdocument.SaveAs(Server.MapPath("Upload/Project/PDF/" + imgFile));
                    p.IMG_FILE = imgFile;
                }
                p.PRO_ID = int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
                p.UPDATE_PROJECT();

                Notsuccess.Visible = false;
                success.Visible = true;
            }
        }
    }
}