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
    }
}