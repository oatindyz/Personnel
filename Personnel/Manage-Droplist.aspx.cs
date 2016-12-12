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
    public partial class Manage_Droplist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlInsertStatusUniv, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusTitle, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusGender, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusProvince, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusAmphur, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusTambon, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusNation, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusStafftype, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusTimeContact, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusBudget, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusSubStafftype, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusAdminPosition, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusPosition, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusDepartment, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusTeachISCED, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusGradLev, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusGradProg, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusDeform, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusReligion, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlInsertStatusMovementType, "SELECT * FROM TB_STATUS_ACTIVE ORDER BY STATUS_ID", "STATUS_NAME", "STATUS_ID", "--กรุณาเลือก--");
        }

        protected void BindUniv()
        {
            Panel1.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT UNIV_ID,UNIV_NAME_TH,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_UNIV.STATUS_ID) STATUS_NAME FROM REF_UNIV ORDER BY UNIV_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterUniv.DataSource = dt;
            myRepeaterUniv.DataBind();

            divheader1.Visible = true;
            divInsertUniv.Visible = true;
            divLoadUniv.Visible = true;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearUniv()
        {
            tbInsertIdUniv.Text = "";
            tbInsertNameUniv.Text = "";
            ddlInsertStatusUniv.SelectedIndex = 0;
        }

        protected void lbuMenuUniv_Click(object sender, EventArgs e)
        {
            BindUniv();
        }

        protected void btnInsertUniv_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_UNIV (UNIV_ID,UNIV_NAME_TH,STATUS_ID) VALUES (" + tbInsertIdUniv.Text + "," + tbInsertNameUniv.Text + "," + ddlInsertStatusUniv.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindUniv();
            ClearUniv();
        }

        protected void btnUpdateUniv_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdUniv.Text;
            string ValueName = tbInsertNameUniv.Text;
            string ValueStatus = ddlInsertStatusUniv.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_UNIV SET UNIV_ID = '" + ValueID + "', UNIV_NAME_TH = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE UNIV_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindUniv();
                ClearUniv();
            }
        }

        protected void lbuClearUniv_Click(object sender, EventArgs e)
        {
            BindUniv();
            ClearUniv();
        }

        protected void OnEditUniv(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbUnivID") as Label).Text;
            string ValueName = (item.FindControl("lbUnivName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlUnivStatus") as DropDownList).SelectedValue;

            tbInsertIdUniv.Text = ValueID;
            tbInsertNameUniv.Text = ValueName;
            ddlInsertStatusUniv.SelectedValue = ValueStatus;
        }

        protected void OnDeleteUniv(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbUnivID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_UNIV WHERE UNIV_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindUniv();
            }
        }
        //
        protected void BindTitle()
        {
            Panel2.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT PREFIX_NAME_ID,FULLNAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_PREFIX_NAME.STATUS_ID) STATUS_NAME FROM REF_PREFIX_NAME ORDER BY PREFIX_NAME_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterTitle.DataSource = dt;
            myRepeaterTitle.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = true;
            divInsertTitle.Visible = true;
            divLoadTitle.Visible = true;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearTitle()
        {
            tbInsertIdTitle.Text = "";
            tbInsertNameTitle.Text = "";
            ddlInsertStatusTitle.SelectedIndex = 0;
        }

        protected void lbuMenuTitle_Click(object sender, EventArgs e)
        {
            BindTitle();
        }

        protected void btnInsertTitle_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_PREFIX_NAME (PREFIX_NAME_ID,FULLNAME,STATUS_ID) VALUES (" + tbInsertIdTitle.Text + "," + tbInsertNameTitle.Text + "," + ddlInsertStatusTitle.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindTitle();
            ClearTitle();
        }

        protected void btnUpdateTitle_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdTitle.Text;
            string ValueName = tbInsertNameTitle.Text;
            string ValueStatus = ddlInsertStatusTitle.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_PREFIX_NAME SET PREFIX_NAME_ID = '" + ValueID + "', FULLNAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE PREFIX_NAME_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindTitle();
                ClearTitle();
            }
        }

        protected void lbuClearTitle_Click(object sender, EventArgs e)
        {
            BindTitle();
            ClearTitle();
        }

        protected void OnEditTitle(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbTitleID") as Label).Text;
            string ValueName = (item.FindControl("lbTitleName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlTitleStatus") as DropDownList).SelectedValue;

            tbInsertIdTitle.Text = ValueID;
            tbInsertNameTitle.Text = ValueName;
            ddlInsertStatusTitle.SelectedValue = ValueStatus;
        }

        protected void OnDeleteTitle(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbTitleID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_PREFIX_NAME WHERE PREFIX_NAME_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindTitle();
            }
        }
        //
        protected void BindGender()
        {
            Panel3.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT GENDER_ID,GENDER_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_GENDER.STATUS_ID) STATUS_NAME FROM REF_GENDER ORDER BY GENDER_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterGender.DataSource = dt;
            myRepeaterGender.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = true;
            divInsertGender.Visible = true;
            divLoadGender.Visible = true;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearGender()
        {
            tbInsertIdGender.Text = "";
            tbInsertNameGender.Text = "";
            ddlInsertStatusGender.SelectedIndex = 0;
        }

        protected void lbuMenuGender_Click(object sender, EventArgs e)
        {
            BindGender();
        }

        protected void btnInsertGender_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_GENDER (GENDER_ID,GENDER_NAME,STATUS_ID) VALUES (" + tbInsertIdGender.Text + "," + tbInsertNameGender.Text + "," + ddlInsertStatusGender.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindGender();
            ClearGender();
        }

        protected void btnUpdateGender_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdGender.Text;
            string ValueName = tbInsertNameGender.Text;
            string ValueStatus = ddlInsertStatusGender.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_GENDER SET GENDER_ID = '" + ValueID + "', GENDER_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE GENDER_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindGender();
                ClearGender();
            }
        }

        protected void lbuClearGender_Click(object sender, EventArgs e)
        {
            BindGender();
            ClearGender();
        }

        protected void OnEditGender(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbGenderID") as Label).Text;
            string ValueName = (item.FindControl("lbGenderName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlGenderStatus") as DropDownList).SelectedValue;

            tbInsertIdGender.Text = ValueID;
            tbInsertNameGender.Text = ValueName;
            ddlInsertStatusGender.SelectedValue = ValueStatus;
        }

        protected void OnDeleteGender(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbGenderID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_GENDER WHERE GENDER_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindGender();
            }
        }
        //
        protected void BindProvince()
        {
            Panel4.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT PROVINCE_ID,PROVINCE_NAME_TH,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_PROVINCE.STATUS_ID) STATUS_NAME FROM REF_PROVINCE ORDER BY PROVINCE_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterProvince.DataSource = dt;
            myRepeaterProvince.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = true;
            divInsertProvince.Visible = true;
            divLoadProvince.Visible = true;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearProvince()
        {
            tbInsertIdProvince.Text = "";
            tbInsertNameProvince.Text = "";
            ddlInsertStatusProvince.SelectedIndex = 0;
        }

        protected void lbuMenuProvince_Click(object sender, EventArgs e)
        {
            BindProvince();
        }

        protected void btnInsertProvince_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_PROVINCE (PROVINCE_ID,PROVINCE_NAME_TH,STATUS_ID) VALUES (" + tbInsertIdProvince.Text + "," + tbInsertNameProvince.Text + "," + ddlInsertStatusProvince.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindProvince();
            ClearProvince();
        }

        protected void btnUpdateProvince_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdProvince.Text;
            string ValueName = tbInsertNameProvince.Text;
            string ValueStatus = ddlInsertStatusProvince.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_PROVINCE SET PROVINCE_ID = '" + ValueID + "', PROVINCE_NAME_TH = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE PROVINCE_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindProvince();
                ClearProvince();
            }
        }

        protected void lbuClearProvince_Click(object sender, EventArgs e)
        {
            BindProvince();
            ClearProvince();
        }

        protected void OnEditProvince(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbProvinceID") as Label).Text;
            string ValueName = (item.FindControl("lbProvinceName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlProvinceStatus") as DropDownList).SelectedValue;

            tbInsertIdProvince.Text = ValueID;
            tbInsertNameProvince.Text = ValueName;
            ddlInsertStatusProvince.SelectedValue = ValueStatus;
        }

        protected void OnDeleteProvince(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbProvinceID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_PROVINCE WHERE PROVINCE_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindProvince();
            }
        }
        //
        protected void BindAmphur()
        {
            Panel5.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT DISTRICT_ID,DISTRICT_NAME_TH,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_DISTRICT.STATUS_ID) STATUS_NAME FROM REF_DISTRICT ORDER BY DISTRICT_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterAmphur.DataSource = dt;
            myRepeaterAmphur.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = true;
            divInsertAmphur.Visible = true;
            divLoadAmphur.Visible = true;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearAmphur()
        {
            tbInsertIdAmphur.Text = "";
            tbInsertNameAmphur.Text = "";
            ddlInsertStatusAmphur.SelectedIndex = 0;
        }

        protected void lbuMenuAmphur_Click(object sender, EventArgs e)
        {
            BindAmphur();
        }

        protected void btnInsertAmphur_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_DISTRICT (DISTRICT_ID,DISTRICT_NAME_TH,STATUS_ID) VALUES (" + tbInsertIdAmphur.Text + "," + tbInsertNameAmphur.Text + "," + ddlInsertStatusAmphur.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindAmphur();
            ClearAmphur();
        }

        protected void btnUpdateAmphur_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdAmphur.Text;
            string ValueName = tbInsertNameAmphur.Text;
            string ValueStatus = ddlInsertStatusAmphur.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_DISTRICT SET DISTRICT_ID = '" + ValueID + "', DISTRICT_NAME_TH = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE DISTRICT_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindAmphur();
                ClearAmphur();
            }
        }

        protected void lbuClearAmphur_Click(object sender, EventArgs e)
        {
            BindAmphur();
            ClearAmphur();
        }

        protected void OnEditAmphur(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbAmphurID") as Label).Text;
            string ValueName = (item.FindControl("lbAmphurName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlAmphurStatus") as DropDownList).SelectedValue;

            tbInsertIdAmphur.Text = ValueID;
            tbInsertNameAmphur.Text = ValueName;
            ddlInsertStatusAmphur.SelectedValue = ValueStatus;
        }

        protected void OnDeleteAmphur(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbAmphurID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_DISTRICT WHERE DISTRICT_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindAmphur();
            }
        }
        //
        protected void BindTambon()
        {
            Panel6.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT SUB_DISTRICT_ID,SUB_DISTRICT_NAME_TH,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_SUB_DISTRICT.STATUS_ID) STATUS_NAME FROM REF_SUB_DISTRICT ORDER BY SUB_DISTRICT_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterTambon.DataSource = dt;
            myRepeaterTambon.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = true;
            divInsertTambon.Visible = true;
            divLoadTambon.Visible = true;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearTambon()
        {
            tbInsertIdTambon.Text = "";
            tbInsertNameTambon.Text = "";
            ddlInsertStatusTambon.SelectedIndex = 0;
        }

        protected void lbuMenuTambon_Click(object sender, EventArgs e)
        {
            BindTambon();
        }

        protected void btnInsertTambon_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_SUB_DISTRICT (SUB_DISTRICT_ID,SUB_DISTRICT_NAME_TH,STATUS_ID) VALUES (" + tbInsertIdTambon.Text + "," + tbInsertNameTambon.Text + "," + ddlInsertStatusTambon.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindTambon();
            ClearTambon();
        }

        protected void btnUpdateTambon_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdTambon.Text;
            string ValueName = tbInsertNameTambon.Text;
            string ValueStatus = ddlInsertStatusTambon.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_SUB_DISTRICT SET SUB_DISTRICT_ID = '" + ValueID + "', SUB_DISTRICT_NAME_TH = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE SUB_DISTRICT_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindTambon();
                ClearTambon();
            }
        }

        protected void lbuClearTambon_Click(object sender, EventArgs e)
        {
            BindTambon();
            ClearTambon();
        }

        protected void OnEditTambon(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbTambonID") as Label).Text;
            string ValueName = (item.FindControl("lbTambonName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlTambonStatus") as DropDownList).SelectedValue;

            tbInsertIdTambon.Text = ValueID;
            tbInsertNameTambon.Text = ValueName;
            ddlInsertStatusTambon.SelectedValue = ValueStatus;
        }

        protected void OnDeleteTambon(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbTambonID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_SUB_DISTRICT WHERE SUB_DISTRICT_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindTambon();
            }
        }
        //
        protected void BindNation()
        {
            Panel7.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT NATION_ID,NATION_NAME_ENG,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_NATION.STATUS_ID) STATUS_NAME FROM REF_NATION ORDER BY NATION_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterNation.DataSource = dt;
            myRepeaterNation.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = true;
            divInsertNation.Visible = true;
            divLoadNation.Visible = true;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearNation()
        {
            tbInsertIdNation.Text = "";
            tbInsertNameNation.Text = "";
            ddlInsertStatusNation.SelectedIndex = 0;
        }

        protected void lbuMenuNation_Click(object sender, EventArgs e)
        {
            BindNation();
        }

        protected void btnInsertNation_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_NATION (NATION_ID,NATION_NAME_ENG,STATUS_ID) VALUES (" + tbInsertIdNation.Text + "," + tbInsertNameNation.Text + "," + ddlInsertStatusNation.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindNation();
            ClearNation();
        }

        protected void btnUpdateNation_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdNation.Text;
            string ValueName = tbInsertNameNation.Text;
            string ValueStatus = ddlInsertStatusNation.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_NATION SET NATION_ID = '" + ValueID + "', NATION_NAME_ENG = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE NATION_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindNation();
                ClearNation();
            }
        }

        protected void lbuClearNation_Click(object sender, EventArgs e)
        {
            BindNation();
            ClearNation();
        }

        protected void OnEditNation(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbNationID") as Label).Text;
            string ValueName = (item.FindControl("lbNationName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlNationStatus") as DropDownList).SelectedValue;

            tbInsertIdNation.Text = ValueID;
            tbInsertNameNation.Text = ValueName;
            ddlInsertStatusNation.SelectedValue = ValueStatus;
        }

        protected void OnDeleteNation(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbNationID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_NATION WHERE NATION_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindNation();
            }
        }
        //
        protected void BindStafftype()
        {
            Panel8.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT STAFFTYPE_ID,STAFFTYPE_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_STAFFTYPE.STATUS_ID) STATUS_NAME FROM REF_STAFFTYPE ORDER BY STAFFTYPE_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterStafftype.DataSource = dt;
            myRepeaterStafftype.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = true;
            divInsertStafftype.Visible = true;
            divLoadStafftype.Visible = true;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearStafftype()
        {
            tbInsertIdStafftype.Text = "";
            tbInsertNameStafftype.Text = "";
            ddlInsertStatusStafftype.SelectedIndex = 0;
        }

        protected void lbuMenuStafftype_Click(object sender, EventArgs e)
        {
            BindStafftype();
        }

        protected void btnInsertStafftype_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_STAFFTYPE (STAFFTYPE_ID,STAFFTYPE_NAME,STATUS_ID) VALUES (" + tbInsertIdStafftype.Text + "," + tbInsertNameStafftype.Text + "," + ddlInsertStatusStafftype.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindStafftype();
            ClearStafftype();
        }

        protected void btnUpdateStafftype_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdStafftype.Text;
            string ValueName = tbInsertNameStafftype.Text;
            string ValueStatus = ddlInsertStatusStafftype.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_STAFFTYPE SET STAFFTYPE_ID = '" + ValueID + "', STAFFTYPE_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE STAFFTYPE_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindStafftype();
                ClearStafftype();
            }
        }

        protected void lbuClearStafftype_Click(object sender, EventArgs e)
        {
            BindStafftype();
            ClearStafftype();
        }

        protected void OnEditStafftype(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbStafftypeID") as Label).Text;
            string ValueName = (item.FindControl("lbStafftypeName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlStafftypeStatus") as DropDownList).SelectedValue;

            tbInsertIdStafftype.Text = ValueID;
            tbInsertNameStafftype.Text = ValueName;
            ddlInsertStatusStafftype.SelectedValue = ValueStatus;
        }

        protected void OnDeleteStafftype(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbStafftypeID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_STAFFTYPE WHERE STAFFTYPE_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindStafftype();
            }
        }
        //
        protected void BindTimeContact()
        {
            Panel9.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT TIME_CONTACT_ID,TIME_CONTACT_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_TIME_CONTACT.STATUS_ID) STATUS_NAME FROM REF_TIME_CONTACT ORDER BY TIME_CONTACT_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterTimeContact.DataSource = dt;
            myRepeaterTimeContact.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = true;
            divInsertTimeContact.Visible = true;
            divLoadTimeContact.Visible = true;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearTimeContact()
        {
            tbInsertIdTimeContact.Text = "";
            tbInsertNameTimeContact.Text = "";
            ddlInsertStatusTimeContact.SelectedIndex = 0;
        }

        protected void lbuMenuTimeContact_Click(object sender, EventArgs e)
        {
            BindTimeContact();
        }

        protected void btnInsertTimeContact_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_TIME_CONTACT (TIME_CONTACT_ID,TIME_CONTACT_NAME,STATUS_ID) VALUES (" + tbInsertIdTimeContact.Text + "," + tbInsertNameTimeContact.Text + "," + ddlInsertStatusTimeContact.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindTimeContact();
            ClearTimeContact();
        }

        protected void btnUpdateTimeContact_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdTimeContact.Text;
            string ValueName = tbInsertNameTimeContact.Text;
            string ValueStatus = ddlInsertStatusTimeContact.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_TIME_CONTACT SET TIME_CONTACT_ID = '" + ValueID + "', TIME_CONTACT_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE TIME_CONTACT_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindTimeContact();
                ClearTimeContact();
            }
        }

        protected void lbuClearTimeContact_Click(object sender, EventArgs e)
        {
            BindTimeContact();
            ClearTimeContact();
        }

        protected void OnEditTimeContact(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbTimeContactID") as Label).Text;
            string ValueName = (item.FindControl("lbTimeContactName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlTimeContactStatus") as DropDownList).SelectedValue;

            tbInsertIdTimeContact.Text = ValueID;
            tbInsertNameTimeContact.Text = ValueName;
            ddlInsertStatusTimeContact.SelectedValue = ValueStatus;
        }

        protected void OnDeleteTimeContact(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbTimeContactID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_TIME_CONTACT WHERE TIME_CONTACT_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindTimeContact();
            }
        }
        //
        protected void BindBudget()
        {
            Panel10.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT BUDGET_ID,BUDGET_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_BUDGET.STATUS_ID) STATUS_NAME FROM REF_BUDGET ORDER BY BUDGET_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterBudget.DataSource = dt;
            myRepeaterBudget.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = true;
            divInsertBudget.Visible = true;
            divLoadBudget.Visible = true;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearBudget()
        {
            tbInsertIdBudget.Text = "";
            tbInsertNameBudget.Text = "";
            ddlInsertStatusBudget.SelectedIndex = 0;
        }

        protected void lbuMenuBudget_Click(object sender, EventArgs e)
        {
            BindBudget();
        }

        protected void btnInsertBudget_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_BUDGET (BUDGET_ID,BUDGET_NAME,STATUS_ID) VALUES (" + tbInsertIdBudget.Text + "," + tbInsertNameBudget.Text + "," + ddlInsertStatusBudget.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindBudget();
            ClearBudget();
        }

        protected void btnUpdateBudget_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdBudget.Text;
            string ValueName = tbInsertNameBudget.Text;
            string ValueStatus = ddlInsertStatusBudget.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_BUDGET SET BUDGET_ID = '" + ValueID + "', BUDGET_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE BUDGET_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindBudget();
                ClearBudget();
            }
        }

        protected void lbuClearBudget_Click(object sender, EventArgs e)
        {
            BindBudget();
            ClearBudget();
        }

        protected void OnEditBudget(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbBudgetID") as Label).Text;
            string ValueName = (item.FindControl("lbBudgetName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlBudgetStatus") as DropDownList).SelectedValue;

            tbInsertIdBudget.Text = ValueID;
            tbInsertNameBudget.Text = ValueName;
            ddlInsertStatusBudget.SelectedValue = ValueStatus;
        }

        protected void OnDeleteBudget(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbBudgetID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_BUDGET WHERE BUDGET_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindBudget();
            }
        }
        //
        protected void BindSubStafftype()
        {
            Panel11.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT SUBSTAFFTYPE_ID,SUBSTAFFTYPE_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_SUBSTAFFTYPE.STATUS_ID) STATUS_NAME FROM REF_SUBSTAFFTYPE ORDER BY SUBSTAFFTYPE_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterSubStafftype.DataSource = dt;
            myRepeaterSubStafftype.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = true;
            divInsertSubStafftype.Visible = true;
            divLoadSubStafftype.Visible = true;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearSubStafftype()
        {
            tbInsertIdSubStafftype.Text = "";
            tbInsertNameSubStafftype.Text = "";
            ddlInsertStatusSubStafftype.SelectedIndex = 0;
        }

        protected void lbuMenuSubStafftype_Click(object sender, EventArgs e)
        {
            BindSubStafftype();
        }

        protected void btnInsertSubStafftype_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_SUBSTAFFTYPE (SUBSTAFFTYPE_ID,SUBSTAFFTYPE_NAME,STATUS_ID) VALUES (" + tbInsertIdSubStafftype.Text + "," + tbInsertNameSubStafftype.Text + "," + ddlInsertStatusSubStafftype.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindSubStafftype();
            ClearSubStafftype();
        }

        protected void btnUpdateSubStafftype_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdSubStafftype.Text;
            string ValueName = tbInsertNameSubStafftype.Text;
            string ValueStatus = ddlInsertStatusSubStafftype.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_SUBSTAFFTYPE SET SUBSTAFFTYPE_ID = '" + ValueID + "', SUBSTAFFTYPE_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE SUBSTAFFTYPE_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindSubStafftype();
                ClearSubStafftype();
            }
        }

        protected void lbuClearSubStafftype_Click(object sender, EventArgs e)
        {
            BindSubStafftype();
            ClearSubStafftype();
        }

        protected void OnEditSubStafftype(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbSubStafftypeID") as Label).Text;
            string ValueName = (item.FindControl("lbSubStafftypeName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlSubStafftypeStatus") as DropDownList).SelectedValue;

            tbInsertIdSubStafftype.Text = ValueID;
            tbInsertNameSubStafftype.Text = ValueName;
            ddlInsertStatusSubStafftype.SelectedValue = ValueStatus;
        }

        protected void OnDeleteSubStafftype(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbSubStafftypeID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_SUBSTAFFTYPE WHERE SUBSTAFFTYPE_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindSubStafftype();
            }
        }
        //
        protected void BindAdminPosition()
        {
            Panel12.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT ADMIN_ID,ADMIN_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_ADMIN.STATUS_ID) STATUS_NAME FROM REF_ADMIN ORDER BY ADMIN_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterAdminPosition.DataSource = dt;
            myRepeaterAdminPosition.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = true;
            divInsertAdminPosition.Visible = true;
            divLoadAdminPosition.Visible = true;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearAdminPosition()
        {
            tbInsertIdAdminPosition.Text = "";
            tbInsertNameAdminPosition.Text = "";
            ddlInsertStatusAdminPosition.SelectedIndex = 0;
        }

        protected void lbuMenuAdminPosition_Click(object sender, EventArgs e)
        {
            BindAdminPosition();
        }

        protected void btnInsertAdminPosition_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_ADMIN (ADMIN_ID,ADMIN_NAME,STATUS_ID) VALUES (" + tbInsertIdAdminPosition.Text + "," + tbInsertNameAdminPosition.Text + "," + ddlInsertStatusAdminPosition.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindAdminPosition();
            ClearAdminPosition();
        }

        protected void btnUpdateAdminPosition_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdAdminPosition.Text;
            string ValueName = tbInsertNameAdminPosition.Text;
            string ValueStatus = ddlInsertStatusAdminPosition.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_ADMIN SET ADMIN_ID = '" + ValueID + "', ADMIN_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE ADMIN_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindAdminPosition();
                ClearAdminPosition();
            }
        }

        protected void lbuClearAdminPosition_Click(object sender, EventArgs e)
        {
            BindAdminPosition();
            ClearAdminPosition();
        }

        protected void OnEditAdminPosition(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbAdminPositionID") as Label).Text;
            string ValueName = (item.FindControl("lbAdminPositionName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlAdminPositionStatus") as DropDownList).SelectedValue;

            tbInsertIdAdminPosition.Text = ValueID;
            tbInsertNameAdminPosition.Text = ValueName;
            ddlInsertStatusAdminPosition.SelectedValue = ValueStatus;
        }

        protected void OnDeleteAdminPosition(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbAdminPositionID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_ADMIN WHERE ADMIN_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindAdminPosition();
            }
        }
        //
        protected void BindPosition()
        {
            Panel13.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT POSITION_ID,POSITION_NAME_TH,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_POSITION.STATUS_ID) STATUS_NAME FROM REF_POSITION ORDER BY POSITION_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterPosition.DataSource = dt;
            myRepeaterPosition.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = true;
            divInsertPosition.Visible = true;
            divLoadPosition.Visible = true;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearPosition()
        {
            tbInsertIdPosition.Text = "";
            tbInsertNamePosition.Text = "";
            ddlInsertStatusPosition.SelectedIndex = 0;
        }

        protected void lbuMenuPosition_Click(object sender, EventArgs e)
        {
            BindPosition();
        }

        protected void btnInsertPosition_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_POSITION (POSITION_ID,POSITION_NAME_TH,STATUS_ID) VALUES (" + tbInsertIdPosition.Text + "," + tbInsertNamePosition.Text + "," + ddlInsertStatusPosition.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindPosition();
            ClearPosition();
        }

        protected void btnUpdatePosition_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdPosition.Text;
            string ValueName = tbInsertNamePosition.Text;
            string ValueStatus = ddlInsertStatusPosition.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_POSITION SET POSITION_ID = '" + ValueID + "', POSITION_NAME_TH = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE POSITION_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindPosition();
                ClearPosition();
            }
        }

        protected void lbuClearPosition_Click(object sender, EventArgs e)
        {
            BindPosition();
            ClearPosition();
        }

        protected void OnEditPosition(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbPositionID") as Label).Text;
            string ValueName = (item.FindControl("lbPositionName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlPositionStatus") as DropDownList).SelectedValue;

            tbInsertIdPosition.Text = ValueID;
            tbInsertNamePosition.Text = ValueName;
            ddlInsertStatusPosition.SelectedValue = ValueStatus;
        }

        protected void OnDeletePosition(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbPositionID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_POSITION WHERE POSITION_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindPosition();
            }
        }
        //
        protected void BindDepartment()
        {
            Panel14.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT FAC_ID,FAC_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_FAC.STATUS_ID) STATUS_NAME FROM REF_FAC ORDER BY FAC_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterDepartment.DataSource = dt;
            myRepeaterDepartment.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = true;
            divInsertDepartment.Visible = true;
            divLoadDepartment.Visible = true;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearDepartment()
        {
            tbInsertIdDepartment.Text = "";
            tbInsertNameDepartment.Text = "";
            ddlInsertStatusDepartment.SelectedIndex = 0;
        }

        protected void lbuMenuDepartment_Click(object sender, EventArgs e)
        {
            BindDepartment();
        }

        protected void btnInsertDepartment_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_FAC (FAC_ID,FAC_NAME,STATUS_ID) VALUES (" + tbInsertIdDepartment.Text + "," + tbInsertNameDepartment.Text + "," + ddlInsertStatusDepartment.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindDepartment();
            ClearDepartment();
        }

        protected void btnUpdateDepartment_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdDepartment.Text;
            string ValueName = tbInsertNameDepartment.Text;
            string ValueStatus = ddlInsertStatusDepartment.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_FAC SET FAC_ID = '" + ValueID + "', FAC_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE FAC_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindDepartment();
                ClearDepartment();
            }
        }

        protected void lbuClearDepartment_Click(object sender, EventArgs e)
        {
            BindDepartment();
            ClearDepartment();
        }

        protected void OnEditDepartment(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbDepartmentID") as Label).Text;
            string ValueName = (item.FindControl("lbDepartmentName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlDepartmentStatus") as DropDownList).SelectedValue;

            tbInsertIdDepartment.Text = ValueID;
            tbInsertNameDepartment.Text = ValueName;
            ddlInsertStatusDepartment.SelectedValue = ValueStatus;
        }

        protected void OnDeleteDepartment(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbDepartmentID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_FAC WHERE FAC_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindDepartment();
            }
        }
        //
        protected void BindTeachISCED()
        {
            Panel15.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT ISCED_ID,ISCED_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_ISCED.STATUS_ID) STATUS_NAME FROM REF_ISCED ORDER BY ISCED_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterTeachISCED.DataSource = dt;
            myRepeaterTeachISCED.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = true;
            divInsertTeachISCED.Visible = true;
            divLoadTeachISCED.Visible = true;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearTeachISCED()
        {
            tbInsertIdTeachISCED.Text = "";
            tbInsertNameTeachISCED.Text = "";
            ddlInsertStatusTeachISCED.SelectedIndex = 0;
        }

        protected void lbuMenuTeachISCED_Click(object sender, EventArgs e)
        {
            BindTeachISCED();
        }

        protected void btnInsertTeachISCED_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_ISCED (ISCED_ID,ISCED_NAME,STATUS_ID) VALUES (" + tbInsertIdTeachISCED.Text + "," + tbInsertNameTeachISCED.Text + "," + ddlInsertStatusTeachISCED.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindTeachISCED();
            ClearTeachISCED();
        }

        protected void btnUpdateTeachISCED_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdTeachISCED.Text;
            string ValueName = tbInsertNameTeachISCED.Text;
            string ValueStatus = ddlInsertStatusTeachISCED.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_ISCED SET ISCED_ID = '" + ValueID + "', ISCED_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE ISCED_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindTeachISCED();
                ClearTeachISCED();
            }
        }

        protected void lbuClearTeachISCED_Click(object sender, EventArgs e)
        {
            BindTeachISCED();
            ClearTeachISCED();
        }

        protected void OnEditTeachISCED(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbTeachISCEDID") as Label).Text;
            string ValueName = (item.FindControl("lbTeachISCEDName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlTeachISCEDStatus") as DropDownList).SelectedValue;

            tbInsertIdTeachISCED.Text = ValueID;
            tbInsertNameTeachISCED.Text = ValueName;
            ddlInsertStatusTeachISCED.SelectedValue = ValueStatus;
        }

        protected void OnDeleteTeachISCED(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbTeachISCEDID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_ISCED WHERE ISCED_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindTeachISCED();
            }
        }
        //
        protected void BindGradLev()
        {
            Panel16.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT LEV_ID,LEV_NAME_TH,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_LEV.STATUS_ID) STATUS_NAME FROM REF_LEV ORDER BY LEV_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterGradLev.DataSource = dt;
            myRepeaterGradLev.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = true;
            divInsertGradLev.Visible = true;
            divLoadGradLev.Visible = true;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearGradLev()
        {
            tbInsertIdGradLev.Text = "";
            tbInsertNameGradLev.Text = "";
            ddlInsertStatusGradLev.SelectedIndex = 0;
        }

        protected void lbuMenuGradLev_Click(object sender, EventArgs e)
        {
            BindGradLev();
        }

        protected void btnInsertGradLev_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_LEV (LEV_ID,LEV_NAME_TH,STATUS_ID) VALUES (" + tbInsertIdGradLev.Text + "," + tbInsertNameGradLev.Text + "," + ddlInsertStatusGradLev.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindGradLev();
            ClearGradLev();
        }

        protected void btnUpdateGradLev_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdGradLev.Text;
            string ValueName = tbInsertNameGradLev.Text;
            string ValueStatus = ddlInsertStatusGradLev.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_LEV SET LEV_ID = '" + ValueID + "', LEV_NAME_TH = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE LEV_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindGradLev();
                ClearGradLev();
            }
        }

        protected void lbuClearGradLev_Click(object sender, EventArgs e)
        {
            BindGradLev();
            ClearGradLev();
        }

        protected void OnEditGradLev(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbGradLevID") as Label).Text;
            string ValueName = (item.FindControl("lbGradLevName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlGradLevStatus") as DropDownList).SelectedValue;

            tbInsertIdGradLev.Text = ValueID;
            tbInsertNameGradLev.Text = ValueName;
            ddlInsertStatusGradLev.SelectedValue = ValueStatus;
        }

        protected void OnDeleteGradLev(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbGradLevID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_LEV WHERE LEV_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindGradLev();
            }
        }
        //
        protected void BindGradProg()
        {
            Panel17.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT PROGRAM_ID_NEW,PROGRAM_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_PROGRAM.STATUS_ID) STATUS_NAME FROM REF_PROGRAM ORDER BY PROGRAM_ID_NEW ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterGradProg.DataSource = dt;
            myRepeaterGradProg.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = true;
            divInsertGradProg.Visible = true;
            divLoadGradProg.Visible = true;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearGradProg()
        {
            tbInsertIdGradProg.Text = "";
            tbInsertNameGradProg.Text = "";
            ddlInsertStatusGradProg.SelectedIndex = 0;
        }

        protected void lbuMenuGradProg_Click(object sender, EventArgs e)
        {
            BindGradProg();
        }

        protected void btnInsertGradProg_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_PROGRAM (PROGRAM_ID_NEW,PROGRAM_NAME,STATUS_ID) VALUES (" + tbInsertIdGradProg.Text + "," + tbInsertNameGradProg.Text + "," + ddlInsertStatusGradProg.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindGradProg();
            ClearGradProg();
        }

        protected void btnUpdateGradProg_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdGradProg.Text;
            string ValueName = tbInsertNameGradProg.Text;
            string ValueStatus = ddlInsertStatusGradProg.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_PROGRAM SET PROGRAM_ID_NEW = '" + ValueID + "', PROGRAM_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE PROGRAM_ID_NEW = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindGradProg();
                ClearGradProg();
            }
        }

        protected void lbuClearGradProg_Click(object sender, EventArgs e)
        {
            BindGradProg();
            ClearGradProg();
        }

        protected void OnEditGradProg(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbGradProgID") as Label).Text;
            string ValueName = (item.FindControl("lbGradProgName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlGradProgStatus") as DropDownList).SelectedValue;

            tbInsertIdGradProg.Text = ValueID;
            tbInsertNameGradProg.Text = ValueName;
            ddlInsertStatusGradProg.SelectedValue = ValueStatus;
        }

        protected void OnDeleteGradProg(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbGradProgID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_PROGRAM WHERE PROGRAM_ID_NEW = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindGradProg();
            }
        }
        //
        protected void BindDeform()
        {
            Panel18.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT DEFORM_ID,DEFORM_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_DEFORM.STATUS_ID) STATUS_NAME FROM REF_DEFORM ORDER BY DEFORM_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterDeform.DataSource = dt;
            myRepeaterDeform.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = true;
            divInsertDeform.Visible = true;
            divLoadDeform.Visible = true;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearDeform()
        {
            tbInsertIdDeform.Text = "";
            tbInsertNameDeform.Text = "";
            ddlInsertStatusDeform.SelectedIndex = 0;
        }

        protected void lbuMenuDeform_Click(object sender, EventArgs e)
        {
            BindDeform();
        }

        protected void btnInsertDeform_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_DEFORM (DEFORM_ID,DEFORM_NAME,STATUS_ID) VALUES (" + tbInsertIdDeform.Text + "," + tbInsertNameDeform.Text + "," + ddlInsertStatusDeform.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindDeform();
            ClearDeform();
        }

        protected void btnUpdateDeform_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdDeform.Text;
            string ValueName = tbInsertNameDeform.Text;
            string ValueStatus = ddlInsertStatusDeform.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_DEFORM SET DEFORM_ID = '" + ValueID + "', DEFORM_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE DEFORM_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindDeform();
                ClearDeform();
            }
        }

        protected void lbuClearDeform_Click(object sender, EventArgs e)
        {
            BindDeform();
            ClearDeform();
        }

        protected void OnEditDeform(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbDeformID") as Label).Text;
            string ValueName = (item.FindControl("lbDeformName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlDeformStatus") as DropDownList).SelectedValue;

            tbInsertIdDeform.Text = ValueID;
            tbInsertNameDeform.Text = ValueName;
            ddlInsertStatusDeform.SelectedValue = ValueStatus;
        }

        protected void OnDeleteDeform(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbDeformID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_DEFORM WHERE DEFORM_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindDeform();
            }
        }
        //
        protected void BindReligion()
        {
            Panel19.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT RELIGION_ID,RELIGION_NAME_TH,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_RELIGION.STATUS_ID) STATUS_NAME FROM REF_RELIGION ORDER BY RELIGION_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterReligion.DataSource = dt;
            myRepeaterReligion.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = true;
            divInsertReligion.Visible = true;
            divLoadReligion.Visible = true;

            divheader20.Visible = false;
            divInsertMovementType.Visible = false;
            divLoadMovementType.Visible = false;
        }

        protected void ClearReligion()
        {
            tbInsertIdReligion.Text = "";
            tbInsertNameReligion.Text = "";
            ddlInsertStatusReligion.SelectedIndex = 0;
        }

        protected void lbuMenuReligion_Click(object sender, EventArgs e)
        {
            BindReligion();
        }

        protected void btnInsertReligion_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_RELIGION (RELIGION_ID,RELIGION_NAME_TH,STATUS_ID) VALUES (" + tbInsertIdReligion.Text + "," + tbInsertNameReligion.Text + "," + ddlInsertStatusReligion.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindReligion();
            ClearReligion();
        }

        protected void btnUpdateReligion_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdReligion.Text;
            string ValueName = tbInsertNameReligion.Text;
            string ValueStatus = ddlInsertStatusReligion.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_RELIGION SET RELIGION_ID = '" + ValueID + "', RELIGION_NAME_TH = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE RELIGION_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindReligion();
                ClearReligion();
            }
        }

        protected void lbuClearReligion_Click(object sender, EventArgs e)
        {
            BindReligion();
            ClearReligion();
        }

        protected void OnEditReligion(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbReligionID") as Label).Text;
            string ValueName = (item.FindControl("lbReligionName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlReligionStatus") as DropDownList).SelectedValue;

            tbInsertIdReligion.Text = ValueID;
            tbInsertNameReligion.Text = ValueName;
            ddlInsertStatusReligion.SelectedValue = ValueStatus;
        }

        protected void OnDeleteReligion(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbReligionID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_RELIGION WHERE RELIGION_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindReligion();
            }
        }
        //
        protected void BindMovementType()
        {
            Panel20.Visible = true;

            OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING);
            OracleDataAdapter sda = new OracleDataAdapter("SELECT MOVEMENT_TYPE_ID,MOVEMENT_TYPE_NAME,STATUS_ID,(SELECT STATUS_NAME FROM TB_STATUS_ACTIVE WHERE TB_STATUS_ACTIVE.STATUS_ID = REF_MOVEMENT_TYPE.STATUS_ID) STATUS_NAME FROM REF_MOVEMENT_TYPE ORDER BY MOVEMENT_TYPE_ID ASC", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            myRepeaterMovementType.DataSource = dt;
            myRepeaterMovementType.DataBind();

            divheader1.Visible = false;
            divInsertUniv.Visible = false;
            divLoadUniv.Visible = false;

            divheader2.Visible = false;
            divInsertTitle.Visible = false;
            divLoadTitle.Visible = false;

            divheader3.Visible = false;
            divInsertGender.Visible = false;
            divLoadGender.Visible = false;

            divheader4.Visible = false;
            divInsertProvince.Visible = false;
            divLoadProvince.Visible = false;

            divheader5.Visible = false;
            divInsertAmphur.Visible = false;
            divLoadAmphur.Visible = false;

            divheader6.Visible = false;
            divInsertTambon.Visible = false;
            divLoadTambon.Visible = false;

            divheader7.Visible = false;
            divInsertNation.Visible = false;
            divLoadNation.Visible = false;

            divheader8.Visible = false;
            divInsertStafftype.Visible = false;
            divLoadStafftype.Visible = false;

            divheader9.Visible = false;
            divInsertTimeContact.Visible = false;
            divLoadTimeContact.Visible = false;

            divheader10.Visible = false;
            divInsertBudget.Visible = false;
            divLoadBudget.Visible = false;

            divheader11.Visible = false;
            divInsertSubStafftype.Visible = false;
            divLoadSubStafftype.Visible = false;

            divheader12.Visible = false;
            divInsertAdminPosition.Visible = false;
            divLoadAdminPosition.Visible = false;

            divheader13.Visible = false;
            divInsertPosition.Visible = false;
            divLoadPosition.Visible = false;

            divheader14.Visible = false;
            divInsertDepartment.Visible = false;
            divLoadDepartment.Visible = false;

            divheader15.Visible = false;
            divInsertTeachISCED.Visible = false;
            divLoadTeachISCED.Visible = false;

            divheader16.Visible = false;
            divInsertGradLev.Visible = false;
            divLoadGradLev.Visible = false;

            divheader17.Visible = false;
            divInsertGradProg.Visible = false;
            divLoadGradProg.Visible = false;

            divheader18.Visible = false;
            divInsertDeform.Visible = false;
            divLoadDeform.Visible = false;

            divheader19.Visible = false;
            divInsertReligion.Visible = false;
            divLoadReligion.Visible = false;

            divheader20.Visible = true;
            divInsertMovementType.Visible = true;
            divLoadMovementType.Visible = true;
        }

        protected void ClearMovementType()
        {
            tbInsertIdMovementType.Text = "";
            tbInsertNameMovementType.Text = "";
            ddlInsertStatusMovementType.SelectedIndex = 0;
        }

        protected void lbuMenuMovementType_Click(object sender, EventArgs e)
        {
            BindMovementType();
        }

        protected void btnInsertMovementType_Click(object sender, EventArgs e)
        {
            DatabaseManager.ExecuteNonQuery("INSERT INTO REF_MOVEMENT_TYPE (MOVEMENT_TYPE_ID,MOVEMENT_TYPE_NAME,STATUS_ID) VALUES (" + tbInsertIdMovementType.Text + "," + tbInsertNameMovementType.Text + "," + ddlInsertStatusMovementType.SelectedValue + ")");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            BindMovementType();
            ClearMovementType();
        }

        protected void btnUpdateMovementType_Click(object sender, EventArgs e)
        {
            string ValueID = tbInsertIdMovementType.Text;
            string ValueName = tbInsertNameMovementType.Text;
            string ValueStatus = ddlInsertStatusMovementType.SelectedValue;

            if (ValueID != "" && ValueName != "" && ValueStatus != "")
            {
                DatabaseManager.ExecuteNonQuery("UPDATE REF_MOVEMENT_TYPE SET MOVEMENT_TYPE_ID = '" + ValueID + "', MOVEMENT_TYPE_NAME = '" + ValueName + "', STATUS_ID = '" + ValueStatus + "' WHERE MOVEMENT_TYPE_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                BindMovementType();
                ClearMovementType();
            }
        }

        protected void lbuClearMovementType_Click(object sender, EventArgs e)
        {
            BindMovementType();
            ClearMovementType();
        }

        protected void OnEditMovementType(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            string ValueID = (item.FindControl("lbMovementTypeID") as Label).Text;
            string ValueName = (item.FindControl("lbMovementTypeName") as Label).Text;
            string ValueStatus = (item.FindControl("ddlMovementTypeStatus") as DropDownList).SelectedValue;

            tbInsertIdMovementType.Text = ValueID;
            tbInsertNameMovementType.Text = ValueName;
            ddlInsertStatusMovementType.SelectedValue = ValueStatus;
        }

        protected void OnDeleteMovementType(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int ValueID = int.Parse((item.FindControl("lbMovementTypeID") as Label).Text);

            if (ValueID != 0)
            {
                DatabaseManager.ExecuteNonQuery("DELETE REF_MOVEMENT_TYPE WHERE MOVEMENT_TYPE_ID = '" + ValueID + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
                BindMovementType();
            }
        }

    }
}