using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace Personnel.Class
{
    public class PS_PERSON
    {
        public int UOC_ID { get; set; }
        public string YEAR { get; set; }
        public string UNIV_ID { get; set; }
        public string CITIZEN_ID { get; set; }
        public string PREFIX_NAME { get; set; }
        public string STF_FNAME { get; set; }
        public string STF_LNAME { get; set; }
        public string GENDER_ID { get; set; }
        public string BIRTHDAY { get; set; }
        public string HOMEADD { get; set; }
        public string MOO { get; set; }
        public string STREET { get; set; }
        public string SUB_DISTRICT_ID { get; set; }
        public string DISTRICT_ID { get; set; }
        public string PROVINCE_ID { get; set; }
        public string TELEPHONE { get; set; }
        public string ZIPCODE { get; set; }
        public string NATION_ID { get; set; }
        public string STAFFTYPE_ID { get; set; }
        public string TIME_CONTACT_ID { get; set; }
        public string BUDGET_ID { get; set; }
        public string SUBSTAFFTYPE_ID { get; set; }
        public string ADMIN_POSITION_ID { get; set; }
        public string POSITION_ID { get; set; }
        public string POSITION_WORK { get; set; }
        public string DEPARTMENT_ID { get; set; }
        public string DATE_INWORK { get; set; }
        public string DATE_START_THIS_U { get; set; }
        public string SPECIAL_NAME { get; set; }
        public string TEACH_ISCED_ID { get; set; }
        public string GRAD_LEV_ID { get; set; }
        public string GRAD_CURR { get; set; }
        public string GRAD_ISCED_ID { get; set; }
        public string GRAD_PROG { get; set; }
        public string GRAD_UNIV { get; set; }
        public string GRAD_COUNTRY_ID { get; set; }
        public string DEFORM_ID { get; set; }
        public string SIT_NO { get; set; }
        public string SALARY { get; set; }
        public string POSITION_SALARY { get; set; }
        public string RELIGION_ID { get; set; }
        public string MOVEMENT_TYPE_ID { get; set; }
        public string MOVEMENT_DATE { get; set; }
        public string DECORATION { get; set; }
        public string RESULT1 { get; set; }
        public string PERCENT_SALARY1 { get; set; }
        public string RESULT2 { get; set; }
        public string PERCENT_SALARY2 { get; set; }
        public string PASSWORD { get; set; }
        public int LOGIN_FIRST { get; set; }
        public int CAMPUS_ID { get; set; }
        public int FACULTY_ID { get; set; }
        public int DIVISION_ID { get; set; }
        public int WORK_DIVISION_ID { get; set; }
        public int PERSON_ROLE_ID { get; set; }

        public PS_PERSON() { }
        public PS_PERSON(
            int UOC_ID,
            string YEAR,
            string UNIV_ID,
            string CITIZEN_ID,
            string PREFIX_NAME,
            string STF_FNAME,
            string STF_LNAME,
            string GENDER_ID,
            string BIRTHDAY,
            string HOMEADD,
            string MOO,
            string STREET,
            string SUB_DISTRICT_ID,
            string DISTRICT_ID,
            string PROVINCE_ID,
            string TELEPHONE,
            string ZIPCODE,
            string NATION_ID,
            string STAFFTYPE_ID,
            string TIME_CONTACT_ID,
            string BUDGET_ID,
            string SUBSTAFFTYPE_ID,
            string ADMIN_POSITION_ID,
            string POSITION_ID,
            string POSITION_WORK,
            string DEPARTMENT_ID,
            string DATE_INWORK,
            string DATE_START_THIS_U,
            string SPECIAL_NAME,
            string TEACH_ISCED_ID,
            string GRAD_LEV_ID,
            string GRAD_CURR,
            string GRAD_ISCED_ID,
            string GRAD_PROG,
            string GRAD_UNIV,
            string GRAD_COUNTRY_ID,
            string DEFORM_ID,
            string SIT_NO,
            string SALARY,
            string POSITION_SALARY,
            string RELIGION_ID,
            string MOVEMENT_TYPE_ID,
            string MOVEMENT_DATE,
            string DECORATION,
            string RESULT1,
            string PERCENT_SALARY1,
            string RESULT2,
            string PERCENT_SALARY2,
            string PASSWORD,
            int LOGIN_FIRST,
            int CAMPUS_ID,
            int FACULTY_ID,
            int DIVISION_ID,
            int WORK_DIVISION_ID,
            int PERSON_ROLE_ID
            )
        {
            this.UOC_ID = UOC_ID;
            this.YEAR = YEAR;
            this.UNIV_ID = UNIV_ID;
            this.CITIZEN_ID = CITIZEN_ID;
            this.PREFIX_NAME = PREFIX_NAME;
            this.STF_FNAME = STF_FNAME;
            this.STF_LNAME = STF_LNAME;
            this.GENDER_ID = GENDER_ID;
            this.BIRTHDAY = BIRTHDAY;
            this.HOMEADD = HOMEADD;
            this.MOO = MOO;
            this.STREET = STREET;
            this.SUB_DISTRICT_ID = SUB_DISTRICT_ID;
            this.DISTRICT_ID = DISTRICT_ID;
            this.PROVINCE_ID = PROVINCE_ID;
            this.TELEPHONE = TELEPHONE;
            this.ZIPCODE = ZIPCODE;
            this.NATION_ID = NATION_ID;
            this.STAFFTYPE_ID = STAFFTYPE_ID;
            this.TIME_CONTACT_ID = TIME_CONTACT_ID;
            this.BUDGET_ID = BUDGET_ID;
            this.SUBSTAFFTYPE_ID = SUBSTAFFTYPE_ID;
            this.ADMIN_POSITION_ID = ADMIN_POSITION_ID;
            this.POSITION_ID = POSITION_ID;
            this.POSITION_WORK = POSITION_WORK;
            this.DEPARTMENT_ID = DEPARTMENT_ID;
            this.DATE_INWORK = DATE_INWORK;
            this.DATE_START_THIS_U = DATE_START_THIS_U;
            this.SPECIAL_NAME = SPECIAL_NAME;
            this.TEACH_ISCED_ID = TEACH_ISCED_ID;
            this.GRAD_LEV_ID = GRAD_LEV_ID;
            this.GRAD_CURR = GRAD_CURR;
            this.GRAD_ISCED_ID = GRAD_ISCED_ID;
            this.GRAD_PROG = GRAD_PROG;
            this.GRAD_UNIV = GRAD_UNIV;
            this.GRAD_COUNTRY_ID = GRAD_COUNTRY_ID;
            this.DEFORM_ID = DEFORM_ID;
            this.SIT_NO = SIT_NO;
            this.SALARY = SALARY;
            this.POSITION_SALARY = POSITION_SALARY;
            this.RELIGION_ID = RELIGION_ID;
            this.MOVEMENT_TYPE_ID = MOVEMENT_TYPE_ID;
            this.MOVEMENT_DATE = MOVEMENT_DATE;
            this.DECORATION = DECORATION;
            this.RESULT1 = RESULT1;
            this.PERCENT_SALARY1 = PERCENT_SALARY1;
            this.RESULT2 = RESULT2;
            this.PERCENT_SALARY2 = PERCENT_SALARY2;
            this.PASSWORD = PASSWORD;
            this.LOGIN_FIRST = LOGIN_FIRST;
            this.CAMPUS_ID = CAMPUS_ID;
            this.FACULTY_ID = FACULTY_ID;
            this.DIVISION_ID = DIVISION_ID;
            this.WORK_DIVISION_ID = WORK_DIVISION_ID;
            this.PERSON_ROLE_ID = PERSON_ROLE_ID;
        }

        public DataTable GetDataUOC(string UOC_ID)
        {
            DataTable dt = new DataTable();
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT * FROM UOC_STAFF";
                if (!string.IsNullOrEmpty(UOC_ID))
                {
                    query += "where 1=1";
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        query += " and UOC_ID :UOC_ID";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    }
                    using(OracleDataAdapter da = new OracleDataAdapter(com))
                    {
                        da.Fill(dt);
                    }
                }

            }

            return dt;
        }

        public int INSERT_PERSON()
        {
            int id = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING)) {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO UOC_STAFF (UOC_ID,YEAR,UNIV_ID,CITIZEN_ID,PREFIX_NAME,STF_FNAME,STF_LNAME,GENDER_ID,BIRTHDAY,HOMEADD,MOO,STREET,SUB_DISTRICT_ID,DISTRICT_ID,PROVINCE_ID,TELEPHONE,ZIPCODE,NATION_ID,STAFFTYPE_ID,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_ID,POSITION_WORK,DEPARTMENT_ID,DATE_INWORK,DATE_START_THIS_U,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_LEV_ID,GRAD_CURR,GRAD_ISCED_ID,GRAD_PROG,GRAD_UNIV,GRAD_COUNTRY_ID,DEFORM_ID,SIT_NO,SALARY,POSITION_SALARY,RELIGION_ID,MOVEMENT_TYPE_ID,MOVEMENT_DATE,DECORATION,RESULT1,PERCENT_SALARY1,RESULT2,PERCENT_SALARY2,LOGIN_FIRST) VALUES (:UOC_ID,:YEAR,:UNIV_ID,:CITIZEN_ID,:PREFIX_NAME,:STF_FNAME,:STF_LNAME,:GENDER_ID,:BIRTHDAY,:HOMEADD,:MOO,:STREET,:SUB_DISTRICT_ID,:DISTRICT_ID,:PROVINCE_ID,:TELEPHONE,:ZIPCODE,:NATION_ID,:STAFFTYPE_ID,:TIME_CONTACT_ID,:BUDGET_ID,:SUBSTAFFTYPE_ID,:ADMIN_POSITION_ID,:POSITION_ID,:POSITION_WORK,:DEPARTMENT_ID,:DATE_INWORK,:DATE_START_THIS_U,:SPECIAL_NAME,:TEACH_ISCED_ID,:GRAD_LEV_ID,:GRAD_CURR,:GRAD_ISCED_ID,:GRAD_PROG,:GRAD_UNIV,:GRAD_COUNTRY_ID,:DEFORM_ID,:SIT_NO,:SALARY,:POSITION_SALARY,:RELIGION_ID,:MOVEMENT_TYPE_ID,:MOVEMENT_DATE,:DECORATION,:RESULT1,:PERCENT_SALARY1,:RESULT2,:PERCENT_SALARY2,:LOGIN_FIRST)", con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("YEAR", YEAR));
                    com.Parameters.Add(new OracleParameter("UNIV_ID", UNIV_ID));
                    com.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));
                    com.Parameters.Add(new OracleParameter("PREFIX_NAME", PREFIX_NAME));
                    com.Parameters.Add(new OracleParameter("STF_FNAME", STF_FNAME));
                    com.Parameters.Add(new OracleParameter("STF_LNAME", STF_LNAME));
                    com.Parameters.Add(new OracleParameter("GENDER_ID", GENDER_ID));
                    com.Parameters.Add(new OracleParameter("BIRTHDAY", BIRTHDAY));
                    com.Parameters.Add(new OracleParameter("HOMEADD", HOMEADD));
                    com.Parameters.Add(new OracleParameter("MOO", MOO));
                    com.Parameters.Add(new OracleParameter("STREET", STREET));
                    com.Parameters.Add(new OracleParameter("SUB_DISTRICT_ID", SUB_DISTRICT_ID));
                    com.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID));
                    com.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
                    com.Parameters.Add(new OracleParameter("TELEPHONE", TELEPHONE));
                    com.Parameters.Add(new OracleParameter("ZIPCODE", ZIPCODE));
                    com.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID));
                    com.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID));
                    com.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
                    com.Parameters.Add(new OracleParameter("BUDGET_ID", BUDGET_ID));
                    com.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", SUBSTAFFTYPE_ID));
                    com.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ADMIN_POSITION_ID));
                    com.Parameters.Add(new OracleParameter("POSITION_ID", POSITION_ID));
                    com.Parameters.Add(new OracleParameter("POSITION_WORK", POSITION_WORK));
                    com.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DEPARTMENT_ID));
                    com.Parameters.Add(new OracleParameter("DATE_INWORK", DATE_INWORK));
                    com.Parameters.Add(new OracleParameter("DATE_START_THIS_U", DATE_START_THIS_U));
                    com.Parameters.Add(new OracleParameter("SPECIAL_NAME", SPECIAL_NAME));
                    com.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", TEACH_ISCED_ID));
                    com.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GRAD_LEV_ID));
                    com.Parameters.Add(new OracleParameter("GRAD_CURR", GRAD_CURR));
                    com.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", GRAD_ISCED_ID));
                    com.Parameters.Add(new OracleParameter("GRAD_PROG", GRAD_PROG));
                    com.Parameters.Add(new OracleParameter("GRAD_UNIV", GRAD_UNIV));
                    com.Parameters.Add(new OracleParameter("GRAD_COUNTRY_ID", GRAD_COUNTRY_ID));
                    com.Parameters.Add(new OracleParameter("DEFORM_ID", DEFORM_ID));
                    com.Parameters.Add(new OracleParameter("SIT_NO", SIT_NO));
                    com.Parameters.Add(new OracleParameter("SALARY", SALARY));
                    com.Parameters.Add(new OracleParameter("POSITION_SALARY", POSITION_SALARY));
                    com.Parameters.Add(new OracleParameter("RELIGION_ID", RELIGION_ID));
                    com.Parameters.Add(new OracleParameter("MOVEMENT_TYPE_ID", MOVEMENT_TYPE_ID));
                    com.Parameters.Add(new OracleParameter("MOVEMENT_DATE", MOVEMENT_DATE));
                    com.Parameters.Add(new OracleParameter("DECORATION", DECORATION));
                    com.Parameters.Add(new OracleParameter("RESULT1", RESULT1));
                    com.Parameters.Add(new OracleParameter("PERCENT_SALARY1", PERCENT_SALARY1));
                    com.Parameters.Add(new OracleParameter("RESULT2", RESULT2));
                    com.Parameters.Add(new OracleParameter("PERCENT_SALARY2", PERCENT_SALARY2));
                    com.Parameters.Add(new OracleParameter("LOGIN_FIRST", LOGIN_FIRST));
                    id = com.ExecuteNonQuery();

                }
            }
            return id;
        }

        public bool UPDATE_PERSON()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update UOC_STAFF Set";
                query += " UNIV_ID = :UNIV_ID ,";
                query += " CITIZEN_ID = :CITIZEN_ID ,";
                query += " PREFIX_NAME = :PREFIX_NAME ,";
                query += " STF_FNAME = :STF_FNAME ,";
                query += " STF_LNAME = :STF_LNAME ,";
                query += " GENDER_ID = :GENDER_ID ,";
                query += " BIRTHDAY = :BIRTHDAY ,";
                query += " HOMEADD = :HOMEADD ,";
                query += " MOO = :MOO ,";
                query += " STREET = :STREET ,";
                query += " PROVINCE_ID = :PROVINCE_ID ,";
                query += " DISTRICT_ID = :DISTRICT_ID ,";
                query += " SUB_DISTRICT_ID = :SUB_DISTRICT_ID ,";
                query += " TELEPHONE = :TELEPHONE ,";
                query += " ZIPCODE = :ZIPCODE ,";
                query += " NATION_ID = :NATION_ID ,";
                query += " STAFFTYPE_ID = :STAFFTYPE_ID ,";
                query += " TIME_CONTACT_ID = :TIME_CONTACT_ID ,";
                query += " BUDGET_ID = :BUDGET_ID ,";
                query += " SUBSTAFFTYPE_ID = :SUBSTAFFTYPE_ID ,";
                query += " ADMIN_POSITION_ID = :ADMIN_POSITION_ID ,";
                query += " POSITION_ID = :POSITION_ID ,";
                query += " POSITION_WORK = :POSITION_WORK ,";
                query += " DEPARTMENT_ID = :DEPARTMENT_ID ,";
                query += " DATE_INWORK = :DATE_INWORK ,";
                query += " DATE_START_THIS_U = :DATE_START_THIS_U ,";
                query += " SPECIAL_NAME = :SPECIAL_NAME ,";
                query += " TEACH_ISCED_ID = :TEACH_ISCED_ID ,";
                query += " GRAD_LEV_ID = :GRAD_LEV_ID ,";
                query += " GRAD_CURR = :GRAD_CURR ,";
                query += " GRAD_ISCED_ID = :GRAD_ISCED_ID ,";
                query += " GRAD_PROG = :GRAD_PROG ,";
                query += " GRAD_UNIV = :GRAD_UNIV ,";
                query += " GRAD_COUNTRY_ID = :GRAD_COUNTRY_ID ,";
                query += " DEFORM_ID = :DEFORM_ID ,";
                query += " SIT_NO = :SIT_NO ,";
                query += " SALARY = :SALARY ,";
                query += " POSITION_SALARY = :POSITION_SALARY ,";
                query += " RELIGION_ID = :RELIGION_ID ,";
                query += " MOVEMENT_TYPE_ID = :MOVEMENT_TYPE_ID ,";
                query += " MOVEMENT_DATE = :MOVEMENT_DATE ,";
                query += " DECORATION = :DECORATION ,";
                query += " RESULT1 = :RESULT1 ,";
                query += " PERCENT_SALARY1 = :PERCENT_SALARY1 ,";
                query += " RESULT2 = :RESULT2 ,";
                query += " PERCENT_SALARY2 = :PERCENT_SALARY2 ";
                query += " where CITIZEN_ID = :CITIZEN_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("UNIV_ID", UNIV_ID));
                    com.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));
                    com.Parameters.Add(new OracleParameter("PREFIX_NAME", PREFIX_NAME));
                    com.Parameters.Add(new OracleParameter("STF_FNAME", STF_FNAME));
                    com.Parameters.Add(new OracleParameter("STF_LNAME", STF_LNAME));
                    com.Parameters.Add(new OracleParameter("GENDER_ID", GENDER_ID));
                    com.Parameters.Add(new OracleParameter("BIRTHDAY", BIRTHDAY));
                    com.Parameters.Add(new OracleParameter("HOMEADD", HOMEADD));
                    com.Parameters.Add(new OracleParameter("MOO", MOO));
                    com.Parameters.Add(new OracleParameter("STREET", STREET));
                    com.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
                    com.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID));
                    com.Parameters.Add(new OracleParameter("SUB_DISTRICT_ID", SUB_DISTRICT_ID));
                    com.Parameters.Add(new OracleParameter("TELEPHONE", TELEPHONE));
                    com.Parameters.Add(new OracleParameter("ZIPCODE", ZIPCODE));
                    com.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID));
                    com.Parameters.Add(new OracleParameter("STAFFTYPE_ID", STAFFTYPE_ID));
                    com.Parameters.Add(new OracleParameter("TIME_CONTACT_ID", TIME_CONTACT_ID));
                    com.Parameters.Add(new OracleParameter("BUDGET_ID", BUDGET_ID));
                    com.Parameters.Add(new OracleParameter("SUBSTAFFTYPE_ID", SUBSTAFFTYPE_ID));
                    com.Parameters.Add(new OracleParameter("ADMIN_POSITION_ID", ADMIN_POSITION_ID));
                    com.Parameters.Add(new OracleParameter("POSITION_ID", POSITION_ID));
                    com.Parameters.Add(new OracleParameter("POSITION_WORK", POSITION_WORK));
                    com.Parameters.Add(new OracleParameter("DEPARTMENT_ID", DEPARTMENT_ID));
                    com.Parameters.Add(new OracleParameter("DATE_INWORK", DATE_INWORK));
                    com.Parameters.Add(new OracleParameter("DATE_START_THIS_U", DATE_START_THIS_U));
                    com.Parameters.Add(new OracleParameter("SPECIAL_NAME", SPECIAL_NAME));
                    com.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", TEACH_ISCED_ID));
                    com.Parameters.Add(new OracleParameter("GRAD_LEV_ID", GRAD_LEV_ID));
                    com.Parameters.Add(new OracleParameter("GRAD_CURR", GRAD_CURR));
                    com.Parameters.Add(new OracleParameter("GRAD_ISCED_ID", GRAD_ISCED_ID));
                    com.Parameters.Add(new OracleParameter("GRAD_PROG", GRAD_PROG));
                    com.Parameters.Add(new OracleParameter("GRAD_UNIV", GRAD_UNIV));
                    com.Parameters.Add(new OracleParameter("GRAD_COUNTRY_ID", GRAD_COUNTRY_ID));
                    com.Parameters.Add(new OracleParameter("DEFORM_ID", DEFORM_ID));
                    com.Parameters.Add(new OracleParameter("SIT_NO", SIT_NO));
                    com.Parameters.Add(new OracleParameter("SALARY", SALARY));
                    com.Parameters.Add(new OracleParameter("POSITION_SALARY", POSITION_SALARY));
                    com.Parameters.Add(new OracleParameter("RELIGION_ID", RELIGION_ID));
                    com.Parameters.Add(new OracleParameter("MOVEMENT_TYPE_ID", MOVEMENT_TYPE_ID));
                    com.Parameters.Add(new OracleParameter("MOVEMENT_DATE", MOVEMENT_DATE));
                    com.Parameters.Add(new OracleParameter("DECORATION", DECORATION));
                    com.Parameters.Add(new OracleParameter("RESULT1", RESULT1));
                    com.Parameters.Add(new OracleParameter("PERCENT_SALARY1", PERCENT_SALARY1));
                    com.Parameters.Add(new OracleParameter("RESULT2", RESULT2));
                    com.Parameters.Add(new OracleParameter("PERCENT_SALARY2", PERCENT_SALARY2));
                    com.Parameters.Add(new OracleParameter("CITIZEN_ID", CITIZEN_ID));

                    if(com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }

            return result;
            }
        }

        public bool UPDATE_PERSON_USER()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update UOC_STAFF Set";
                query += " UNIV_ID = :UNIV_ID ,";
                query += " PREFIX_NAME = :PREFIX_NAME ,";
                query += " STF_FNAME = :STF_FNAME ,";
                query += " STF_LNAME = :STF_LNAME ,";
                query += " GENDER_ID = :GENDER_ID ,";
                query += " BIRTHDAY = :BIRTHDAY ,";
                query += " HOMEADD = :HOMEADD ,";
                query += " MOO = :MOO ,";
                query += " STREET = :STREET ,";
                query += " PROVINCE_ID = :PROVINCE_ID ,";
                query += " DISTRICT_ID = :DISTRICT_ID ,";
                query += " SUB_DISTRICT_ID = :SUB_DISTRICT_ID ,";
                query += " TELEPHONE = :TELEPHONE ,";
                query += " ZIPCODE = :ZIPCODE ,";
                query += " NATION_ID = :NATION_ID ";
                query += " where UOC_ID = :UOC_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("UNIV_ID", UNIV_ID));
                    com.Parameters.Add(new OracleParameter("PREFIX_NAME", PREFIX_NAME));
                    com.Parameters.Add(new OracleParameter("STF_FNAME", STF_FNAME));
                    com.Parameters.Add(new OracleParameter("STF_LNAME", STF_LNAME));
                    com.Parameters.Add(new OracleParameter("GENDER_ID", GENDER_ID));
                    com.Parameters.Add(new OracleParameter("BIRTHDAY", BIRTHDAY));
                    com.Parameters.Add(new OracleParameter("HOMEADD", HOMEADD));
                    com.Parameters.Add(new OracleParameter("MOO", MOO));
                    com.Parameters.Add(new OracleParameter("STREET", STREET));
                    com.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
                    com.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID));
                    com.Parameters.Add(new OracleParameter("SUB_DISTRICT_ID", SUB_DISTRICT_ID));
                    com.Parameters.Add(new OracleParameter("TELEPHONE", TELEPHONE));
                    com.Parameters.Add(new OracleParameter("ZIPCODE", ZIPCODE));
                    com.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID));
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }
    }
} 