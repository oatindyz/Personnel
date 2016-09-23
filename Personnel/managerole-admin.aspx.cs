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
    public partial class managerole_admin : System.Web.UI.Page
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
            OracleConnection con = new OracleConnection("DATA SOURCE=ORCL_RMUTTO;PERSIST SECURITY INFO=True;USER ID=PERSONNEL;PASSWORD=Zxcvbnm");
            OracleDataAdapter sda = new OracleDataAdapter("SELECT UOC_ID,STF_FNAME || ' ' || STF_LNAME NAME, (SELECT FAC_NAME FROM REF_FAC WHERE UOC_STAFF.DEPARTMENT_ID = REF_FAC.FAC_ID) FAC_NAME, PERSON_ROLE_ID FROM UOC_STAFF", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeater.DataSource = dt;
            myRepeater.DataBind();
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var id = (Label)item.FindControl("lbID");
            var ddl = (DropDownList)item.FindControl("ddlRole");

            string uocID = id.Text;
            string value = ddl.SelectedValue;
            TextBox1.Text = value;
            TextBox2.Text = uocID;

            if (uocID != null && value != null)
            {
                DatabaseManager.ExecuteNonQuery("UPDATE UOC_STAFF SET PERSON_ROLE_ID = '" + value + "' WHERE UOC_ID = '" + uocID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            }
            
        }
    }   
}