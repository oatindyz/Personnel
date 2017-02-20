using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personnel.Class
{
    public class Department
    {
        public string ID;
        public string name;
        public string campusID;
        public Department(string ID,string name,string campusID)
        {
            this.ID = ID;
            this.name = name;
            this.campusID = campusID;
        }
    }

}