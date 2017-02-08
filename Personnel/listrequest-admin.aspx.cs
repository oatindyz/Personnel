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
    public partial class listrequest_admin : System.Web.UI.Page
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
            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT (SELECT STF_FNAME || ' ' || STF_LNAME FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_EDIT.UOC_ID) NAME, (SELECT (SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE UOC_STAFF.STAFFTYPE_ID = REF_STAFFTYPE.STAFFTYPE_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_EDIT.UOC_ID) STAFF_NAME, (SELECT (SELECT FAC_NAME FROM REF_FAC WHERE UOC_STAFF.DEPARTMENT_ID = REF_FAC.FAC_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_EDIT.UOC_ID) FAC_NAME, ID_EDIT FROM TB_EDIT WHERE STATUS_ID = 0 ORDER BY ID_EDIT ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeater.DataSource = dt;
            myRepeater.DataBind();
        }

        protected void myRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit" && e.CommandArgument.ToString() != "")
            {
                LinkButton lbu = (LinkButton)e.Item.FindControl("lbuEdit");
                string value = lbu.CommandArgument;
                Response.Redirect("managerequestlist.aspx?id=" + value);
            }
        }

    }
}