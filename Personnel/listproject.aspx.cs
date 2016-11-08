﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using Personnel.Class;

namespace Personnel
{
    public partial class listproject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;
            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT (SELECT STF_FNAME || ' ' || STF_LNAME FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) NAME, (SELECT CATEGORY_NAME FROM TB_PROJECT_CATEGORY WHERE TB_PROJECT_CATEGORY.CATEGORY_ID = TB_PROJECT.CATEGORY_ID) CATEGORY_ID, PROJECT_NAME, ADDRESS_PROJECT, PRO_ID FROM TB_PROJECT WHERE UOC_ID = '" + loginPerson.UOC_ID + "' ORDER BY PRO_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeater.DataSource = dt;
            myRepeater.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var hidden = (HiddenField)item.FindControl("HF1");

            string proID = hidden.Value;
            if (hidden != null)
            {
                DatabaseManager.ExecuteNonQuery("DELETE TB_PROJECT WHERE PRO_ID = '" + proID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
            }
        }

        protected void myRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Preview" && e.CommandArgument.ToString() != "")
            {
                LinkButton lbu = (LinkButton)e.Item.FindControl("lbuPreview");
                string value = lbu.CommandArgument;
                Response.Redirect("previewproject.aspx?id=" + value);
            }
            if (e.CommandName == "Edit" && e.CommandArgument.ToString() != "")
            {
                LinkButton lbu = (LinkButton)e.Item.FindControl("lbuEdit");
                string value = lbu.CommandArgument;
                Response.Redirect("editproject.aspx?id=" + value);
            }
            if (e.CommandName == "Delete" && e.CommandArgument.ToString() != "")
            {
                LinkButton lbu = (LinkButton)e.Item.FindControl("lbuDelete");
                HiddenField hidden = (HiddenField)e.Item.FindControl("HF1");
                string value = lbu.CommandArgument;
                string proID = hidden.Value;

                List<int> pro_id = new List<int>();
                List<string> img_file = new List<string>();

                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT PRO_ID, IMG_FILE FROM TB_PROJECT WHERE PRO_ID = " + proID, con))
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

                    DatabaseManager.ExecuteNonQuery("DELETE TB_PROJECT WHERE PRO_ID = '" + value + "'");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                    BindData();
                }

            }
            if (e.CommandName == "Report" && e.CommandArgument.ToString() != "")
            {
                LinkButton lbu = (LinkButton)e.Item.FindControl("lbuReport");
                string value = lbu.CommandArgument;
                Response.Redirect("reportproject-admin.aspx?id=" + value);
            }
        }
    }
}