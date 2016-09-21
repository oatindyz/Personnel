using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Personnel.Class;

namespace Personnel
{
    public partial class ManageTimecontact_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["Timecon"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["Timecon"] = data;
        }

        #endregion

        void BindData()
        {
            Manage m = new Manage();
            DataTable dt = m.Get_Timecontact("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        void BindData1()
        {
            Manage m = new Manage();
            DataTable dt = m.Get_Timecontact(txtSearchIDtimecon.Text, txtSearchNametimecon.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        private void ClearData()
        {
            txtSearchIDtimecon.Text = "";
            txtSearchNametimecon.Text = "";
            txtInsertIDtimecon.Text = "";
            txtInsertNametimecon.Text = "";
        }

        protected void lbuSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInsertIDtimecon.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ รหัสระยะเวลาจ้าง')", true);
                return;
            }
            if (string.IsNullOrEmpty(txtInsertNametimecon.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาใส่ ชื่อระยะเวลาจ้าง')", true);
                return;
            }
            Manage m = new Manage();
            m.TIME_CONTACT_ID = txtInsertIDtimecon.Text;
            m.TIME_CONTACT_NAME = txtInsertNametimecon.Text;

            if (m.Check_Timecontact())
            {
                m.Insert_Timecontact();
                BindData();
                ClearData();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ข้อมูลที่จะเพิ่ม มีอยู่ในระบบแล้ว !')", true);
            }

        }

        protected void modEditCommand(Object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData1();
        }
        protected void modCancelCommand(Object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            Manage m = new Manage();
            m.TIME_CONTACT_ID = id;
            m.Delete_Timecontact();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridView1.EditIndex = -1;
            BindData1();
        }
        protected void modUpdateCommand(Object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtIDtimeconEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtIDtimeconEdit");
            TextBox txtNametimeconEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNametimeconEdit");

            Manage m = new Manage(txtIDtimeconEdit.Text, txtNametimeconEdit.Text);

            if (m.Check_Timecontact())
            {
                m.Update_Timecontact();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพเดทข้อมูลเรียบร้อย')", true);
                GridView1.EditIndex = -1;
                BindData1();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ข้อมูลที่จะอัพเดท มีอยู่ในระบบแล้ว !')", true);
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะรหัสระยะเวลาจ้าง " + DataBinder.Eval(e.Row.DataItem, "TIME_CONTACT_ID") + " ใช่ไหม ?');");
            }
        }
        protected void myGridViewTimecontact_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetViewState();
            GridView1.DataBind();
        }

        protected void lbuCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            Manage m = new Manage();
            DataTable dt = m.Get_Timecontact("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }

        protected void lbuSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchIDtimecon.Text) && string.IsNullOrEmpty(txtSearchNametimecon.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอก คำค้นหา')", true);
                return;
            }
            else
            {
                Manage m = new Manage();
                DataTable dt = m.Get_Timecontact(txtSearchIDtimecon.Text, txtSearchNametimecon.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                SetViewState(dt);
            }
        }

        protected void lbuRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            Manage m = new Manage();
            DataTable dt = m.Get_Timecontact("", "");
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SetViewState(dt);
        }
    }
}