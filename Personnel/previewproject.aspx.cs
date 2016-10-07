using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using Personnel.Class;

namespace Personnel
{
    public partial class previewproject : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Notsuccess.Visible = true;
            success.Visible = false;
            delete.Visible = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
                    ReadSelectID();
                }
                else { Response.Redirect("listproject.aspx"); }
            }
            ReadFile();
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

                file_pdf.Controls.Add(p);
            }
        }

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT (SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) || ' ' || STF_FNAME || ' ' || STF_LNAME FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) NAME, (SELECT (SELECT POSITION_NAME_TH FROM REF_POSITION WHERE REF_POSITION.POSITION_ID = UOC_STAFF.POSITION_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) POSITION_NAME,(SELECT (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) DEPART_NAME, (SELECT CATEGORY_NAME FROM TB_PROJECT_CATEGORY WHERE TB_PROJECT_CATEGORY.CATEGORY_ID = TB_PROJECT.CATEGORY_ID) CATEGORY_ID, PROJECT_NAME, ADDRESS_PROJECT, START_DATE, END_DATE, EXPENSES, FUNDING, CERTIFICATE, SUMMARIZE_PROJECT, RESULT_TEACHING, RESULT_ACADEMIC, DIFFICULTY_PROJECT, RESULT_PROJECT, RESULT_RESEARCHING, RESULT_OTHER, COUNSEL FROM TB_PROJECT WHERE PRO_ID = '" + id + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            lbName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPosition.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDepartment.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbCATEGORY_ID.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPROJECT_NAME.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbADDRESS_PROJECT.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDateStart.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            lbDateEnd.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            lbEXPENSES.Text = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString("#,###"); ++i;
                            lbFUNDING.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbCERTIFICATE.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbSUMMARIZE_PROJECT.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbRESULT_TEACHING.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbRESULT_ACADEMIC.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDIFFICULTY_PROJECT.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbRESULT_PROJECT.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbRESULT_RESEARCHING.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbRESULT_OTHER.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbCOUNSEL.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;


                        }
                    }
                }
            }
        }

        protected void lbuEdit_Click(object sender, EventArgs e)
        {
            string link = MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString());
            string encrypt = MyCrypto.GetEncryptedQueryString(link);
            Response.Redirect("editproject.aspx?id=" + encrypt);
        }

        protected void lbuDelete_Click(object sender, EventArgs e)
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

                string pathVS = Server.MapPath("Upload/Project/PDF/" + IMG_FILE);
                if ((System.IO.File.Exists(pathVS)))
                {
                    System.IO.File.Delete(pathVS);
                }

                DatabaseManager.ExecuteNonQuery("DELETE TB_PROJECT WHERE PRO_ID = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
            }

            string link = MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString());
            DatabaseManager.ExecuteNonQuery("DELETE TB_PROJECT WHERE PRO_ID = '" + link + "'");
            Notsuccess.Visible = false;
            success.Visible = false;
            delete.Visible = true;
        }
    }
}