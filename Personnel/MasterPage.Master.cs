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
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
            UOC_STAFF loginPerson = ps.LoginPerson;

        }
    }
}