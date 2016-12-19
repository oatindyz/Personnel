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
            for (int i = 0; i < Session.Count; i++)
            {
                var crntSession = Session.Keys[i];
                Response.Write(string.Concat(crntSession, "=", Session[crntSession]) + "<br />");
            }

            Session.Remove("วิทยาเขตบางพระ0");
            Session.Remove("วิทยาเขตบางพระ1");
            Session.Remove("วิทยาเขตบางพระ2");
            Session.Remove("วิทยาเขตบางพระ3");
            Session.Remove("วิทยาเขตบางพระ4");
            Session.Remove("วิทยาเขตบางพระ5");
            Session.Remove("วิทยาเขตบางพระ6");
            Session.Remove("วิทยาเขตบางพระ7");
            Session.Remove("วิทยาเขตบางพระ8");
            Session.Remove("วิทยาเขตบางพระ9");
            Session.Remove("วิทยาเขตบางพระ10");
            Session.Remove("วิทยาเขตบางพระ11");
            Session.Remove("วิทยาเขตบางพระ12");
            Session.Remove("วิทยาเขตบางพระ13");
            Session.Remove("วิทยาเขตบางพระ14");
            Session.Remove("วิทยาเขตบางพระ15");
            Session.Remove("วิทยาเขตบางพระ16");
            Session.Remove("วิทยาเขตบางพระ17");
            Session.Remove("วิทยาเขตบางพระ18");
            Session.Remove("วิทยาเขตบางพระ19");
            Session.Remove("วิทยาเขตบางพระ20");
            Session.Remove("วิทยาเขตบางพระ21");
            Session.Remove("วิทยาเขตบางพระ22");
            Session.Remove("วิทยาเขตบางพระ23");
            Session.Remove("วิทยาเขตบางพระ24");
            Session.Remove("0วิทยาเขตบางพระ0");
            Session.Remove("0วิทยาเขตบางพระ1");
            Session.Remove("0วิทยาเขตบางพระ2");
            Session.Remove("0วิทยาเขตบางพระ3");
            Session.Remove("0วิทยาเขตบางพระ4");
            Session.Remove("0วิทยาเขตบางพระ5");
            Session.Remove("0วิทยาเขตบางพระ6");
            Session.Remove("0วิทยาเขตบางพระ7");
            Session.Remove("0วิทยาเขตบางพระ8");
            Session.Remove("0วิทยาเขตบางพระ9");
            Session.Remove("0วิทยาเขตบางพระ10");
            Session.Remove("0วิทยาเขตบางพระ11");
            Session.Remove("0วิทยาเขตบางพระ12");
            Session.Remove("0วิทยาเขตบางพระ13");
            Session.Remove("0วิทยาเขตบางพระ14");
            Session.Remove("0วิทยาเขตบางพระ15");
            Session.Remove("0วิทยาเขตบางพระ16");
            Session.Remove("0วิทยาเขตบางพระ17");
            Session.Remove("0วิทยาเขตบางพระ18");
            Session.Remove("0วิทยาเขตบางพระ19");

            Session.Remove("วิทยาเขตจันทบุรี0");
            Session.Remove("วิทยาเขตจันทบุรี1");
            Session.Remove("วิทยาเขตจันทบุรี2");
            Session.Remove("วิทยาเขตจันทบุรี3");
            Session.Remove("วิทยาเขตจันทบุรี4");
            Session.Remove("วิทยาเขตจันทบุรี5");
            Session.Remove("วิทยาเขตจันทบุรี6");
            Session.Remove("วิทยาเขตจันทบุรี7");
            Session.Remove("วิทยาเขตจันทบุรี8");
            Session.Remove("วิทยาเขตจันทบุรี9");
            Session.Remove("วิทยาเขตจันทบุรี10");
            Session.Remove("วิทยาเขตจันทบุรี11");
            Session.Remove("วิทยาเขตจันทบุรี12");
            Session.Remove("วิทยาเขตจันทบุรี13");
            Session.Remove("วิทยาเขตจันทบุรี14");
            Session.Remove("วิทยาเขตจันทบุรี15");
            Session.Remove("วิทยาเขตจันทบุรี16");
            Session.Remove("วิทยาเขตจันทบุรี17");
            Session.Remove("วิทยาเขตจันทบุรี18");
            Session.Remove("วิทยาเขตจันทบุรี19");
            Session.Remove("วิทยาเขตจันทบุรี20");
            Session.Remove("วิทยาเขตจันทบุรี21");
            Session.Remove("วิทยาเขตจันทบุรี22");
            Session.Remove("วิทยาเขตจันทบุรี23");
            Session.Remove("วิทยาเขตจันทบุรี24");
            Session.Remove("0วิทยาเขตจันทบุรี0");
            Session.Remove("0วิทยาเขตจันทบุรี1");
            Session.Remove("0วิทยาเขตจันทบุรี2");
            Session.Remove("0วิทยาเขตจันทบุรี3");
            Session.Remove("0วิทยาเขตจันทบุรี4");
            Session.Remove("0วิทยาเขตจันทบุรี5");
            Session.Remove("0วิทยาเขตจันทบุรี6");
            Session.Remove("0วิทยาเขตจันทบุรี7");
            Session.Remove("0วิทยาเขตจันทบุรี8");
            Session.Remove("0วิทยาเขตจันทบุรี9");
            Session.Remove("0วิทยาเขตจันทบุรี10");
            Session.Remove("0วิทยาเขตจันทบุรี11");
            Session.Remove("0วิทยาเขตจันทบุรี12");
            Session.Remove("0วิทยาเขตจันทบุรี13");
            Session.Remove("0วิทยาเขตจันทบุรี14");
            Session.Remove("0วิทยาเขตจันทบุรี15");
            Session.Remove("0วิทยาเขตจันทบุรี16");
            Session.Remove("0วิทยาเขตจันทบุรี17");
            Session.Remove("0วิทยาเขตจันทบุรี18");
            Session.Remove("0วิทยาเขตจันทบุรี19");

            Session.Remove("วิทยาเขตจักรพงษภูวนารถ0");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ1");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ2");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ3");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ4");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ5");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ6");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ7");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ8");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ9");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ10");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ11");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ12");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ13");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ14");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ15");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ16");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ17");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ18");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ19");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ20");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ21");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ22");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ23");
            Session.Remove("วิทยาเขตจักรพงษภูวนารถ24");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ0");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ1");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ2");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ3");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ4");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ5");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ6");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ7");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ8");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ9");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ10");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ11");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ12");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ13");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ14");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ15");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ16");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ17");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ18");
            Session.Remove("0วิทยาเขตจักรพงษภูวนารถ19");

            Session.Remove("วิทยาเขตอุเทนถวาย0");
            Session.Remove("วิทยาเขตอุเทนถวาย1");
            Session.Remove("วิทยาเขตอุเทนถวาย2");
            Session.Remove("วิทยาเขตอุเทนถวาย3");
            Session.Remove("วิทยาเขตอุเทนถวาย4");
            Session.Remove("วิทยาเขตอุเทนถวาย5");
            Session.Remove("วิทยาเขตอุเทนถวาย6");
            Session.Remove("วิทยาเขตอุเทนถวาย7");
            Session.Remove("วิทยาเขตอุเทนถวาย8");
            Session.Remove("วิทยาเขตอุเทนถวาย9");
            Session.Remove("วิทยาเขตอุเทนถวาย10");
            Session.Remove("วิทยาเขตอุเทนถวาย11");
            Session.Remove("วิทยาเขตอุเทนถวาย12");
            Session.Remove("วิทยาเขตอุเทนถวาย13");
            Session.Remove("วิทยาเขตอุเทนถวาย14");
            Session.Remove("วิทยาเขตอุเทนถวาย15");
            Session.Remove("วิทยาเขตอุเทนถวาย16");
            Session.Remove("วิทยาเขตอุเทนถวาย17");
            Session.Remove("วิทยาเขตอุเทนถวาย18");
            Session.Remove("วิทยาเขตอุเทนถวาย19");
            Session.Remove("วิทยาเขตอุเทนถวาย20");
            Session.Remove("วิทยาเขตอุเทนถวาย21");
            Session.Remove("วิทยาเขตอุเทนถวาย22");
            Session.Remove("วิทยาเขตอุเทนถวาย23");
            Session.Remove("วิทยาเขตอุเทนถวาย24");
            Session.Remove("0วิทยาเขตอุเทนถวาย0");
            Session.Remove("0วิทยาเขตอุเทนถวาย1");
            Session.Remove("0วิทยาเขตอุเทนถวาย2");
            Session.Remove("0วิทยาเขตอุเทนถวาย3");
            Session.Remove("0วิทยาเขตอุเทนถวาย4");
            Session.Remove("0วิทยาเขตอุเทนถวาย5");
            Session.Remove("0วิทยาเขตอุเทนถวาย6");
            Session.Remove("0วิทยาเขตอุเทนถวาย7");
            Session.Remove("0วิทยาเขตอุเทนถวาย8");
            Session.Remove("0วิทยาเขตอุเทนถวาย9");
            Session.Remove("0วิทยาเขตอุเทนถวาย10");
            Session.Remove("0วิทยาเขตอุเทนถวาย11");
            Session.Remove("0วิทยาเขตอุเทนถวาย12");
            Session.Remove("0วิทยาเขตอุเทนถวาย13");
            Session.Remove("0วิทยาเขตอุเทนถวาย14");
            Session.Remove("0วิทยาเขตอุเทนถวาย15");
            Session.Remove("0วิทยาเขตอุเทนถวาย16");
            Session.Remove("0วิทยาเขตอุเทนถวาย17");
            Session.Remove("0วิทยาเขตอุเทนถวาย18");
            Session.Remove("0วิทยาเขตอุเทนถวาย19");


        }

    }
}