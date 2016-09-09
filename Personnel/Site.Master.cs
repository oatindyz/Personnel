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
            Session.Timeout = 60;
            OracleConnection.ClearAllPools();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

            //lbName.Text = loginPerson.FullName;
            //lbStaffType.Text = loginPerson.StaffTypeName;
            //lbPosition.Text = loginPerson.PositionWorkName;
            //lbPositionRank.Text = loginPerson.AdminPositionName;
            //lbDepartment.Text = loginPerson.DivisionName;

            string name = loginPerson.FirstNameAndLastName;
            profile_name.InnerText = name;
        }

        private void Logout()
        {
            Session.Remove("login_person");
            Session.Remove("login_id");
            Session.Remove("login_system_status");
            Session.Remove("login_name");
            Session.Remove("login_lastname");
            Session.Remove("redirect_to");
            Session.Remove("login_system_status_id");
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