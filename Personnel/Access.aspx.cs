using System;
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
            else
            {
                if (DatabaseManager.ValidateUser(tbUsername.Text, tbPassword.Text))
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
