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
    public partial class addproject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Notsuccess.Visible = true;
            success.Visible = false;

            if (!IsPostBack)
            {
                BindDDL();
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlCategory, "SELECT * FROM TB_PROJECT_CATEGORY ORDER BY CATEGORY_ID", "CATEGORY_NAME", "CATEGORY_ID", "--กรุณาเลือก--");
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
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            PROJECT p = new PROJECT();

            p.UOC_ID = loginPerson.UOC_ID;
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
            p.ST_APPROVE_ID = 0;

            p.INSERT_PROJECT();

            Notsuccess.Visible = false;
            success.Visible = true;

        }

    }
}