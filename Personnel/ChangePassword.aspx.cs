using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using Personnel.Class;
using System.Data;

namespace Personnel
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;
            string never = loginPerson.LOGIN_FIRST;

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                int Login = 0;
                using (OracleCommand com = new OracleCommand("SELECT LOGIN_FIRST FROM UOC_STAFF WHERE CITIZEN_ID ='" + loginPerson.CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == Login)
                            {
                                
                            }
                        }
                    }
                }
            }*/
        }

        protected void lbuFinish_Click(object sender, EventArgs e)
        {

        }

        protected void lbuChangePassword_Click(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            Label12X.Text = "";
            /*if (tbPasswordNew.Text.Length < 8)
            {
                Label12X.Text = "รหัสต้องมีความยาวอย่างน้อย 8 ตัวอักษร";
                Label12X.ForeColor = System.Drawing.Color.Red;
                return;
            }*/

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
                using (OracleCommand com = new OracleCommand("SELECT LOGIN_FIRST,BIRTHDAY,PASSWORD FROM UOC_STAFF WHERE CITIZEN_ID ='" + loginPerson.CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == 0)
                            {
                                if (tbPasswordOld.Text != reader.GetString(1))
                                {
                                    Label12X.Text = "รหัสผ่านเก่าไม่ถูกต้อง";
                                    Label12X.ForeColor = System.Drawing.Color.Red;
                                    return;
                                }
                                if (tbPasswordNew.Text == reader.GetString(1))
                                {
                                    Label12X.Text = "รหัสผ่านใหม่ไม่สามารถซ้ำรหัสผ่านเดิม";
                                    Label12X.ForeColor = System.Drawing.Color.Red;
                                    return;
                                }
                                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET PASSWORD = '" + tbPasswordNew.Text + "', LOGIN_FIRST = 1 WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "'");
                                Label12X.Text = "เปลี่ยนรหัสผ่านสำเร็จ";
                                Label12X.ForeColor = System.Drawing.Color.Green;
                            }

                            if (reader.GetInt32(0) == 1)
                            {
                                if (tbPasswordOld.Text != reader.GetString(2))
                                {
                                    Label12X.Text = "รหัสผ่านเก่าไม่ถูกต้อง";
                                    Label12X.ForeColor = System.Drawing.Color.Red;
                                    return;
                                }
                                if (tbPasswordNew.Text == reader.GetString(2))
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