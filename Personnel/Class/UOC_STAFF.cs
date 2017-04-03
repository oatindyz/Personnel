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
        public int UOC_ID;
        public string CITIZEN_ID;
        public string YEAR;
        public string UNIV_ID;
        public string UNIV_NAME;
        public string PREFIX_ID;
        public string PREFIX_NAME;
        public string STF_FNAME;
        public string STF_LNAME;
        public string GENDER_ID;
        public string GENDER_NAME;
        public DateTime? BIRTHDAY;
        public string HOMEADD;
        public string MOO;
        public string STREET;
        public string SUB_DISTRICT_ID;
        public string SUB_DISTRICT_NAME;
        public string DISTRICT_ID;
        public string DISTRICT_NAME;
        public string PROVINCE_ID;
        public string PROVINCE_NAME;
        public string TELEPHONE;
        public string ZIPCODE;
        public string NATION_ID;
        public string NATION_NAME;
        public string STAFFTYPE_ID;
        public string STAFFTYPE_NAME;
        public string TIME_CONTACT_ID;
        public string TIME_CONTACT_NAME;
        public string BUDGET_ID;
        public string BUDGET_NAME;
        public string SUBSTAFFTYPE_ID;
        public string SUBSTAFFTYPE_NAME;
        public string ADMIN_POSITION_ID;
        public string ADMIN_POSITION_NAME;
        public string POSITION_ID;
        public string POSITION_NAME;
        public string POSITION_WORK;
        public string DEPARTMENT_ID;
        public string DEPARTMENT_NAME;
        public DateTime? DATE_INWORK;
        public DateTime? DATE_START_THIS_U;
        public string SPECIAL_NAME;
        public string TEACH_ISCED_ID;
        public string TEACH_ISCED_NAME;
        public string GRAD_LEV_ID;
        public string GRAD_LEV_NAME;
        public string GRAD_CURR;
        public string GRAD_ISCED_ID;
        public string GRAD_ISCED_NAME;
        public string GRAD_PROG;
        public string GRAD_UNIV;
        public string GRAD_COUNTRY_ID;
        public string GRAD_COUNTRY_NAME;
        public string DEFORM_ID;
        public string DEFORM_NAME;
        public string SIT_NO;
        public string SALARY;
        public string POSITION_SALARY;
        public string RELIGION_ID;
        public string RELIGION_NAME;
        public string MOVEMENT_TYPE_ID;
        public string MOVEMENT_TYPE_NAME;
        public DateTime? MOVEMENT_DATE;
        public string DECORATION;
        public string RESULT1;
        public string PERCENT_SALARY1;
        public string RESULT2;
        public string PERCENT_SALARY2;
        public string PASSWORD;
        public int ST_LOGIN_ID;
        public string ST_LOGIN_NAME;
        public int PERSON_ROLE_ID;
        public string PERSON_ROLE_NAME;
        public string FATHER_NAME;
        public string FATHER_LNAME;
        public string MOTHER_NAME;
        public string MOTHER_LNAME;
        public string MOTHER_ONAME;
        public string COUPLE_NAME;
        public string COUPLE_LNAME;
        public string COUPLE_ONAME;

        public string AdminPositionPower;
        public string PositionWorkName;
        public string AdminPositionName;

        public string AdminPositionID;
        public string CampusID;
        public string CampusName;
        public string FacultyID;
        public string FacultyName;
        public string DivisionID;
        public string DivisionName;
        public string WorkDivisionID;
        public string WorkDivisionName;

        public string FirstName;
        public string LastName;


        public string AdminPositionNameExtra()
        {
            if (AdminPositionID == "1")
            {
                return "มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก";
            }
            else if (AdminPositionID == "2")
            {
                return CampusName;
            }
            else if (AdminPositionID == "4")
            {
                return FacultyName;
            }
            else if (AdminPositionID == "5")
            {
                return WorkDivisionName;
            }
            else if (AdminPositionID == "10")
            {
                return DivisionName;
            }
            return AdminPositionName;
        }

        public string FullName
        {
            get { return PREFIX_NAME + " " + STF_FNAME + " " + STF_LNAME; }
        }
        public string FirstNameAndLastName
        {
            get { return STF_FNAME + " " + STF_LNAME; }
        }

        public bool IsLoginFirst()
        {
            return ST_LOGIN_ID == 0;
        }
        public bool IsLoginSecond()
        {
            return ST_LOGIN_ID == 1;
        }

        public bool IsMale()
        {
            return GENDER_ID == "1";
        }
        public bool IsFemale()
        {
            return GENDER_ID == "2";
        }

    }
}