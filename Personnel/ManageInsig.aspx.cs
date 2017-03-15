using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Personnel.Class;
using System.IO;
using System.Data.OracleClient;
using System.Data;

namespace Personnel
{
    public partial class ManageInsig : System.Web.UI.Page
    {
        int id = 0;
        DateTime LastInsig;
        string LastNameInsig;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
            }
            else { Response.Redirect("listInsig-admin.aspx"); }
      
            if (!IsPostBack)
            {
                ReadSelectID();
                BindManage();
                BindDDL();
            }
        }

        protected void BindDDL()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string where = "";
                string InsigIDitem = DatabaseManager.ExecuteString("SELECT * FROM (SELECT INSIG_ITEM_ID FROM TB_INSIG WHERE UOC_ID = '" + int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "' ORDER BY INSIG_ITEM_ID ASC) WHERE ROWNUM = 1");
                if (InsigIDitem == "12")
                {
                    where += "11";
                }
                else if (InsigIDitem == "11")
                {
                    where += "10";
                }
                else if (InsigIDitem == "10")
                {
                    where += "9";
                }
                else if (InsigIDitem == "9")
                {
                    where += "8";
                }
                else if (InsigIDitem == "8")
                {
                    where += "7";
                }
                else if (InsigIDitem == "7")
                {
                    where += "6";
                }
                else if (InsigIDitem == "6")
                {
                    where += "5";
                }
                else if (InsigIDitem == "5")
                {
                    where += "4";
                }
                else if (InsigIDitem == "4")
                {
                    where += "3";
                }
                else if (InsigIDitem == "3")
                {
                    where += "2";
                }
                else if (InsigIDitem == "2")
                {
                    where += "1";
                }
                else if (InsigIDitem == "1")
                {
                    ddlInsigItem.Visible = true;
                    lbHighEnd.Visible = true;
                }
                else
                {
                    where += "12";
                }
                using (OracleCommand com = new OracleCommand("SELECT INSIG_ITEM_ID, INSIG_NAME, INSIG_NAME_FULL FROM TB_INSIG_ITEM WHERE INSIG_ITEM_ID = '" + where + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        ddlInsigItem.Items.Clear();
                        while (reader.Read())
                        {
                            ddlInsigItem.Items.Add(new ListItem(reader.GetValue(1).ToString() + " | " + reader.GetValue(2).ToString(), reader.GetValue(0).ToString() + ""));
                        }
                        ddlInsigItem.Items.Insert(0, new ListItem("--กรุณาเลือก--", ""));
                    }
                }
            }
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["ManageInsig"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["ManageInsig"] = data;
        }

        #endregion

        protected void BindManage()
        {
            ClassInsig MInsig = new ClassInsig();
            DataTable dt = MInsig.SELECT_ManageInsig("", MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
            GridViewInsig.DataSource = dt;
            GridViewInsig.DataBind();
            SetViewState(dt);
        }

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT (SELECT FULLNAME FROM REF_PREFIX_NAME WHERE REF_PREFIX_NAME.prefix_name_id = UOC_STAFF.PREFIX_NAME) || ' ' || STF_FNAME || ' ' || STF_LNAME NAME, (SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE REF_STAFFTYPE.STAFFTYPE_ID = UOC_STAFF.STAFFTYPE_ID) STAFFTYPE_NAME, (SELECT POSITION_NAME_TH FROM REF_POSITION WHERE REF_POSITION.POSITION_ID = UOC_STAFF.POSITION_ID) POSITION_NAME, (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME, SALARY, POSITION_SALARY FROM UOC_STAFF WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;

                            if (reader.GetValue(0).ToString() == null || reader.GetValue(0).ToString() == DBNull.Value.ToString())
                            {
                                lbName.Text = "-";
                            }
                            else
                            {
                                lbName.Text = reader.GetValue(i).ToString(); ++i;
                            }
                            if (reader.GetValue(1).ToString() == null || reader.GetValue(1).ToString() == DBNull.Value.ToString())
                            {
                                lbStafftype.Text = "-";
                            }
                            else
                            {
                                lbStafftype.Text = reader.GetValue(i).ToString(); ++i;
                            }
                            if (reader.GetValue(2).ToString() == null || reader.GetValue(2).ToString() == DBNull.Value.ToString())
                            {
                                lbPosition.Text = "-";
                            }
                            else
                            {
                                lbPosition.Text = reader.GetValue(i).ToString(); ++i;
                            }
                            if (reader.GetValue(3).ToString() == null || reader.GetValue(3).ToString() == DBNull.Value.ToString())
                            {
                                lbDepartment.Text = "-";
                            }
                            else
                            {
                                lbDepartment.Text = reader.GetValue(i).ToString(); ++i;
                            }
                            if (reader.GetValue(4).ToString() == null || reader.GetValue(4).ToString() == DBNull.Value.ToString())
                            {
                                lbSalary.Text = "-";
                            }
                            else
                            {
                                lbSalary.Text = reader.GetValue(i).ToString(); ++i;
                            }
                            if (reader.GetValue(5).ToString() == null || reader.GetValue(5).ToString() == DBNull.Value.ToString())
                            {
                                lbPositionSalary.Text = "-";
                            }
                            else
                            {
                                lbPositionSalary.Text = reader.GetValue(i).ToString(); ++i;
                            }
                        }
                    }
                }

                using (OracleCommand com = new OracleCommand("SELECT (SELECT INSIG_NAME || ' | ' || INSIG_NAME_FULL FROM TB_INSIG_ITEM WHERE TB_INSIG_ITEM.INSIG_ITEM_ID = TB_INSIG.INSIG_ITEM_ID) INSIG, INSIG_GET_DATE FROM TB_INSIG WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND insig_get_date = (SELECT MAX(INSIG_GET_DATE) FROM TB_INSIG WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "')", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(0).ToString() == null || reader.GetValue(0).ToString() == DBNull.Value.ToString())
                            {
                                lbLastInsig.Text = "-";
                            }
                            else
                            {
                                lbLastInsig.Text = reader.GetValue(0).ToString();
                                LastNameInsig = reader.GetValue(0).ToString();
                                LastInsig = DateTime.Parse(reader.GetValue(1).ToString());
                            }
                        }
                    }
                }
            }
        }

        protected void myGridViewInsig_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewInsig.PageIndex = e.NewPageIndex;
            GridViewInsig.DataSource = GetViewState();
            GridViewInsig.DataBind();
        }

        protected void btnSaveInsig_Click(object sender, EventArgs e)
        {
            ReadSelectID();
            string[] ss = tbGetDate.Text.Split('/');
            DateTime DateText = new DateTime(int.Parse(ss[2]),int.Parse(ss[1]),int.Parse(ss[0]));
            
            if (DateText.AddYears(-543) <= LastInsig)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('วันที่ไม่สามารถต่ำกว่าวันที่ของชั้นเครื่องราช "+ LastNameInsig.ToString() + "')", true);
                return;
            }

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO TB_INSIG (UOC_ID,INSIG_ITEM_ID,INSIG_GET_DATE) VALUES (:UOC_ID,:INSIG_ITEM_ID,:INSIG_GET_DATE)", con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", int.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()))));
                    com.Parameters.Add(new OracleParameter("INSIG_ITEM_ID", ddlInsigItem.SelectedValue));
                    com.Parameters.Add(new OracleParameter("INSIG_GET_DATE", DateTime.Parse(tbGetDate.Text)));
                    com.ExecuteNonQuery();
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('เพิ่มข้อมูลเรียบร้อย')", true);

            tbGetDate.Text = "";
            BindManage();
            BindDDL();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int InSIG_ID = DatabaseManager.ExecuteInt("SELECT INSIG_ID FROM TB_INSIG WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND insig_get_date = (SELECT MAX(INSIG_GET_DATE) FROM TB_INSIG WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' )");

            if (InSIG_ID == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ไม่มีรายการข้อมูลจึงไม่สามารถลบได้')", true);
                return;
            }

            DatabaseManager.ExecuteInt("delete TB_INSIG where INSIG_ID = " + InSIG_ID);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);
            ReadSelectID();
            BindManage();
            BindDDL();
        }
    }
}