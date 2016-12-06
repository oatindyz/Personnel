using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Personnel.Class
{
    public class PersonnelSystem {

        public UOC_STAFF LoginPerson;

        public PersonnelSystem() {}

        public static PersonnelSystem GetPersonnelSystem(Control control) {
            return ((PersonnelSystem)control.Page.Session["PersonnelSystem"]);
        }
        public static PersonnelSystem GetRoleAdmin(Control control)
        {
            return ((PersonnelSystem)control.Page.Session["ROLE-ADMIN"]);
        }
        public static PersonnelSystem GetRoleFree(Control control)
        {
            return ((PersonnelSystem)control.Page.Session["ROLE-FREE"]);
        }
        public static PersonnelSystem GetRolePersonnel(Control control)
        {
            return ((PersonnelSystem)control.Page.Session["ROLE-PERSONNEL"]);
        }
        public static PersonnelSystem GetRoleGP7(Control control)
        {
            return ((PersonnelSystem)control.Page.Session["ROLE-GP7"]);
        }
    }
}