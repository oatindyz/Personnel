using System;
using System.Text;
using System.Security.Cryptography;
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

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
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
                string source = tbPasswordNew.Text;
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, source);
                    DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET PASSWORD = '" + hash.ToString() + "', ST_LOGIN_ID = 1 WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "'");
                    Label12X.Text = "ตั้งรหัสผ่านสำเร็จ";
                    Label12X.ForeColor = System.Drawing.Color.Green;
                }
            }

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
                if (tbPasswordOld.Text == tbPasswordNew.Text)
                {
                    Label12X.Text = "รหัสผ่านใหม่ไม่สามารถซ้ำรหัสผ่านเก่า";
                    Label12X.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (tbPasswordNew.Text != tbPasswordNewAgain.Text)
                {
                    Label12X.Text = "รหัสผ่านใหม่กับรหัสผ่านใหม่อีกครั้งไม่ตรงกัน";
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
                            string source = tbPasswordNew.Text;
                            string CheckOld = tbPasswordOld.Text;
                            while (reader.Read())
                            {
                                using (MD5 md5Hash = MD5.Create())
                                {
                                    string hash = GetMd5Hash(md5Hash, source);
                                    string hashOld = GetMd5Hash(md5Hash, CheckOld);
                                    if (!reader.IsDBNull(0))
                                    {
                                        if (hashOld != reader.GetString(0))
                                        {
                                            Label12X.Text = "รหัสผ่านเก่าไม่ถูกต้อง";
                                            Label12X.ForeColor = System.Drawing.Color.Red;
                                            return;
                                        }

                                        DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET PASSWORD = '" + hash.ToString() + "' WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "'");
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
    }
}