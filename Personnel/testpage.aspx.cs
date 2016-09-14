using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using Personnel.Class;

namespace Personnel
{
    public partial class testpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.Visible = false;

            OracleConnection con = new OracleConnection("DATA SOURCE=ORCL_RMUTTO;PERSIST SECURITY INFO=True;USER ID=PERSONNEL;PASSWORD=Zxcvbnm");
            OracleDataAdapter sda = new OracleDataAdapter("SELECT UOC_ID,STF_FNAME || ' ' || STF_LNAME NAME,(SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE UOC_STAFF.STAFFTYPE_ID = REF_STAFFTYPE.STAFFTYPE_ID) STAFF_NAME, (SELECT FAC_NAME FROM REF_FAC WHERE UOC_STAFF.DEPARTMENT_ID = REF_FAC.FAC_ID) FAC_NAME FROM UOC_STAFF", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeater.DataSource = dt;
            myRepeater.DataBind();
            
        }
        protected void doIt(object sender, EventArgs e)
        {/*
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT GRAD_LEV_ID FROM UOC_STAFF", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(0) != "30" || reader.GetString(0) != "35" || reader.GetString(0) != "40" || reader.GetString(0) != "50" || reader.GetString(0) != "60" || reader.GetString(0) != "70" || reader.GetString(0) != "80" || reader.GetString(0) != "90")
                            {
                                using (OracleCommand com1 = new OracleCommand("UPDATE UOC_STAFF SET GRAD_LEV_ID = (null) where UOC_ID = ", con))
                                {
                                    com1.ExecuteNonQuery();
                                }
                            }

                        }
                    }
                }
            }

                MultiView1.Visible = true;
            MultiView1.ActiveViewIndex = 0;
        */}
    }
}