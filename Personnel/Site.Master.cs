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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionTimeOut.Text = Session.Timeout.ToString() + " นาที";

            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

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

                if (loginPerson.PERSON_ROLE_ID == 99)
                {
                    MenuPublic.Visible = true;
                    MenuPublic2.Visible = true;
                    MenuRolePerson.Visible = false;
                    MenuRoleInsig.Visible = false;
                    MenuRoleSalary.Visible = false;
                    MenuRoleLeave.Visible = false;
                    MenuRoleAdmin.Visible = true;
                }
                else if (loginPerson.PERSON_ROLE_ID == 1)
                {
                    MenuPublic.Visible = true;
                    MenuPublic2.Visible = true;
                    MenuRolePerson.Visible = false;
                    MenuRoleInsig.Visible = false;
                    MenuRoleSalary.Visible = false;
                    MenuRoleLeave.Visible = false;
                    MenuRoleAdmin.Visible = false;
                }
                else if (loginPerson.PERSON_ROLE_ID == 2)
                {
                    MenuPublic.Visible = true;
                    MenuPublic2.Visible = true;
                    MenuRolePerson.Visible = true;
                    MenuRoleInsig.Visible = false;
                    MenuRoleSalary.Visible = false;
                    MenuRoleLeave.Visible = false;
                    MenuRoleAdmin.Visible = false;
                }
                else if (loginPerson.PERSON_ROLE_ID == 3)
                {
                    MenuPublic.Visible = true;
                    MenuPublic2.Visible = true;
                    MenuRolePerson.Visible = false;
                    MenuRoleInsig.Visible = true;
                    MenuRoleSalary.Visible = false;
                    MenuRoleLeave.Visible = false;
                    MenuRoleAdmin.Visible = false;
                }
                else if (loginPerson.PERSON_ROLE_ID == 4)
                {
                    MenuPublic.Visible = true;
                    MenuPublic2.Visible = true;
                    MenuRolePerson.Visible = false;
                    MenuRoleInsig.Visible = false;
                    MenuRoleSalary.Visible = true;
                    MenuRoleLeave.Visible = false;
                    MenuRoleAdmin.Visible = false;
                }
                else if (loginPerson.PERSON_ROLE_ID == 5)
                {
                    MenuPublic.Visible = true;
                    MenuPublic2.Visible = true;
                    MenuRolePerson.Visible = false;
                    MenuRoleInsig.Visible = false;
                    MenuRoleSalary.Visible = false;
                    MenuRoleLeave.Visible = true;
                    MenuRoleAdmin.Visible = false;
                }

            }

            //Declare
            int countRequestID = 0;

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

                if (loginPerson.PERSON_ROLE_ID == 2)
                {
                    //Count
                    using (OracleCommand com = new OracleCommand("SELECT COUNT(STATUS_ID) FROM TB_REQUEST WHERE STATUS_ID = 0", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                countRequestID = reader.GetInt32(0);
                                IntCountRequest.Text = "คุณมีรายการที่ต้องอนุมัติ" + reader.GetInt32(0).ToString() + "รายการ";
                            }
                        }
                    }
                    
                    noti_request_none.Visible = false;
                    noti_request_approve.Visible = false;

                    int count = countRequestID;

                    if (countRequestID == 0)
                    {
                        noti_request_none.Visible = true;
                    }
                    else
                    {
                        noti_request_approve.Visible = true;
                    }

                    if (count > 0)
                    {
                        noti_alert.InnerText = "" + count;
                        noti_alert.Attributes["class"] = "ps-ms-main-hd-noti-alert";
                    }
                }
                else
                {
                    NotiAllsee.Visible = true;
                    NotiManageRequest.Visible = false;
                }
            }

        }

        protected void lbuUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}