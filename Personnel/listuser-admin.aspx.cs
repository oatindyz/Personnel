using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Text;
using Personnel.Class;

namespace Personnel
{
    public partial class listuser_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=ORCL_RMUTTO;PERSIST SECURITY INFO=True;USER ID=PERSONNEL;PASSWORD=Zxcvbnm");
                OracleDataAdapter sda = new OracleDataAdapter("SELECT UOC_ID,STF_FNAME || ' ' || STF_LNAME NAME,(SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE UOC_STAFF.STAFFTYPE_ID = REF_STAFFTYPE.STAFFTYPE_ID) STAFF_NAME, (SELECT FAC_NAME FROM REF_FAC WHERE UOC_STAFF.DEPARTMENT_ID = REF_FAC.FAC_ID) FAC_NAME FROM UOC_STAFF", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                myRepeater.DataSource = dt;
                myRepeater.DataBind();
            }
        }

    }
}