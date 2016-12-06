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
    public partial class insig_admin : System.Web.UI.Page
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
            OracleDataAdapter sda = new OracleDataAdapter("SELECT IS_ID, (SELECT STF_FNAME || ' ' || STF_LNAME FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_INSIG.UOC_ID) NAME, (SELECT (SELECT FAC_NAME FROM REF_FAC WHERE UOC_STAFF.DEPARTMENT_ID = REF_FAC.FAC_ID) DEPARTMENT_ID FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_INSIG.UOC_ID) FAC_NAME FROM TB_INSIG WHERE IS_STATUS = 1 ORDER BY IS_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeater.DataSource = dt;
            myRepeater.DataBind();
        }

        protected void myRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select" && e.CommandArgument.ToString() != "")
            {
                LinkButton lbu = (LinkButton)e.Item.FindControl("lbuSelect");
                string value = lbu.CommandArgument;
            }
        }

    }
}