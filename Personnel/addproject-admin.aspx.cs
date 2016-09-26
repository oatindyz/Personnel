using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Personnel.Class;
using System.Data.OracleClient;

namespace Personnel
{
    public partial class addproject_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Notsuccess.Visible = true;
            success.Visible = false;

            if (!IsPostBack)
            {
                BindDDL();
                BindData();
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlCategory, "SELECT * FROM TB_PROJECT_CATEGORY ORDER BY CATEGORY_ID", "CATEGORY_NAME", "CATEGORY_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlPosition, "SELECT * FROM REF_POSITION ORDER BY POSITION_ID", "POSITION_NAME_TH", "POSITION_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlCategoryCountry, "SELECT * FROM TB_PROJECT_COUNTRY ORDER BY COUNTRY_ID", "COUNTRY_NAME", "COUNTRY_ID", "--กรุณาเลือก--");
            ddlCategoryCountrySub.Items.Insert(0, new ListItem("--กรุณาเลือก--", ""));

            DatabaseManager.ExeDDLselectNameAndLast(ddlNameLastName, "SELECT UOC_ID, (SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) || ' ' || STF_FNAME || ' ' || STF_LNAME NAME FROM UOC_STAFF");
            ddlNameLastName.Items.Insert(0, new ListItem("--กรุณาเลือก--", ""));
        }

        protected void BindData()
        {
            lbYear.Text = DatabaseManager.ExecuteString("select to_char(sysdate, 'YYYY')+543 CUR_YEAR from dual");
            lbDepartment.Text = DatabaseManager.ExecuteString("SELECT (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME FROM UOC_STAFF WHERE UOC_ID = '" + ddlNameLastName.SelectedValue + "'");
            lbGradCURR.Text = DatabaseManager.ExecuteString("SELECT GRAD_CURR FROM UOC_STAFF WHERE UOC_ID = '" + ddlNameLastName.SelectedValue + "'");
        }

        protected void lbuAddPerson_Click(object sender, EventArgs e)
        {

            //
            Notsuccess.Visible = false;
            success.Visible = true;
        }

        protected void ddlCategoryCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlConn = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    using (OracleCommand sqlCmd = new OracleCommand())
                    {
                        sqlCmd.CommandText = "select * from TB_PROJECT_COUNTRY_SUB where COUNTRY_ID=:COUNTRY_ID";
                        sqlCmd.Parameters.Add(":COUNTRY_ID", ddlCategoryCountry.SelectedValue);
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        OracleDataAdapter da = new OracleDataAdapter(sqlCmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlCategoryCountrySub.DataSource = dt;
                        ddlCategoryCountrySub.DataValueField = "COUNTRY_SUB_ID";
                        ddlCategoryCountrySub.DataTextField = "COUNTRY_SUB_NAME";
                        ddlCategoryCountrySub.DataBind();
                        sqlConn.Close();

                        ddlCategoryCountrySub.Items.Insert(0, new ListItem("--กรุณาเลือก--", ""));
                    }
                }
            }
            catch { }
        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            if (tbStartDate.Text != "" && tbEndDate.Text != "")
            {
                DateTime dtEndDate = DateTime.Parse(tbEndDate.Text);
                DateTime dtStartDate = DateTime.Parse(tbStartDate.Text);
                int totalDay = (int)(dtEndDate - dtStartDate).TotalDays + 1;

                if (totalDay <= 0)
                {
                    notification.Attributes["class"] = "alert alert_danger";
                    notification.InnerHtml = "";
                    notification.InnerHtml += "<div> <img src='Image/Small/red_alert.png' /> วันที่เริ่มโครงการ - วันที่สิ้นสุดโครงการ : วันที่ไม่ถูกต้อง !</div>";
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.tbStartDate);
                    return;
                }
                else
                {
                    notification.Attributes["class"] = "none";
                    notification.InnerHtml = "";
                }
            }


        }

        protected void ddlNameLastName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbDepartment.Text = DatabaseManager.ExecuteString("SELECT (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME FROM UOC_STAFF WHERE UOC_ID = '" + ddlNameLastName.SelectedValue + "'");
            lbGradCURR.Text = DatabaseManager.ExecuteString("SELECT GRAD_CURR FROM UOC_STAFF WHERE UOC_ID = '" + ddlNameLastName.SelectedValue + "'");
        }
    }
}