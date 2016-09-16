using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.IO;
using Personnel.Class;

namespace Personnel
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF LoginPerson;
            if (Request.QueryString["id"] != null)
            {
                LoginPerson = DatabaseManager.GetOUC_STAFF(Request.QueryString["id"]);
                id1.Visible = false;
                if (LoginPerson == null)
                {
                    LoginPerson = ps.LoginPerson;
                }
            }
            else
            {
                LoginPerson = ps.LoginPerson;
            }

            profile_images.InnerHtml = "";

            List<int> ids = new List<int>();
            List<string> urls = new List<string>();

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT ID, URL FROM PS_PERSON_IMAGE WHERE CITIZEN_ID = '" + LoginPerson.CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ids.Add(reader.GetInt32(0));
                            urls.Add(reader.GetString(1));
                        }
                    }
                }
            }

            for (int i = 0; i < ids.Count; i++)
            {
                string path = "Upload/PersonImage/" + urls[i];
                int ID = ids[i];
                string url = urls[i];

                Panel p = new Panel();
                p.Style.Add("display", "inline-block");

                LinkButton lb = new LinkButton();
                lb.Attributes["href"] = path;
                p.Controls.Add(lb);

                Image img = new Image();
                img.Attributes["src"] = path;
                lb.Controls.Add(img);

                profile_images.Controls.Add(p);

                Panel p2 = new Panel();
                p.Controls.Add(p2);

                LinkButton lbSelectImagePresent = new LinkButton();
                lbSelectImagePresent.CssClass = "ps-button";
                lbSelectImagePresent.Text = "<img src='Image/Small/pointer.png' class='icon_left' />เลือก";
                lbSelectImagePresent.Click += (e1, e2) =>
                {
                    DatabaseManager.ExecuteNonQuery("UPDATE PS_PERSON_IMAGE SET PRESENT = 0 WHERE CITIZEN_ID = '" + LoginPerson.CITIZEN_ID + "'");
                    DatabaseManager.ExecuteNonQuery("UPDATE PS_PERSON_IMAGE SET PRESENT = 1 WHERE CITIZEN_ID = '" + LoginPerson.CITIZEN_ID + "' AND ID = " + ID);
                    Response.Redirect("Profile.aspx");
                };
                if (id1.Visible)
                    p2.Controls.Add(lbSelectImagePresent);

                LinkButton lbDeleteImagePresent = new LinkButton();
                lbDeleteImagePresent.CssClass = "ps-button";
                lbDeleteImagePresent.Text = "<img src='Image/Small/delete.png' class='icon_left' />ลบ";
                lbDeleteImagePresent.Click += (e1, e2) =>
                {
                    FileInfo FileIn = new FileInfo(Server.MapPath("~/Upload/PersonImage/" + url));
                    if (FileIn.Exists)
                    {
                        FileIn.Delete();
                    }
                    DatabaseManager.ExecuteNonQuery("DELETE FROM PS_PERSON_IMAGE WHERE ID = " + ID);
                    Response.Redirect("Profile.aspx");
                };
                if (id1.Visible)
                    p2.Controls.Add(lbDeleteImagePresent);
            }

            lbPrefix.Text = LoginPerson.PREFIX_NAME;
            lbName.Text = LoginPerson.STF_FNAME;
            lbLastName.Text = LoginPerson.STF_LNAME;
            lbGender.Text = LoginPerson.GENDER_NAME;

            lbHomeAdd.Text = LoginPerson.HOMEADD;
            lbMoo.Text = LoginPerson.MOO;
            lbStreet.Text = LoginPerson.STREET;
            lbProvince.Text = LoginPerson.PROVINCE_NAME;
            lbDistrict.Text = LoginPerson.DISTRICT_NAME;
            lbSubDistrict.Text = LoginPerson.SUB_DISTRICT_NAME;

        }

        public static string RandomFileName()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 24)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected void lbuUploadPicture_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF LoginPerson = ps.LoginPerson;

            if (FileUpload1.HasFile)
            {
                FileInfo fi = new FileInfo(FileUpload1.FileName);
                string fname = RandomFileName() + fi.Extension;
                FileUpload1.SaveAs(Server.MapPath("~/Upload/PersonImage/" + fname));
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("INSERT INTO PS_PERSON_IMAGE (ID, CITIZEN_ID, URL, PRESENT) VALUES (PS_PERSON_IMAGE_SEQ.NEXTVAL, :CITIZEN_ID, :URL, :PRESENT)", con))
                    {
                        com.Parameters.AddWithValue("CITIZEN_ID", LoginPerson.CITIZEN_ID);
                        com.Parameters.AddWithValue("URL", fname);
                        int v1 = 0;
                        com.Parameters.AddWithValue("PRESENT", v1);
                        com.ExecuteNonQuery();
                    }
                }
            }
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        
        }

    }
}