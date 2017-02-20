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
    public partial class RequestEditData : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            BindDDL();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                btnAddPerson.Visible = false;
                btnBack.Visible = false;
                btnReally.Visible = true;
            }
            if (MultiView1.ActiveViewIndex == 1)
            {
                btnAddPerson.Visible = true;
                btnBack.Visible = false;
                btnReally.Visible = false;
            }
            if (MultiView1.ActiveViewIndex == 2)
            {
                btnAddPerson.Visible = false;
                btnBack.Visible = false;
                btnReally.Visible = false;
            }

            if (!IsPostBack)
            {
                BindDDL();
                ReadSelectID();
            }
        }

        protected void BindDDL()
        {
            DatabaseManager.BindDropDown(ddlUniv, "SELECT * FROM REF_UNIV ORDER BY ABS(UNIV_ID) ASC", "UNIV_NAME_TH", "UNIV_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlPrefixName, "SELECT * FROM REF_PREFIX_NAME WHERE STATUS_ID = 1 ORDER BY ABS(PREFIX_NAME_ID) ASC", "FULLNAME", "PREFIX_NAME_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGender, "SELECT * FROM REF_GENDER ORDER BY ABS(GENDER_ID) ASC", "GENDER_NAME", "GENDER_ID", "--กรุณาเลือก--");

            DatabaseManager.BindDropDown(ddlStafftype, "SELECT * FROM REF_STAFFTYPE ORDER BY ABS(STAFFTYPE_ID) ASC", "STAFFTYPE_NAME", "STAFFTYPE_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlTimeContact, "SELECT * FROM REF_TIME_CONTACT ORDER BY ABS(TIME_CONTACT_ID) ASC", "TIME_CONTACT_NAME", "TIME_CONTACT_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlBudget, "SELECT * FROM REF_BUDGET ORDER BY ABS(BUDGET_ID) ASC", "BUDGET_NAME", "BUDGET_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlSubStafftype, "SELECT * FROM REF_SUBSTAFFTYPE ORDER BY ABS(SUBSTAFFTYPE_ID) ASC", "SUBSTAFFTYPE_NAME", "SUBSTAFFTYPE_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlAdminPosition, "SELECT * FROM REF_ADMIN ORDER BY ABS(ADMIN_ID) ASC", "ADMIN_NAME", "ADMIN_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlPosition, "SELECT * FROM REF_POSITION ORDER BY ABS(POSITION_ID) ASC", "POSITION_NAME_TH", "POSITION_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlDepartment, "SELECT * FROM REF_FAC ORDER BY ABS(FAC_ID) ASC", "FAC_NAME", "FAC_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlTeachISCED, "SELECT * FROM REF_ISCED  ORDER BY ISCED_ID", "ISCED_NAME", "ISCED_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGradLev, "SELECT * FROM REF_LEV ORDER BY ABS(LEV_ID) ASC", "LEV_NAME_TH", "LEV_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGradISCED, "SELECT * FROM REF_ISCED ORDER BY ISCED_ID", "ISCED_NAME", "ISCED_ID", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGradProg, "SELECT * FROM REF_PROGRAM ORDER BY ABS(PROGRAM_ID_NEW) ASC", "PROGRAM_NAME", "PROGRAM_ID_NEW", "--กรุณาเลือก--");
            DatabaseManager.BindDropDown(ddlGradCountry, "SELECT * FROM REF_NATION ORDER BY NATION_ID", "NATION_NAME_ENG", "NATION_ID", "--กรุณาเลือก--");

            DatabaseManager.BindDropDown(ddlReligion, "SELECT * FROM REF_RELIGION ORDER BY ABS(RELIGION_ID) ASC", "RELIGION_NAME_TH", "RELIGION_ID", "--กรุณาเลือก--");
        }

        private void ReadSelectID()
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT UNIV_ID,PREFIX_NAME,STF_FNAME,STF_LNAME,GENDER_ID,BIRTHDAY,STAFFTYPE_ID,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_ID,POSITION_WORK,DEPARTMENT_ID,DATE_INWORK,DATE_START_THIS_U,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_LEV_ID,GRAD_CURR,GRAD_ISCED_ID,GRAD_PROG,GRAD_UNIV,GRAD_COUNTRY_ID,RELIGION_ID FROM UOC_STAFF WHERE UOC_ID = '" + loginPerson.UOC_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            ddlUniv.SelectedValue = reader.GetString(i); ++i;
                            ddlPrefixName.SelectedValue = reader.GetString(i); ++i;
                            tbName.Text = reader.GetString(i); ++i;
                            tbLastName.Text = reader.GetString(i); ++i;
                            ddlGender.SelectedValue = reader.GetString(i); ++i;
                            tbBirthday.Text = reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;

                            ddlStafftype.SelectedValue = reader.GetString(i); ++i;
                            ddlTimeContact.SelectedValue = reader.GetString(i); ++i;
                            ddlBudget.SelectedValue = reader.GetString(i); ++i;
                            ddlSubStafftype.SelectedValue = reader.GetString(i); ++i;
                            ddlAdminPosition.SelectedValue = reader.GetString(i); ++i;
                            ddlPosition.SelectedValue = reader.GetString(i); ++i;
                            tbPositionWork.Text = reader.GetString(i); ++i;
                            ddlDepartment.SelectedValue = reader.GetString(i); ++i;
                            tbDateInwork.Text = reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            tbDateStartThisU.Text = reader.GetDateTime(i).ToString("dd/MM/yyyy"); ++i;
                            tbSpecialName.Text = reader.GetString(i); ++i;
                            ddlTeachISCED.SelectedValue = reader.GetString(i); ++i;
                            ddlGradLev.SelectedValue = reader.GetString(i); ++i;
                            tbGradCURR.Text = reader.GetString(i); ++i;

                            ddlGradISCED.SelectedValue = reader.GetString(i); ++i;
                            ddlGradProg.SelectedValue = reader.GetString(i); ++i;

                            tbGradUniv.Text = reader.GetString(i); ++i;
                            ddlGradCountry.SelectedValue = reader.GetString(i); ++i;
                            ddlReligion.SelectedValue = reader.GetString(i); ++i;

                        }
                    }
                }
            }
        }

        protected void btnReally_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            btnAddPerson.Visible = true;
            btnBack.Visible = true;
            btnReally.Visible = false;

            if (cbUniv.Checked)
            {
                lb4Univ.Text = ddlUniv.SelectedItem.Text;
                tr4_lb4Univ.Visible = true;
            }
            else { tr4_lb4Univ.Visible = false; }

            if (cbPrefixName.Checked)
            {
                lb4PrefixName.Text = ddlPrefixName.SelectedItem.Text;
                tr4_lb4PrefixName.Visible = true;
            }
            else { tr4_lb4PrefixName.Visible = false; }

            if (cbName.Checked)
            {
                lb4Name.Text = tbName.Text;
                tr4_lb4Name.Visible = true;
            }
            else { tr4_lb4Name.Visible = false; }

            if (cbLastName.Checked)
            {
                lb4LastName.Text = tbLastName.Text;
                tr4_lb4LastName.Visible = true;
            }
            else { tr4_lb4LastName.Visible = false; }


            if (cbGender.Checked)
            {
                lb4Gender.Text = ddlGender.SelectedItem.Text;
                tr4_lb4Gender.Visible = true;
            }
            else { tr4_lb4Gender.Visible = false; }

            if (cbBirthday.Checked)
            {
                lb4Birthday.Text = tbBirthday.Text;
                tr4_lb4Birthday.Visible = true;
            }
            else { tr4_lb4Birthday.Visible = false; }

            if (cbStafftype.Checked)
            {
                lb4Stafftype.Text = ddlStafftype.SelectedItem.Text;
                tr4_lb4Stafftype.Visible = true;
            }
            else { tr4_lb4Stafftype.Visible = false; }

            if (cbTimeContact.Checked)
            {
                lb4TimeContact.Text = ddlTimeContact.SelectedItem.Text;
                tr4_lb4TimeContact.Visible = true;
            }
            else { tr4_lb4TimeContact.Visible = false; }

            if (cbBudget.Checked)
            {
                lb4Budget.Text = ddlBudget.SelectedItem.Text;
                tr4_lb4Budget.Visible = true;
            }
            else { tr4_lb4Budget.Visible = false; }

            if (cbSubStafftype.Checked)
            {
                lb4SubStafftype.Text = ddlSubStafftype.SelectedItem.Text;
                tr4_lb4SubStafftype.Visible = true;
            }
            else { tr4_lb4SubStafftype.Visible = false; }

            if (cbAdminPosition.Checked)
            {
                lb4AdminPosition.Text = ddlAdminPosition.SelectedItem.Text;
                tr4_lb4AdminPosition.Visible = true;
            }
            else { tr4_lb4AdminPosition.Visible = false; }

            if (cbPosition.Checked)
            {
                lb4Position.Text = ddlPosition.SelectedItem.Text;
                tr4_lb4Position.Visible = true;
            }
            else { tr4_lb4Position.Visible = false; }

            if (cbPositionWork.Checked)
            {
                lb4PositionWork.Text = tbPositionWork.Text;
                tr4_lb4PositionWork.Visible = true;
            }
            else { tr4_lb4PositionWork.Visible = false; }

            if (cbDepartment.Checked)
            {
                lb4Department.Text = ddlDepartment.SelectedItem.Text;
                tr4_lb4Department.Visible = true;
            }
            else { tr4_lb4Department.Visible = false; }

            if (cbDateInwork.Checked)
            {
                lb4DateInwork.Text = tbDateInwork.Text;
                tr4_lb4DateInwork.Visible = true;
            }
            else { tr4_lb4DateInwork.Visible = false; }

            if (cbDateStartThisU.Checked)
            {
                lb4DateStartThisU.Text = tbDateStartThisU.Text;
                tr4_lb4DateStartThisU.Visible = true;
            }
            else { tr4_lb4DateStartThisU.Visible = false; }


            if (cbSpecialName.Checked)
            {
                lb4SpecialName.Text = tbSpecialName.Text;
                tr4_lb4SpecialName.Visible = true;
            }
            else { tr4_lb4SpecialName.Visible = false; }

            if (cbTeachISCED.Checked)
            {
                lb4TeachISCED.Text = ddlTeachISCED.SelectedItem.Text;
                tr4_lb4TeachISCED.Visible = true;
            }
            else { tr4_lb4TeachISCED.Visible = false; }

            if (cbGradLev.Checked)
            {
                lb4GradLev.Text = ddlGradLev.SelectedItem.Text;
                tr4_lb4GradLev.Visible = true;
            }
            else { tr4_lb4GradLev.Visible = false; }

            if (cbGradCURR.Checked)
            {
                lb4GradCURR.Text = tbGradCURR.Text;
                tr4_lb4GradCURR.Visible = true;
            }
            else { tr4_lb4GradCURR.Visible = false; }

            if (cbGradISCED.Checked)
            {
                lb4GradISCED.Text = ddlGradISCED.SelectedItem.Text;
                tr4_lb4GradISCED.Visible = true;
            }
            else { tr4_lb4GradISCED.Visible = false; }

            if (cbGradProg.Checked)
            {
                lb4GradProg.Text = ddlGradProg.SelectedItem.Text;
                tr4_lb4GradProg.Visible = true;
            }
            else { tr4_lb4GradProg.Visible = false; }

            if (cbGradUniv.Checked)
            {
                lb4GradUniv.Text = tbGradUniv.Text;
                tr4_lb4GradUniv.Visible = true;
            }
            else { tr4_lb4GradUniv.Visible = false; }

            if (cbGradCountry.Checked)
            {
                lb4GradCountry.Text = ddlGradCountry.SelectedItem.Text;
                tr4_lb4GradCountry.Visible = true;
            }
            else { tr4_lb4GradCountry.Visible = false; }

            if (cbReligion.Checked)
            {
                lb4Religion.Text = ddlReligion.SelectedItem.Text;
                tr4_lb4Religion.Visible = true;
            }
            else { tr4_lb4Religion.Visible = false; }

        }

        protected void lbuAddPerson_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            btnAddPerson.Visible = false;
            btnBack.Visible = false;
            btnReally.Visible = false;

            INSERT_REQUEST_EDIT();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            btnAddPerson.Visible = false;
            btnBack.Visible = false;
            btnReally.Visible = true;
        }

        public int INSERT_REQUEST_EDIT()
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            int id = 0;
            int id2 = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com2 = new OracleCommand("INSERT INTO TB_REQUEST (UOC_ID,STATUS_ID,DATE_START,UNIV_ID,PREFIX_NAME,STF_FNAME,STF_LNAME,GENDER_ID,BIRTHDAY,STAFFTYPE_ID,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_ID,POSITION_WORK,DEPARTMENT_ID,DATE_INWORK,DATE_START_THIS_U,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_LEV_ID,GRAD_CURR,GRAD_ISCED_ID,GRAD_PROG,GRAD_UNIV,GRAD_COUNTRY_ID,RELIGION_ID) VALUES (:UOC_ID,:STATUS_ID,:DATE_START,:UNIV_ID,:PREFIX_NAME,:STF_FNAME,:STF_LNAME,:GENDER_ID,:BIRTHDAY,:STAFFTYPE_ID,:TIME_CONTACT_ID,:BUDGET_ID,:SUBSTAFFTYPE_ID,:ADMIN_POSITION_ID,:POSITION_ID,:POSITION_WORK,:DEPARTMENT_ID,:DATE_INWORK,:DATE_START_THIS_U,:SPECIAL_NAME,:TEACH_ISCED_ID,:GRAD_LEV_ID,:GRAD_CURR,:GRAD_ISCED_ID,:GRAD_PROG,:GRAD_UNIV,:GRAD_COUNTRY_ID,:RELIGION_ID)", con))
                {
                    com2.Parameters.Add(new OracleParameter("UOC_ID", loginPerson.UOC_ID));
                    com2.Parameters.Add(new OracleParameter("STATUS_ID", "0"));
                    com2.Parameters.Add(new OracleParameter("DATE_START", DateTime.Today));
                    if (cbUniv.Checked) { com2.Parameters.Add(new OracleParameter("UNIV_ID", ddlUniv.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("UNIV_ID", DBNull.Value)); }
                    if (cbPrefixName.Checked) { com2.Parameters.Add(new OracleParameter("PREFIX_NAME", ddlPrefixName.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("PREFIX_NAME", DBNull.Value)); }
                    if (cbName.Checked) { com2.Parameters.Add(new OracleParameter("STF_FNAME", tbName.Text)); } else { com2.Parameters.Add(new OracleParameter("STF_FNAME", DBNull.Value)); }
                    if (cbLastName.Checked) { com2.Parameters.Add(new OracleParameter("STF_LNAME", tbLastName.Text)); } else { com2.Parameters.Add(new OracleParameter("STF_LNAME", DBNull.Value)); }
                    if (cbGender.Checked) { com2.Parameters.Add(new OracleParameter("GENDER_ID", ddlGender.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("GENDER_ID", DBNull.Value)); }
                    if (cbBirthday.Checked) { com2.Parameters.Add(new OracleParameter("BIRTHDAY", tbBirthday.Text)); } else { com2.Parameters.Add(new OracleParameter("BIRTHDAY", DBNull.Value)); }
                    if (cbStafftype.Checked) { com2.Parameters.Add(new OracleParameter("STAFFTYPE_ID", ddlStafftype.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("STAFFTYPE_ID", DBNull.Value)); }
                    if (cbTimeContact.Checked) { com2.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", ddlTimeContact.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", DBNull.Value)); }
                    if (cbBudget.Checked) { com2.Parameters.Add(new OracleParameter("BUDGET_ID", ddlBudget.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("BUDGET_ID", DBNull.Value)); }
                    if (cbSubStafftype.Checked) { com2.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", ddlStafftype.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", DBNull.Value)); }
                    if (cbAdminPosition.Checked) { com2.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ddlAdminPosition.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", DBNull.Value)); }
                    if (cbPosition.Checked) { com2.Parameters.Add(new OracleParameter("POSITION_ID", ddlPosition.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("POSITION_ID", DBNull.Value)); }
                    if (cbPositionWork.Checked) { com2.Parameters.Add(new OracleParameter("POSITION_WORK", tbPositionWork.Text)); } else { com2.Parameters.Add(new OracleParameter("POSITION_WORK", DBNull.Value)); }
                    if (cbDepartment.Checked) { com2.Parameters.Add(new OracleParameter("DEPARTMENT_ID", ddlDepartment.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DBNull.Value)); }
                    if (cbDateInwork.Checked) { com2.Parameters.Add(new OracleParameter("DATE_INWORK", tbDateInwork.Text)); } else { com2.Parameters.Add(new OracleParameter("DATE_INWORK", DBNull.Value)); }
                    if (cbDateStartThisU.Checked) { com2.Parameters.Add(new OracleParameter("DATE_START_THIS_U", tbDateStartThisU.Text)); } else { com2.Parameters.Add(new OracleParameter("DATE_START_THIS_U", DBNull.Value)); }
                    if (cbSpecialName.Checked) { com2.Parameters.Add(new OracleParameter("SPECIAL_NAME", tbSpecialName.Text)); } else { com2.Parameters.Add(new OracleParameter("SPECIAL_NAME", DBNull.Value)); }
                    if (cbTeachISCED.Checked) { com2.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", ddlTeachISCED.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", DBNull.Value)); }
                    if (cbGradLev.Checked) { com2.Parameters.Add(new OracleParameter("GRAD_LEV_ID", ddlGradLev.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("GRAD_LEV_ID", DBNull.Value)); }
                    if (cbGradCURR.Checked) { com2.Parameters.Add(new OracleParameter("GRAD_CURR", tbGradCURR.Text)); } else { com2.Parameters.Add(new OracleParameter("GRAD_CURR", DBNull.Value)); }
                    if (cbGradISCED.Checked) { com2.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", ddlGradISCED.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", DBNull.Value)); }
                    if (cbGradProg.Checked) { com2.Parameters.Add(new OracleParameter("GRAD_PROG", ddlGradProg.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("GRAD_PROG", DBNull.Value)); }
                    if (cbGradUniv.Checked) { com2.Parameters.Add(new OracleParameter("GRAD_UNIV", tbGradUniv.Text)); } else { com2.Parameters.Add(new OracleParameter("GRAD_UNIV", DBNull.Value)); }
                    if (cbGradCountry.Checked) { com2.Parameters.Add(new OracleParameter("GRAD_COUNTRY_ID", ddlGradCountry.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("GRAD_COUNTRY_ID", DBNull.Value)); }
                    if (cbReligion.Checked) { com2.Parameters.Add(new OracleParameter("RELIGION_ID", ddlReligion.SelectedValue)); } else { com2.Parameters.Add(new OracleParameter("RELIGION_ID", DBNull.Value)); }

                    id2 = com2.ExecuteNonQuery();
                }
            }
            return id;
        }

    }
}