using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data.OracleClient;
using Personnel.Class;

namespace Personnel
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (PersonnelSystem.GetPersonnelSystem(this) == null)
            {
                Response.Redirect("Access.aspx");
                return;
            }
            Session.Timeout = 300;
            OracleConnection.ClearAllPools();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            if (!IsPostBack)
            {
                lbName.Text = loginPerson.FullName;
                lbStaffType.Text = loginPerson.STAFFTYPE_NAME;
                lbPosition.Text = loginPerson.POSITION_NAME;
                lbPositionRank.Text = loginPerson.ADMIN_POSITION_NAME;
                lbDepartment.Text = loginPerson.DEPARTMENT_NAME;

                string name = loginPerson.FirstNameAndLastName;
                profile_name.InnerText = name;

                if (loginPerson.LOGIN_FIRST == 0)
                {
                    menu1.Visible = false;
                }

                if (loginPerson.PERSON_ROLE_ID == 1)
                {
                    MenuAdminRolePerson.Visible = false;
                    MenuAdminRoleManage.Visible = false;
                    MenuUserRolePerson.Visible = true;
                }
                else if (loginPerson.PERSON_ROLE_ID == 2)
                {
                    MenuAdminRolePerson.Visible = true;
                    MenuUserRolePerson.Visible = false;
                }
                else if (loginPerson.PERSON_ROLE_ID == 3)
                {

                }
                else if (loginPerson.PERSON_ROLE_ID == 4)
                {

                }
                else if (loginPerson.PERSON_ROLE_ID == 5)
                {

                }
            }

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                using (OracleCommand com = new OracleCommand("SELECT URL FROM PS_PERSON_IMAGE WHERE CITIZEN_ID = '" + loginPerson.CITIZEN_ID + "' AND PRESENT = 1", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fileName;
                            fileName = reader.GetValue(0).ToString();
                            string personImageFileName = DatabaseManager.GetPersonImageFileName(loginPerson.CITIZEN_ID);
                            if (personImageFileName != "")
                            {
                                profile_pic.Src = "Upload/PersonImage/" + personImageFileName;
                                profile_pic2.Src = "Upload/PersonImage/" + personImageFileName;
                            }
                            else
                            {
                                profile_pic.Src = "Image/Small/person2.png";
                            }
                        }
                    }
                }
            }

        }

        protected void lbuLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("PersonnelSystem");
            Response.Redirect("Access.aspx");
        }

        protected void lbuUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}