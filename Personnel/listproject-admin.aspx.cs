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
    public partial class listproject_admin : System.Web.UI.Page
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
            OracleDataAdapter sda = new OracleDataAdapter("SELECT (SELECT STF_FNAME || ' ' || STF_LNAME FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) NAME, (SELECT CATEGORY_NAME FROM TB_PROJECT_CATEGORY WHERE TB_PROJECT_CATEGORY.CATEGORY_ID = TB_PROJECT.CATEGORY_ID) CATEGORY_ID, PROJECT_NAME, ADDRESS_PROJECT, PRO_ID, (SELECT ST_APPROVE_NAME FROM TB_STATUS_APPROVE WHERE TB_STATUS_APPROVE.ST_APPROVE_ID = TB_PROJECT.ST_APPROVE_ID) ST_APPROVE_NAME FROM TB_PROJECT WHERE ST_APPROVE_ID = 0 ORDER BY PRO_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeater.DataSource = dt;
            myRepeater.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var hidden = (HiddenField)item.FindControl("HF1");

            string proID = hidden.Value;
            if (hidden != null)
            {
                DatabaseManager.ExecuteNonQuery("DELETE TB_PROJECT WHERE PRO_ID = '" + proID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
            }
        }

        protected void myRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Preview" && e.CommandArgument.ToString() != "")
            {
                LinkButton lbu = (LinkButton)e.Item.FindControl("lbuPreview");
                string value = lbu.CommandArgument;
                Response.Redirect("previewproject-admin.aspx?id=" + value);
            }
            if (e.CommandName == "Edit" && e.CommandArgument.ToString() != "")
            {
                LinkButton lbu = (LinkButton)e.Item.FindControl("lbuEdit");
                string value = lbu.CommandArgument;
                Response.Redirect("editproject-admin.aspx?id=" + value);
            }
            if (e.CommandName == "Delete" && e.CommandArgument.ToString() != "")
            {
                LinkButton lbu = (LinkButton)e.Item.FindControl("lbuDelete");
                string value = lbu.CommandArgument;
                DatabaseManager.ExecuteNonQuery("DELETE TB_PROJECT WHERE PRO_ID = '" + value + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                myRepeater.DataBind();
            }
        }

    }
}