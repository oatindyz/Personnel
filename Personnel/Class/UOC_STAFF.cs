using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Globalization;

namespace Personnel.Class
{
    public class UOC_STAFF
    {
        public string CITIZEN_ID;
        public string YEAR;
        public string UNIV_ID;
        public string PREFIX_NAME;
        public string STF_FNAME;
        public string STF_LNAME;
        public string GENDER_ID;
        public string BIRTHDAY;
        public string HOMEADD;
        public string MOO;
        public string STREET;
        public string SUB_DISTRICT_ID;
        public string DISTRICT_ID;
        public string PROVINCE_ID;
        public string TELEPHONE;
        public string ZIPCODE;
        public string NATION_ID;
        public string STAFFTYPE_ID;
        public string TIME_CONTACT_ID;
        public string BUDGET_ID;
        public string SUBSTAFFTYPE_ID;
        public string ADMIN_POSITION_ID;
        public string POSITION_ID;
        public string POSITION_WORK;
        public string DEPARTMENT_ID;
        public string DATE_INWORK;
        public string DATE_START_THIS_U;
        public string SPECIAL_NAME;
        public string TEACH_ISCED_ID;
        public string GRAD_LEV_ID;
        public string GRAD_CURR;
        public string GRAD_ISCED_ID;
        public string GRAD_PROG;
        public string GRAD_UNIV;
        public string GRAD_COUNTRY_ID;
        public string DEFORM_ID;
        public string SIT_NO;
        public string SALARY;
        public string POSITION_SALARY;
        public string RELIGION_ID;
        public string MOVEMENT_TYPE_ID;
        public string MOVEMENT_DATE;
        public string DECORATION;
        public string RESULT1;
        public string PERCENT_SALARY1;
        public string RESULT2;
        public string PERCENT_SALARY2;
        public string PASSWORD;

        public string FullName
        {
            get { return PREFIX_NAME + STF_FNAME + " " + STF_LNAME; }
        }
        public string FirstNameAndLastName
        {
            get { return STF_FNAME + " " + STF_LNAME; }
        }


    }
}