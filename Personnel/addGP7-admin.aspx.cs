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
    public partial class addGP7_admin : System.Web.UI.Page
    {
        int id = 0;
        string p;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
                }
                BindData();
            }

            if (HF1.Value != "")
            {
                p = HF1.Value;
            }

            if (p == null)
            {
                selectTab("1");
                if (CreateSelectPersonPageLoad(this, "addGP7-admin.aspx"))
                {
                    return;
                }
            }
            
        }

        public bool CreateSelectPersonPageLoad(Page page, string pageURL)
        {
            if (p == null)
            {
                p = MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString());
                HF1.Value = p;
                return true;
            }

            return false;
        }

        private void selectTab(string _tab)
        {
            divTab1.Visible = false;
            divTab2.Visible = false;
            divTab3.Visible = false;
            divTab4.Visible = false;
            divTab5.Visible = false;
            divTab6.Visible = false;
            lbuTab1.CssClass = "ps-tab-unselected";
            lbuTab2.CssClass = "ps-tab-unselected";
            lbuTab3.CssClass = "ps-tab-unselected";
            lbuTab4.CssClass = "ps-tab-unselected";
            lbuTab5.CssClass = "ps-tab-unselected";
            lbuTab6.CssClass = "ps-tab-unselected";

            if (_tab == "1")
            {
                divTab1.Visible = true;
                lbuTab1.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            else if (_tab == "2")
            {
                divTab2.Visible = true;
                lbuTab2.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            else if (_tab == "3")
            {
                divTab3.Visible = true;
                lbuTab3.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            else if (_tab == "4")
            {
                divTab4.Visible = true;
                lbuTab4.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            else if (_tab == "5")
            {
                divTab5.Visible = true;
                lbuTab5.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
            else if (_tab == "6")
            {
                divTab6.Visible = true;
                lbuTab6.CssClass = "ps-tab-selected";
                notification.Attributes["class"] = "none";
                notification.InnerHtml = "";
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["addGP7-admin"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["addGP7-admin"] = data;
        }

        #endregion

        void BindData()
        {
            PS_STUDY PStudy = new PS_STUDY();
            DataTable dt1 = PStudy.SELECT_PS_STUDY("", MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), "", "", "", "");
            GridViewStudy.DataSource = dt1;
            GridViewStudy.DataBind();
            SetViewState(dt1);

            PS_PRO_LICENSE PLicense = new PS_PRO_LICENSE();
            DataTable dt2 = PLicense.SELECT_PS_PRO_LICENSE("", MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), "", "", "", "");
            GridViewLicense.DataSource = dt2;
            GridViewLicense.DataBind();
            SetViewState(dt2);

            PS_TRAINING Training = new PS_TRAINING();
            DataTable dt3 = Training.SELECT_PS_TRAINING("", MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), "", "", "", "");
            GridViewTraining.DataSource = dt3;
            GridViewTraining.DataBind();
            SetViewState(dt3);

            PS_PUNISHMENT Punishment = new PS_PUNISHMENT();
            DataTable dt4 = Punishment.SELECT_PS_PUNISHMENT("", MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), "", "", "");
            GridViewPunish.DataSource = dt4;
            GridViewPunish.DataBind();
            SetViewState(dt4);

            PS_POSI_AND_SALARY PosiSalary = new PS_POSI_AND_SALARY();
            DataTable dt5 = PosiSalary.SELECT_PS_POSI_AND_SALARY("", MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), "", "", "", "", "", "", "", "");
            GridViewPosiSalary.DataSource = dt5;
            GridViewPosiSalary.DataBind();
            SetViewState(dt5);
        }
        //11111111111111111111111111111111111111111111111111111111111111111111
        protected void modEditCommand1(Object sender, GridViewEditEventArgs e)
        {
            GridViewStudy.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void modCancelCommand1(Object sender, GridViewCancelEditEventArgs e)
        {
            GridViewStudy.EditIndex = -1;
            BindData();
        }
        protected void modDeleteCommand1(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewStudy.DataKeys[e.RowIndex].Value);
            PS_STUDY PStudy = new PS_STUDY();
            PStudy.STUDY_ID = id;
            PStudy.DELETE_PS_STUDY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridViewStudy.EditIndex = -1;
            BindData();
        }
        protected void modUpdateCommand1(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblStudyID10 = (Label)GridViewStudy.Rows[e.RowIndex].FindControl("lblStudyID10");
            Label lblStudyUOC_ID10 = (Label)GridViewStudy.Rows[e.RowIndex].FindControl("lblStudyUOC_ID10");
            TextBox txtUNIV_NAME10 = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtUNIV_NAME10");
            TextBox txtSTART_DATE10 = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtSTART_DATE10");
            TextBox txtEND_DATE10 = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtEND_DATE10");
            TextBox txtQUALIFICATION10 = (TextBox)GridViewStudy.Rows[e.RowIndex].FindControl("txtQUALIFICATION10");
            

            PS_STUDY PStudy = new PS_STUDY(Convert.ToInt32(lblStudyID10.Text)
                , Convert.ToInt32(lblStudyUOC_ID10.Text)
                , txtUNIV_NAME10.Text
                , DateTime.Parse(txtSTART_DATE10.Text)
                , DateTime.Parse(txtEND_DATE10.Text)
                , txtQUALIFICATION10.Text);

            PStudy.UPDATE_PS_STUDY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridViewStudy.EditIndex = -1;
            BindData();
        }
        protected void GridViewStudy_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบใช่หรือไม่ ?');");
            }
        }
        protected void myGridViewStudy_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridViewStudy.PageIndex = e.NewPageIndex;
            GridViewStudy.DataSource = GetViewState();
            GridViewStudy.DataBind();
        }

        //22222222222222222222222222222222222222222222222222222222222222222222
        protected void modEditCommand2(Object sender, GridViewEditEventArgs e)
        {
            GridViewLicense.EditIndex = e.NewEditIndex;
            BindData();

        }
        protected void modCancelCommand2(Object sender, GridViewCancelEditEventArgs e)
        {
            GridViewLicense.EditIndex = -1;
            BindData();
        }
        protected void modDeleteCommand2(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewLicense.DataKeys[e.RowIndex].Value);
            PS_PRO_LICENSE PStudy = new PS_PRO_LICENSE();
            PStudy.PRO_ID = id;
            PStudy.DELETE_PS_PRO_LICENSE();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridViewLicense.EditIndex = -1;
            BindData();
        }
        protected void modUpdateCommand2(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblProID11 = (Label)GridViewLicense.Rows[e.RowIndex].FindControl("lblProID11");
            Label lblProUOC_ID11 = (Label)GridViewLicense.Rows[e.RowIndex].FindControl("lblProUOC_ID11");
            TextBox txtLICENSE_NAME11 = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtLICENSE_NAME11");
            TextBox txtDEPARTMENT11 = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtDEPARTMENT11");
            TextBox txtLICENSE_NUMBER11 = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtLICENSE_NUMBER11");
            TextBox txtSTART_DATE11 = (TextBox)GridViewLicense.Rows[e.RowIndex].FindControl("txtSTART_DATE11");


            PS_PRO_LICENSE PStudy = new PS_PRO_LICENSE(Convert.ToInt32(lblProID11.Text)
                , Convert.ToInt32(lblProUOC_ID11.Text)
                , txtLICENSE_NAME11.Text
                , txtDEPARTMENT11.Text
                , txtLICENSE_NUMBER11.Text
                , DateTime.Parse(txtSTART_DATE11.Text));

            PStudy.UPDATE_PS_PRO_LICENSE();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridViewLicense.EditIndex = -1;
            BindData();
        }
        protected void GridViewLicense_RowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบใช่หรือไม่ ?');");
            }
        }
        protected void myGridViewLicense_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            GridViewLicense.PageIndex = e.NewPageIndex;
            GridViewLicense.DataSource = GetViewState();
            GridViewLicense.DataBind();
        }

        //3333333333333333333333333333333333333333333333333333333333333333333
        protected void modEditCommand3(Object sender, GridViewEditEventArgs e)
        {
            GridViewTraining.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void modCancelCommand3(Object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTraining.EditIndex = -1;
            BindData();
        }
        protected void modDeleteCommand3(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewTraining.DataKeys[e.RowIndex].Value);
            PS_TRAINING PStudy = new PS_TRAINING();
            PStudy.TRAINING_ID = id;
            PStudy.DELETE_PS_TRAINING();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridViewTraining.EditIndex = -1;
            BindData();
        }
        protected void modUpdateCommand3(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblTrainingID12 = (Label)GridViewTraining.Rows[e.RowIndex].FindControl("lblTrainingID12");
            Label lblTrainingUOC_ID12 = (Label)GridViewTraining.Rows[e.RowIndex].FindControl("lblTrainingUOC_ID12");
            TextBox txtTRAINING_NAME12 = (TextBox)GridViewTraining.Rows[e.RowIndex].FindControl("txtTRAINING_NAME12");
            TextBox txtSTART_DATE12 = (TextBox)GridViewTraining.Rows[e.RowIndex].FindControl("txtSTART_DATE12");
            TextBox txtEND_DATE12 = (TextBox)GridViewTraining.Rows[e.RowIndex].FindControl("txtEND_DATE12");
            TextBox txtDEPARTMENT12 = (TextBox)GridViewTraining.Rows[e.RowIndex].FindControl("txtDEPARTMENT12");


            PS_TRAINING PStudy = new PS_TRAINING(Convert.ToInt32(lblTrainingID12.Text)
                , Convert.ToInt32(lblTrainingUOC_ID12.Text)
                , txtTRAINING_NAME12.Text
                , DateTime.Parse(txtSTART_DATE12.Text)
                , DateTime.Parse(txtEND_DATE12.Text)
                , txtDEPARTMENT12.Text);

            PStudy.UPDATE_PS_TRAINING();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridViewTraining.EditIndex = -1;
            BindData();
        }
        protected void GridViewTraining_RowDataBound3(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบใช่หรือไม่ ?');");
            }
        }
        protected void myGridViewTraining_PageIndexChanging3(object sender, GridViewPageEventArgs e)
        {
            GridViewTraining.PageIndex = e.NewPageIndex;
            GridViewTraining.DataSource = GetViewState();
            GridViewTraining.DataBind();
        }

        //4444444444444444444444444444444444444444444444444444444444444444444
        protected void modEditCommand4(Object sender, GridViewEditEventArgs e)
        {
            GridViewPunish.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void modCancelCommand4(Object sender, GridViewCancelEditEventArgs e)
        {
            GridViewPunish.EditIndex = -1;
            BindData();
        }
        protected void modDeleteCommand4(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewPunish.DataKeys[e.RowIndex].Value);
            PS_PUNISHMENT PStudy = new PS_PUNISHMENT();
            PStudy.PUNISH_ID = id;
            PStudy.DELETE_PS_PUNISHMENT();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridViewPunish.EditIndex = -1;
            BindData();
        }
        protected void modUpdateCommand4(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblPUNISH_ID13 = (Label)GridViewPunish.Rows[e.RowIndex].FindControl("lblPUNISH_ID13");
            Label lblPunishUOC_ID13 = (Label)GridViewPunish.Rows[e.RowIndex].FindControl("lblPunishUOC_ID13");
            TextBox txtYEAR13 = (TextBox)GridViewPunish.Rows[e.RowIndex].FindControl("txtYEAR13");
            TextBox txtPUNISH_NAME13 = (TextBox)GridViewPunish.Rows[e.RowIndex].FindControl("txtPUNISH_NAME13");
            TextBox txtREF_DOC13 = (TextBox)GridViewPunish.Rows[e.RowIndex].FindControl("txtREF_DOC13");


            PS_PUNISHMENT PStudy = new PS_PUNISHMENT(Convert.ToInt32(lblPUNISH_ID13.Text)
                , Convert.ToInt32(lblPunishUOC_ID13.Text)
                , txtYEAR13.Text
                , txtPUNISH_NAME13.Text
                , txtREF_DOC13.Text);

            PStudy.UPDATE_PS_PUNISHMENT();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridViewPunish.EditIndex = -1;
            BindData();
        }
        protected void GridViewPunish_RowDataBound4(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบใช่หรือไม่ ?');");
            }
        }
        protected void myGridViewPunish_PageIndexChanging4(object sender, GridViewPageEventArgs e)
        {
            GridViewPunish.PageIndex = e.NewPageIndex;
            GridViewPunish.DataSource = GetViewState();
            GridViewPunish.DataBind();
        }

        //5555555555555555555555555555555555555555555555555555555555555555555
        protected void modEditCommand5(Object sender, GridViewEditEventArgs e)
        {
            GridViewPosiSalary.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void modCancelCommand5(Object sender, GridViewCancelEditEventArgs e)
        {
            GridViewPosiSalary.EditIndex = -1;
            BindData();
        }
        protected void modDeleteCommand5(Object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewPosiSalary.DataKeys[e.RowIndex].Value);
            PS_POSI_AND_SALARY PStudy = new PS_POSI_AND_SALARY();
            PStudy.PAS_ID = id;
            PStudy.DELETE_PS_POSI_AND_SALARY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridViewPosiSalary.EditIndex = -1;
            BindData();
        }
        protected void modUpdateCommand5(Object sender, GridViewUpdateEventArgs e)
        {
            Label lblPAS_ID14 = (Label)GridViewPosiSalary.Rows[e.RowIndex].FindControl("lblPAS_ID14");
            Label lblPosiSalaryUOC_ID14 = (Label)GridViewPosiSalary.Rows[e.RowIndex].FindControl("lblPosiSalaryUOC_ID14");
            TextBox txtSTART_DATE14 = (TextBox)GridViewPosiSalary.Rows[e.RowIndex].FindControl("txtSTART_DATE14");
            TextBox txtPAS_NAME14 = (TextBox)GridViewPosiSalary.Rows[e.RowIndex].FindControl("txtPAS_NAME14");
            TextBox txtNO_POSITION14 = (TextBox)GridViewPosiSalary.Rows[e.RowIndex].FindControl("txtNO_POSITION14");
            TextBox txtPOSITION_TYPE14 = (TextBox)GridViewPosiSalary.Rows[e.RowIndex].FindControl("txtPOSITION_TYPE14");
            TextBox txtPOSITION_DEGREE14 = (TextBox)GridViewPosiSalary.Rows[e.RowIndex].FindControl("txtPOSITION_DEGREE14");
            TextBox txtSALARY14 = (TextBox)GridViewPosiSalary.Rows[e.RowIndex].FindControl("txtSALARY14");
            TextBox txtPOSITION_SALARY14 = (TextBox)GridViewPosiSalary.Rows[e.RowIndex].FindControl("txtPOSITION_SALARY14");
            TextBox txtREF_DOC14 = (TextBox)GridViewPosiSalary.Rows[e.RowIndex].FindControl("txtREF_DOC14");


            PS_POSI_AND_SALARY PStudy = new PS_POSI_AND_SALARY(Convert.ToInt32(lblPAS_ID14.Text)
                , Convert.ToInt32(lblPosiSalaryUOC_ID14.Text)
                , DateTime.Parse(txtSTART_DATE14.Text)
                , txtPAS_NAME14.Text
                , txtNO_POSITION14.Text
                , txtPOSITION_TYPE14.Text
                , txtPOSITION_DEGREE14.Text
                , Convert.ToInt32(txtSALARY14.Text)
                , Convert.ToInt32(txtPOSITION_SALARY14.Text)
                , txtREF_DOC14.Text);

            PStudy.UPDATE_PS_POSI_AND_SALARY();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
            GridViewPosiSalary.EditIndex = -1;
            BindData();
        }
        protected void GridViewPosiSalary_RowDataBound5(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบใช่หรือไม่ ?');");
            }
        }
        protected void myGridViewPosiSalary_PageIndexChanging5(object sender, GridViewPageEventArgs e)
        {
            GridViewPosiSalary.PageIndex = e.NewPageIndex;
            GridViewPosiSalary.DataSource = GetViewState();
            GridViewPosiSalary.DataBind();
        }

        protected void lbuTab1_Click(object sender, EventArgs e)
        {
            selectTab("1");
        }
        protected void lbuTab2_Click(object sender, EventArgs e)
        {
            selectTab("2");
        }
        protected void lbuTab3_Click(object sender, EventArgs e)
        {
            selectTab("3");
        }
        protected void lbuTab4_Click(object sender, EventArgs e)
        {
            selectTab("4");
        }
        protected void lbuTab5_Click(object sender, EventArgs e)
        {
            selectTab("5");
        }
        protected void lbuTab6_Click(object sender, EventArgs e)
        {
            selectTab("6");
        }

        protected void ClearGP7()
        {
            tbFatherName.Text = "";
            tbFatherLastName.Text = "";
            tbMotherName.Text = "";
            tbMotherLastName.Text = "";
            tbCoupleName.Text = "";
            tbCoupleLastName.Text = "";
        }

        protected void ClearStudy10()
        {
            tbUnivName10.Text = "";
            tbStartDate10.Text = "";
            tbEndDate10.Text = "";
            tbCertificate10.Text = "";
        }

        protected void ClearPLicense()
        {
            tbLicenseName11.Text = "";
            tbDepartment11.Text = "";
            tbLicenseNumber11.Text = "";
            tbStartDate11.Text = "";
        }

        protected void ClearTraining()
        {
            tbCourse12.Text = "";
            tbStartDate12.Text = "";
            tbEndDate12.Text = "";
            tbDepartment12.Text = "";
        }

        protected void ClearPunish()
        {
            tbYear13.Text = "";
            tbPunishName13.Text = "";
            tbRefDoc13.Text = "";
        }

        protected void ClearPositionAndSalary()
        {
            tbStartDate14.Text = "";
            tbName14.Text = "";
            tbNoPosition14.Text = "";
            tbPosiType14.Text = "";
            tbPosiDegree14.Text = "";
            tbSalary14.Text = "";
            tbPosiSalary14.Text = "";
            tbRefDoc14.Text = "";
        }

        protected void btnSave1_Click(object sender, EventArgs e)
        {
            PS_PERSON Pson = new PS_PERSON();
            Pson.UOC_ID = Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
            Pson.FATHER_NAME = tbFatherName.Text;
            Pson.FATHER_LNAME = tbFatherLastName.Text;
            Pson.MOTHER_NAME = tbMotherName.Text;
            Pson.MOTHER_LNAME = tbMotherLastName.Text;
            Pson.COUPLE_NAME = tbCoupleName.Text;
            Pson.COUPLE_LNAME = tbCoupleLastName.Text;
            Pson.INSERT_GP7();

            ClearGP7();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
        }

        protected void btnSave2_Click(object sender, EventArgs e)
        {
            PS_STUDY PStudy = new PS_STUDY();
            PStudy.UOC_ID = Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
            PStudy.UNIV_NAME = tbUnivName10.Text;
            PStudy.START_DATE = DateTime.Parse(tbStartDate10.Text);
            PStudy.END_DATE = DateTime.Parse(tbEndDate10.Text);
            PStudy.QUALIFICATION = tbCertificate10.Text;
            PStudy.INSERT_PS_STUDY();

            ClearStudy10();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindData();
        }

        protected void btnSave3_Click(object sender, EventArgs e)
        {
            PS_PRO_LICENSE PLicense = new PS_PRO_LICENSE();
            PLicense.UOC_ID = Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
            PLicense.LICENSE_NAME = tbLicenseName11.Text;
            PLicense.DEPARTMENT = tbDepartment11.Text;
            PLicense.LICENSE_NUMBER = tbLicenseNumber11.Text;
            PLicense.START_DATE = DateTime.Parse(tbStartDate11.Text);
            PLicense.INSERT_PS_PRO_LICENSE();

            ClearPLicense();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindData();
        }

        protected void btnSave4_Click(object sender, EventArgs e)
        {
            PS_TRAINING Training = new PS_TRAINING();
            Training.UOC_ID = Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
            Training.TRAINING_NAME = tbCourse12.Text;
            Training.START_DATE = DateTime.Parse(tbStartDate12.Text);
            Training.END_DATE = DateTime.Parse(tbEndDate12.Text);
            Training.DEPARTMENT = tbDepartment12.Text;
            Training.INSERT_PS_TRAINING();

            ClearTraining();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindData();
        }

        protected void btnSave5_Click(object sender, EventArgs e)
        {
            PS_PUNISHMENT Punish = new PS_PUNISHMENT();
            Punish.UOC_ID = Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
            Punish.YEAR = tbYear13.Text;
            Punish.PUNISH_NAME = tbPunishName13.Text;
            Punish.REF_DOC = tbRefDoc13.Text;
            Punish.INSERT_PS_PUNISHMENT();

            ClearPunish();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindData();
        }

        protected void btnSave6_Click(object sender, EventArgs e)
        {
            PS_POSI_AND_SALARY PosiSalary = new PS_POSI_AND_SALARY();
            PosiSalary.UOC_ID = Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
            PosiSalary.START_DATE = DateTime.Parse(tbStartDate14.Text);
            PosiSalary.PAS_NAME = tbName14.Text;
            PosiSalary.NO_POSITION = tbNoPosition14.Text;
            PosiSalary.POSITION_TYPE = tbPosiType14.Text;
            PosiSalary.POSITION_DEGREE = tbPosiDegree14.Text;
            PosiSalary.SALARY = Convert.ToInt32(tbSalary14.Text);
            PosiSalary.POSITION_SALARY = Convert.ToInt32(tbPosiSalary14.Text);
            PosiSalary.REF_DOC = tbRefDoc14.Text;
            PosiSalary.INSERT_PS_POSI_AND_SALARY();

            ClearPositionAndSalary();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindData();
        }
    }
}