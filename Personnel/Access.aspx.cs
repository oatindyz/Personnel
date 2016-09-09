﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Personnel.Class;
using System.Data.OracleClient;

namespace Personnel
{
    public partial class Access : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PersonnelSystem ps = new PersonnelSystem();
                ps.LoginPerson = DatabaseManager.GetOUC_STAFF(tbUsername.Text);
                Session["PersonnelSystem"] = ps;

                if (tbUsername.Text.Length < 13)
                {
                    Label12X.Text = "";
                }
            }

        }

        protected void lbuLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                Label12X.Text = "กรุณากรอกรหัสประชาชนและรหัสผ่าน";
                return;
            }
            int count = DatabaseManager.ExecuteInt("SELECT count(*) FROM UOC_STAFF WHERE CITIZEN_ID = '" + tbUsername.Text + "'");
            if (count == 0)
            {
                Label12X.Text = "ไม่พบผู้ใช้งาน!";
                return;
            }

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                int First = 0;
                int NotFirst = 1;
                using (OracleCommand com = new OracleCommand("SELECT LOGIN_FIRST FROM UOC_STAFF WHERE CITIZEN_ID ='" + tbUsername.Text + "'" ,con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == First)
                            {
                                if (DatabaseManager.ValidatePasswordFirst(tbUsername.Text, tbPassword.Text))
                                {
                                    PersonnelSystem ps = new PersonnelSystem();
                                    ps.LoginPerson = DatabaseManager.GetOUC_STAFF(tbUsername.Text);
                                    Session["PersonnelSystem"] = ps;
                                    Response.Redirect("ChangePassword.aspx");
                                }
                                else
                                {
                                    Label12X.Text = "รหัสผ่านไม่ถูกต้อง!";
                                    return;                         
                                }
                                Response.Redirect("Default.aspx");
                            }

                            if (reader.GetInt32(0) == NotFirst)
                            {
                                if (DatabaseManager.ValidatePasswordNotFirst(tbUsername.Text, tbPassword.Text))
                                {
                                    PersonnelSystem ps = new PersonnelSystem();
                                    ps.LoginPerson = DatabaseManager.GetOUC_STAFF(tbUsername.Text);
                                    Session["PersonnelSystem"] = ps;
                                }
                                else
                                {
                                    Label12X.Text = "รหัสผ่านไม่ถูกต้อง!";
                                    return;
                                }
                                Response.Redirect("Default.aspx");
                            }
                        }
                    }
                }
            }      
        }

        protected void tbUsername_TextChanged(object sender, EventArgs e)
        {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT LOGIN_FIRST FROM UOC_STAFF WHERE CITIZEN_ID ='" + tbUsername.Text + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Login = reader.GetInt32(0);

                            if (tbUsername.Text.Length == 13)
                            {
                                if (Login == 0)
                                {
                                    Label12X.Text = "รหัสบัตรประชาชนดังกล่าวเป็นการล็อคอินครั้งแรก โปรดยืนยันตัวตน ด้วยการใส่รหัสผ่านเป็นวันเกิด รูปแบบ(01/01/0000)";
                                }
                                if (Login == 1)
                                {
                                    Label12X.Text = "";
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
