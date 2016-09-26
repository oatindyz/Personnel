using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
using Personnel.Class;

namespace Personnel
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            if (!IsPostBack)
            {
                if (loginPerson.IsLoginFirst())
                {
                    TitleDivNamePassOld.Visible = false;
                    divPassOld.Visible = false;
                    tbPasswordOld.Visible = false;
                }
                if (loginPerson.IsLoginSecond())
                {
                    tbPasswordOld.Visible = true;
                }
            }


        }

        protected void lbuFinish_Click(object sender, EventArgs e)
        {

        }

        protected void lbuChangePassword_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            if (loginPerson.IsLoginFirst())
            {
                Label12X.Text = "";

                if (tbPasswordNew.Text == "")
                {
                    Label12X.Text = "กรุณากรอกรหัสผ่านใหม่";
                    Label12X.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (tbPasswordNewAgain.Text == "")
                {
                    Label12X.Text = "กรุณากรอกรหัสผ่านใหม่อีกครั้ง";
                    Label12X.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (tbPasswordNew.Text == "" || tbPasswordNewAgain.Text == "")
                {
                    Label12X.Text = "กรุณากรอกรหัสผ่านใหม่ให้ครบถ้วน";
                    Label12X.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (tbPasswordNew.Text != tbPasswordNewAgain.Text)
                {
                    Label12X.Text = "รหัสผ่านไม่ตรงกัน";
                    Label12X.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET PASSWORD = '" + tbPasswordNew.Text + "', ST_LOGIN_ID = 1 WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "'");
                Label12X.Text = "ตั้งรหัสผ่านสำเร็จ";
                Label12X.ForeColor = System.Drawing.Color.Green;
            }

            //
            if (loginPerson.IsLoginSecond())
            {
                Label12X.Text = "";

                if (tbPasswordNew.Text == "")
                {
                    Label12X.Text = "กรุณากรอกรหัสผ่านใหม่";
                    Label12X.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (tbPasswordNewAgain.Text == "")
                {
                    Label12X.Text = "กรุณากรอกรหัสผ่านใหม่อีกครั้ง";
                    Label12X.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (tbPasswordNew.Text == "" || tbPasswordNewAgain.Text == "")
                {
                    Label12X.Text = "กรุณากรอกรหัสผ่านใหม่ให้ครบถ้วน";
                    Label12X.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (tbPasswordNew.Text != tbPasswordNewAgain.Text)
                {
                    Label12X.Text = "รหัสผ่านไม่ตรงกัน";
                    Label12X.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT PASSWORD FROM UOC_STAFF WHERE CITIZEN_ID ='" + loginPerson.CITIZEN_ID + "'", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.IsDBNull(0)){return;}
                                if (tbPasswordOld.Text != reader.GetString(0))
                                {
                                    Label12X.Text = "รหัสผ่านเก่าไม่ถูกต้อง";
                                    Label12X.ForeColor = System.Drawing.Color.Red;
                                    return;
                                }
                                if (tbPasswordNew.Text == reader.GetString(0))
                                {
                                    Label12X.Text = "รหัสผ่านใหม่ไม่สามารถซ้ำรหัสผ่านเดิม";
                                    Label12X.ForeColor = System.Drawing.Color.Red;
                                    return;
                                }
                                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET PASSWORD = '" + tbPasswordNew.Text + "' WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "'");
                                Label12X.Text = "เปลี่ยนรหัสผ่านสำเร็จ";
                                Label12X.ForeColor = System.Drawing.Color.Green;

                            }
                        }
                    }
                }
            }

        }
    }
}