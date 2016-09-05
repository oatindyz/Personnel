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
    public partial class ChangePassword : System.Web.UI.Page
    {
        public static string strConn = @"Data Source = ORCL_RMUTTO;USER ID=RMUTTO;PASSWORD=Zxcvbnm";
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;
            string never = loginPerson.LOGIN_FIRST;
            int Login = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(strConn))
            {
                con.Open();
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
            }
        }

        protected void lbuFinish_Click(object sender, EventArgs e)
        {

        }

        protected void lbuChangePassword_Click(object sender, EventArgs e)
        {

        }
    }
}