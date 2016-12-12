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
        protected void Page_Init(object sender, EventArgs e) {
            if (PersonnelSystem.GetPersonnelSystem(this) == null) {
                Response.Redirect("Access.aspx");
                return;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionTimeOut.Text = Session.Timeout.ToString() + " นาที";
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            PersonnelSystem ps99 = PersonnelSystem.GetRoleAdmin(this);
            PersonnelSystem ps1 = PersonnelSystem.GetRoleFree(this);
            PersonnelSystem ps2 = PersonnelSystem.GetRolePersonnel(this);
            PersonnelSystem ps3 = PersonnelSystem.GetRoleGP7(this);
            UOC_STAFF loginPerson = ps.LoginPerson;
            UOC_STAFF loginPerson99 = ps99.LoginPerson;
            UOC_STAFF loginPerson1 = ps1.LoginPerson;
            UOC_STAFF loginPerson2 = ps2.LoginPerson;
            UOC_STAFF loginPerson3 = ps3.LoginPerson;

            if (!IsPostBack)
            {
                lbName.Text = loginPerson.FullName;
                lbStaffType.Text = loginPerson.STAFFTYPE_NAME;
                lbPosition.Text = loginPerson.POSITION_NAME;
                lbPositionRank.Text = loginPerson.ADMIN_POSITION_NAME;
                lbDepartment.Text = loginPerson.DEPARTMENT_NAME;

                string name = loginPerson.FullName;
                profile_name.InnerText = name;


                if (loginPerson.ST_LOGIN_ID == 0)
                {
                    menu1.Visible = false;
                }

                if (loginPerson99.PERSON_ROLE_ID == 99)
                {
                    MenuRoleID99.Visible = true;
                    MenuPublic.Visible = true;
                    MenuRoleID2Duty.Visible = false;
                    MenuRoleID3Duty.Visible = false;
                }
                else if (loginPerson1.PERSON_ROLE_ID == 1)
                {
                    MenuRoleID99.Visible = false;
                    MenuPublic.Visible = true;
                    MenuRoleID2Duty.Visible = false;
                    MenuRoleID3Duty.Visible = false;
                }
                else if (loginPerson2.PERSON_ROLE_ID == 2)
                {
                    MenuRoleID99.Visible = false;
                    MenuPublic.Visible = true;
                    MenuRoleID2Duty.Visible = true;
                    MenuRoleID3Duty.Visible = false;
                }
                else if (loginPerson3.PERSON_ROLE_ID == 3)
                {
                    MenuRoleID99.Visible = false;
                    MenuPublic.Visible = true;
                    MenuRoleID2Duty.Visible = false;
                    MenuRoleID3Duty.Visible = true;
                }
                else
                {
                    MenuRoleID99.Visible = true;
                    MenuPublic.Visible = true;
                    MenuRoleID2Duty.Visible = true;
                    MenuRoleID3Duty.Visible = true;
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

        protected void lbuUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}