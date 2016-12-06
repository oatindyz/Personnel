using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Personnel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*for (int i = 0; i < Session.Count; i++)
            {
                var crntSession = Session.Keys[i];
                Response.Write(string.Concat(crntSession, "=", Session[crntSession]) + "<br />");
            }*/
        }

    }
}