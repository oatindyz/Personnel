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
    public partial class editproject_admin : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Notsuccess.Visible = true;
            success.Visible = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
                    BindDDL();
                    ReadSelectID();
                } else { Response.Redirect("listproject-admin.aspx"); }
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlCategory, "SELECT * FROM TB_PROJECT_CATEGORY ORDER BY CATEGORY_ID", "CATEGORY_NAME", "CATEGORY_ID", "--กรุณาเลือก--");
        }

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT (SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) || ' ' || STF_FNAME || ' ' || STF_LNAME FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) NAME, (SELECT (SELECT POSITION_NAME_TH FROM REF_POSITION WHERE REF_POSITION.POSITION_ID = UOC_STAFF.POSITION_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) POSITION_NAME,(SELECT (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) FROM UOC_STAFF WHERE UOC_STAFF.UOC_ID = TB_PROJECT.UOC_ID) DEPART_NAME , CATEGORY_ID, PROJECT_NAME, ADDRESS_PROJECT, START_DATE, END_DATE, EXPENSES, FUNDING, CERTIFICATE, SUMMARIZE_PROJECT, RESULT_TEACHING, RESULT_ACADEMIC, DIFFICULTY_PROJECT, RESULT_PROJECT, RESULT_RESEARCHING, RESULT_OTHER, COUNSEL FROM TB_PROJECT WHERE PRO_ID = '" + id + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            lbName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPosition.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDepartment.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            ddlCategory.SelectedValue = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbProjectName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbAddressProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbStartDate.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            tbEndDate.Text = reader.IsDBNull(i) ? "" : reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            tbExpenses.Text = reader.IsDBNull(i) ? "0" : reader.GetInt32(i).ToString(); ++i;
                            tbFunding.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbCertificate.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbSummarizeProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultTeaching.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultAcademic.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbDifficultyProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultProject.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultResearching.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbResultOther.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            tbCounsel.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                        }
                    }
                }
            }
        }

        protected void btnUpdateProject_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                PROJECT p = new PROJECT();
                p.CATEGORY_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                p.PROJECT_NAME = tbProjectName.Text;
                p.ADDRESS_PROJECT = tbAddressProject.Text;
                p.START_DATE = DateTime.Parse(tbStartDate.Text);
                p.END_DATE = DateTime.Parse(tbEndDate.Text);
                p.EXPENSES = Convert.ToInt32(tbExpenses.Text);
                p.FUNDING = tbFunding.Text;
                p.CERTIFICATE = tbCertificate.Text;
                p.SUMMARIZE_PROJECT = tbSummarizeProject.Text;
                p.RESULT_TEACHING = tbResultTeaching.Text;
                p.RESULT_ACADEMIC = tbResultAcademic.Text;
                p.DIFFICULTY_PROJECT = tbDifficultyProject.Text;
                p.RESULT_PROJECT = tbResultProject.Text;
                p.RESULT_RESEARCHING = tbResultResearching.Text;
                p.RESULT_OTHER = tbResultOther.Text;
                p.COUNSEL = tbCounsel.Text;
                p.PRO_ID = int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
                p.UPDATE_PROJECT();

                Notsuccess.Visible = false;
                success.Visible = true;
            }
            
        }
    }
}