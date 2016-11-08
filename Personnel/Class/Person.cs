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
        public int ST_LOGIN_ID { get; set; }
        public int PERSON_ROLE_ID { get; set; }
        public string FATHER_NAME { get; set; }
        public string FATHER_LNAME { get; set; }
        public string MOTHER_NAME { get; set; }
        public string MOTHER_LNAME { get; set; }
        public string MOTHER_ONAME { get; set; }
        public string COUPLE_NAME { get; set; }
        public string COUPLE_LNAME { get; set; }
        public string COUPLE_ONAME { get; set; }

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
            int ST_LOGIN_ID,
            int PERSON_ROLE_ID,
            string FATHER_NAME,
            string FATHER_LNAME,
            string MOTHER_NAME,
            string MOTHER_LNAME,
            string MOTHER_ONAME,
            string COUPLE_NAME,
            string COUPLE_LNAME,
            string COUPLE_ONAME
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
            this.ST_LOGIN_ID = ST_LOGIN_ID;
            this.PERSON_ROLE_ID = PERSON_ROLE_ID;
            this.FATHER_NAME = FATHER_NAME;
            this.FATHER_LNAME = FATHER_LNAME;
            this.MOTHER_NAME = MOTHER_NAME;
            this.MOTHER_LNAME = MOTHER_LNAME;
            this.MOTHER_ONAME = MOTHER_ONAME;
            this.COUPLE_NAME = COUPLE_NAME;
            this.COUPLE_LNAME = COUPLE_LNAME;
            this.COUPLE_ONAME = COUPLE_ONAME;
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
                using (OracleCommand com = new OracleCommand("INSERT INTO UOC_STAFF (YEAR,UNIV_ID,CITIZEN_ID,PREFIX_NAME,STF_FNAME,STF_LNAME,GENDER_ID,BIRTHDAY,HOMEADD,MOO,STREET,SUB_DISTRICT_ID,DISTRICT_ID,PROVINCE_ID,TELEPHONE,ZIPCODE,NATION_ID,STAFFTYPE_ID,TIME_CONTACT_ID,BUDGET_ID,SUBSTAFFTYPE_ID,ADMIN_POSITION_ID,POSITION_ID,POSITION_WORK,DEPARTMENT_ID,DATE_INWORK,DATE_START_THIS_U,SPECIAL_NAME,TEACH_ISCED_ID,GRAD_LEV_ID,GRAD_CURR,GRAD_ISCED_ID,GRAD_PROG,GRAD_UNIV,GRAD_COUNTRY_ID,DEFORM_ID,SIT_NO,SALARY,POSITION_SALARY,RELIGION_ID,MOVEMENT_TYPE_ID,MOVEMENT_DATE,DECORATION,RESULT1,PERCENT_SALARY1,RESULT2,PERCENT_SALARY2,ST_LOGIN_ID,PERSON_ROLE_ID) VALUES (:YEAR,:UNIV_ID,:CITIZEN_ID,:PREFIX_NAME,:STF_FNAME,:STF_LNAME,:GENDER_ID,:BIRTHDAY,:HOMEADD,:MOO,:STREET,:SUB_DISTRICT_ID,:DISTRICT_ID,:PROVINCE_ID,:TELEPHONE,:ZIPCODE,:NATION_ID,:STAFFTYPE_ID,:TIME_CONTACT_ID,:BUDGET_ID,:SUBSTAFFTYPE_ID,:ADMIN_POSITION_ID,:POSITION_ID,:POSITION_WORK,:DEPARTMENT_ID,:DATE_INWORK,:DATE_START_THIS_U,:SPECIAL_NAME,:TEACH_ISCED_ID,:GRAD_LEV_ID,:GRAD_CURR,:GRAD_ISCED_ID,:GRAD_PROG,:GRAD_UNIV,:GRAD_COUNTRY_ID,:DEFORM_ID,:SIT_NO,:SALARY,:POSITION_SALARY,:RELIGION_ID,:MOVEMENT_TYPE_ID,:MOVEMENT_DATE,:DECORATION,:RESULT1,:PERCENT_SALARY1,:RESULT2,:PERCENT_SALARY2,:ST_LOGIN_ID,:PERSON_ROLE_ID)", con))
                {
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
                    com.Parameters.Add(new OracleParameter("ST_LOGIN_ID", ST_LOGIN_ID));
                    com.Parameters.Add(new OracleParameter("PERSON_ROLE_ID", PERSON_ROLE_ID));
                    id = com.ExecuteNonQuery();

                }
            }
            return id;
        }

        public bool UPDATE_GP7()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update UOC_STAFF Set";
                query += " FATHER_NAME = :FATHER_NAME ,";
                query += " FATHER_LNAME = :FATHER_LNAME ,";
                query += " MOTHER_NAME = :MOTHER_NAME ,";
                query += " MOTHER_LNAME = :MOTHER_LNAME ,";
                query += " MOTHER_ONAME = :MOTHER_ONAME ,";
                query += " COUPLE_NAME = :COUPLE_NAME ,";
                query += " COUPLE_LNAME = :COUPLE_LNAME ,";
                query += " COUPLE_ONAME = :COUPLE_ONAME ";
                query += " where UOC_ID = :UOC_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("FATHER_NAME", FATHER_NAME));
                    com.Parameters.Add(new OracleParameter("FATHER_LNAME", FATHER_LNAME));
                    com.Parameters.Add(new OracleParameter("MOTHER_NAME", MOTHER_NAME));
                    com.Parameters.Add(new OracleParameter("MOTHER_LNAME", MOTHER_LNAME));
                    com.Parameters.Add(new OracleParameter("MOTHER_ONAME", MOTHER_ONAME));
                    com.Parameters.Add(new OracleParameter("COUPLE_NAME", COUPLE_NAME));
                    com.Parameters.Add(new OracleParameter("COUPLE_LNAME", COUPLE_LNAME));
                    com.Parameters.Add(new OracleParameter("COUPLE_ONAME", COUPLE_ONAME));
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
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
                query += " where UOC_ID = :UOC_ID ";

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
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));

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
                query += " HOMEADD = :HOMEADD ,";
                query += " MOO = :MOO ,";
                query += " STREET = :STREET ,";
                query += " PROVINCE_ID = :PROVINCE_ID ,";
                query += " DISTRICT_ID = :DISTRICT_ID ,";
                query += " SUB_DISTRICT_ID = :SUB_DISTRICT_ID ,";
                query += " TELEPHONE = :TELEPHONE ,";
                query += " ZIPCODE = :ZIPCODE ,";
                query += " NATION_ID = :NATION_ID ,";
                query += " SPECIAL_NAME = :SPECIAL_NAME ,";
                query += " TEACH_ISCED_ID = :TEACH_ISCED_ID ";
                query += " where UOC_ID = :UOC_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("HOMEADD", HOMEADD));
                    com.Parameters.Add(new OracleParameter("MOO", MOO));
                    com.Parameters.Add(new OracleParameter("STREET", STREET));
                    com.Parameters.Add(new OracleParameter("PROVINCE_ID", PROVINCE_ID));
                    com.Parameters.Add(new OracleParameter("DISTRICT_ID", DISTRICT_ID));
                    com.Parameters.Add(new OracleParameter("SUB_DISTRICT_ID", SUB_DISTRICT_ID));
                    com.Parameters.Add(new OracleParameter("TELEPHONE", TELEPHONE));
                    com.Parameters.Add(new OracleParameter("ZIPCODE", ZIPCODE));
                    com.Parameters.Add(new OracleParameter("NATION_ID", NATION_ID));
                    com.Parameters.Add(new OracleParameter("SPECIAL_NAME", SPECIAL_NAME));
                    com.Parameters.Add(new OracleParameter("TEACH_ISCED_ID", TEACH_ISCED_ID));
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

    public class PS_STUDY
    {
        public int STUDY_ID { get; set; }
        public int UOC_ID { get; set; }
        public string UNIV_NAME { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public string QUALIFICATION { get; set; }

        public PS_STUDY() { }
        public PS_STUDY(int STUDY_ID, int UOC_ID, string UNIV_NAME, DateTime START_DATE, DateTime END_DATE, string QUALIFICATION)
        {
            this.STUDY_ID = STUDY_ID;
            this.UOC_ID = UOC_ID;
            this.UNIV_NAME = UNIV_NAME;
            this.START_DATE = START_DATE;
            this.END_DATE = END_DATE;
            this.QUALIFICATION = QUALIFICATION;
        }

        public DataTable SELECT_PS_STUDY(string STUDY_ID, string UOC_ID, string UNIV_NAME, string START_DATE, string END_DATE, string QUALIFICATION)
        {
            DataTable dt = new DataTable();
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT * FROM PS_STUDY ";
                if (!string.IsNullOrEmpty(STUDY_ID) || !string.IsNullOrEmpty(UOC_ID) || !string.IsNullOrEmpty(UNIV_NAME) || !string.IsNullOrEmpty(START_DATE) || !string.IsNullOrEmpty(END_DATE) || !string.IsNullOrEmpty(QUALIFICATION))
                {
                    query += "where 1=1";
                    if (!string.IsNullOrEmpty(STUDY_ID))
                    {
                        query += " and STUDY_ID like :STUDY_ID ";
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        query += " and UOC_ID like :UOC_ID ";
                    }
                    if (!string.IsNullOrEmpty(UNIV_NAME))
                    {
                        query += " and UNIV_NAME like :UNIV_NAME ";
                    }
                    if (!string.IsNullOrEmpty(START_DATE))
                    {
                        query += " and START_DATE like :START_DATE ";
                    }
                    if (!string.IsNullOrEmpty(END_DATE))
                    {
                        query += " and END_DATE like :END_DATE ";
                    }
                    if (!string.IsNullOrEmpty(QUALIFICATION))
                    {
                        query += " and QUALIFICATION like :QUALIFICATION ";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(STUDY_ID))
                    {
                        com.Parameters.Add(new OracleParameter("STUDY_ID", STUDY_ID));
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    }
                    if (!string.IsNullOrEmpty(UNIV_NAME))
                    {
                        com.Parameters.Add(new OracleParameter("UNIV_NAME", UNIV_NAME));
                    }
                    if (!string.IsNullOrEmpty(START_DATE))
                    {
                        com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    }
                    if (!string.IsNullOrEmpty(END_DATE))
                    {
                        com.Parameters.Add(new OracleParameter("END_DATE", END_DATE));
                    }
                    if (!string.IsNullOrEmpty(QUALIFICATION))
                    {
                        com.Parameters.Add(new OracleParameter("QUALIFICATION", QUALIFICATION));
                    }
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    {
                        da.Fill(dt);
                    }
                }

            }

            return dt;
        }

        public int INSERT_PS_STUDY()
        {
            int id = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO PS_STUDY (UOC_ID,UNIV_NAME,START_DATE,END_DATE,QUALIFICATION) VALUES (:UOC_ID,:UNIV_NAME,:START_DATE,:END_DATE,:QUALIFICATION)", con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("UNIV_NAME", UNIV_NAME));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    com.Parameters.Add(new OracleParameter("END_DATE", END_DATE));
                    com.Parameters.Add(new OracleParameter("QUALIFICATION", QUALIFICATION));
                    id = com.ExecuteNonQuery();

                }
            }
            return id;
        }

        public bool UPDATE_PS_STUDY()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update PS_STUDY Set";
                query += " UOC_ID = :UOC_ID ,";
                query += " UNIV_NAME = :UNIV_NAME ,";
                query += " START_DATE = :START_DATE ,";
                query += " END_DATE = :END_DATE ,";
                query += " QUALIFICATION = :QUALIFICATION ";
                query += " where STUDY_ID = :STUDY_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("UNIV_NAME", UNIV_NAME));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    com.Parameters.Add(new OracleParameter("END_DATE", END_DATE));
                    com.Parameters.Add(new OracleParameter("QUALIFICATION", QUALIFICATION));
                    com.Parameters.Add(new OracleParameter("STUDY_ID", STUDY_ID));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }

        public bool DELETE_PS_STUDY()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("DELETE PS_STUDY WHERE STUDY_ID = :STUDY_ID", con))
                {
                    com.Parameters.Add(new OracleParameter("STUDY_ID", STUDY_ID));
                    if (com.ExecuteNonQuery() >= 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }

    public class PS_PRO_LICENSE
    {
        public int PRO_ID { get; set; }
        public int UOC_ID { get; set; }
        public string LICENSE_NAME { get; set; }
        public string DEPARTMENT { get; set; }
        public string LICENSE_NUMBER { get; set; }
        public DateTime START_DATE { get; set; }

        public PS_PRO_LICENSE() { }
        public PS_PRO_LICENSE(int PRO_ID, int UOC_ID, string LICENSE_NAME, string DEPARTMENT, string LICENSE_NUMBER, DateTime START_DATE)
        {
            this.PRO_ID = PRO_ID;
            this.UOC_ID = UOC_ID;
            this.LICENSE_NAME = LICENSE_NAME;
            this.DEPARTMENT = DEPARTMENT;
            this.LICENSE_NUMBER = LICENSE_NUMBER;
            this.START_DATE = START_DATE;
        }

        public DataTable SELECT_PS_PRO_LICENSE(string PRO_ID, string UOC_ID, string LICENSE_NAME, string DEPARTMENT, string LICENSE_NUMBER, string START_DATE)
        {
            DataTable dt = new DataTable();
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT * FROM PS_PRO_LICENSE ";
                if (!string.IsNullOrEmpty(PRO_ID) || !string.IsNullOrEmpty(UOC_ID) || !string.IsNullOrEmpty(LICENSE_NAME) || !string.IsNullOrEmpty(DEPARTMENT) || !string.IsNullOrEmpty(LICENSE_NUMBER) || !string.IsNullOrEmpty(START_DATE))
                {
                    query += "where 1=1";
                    if (!string.IsNullOrEmpty(PRO_ID))
                    {
                        query += " and PRO_ID like :PRO_ID ";
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        query += " and UOC_ID like :UOC_ID ";
                    }
                    if (!string.IsNullOrEmpty(LICENSE_NAME))
                    {
                        query += " and LICENSE_NAME like :LICENSE_NAME ";
                    }
                    if (!string.IsNullOrEmpty(DEPARTMENT))
                    {
                        query += " and DEPARTMENT like :DEPARTMENT ";
                    }
                    if (!string.IsNullOrEmpty(LICENSE_NUMBER))
                    {
                        query += " and LICENSE_NUMBER like :LICENSE_NUMBER ";
                    }
                    if (!string.IsNullOrEmpty(START_DATE))
                    {
                        query += " and START_DATE like :START_DATE ";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(PRO_ID))
                    {
                        com.Parameters.Add(new OracleParameter("PRO_ID", PRO_ID));
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    }
                    if (!string.IsNullOrEmpty(LICENSE_NAME))
                    {
                        com.Parameters.Add(new OracleParameter("LICENSE_NAME", LICENSE_NAME));
                    }
                    if (!string.IsNullOrEmpty(DEPARTMENT))
                    {
                        com.Parameters.Add(new OracleParameter("DEPARTMENT", DEPARTMENT));
                    }
                    if (!string.IsNullOrEmpty(LICENSE_NUMBER))
                    {
                        com.Parameters.Add(new OracleParameter("LICENSE_NUMBER", LICENSE_NUMBER));
                    }
                    if (!string.IsNullOrEmpty(START_DATE))
                    {
                        com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    }
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    {
                        da.Fill(dt);
                    }
                }

            }

            return dt;
        }

        public int INSERT_PS_PRO_LICENSE()
        {
            int id = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO PS_PRO_LICENSE (UOC_ID,LICENSE_NAME,DEPARTMENT,LICENSE_NUMBER,START_DATE) VALUES (:UOC_ID,:LICENSE_NAME,:DEPARTMENT,:LICENSE_NUMBER,:START_DATE)", con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("LICENSE_NAME", LICENSE_NAME));
                    com.Parameters.Add(new OracleParameter("DEPARTMENT", DEPARTMENT));
                    com.Parameters.Add(new OracleParameter("LICENSE_NUMBER", LICENSE_NUMBER));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    id = com.ExecuteNonQuery();

                }
            }
            return id;
        }

        public bool UPDATE_PS_PRO_LICENSE()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update PS_PRO_LICENSE Set";
                query += " UOC_ID = :UOC_ID ,";
                query += " LICENSE_NAME = :LICENSE_NAME ,";
                query += " DEPARTMENT = :DEPARTMENT ,";
                query += " LICENSE_NUMBER = :LICENSE_NUMBER ,";
                query += " START_DATE = :START_DATE ";
                query += " where PRO_ID = :PRO_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("LICENSE_NAME", LICENSE_NAME));
                    com.Parameters.Add(new OracleParameter("DEPARTMENT", DEPARTMENT));
                    com.Parameters.Add(new OracleParameter("LICENSE_NUMBER", LICENSE_NUMBER));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    com.Parameters.Add(new OracleParameter("PRO_ID", PRO_ID));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }

        public bool DELETE_PS_PRO_LICENSE()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("DELETE PS_PRO_LICENSE WHERE PRO_ID = :PRO_ID", con))
                {
                    com.Parameters.Add(new OracleParameter("PRO_ID", PRO_ID));
                    if (com.ExecuteNonQuery() >= 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }

    public class PS_TRAINING
    {
        public int TRAINING_ID { get; set; }
        public int UOC_ID { get; set; }
        public string TRAINING_NAME { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public string DEPARTMENT { get; set; }

        public PS_TRAINING() { }
        public PS_TRAINING(int TRAINING_ID, int UOC_ID, string TRAINING_NAME, DateTime START_DATE, DateTime END_DATE, string DEPARTMENT)
        {
            this.TRAINING_ID = TRAINING_ID;
            this.UOC_ID = UOC_ID;
            this.TRAINING_NAME = TRAINING_NAME;
            this.START_DATE = START_DATE;
            this.END_DATE = END_DATE;
            this.DEPARTMENT = DEPARTMENT;
        }

        public DataTable SELECT_PS_TRAINING(string TRAINING_ID, string UOC_ID, string TRAINING_NAME, string START_DATE, string END_DATE, string DEPARTMENT)
        {
            DataTable dt = new DataTable();
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT * FROM PS_TRAINING ";
                if (!string.IsNullOrEmpty(TRAINING_ID) || !string.IsNullOrEmpty(UOC_ID) || !string.IsNullOrEmpty(TRAINING_NAME) || !string.IsNullOrEmpty(START_DATE) || !string.IsNullOrEmpty(END_DATE) || !string.IsNullOrEmpty(DEPARTMENT))
                {
                    query += "where 1=1";
                    if (!string.IsNullOrEmpty(TRAINING_ID))
                    {
                        query += " and TRAINING_ID like :TRAINING_ID ";
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        query += " and UOC_ID like :UOC_ID ";
                    }
                    if (!string.IsNullOrEmpty(TRAINING_NAME))
                    {
                        query += " and TRAINING_NAME like :TRAINING_NAME ";
                    }
                    if (!string.IsNullOrEmpty(START_DATE))
                    {
                        query += " and START_DATE like :START_DATE ";
                    }
                    if (!string.IsNullOrEmpty(END_DATE))
                    {
                        query += " and END_DATE like :END_DATE ";
                    }
                    if (!string.IsNullOrEmpty(DEPARTMENT))
                    {
                        query += " and DEPARTMENT like :DEPARTMENT ";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(TRAINING_ID))
                    {
                        com.Parameters.Add(new OracleParameter("TRAINING_ID", TRAINING_ID));
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    }
                    if (!string.IsNullOrEmpty(TRAINING_NAME))
                    {
                        com.Parameters.Add(new OracleParameter("TRAINING_NAME", TRAINING_NAME));
                    }
                    if (!string.IsNullOrEmpty(START_DATE))
                    {
                        com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    }
                    if (!string.IsNullOrEmpty(END_DATE))
                    {
                        com.Parameters.Add(new OracleParameter("END_DATE", END_DATE));
                    }
                    if (!string.IsNullOrEmpty(DEPARTMENT))
                    {
                        com.Parameters.Add(new OracleParameter("DEPARTMENT", DEPARTMENT));
                    }
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    {
                        da.Fill(dt);
                    }
                }

            }

            return dt;
        }

        public int INSERT_PS_TRAINING()
        {
            int id = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO PS_TRAINING (UOC_ID,TRAINING_NAME,START_DATE,END_DATE,DEPARTMENT) VALUES (:UOC_ID,:TRAINING_NAME,:START_DATE,:END_DATE,:DEPARTMENT)", con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("TRAINING_NAME", TRAINING_NAME));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    com.Parameters.Add(new OracleParameter("END_DATE", END_DATE));
                    com.Parameters.Add(new OracleParameter("DEPARTMENT", DEPARTMENT));
                    id = com.ExecuteNonQuery();

                }
            }
            return id;
        }

        public bool UPDATE_PS_TRAINING()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update PS_TRAINING Set";
                query += " UOC_ID = :UOC_ID ,";
                query += " TRAINING_NAME = :TRAINING_NAME ,";
                query += " START_DATE = :START_DATE ,";
                query += " END_DATE = :END_DATE ,";
                query += " DEPARTMENT = :DEPARTMENT ";
                query += " where TRAINING_ID = :TRAINING_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("TRAINING_NAME", TRAINING_NAME));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    com.Parameters.Add(new OracleParameter("END_DATE", END_DATE));
                    com.Parameters.Add(new OracleParameter("DEPARTMENT", DEPARTMENT));
                    com.Parameters.Add(new OracleParameter("TRAINING_ID", TRAINING_ID));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }

        public bool DELETE_PS_TRAINING()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("DELETE PS_TRAINING WHERE TRAINING_ID = :TRAINING_ID", con))
                {
                    com.Parameters.Add(new OracleParameter("TRAINING_ID", TRAINING_ID));
                    if (com.ExecuteNonQuery() >= 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }

    public class PS_PUNISHMENT
    {
        public int PUNISH_ID { get; set; }
        public int UOC_ID { get; set; }
        public string YEAR { get; set; }
        public string PUNISH_NAME { get; set; }
        public string END_DATE { get; set; }
        public string REF_DOC { get; set; }

        public PS_PUNISHMENT() { }
        public PS_PUNISHMENT(int PUNISH_ID, int UOC_ID, string YEAR, string PUNISH_NAME, string REF_DOC)
        {
            this.PUNISH_ID = PUNISH_ID;
            this.UOC_ID = UOC_ID;
            this.YEAR = YEAR;
            this.PUNISH_NAME = PUNISH_NAME;
            this.END_DATE = END_DATE;
            this.REF_DOC = REF_DOC;
        }

        public DataTable SELECT_PS_PUNISHMENT(string PUNISH_ID, string UOC_ID, string YEAR, string PUNISH_NAME, string REF_DOC)
        {
            DataTable dt = new DataTable();
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT * FROM PS_PUNISHMENT ";
                if (!string.IsNullOrEmpty(PUNISH_ID) || !string.IsNullOrEmpty(UOC_ID) || !string.IsNullOrEmpty(YEAR) || !string.IsNullOrEmpty(PUNISH_NAME) || !string.IsNullOrEmpty(REF_DOC))
                {
                    query += "where 1=1";
                    if (!string.IsNullOrEmpty(PUNISH_ID))
                    {
                        query += " and PUNISH_ID like :PUNISH_ID ";
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        query += " and UOC_ID like :UOC_ID ";
                    }
                    if (!string.IsNullOrEmpty(YEAR))
                    {
                        query += " and YEAR like :YEAR ";
                    }
                    if (!string.IsNullOrEmpty(PUNISH_NAME))
                    {
                        query += " and PUNISH_NAME like :PUNISH_NAME ";
                    }
                    if (!string.IsNullOrEmpty(REF_DOC))
                    {
                        query += " and REF_DOC like :REF_DOC ";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(PUNISH_ID))
                    {
                        com.Parameters.Add(new OracleParameter("PUNISH_ID", PUNISH_ID));
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    }
                    if (!string.IsNullOrEmpty(YEAR))
                    {
                        com.Parameters.Add(new OracleParameter("YEAR", YEAR));
                    }
                    if (!string.IsNullOrEmpty(PUNISH_NAME))
                    {
                        com.Parameters.Add(new OracleParameter("PUNISH_NAME", PUNISH_NAME));
                    }
                    if (!string.IsNullOrEmpty(REF_DOC))
                    {
                        com.Parameters.Add(new OracleParameter("REF_DOC", REF_DOC));
                    }
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    {
                        da.Fill(dt);
                    }
                }

            }

            return dt;
        }

        public int INSERT_PS_PUNISHMENT()
        {
            int id = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO PS_PUNISHMENT (UOC_ID,YEAR,PUNISH_NAME,REF_DOC) VALUES (:UOC_ID,:YEAR,:PUNISH_NAME,:REF_DOC)", con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("YEAR", YEAR));
                    com.Parameters.Add(new OracleParameter("PUNISH_NAME", PUNISH_NAME));
                    com.Parameters.Add(new OracleParameter("REF_DOC", REF_DOC));
                    id = com.ExecuteNonQuery();

                }
            }
            return id;
        }

        public bool UPDATE_PS_PUNISHMENT()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update PS_PUNISHMENT Set";
                query += " UOC_ID = :UOC_ID ,";
                query += " YEAR = :YEAR ,";
                query += " PUNISH_NAME = :PUNISH_NAME ,";
                query += " REF_DOC = :REF_DOC ";
                query += " where PUNISH_ID = :PUNISH_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("YEAR", YEAR));
                    com.Parameters.Add(new OracleParameter("PUNISH_NAME", PUNISH_NAME));
                    com.Parameters.Add(new OracleParameter("REF_DOC", REF_DOC));
                    com.Parameters.Add(new OracleParameter("PUNISH_ID", PUNISH_ID));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }

        public bool DELETE_PS_PUNISHMENT()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("DELETE PS_PUNISHMENT WHERE PUNISH_ID = :PUNISH_ID", con))
                {
                    com.Parameters.Add(new OracleParameter("PUNISH_ID", PUNISH_ID));
                    if (com.ExecuteNonQuery() >= 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }

    public class PS_POSI_AND_SALARY
    {
        public int PAS_ID { get; set; }
        public int UOC_ID { get; set; }
        public DateTime START_DATE { get; set; }
        public string PAS_NAME { get; set; }
        public string NO_POSITION { get; set; }
        public string POSITION_TYPE { get; set; }
        public string POSITION_DEGREE { get; set; }
        public int SALARY { get; set; }
        public int POSITION_SALARY { get; set; }
        public string REF_DOC { get; set; }

        public PS_POSI_AND_SALARY() { }
        public PS_POSI_AND_SALARY(int PAS_ID, int UOC_ID, DateTime START_DATE, string PAS_NAME, string NO_POSITION, string POSITION_TYPE, string POSITION_DEGREE, int SALARY, int POSITION_SALARY, string REF_DOC)
        {
            this.PAS_ID = PAS_ID;
            this.UOC_ID = UOC_ID;
            this.START_DATE = START_DATE;
            this.PAS_NAME = PAS_NAME;
            this.NO_POSITION = NO_POSITION;
            this.POSITION_TYPE = POSITION_TYPE;
            this.POSITION_DEGREE = POSITION_DEGREE;
            this.SALARY = SALARY;
            this.POSITION_SALARY = POSITION_SALARY;
            this.REF_DOC = REF_DOC;
        }

        public DataTable SELECT_PS_POSI_AND_SALARY(string PAS_ID, string UOC_ID, string START_DATE, string PAS_NAME, string NO_POSITION, string POSITION_TYPE, string POSITION_DEGREE, string SALARY, string POSITION_SALARY, string REF_DOC)
        {
            DataTable dt = new DataTable();
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                string query = "SELECT * FROM PS_POSI_AND_SALARY ";
                if (!string.IsNullOrEmpty(PAS_ID) || !string.IsNullOrEmpty(UOC_ID) || !string.IsNullOrEmpty(START_DATE) || !string.IsNullOrEmpty(PAS_NAME) || !string.IsNullOrEmpty(NO_POSITION) || !string.IsNullOrEmpty(POSITION_TYPE) || !string.IsNullOrEmpty(POSITION_DEGREE) || !string.IsNullOrEmpty(SALARY) || !string.IsNullOrEmpty(POSITION_SALARY) || !string.IsNullOrEmpty(REF_DOC))
                {
                    query += "where 1=1";
                    if (!string.IsNullOrEmpty(PAS_ID))
                    {
                        query += " and PAS_ID like :PAS_ID ";
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        query += " and UOC_ID like :UOC_ID ";
                    }
                    if (!string.IsNullOrEmpty(START_DATE))
                    {
                        query += " and START_DATE like :START_DATE ";
                    }
                    if (!string.IsNullOrEmpty(PAS_NAME))
                    {
                        query += " and PAS_NAME like :PAS_NAME ";
                    }
                    if (!string.IsNullOrEmpty(NO_POSITION))
                    {
                        query += " and NO_POSITION like :NO_POSITION ";
                    }
                    if (!string.IsNullOrEmpty(POSITION_TYPE))
                    {
                        query += " and POSITION_TYPE like :POSITION_TYPE ";
                    }
                    if (!string.IsNullOrEmpty(POSITION_DEGREE))
                    {
                        query += " and POSITION_DEGREE like :POSITION_DEGREE ";
                    }
                    if (!string.IsNullOrEmpty(SALARY))
                    {
                        query += " and SALARY like :SALARY ";
                    }
                    if (!string.IsNullOrEmpty(POSITION_SALARY))
                    {
                        query += " and POSITION_SALARY like :POSITION_SALARY ";
                    }
                    if (!string.IsNullOrEmpty(REF_DOC))
                    {
                        query += " and REF_DOC like :REF_DOC ";
                    }
                }
                using (OracleCommand com = new OracleCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(PAS_ID))
                    {
                        com.Parameters.Add(new OracleParameter("PAS_ID", PAS_ID));
                    }
                    if (!string.IsNullOrEmpty(UOC_ID))
                    {
                        com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    }
                    if (!string.IsNullOrEmpty(START_DATE))
                    {
                        com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    }
                    if (!string.IsNullOrEmpty(PAS_NAME))
                    {
                        com.Parameters.Add(new OracleParameter("PAS_NAME", PAS_NAME));
                    }
                    if (!string.IsNullOrEmpty(NO_POSITION))
                    {
                        com.Parameters.Add(new OracleParameter("NO_POSITION", NO_POSITION));
                    }
                    if (!string.IsNullOrEmpty(POSITION_TYPE))
                    {
                        com.Parameters.Add(new OracleParameter("POSITION_TYPE", POSITION_TYPE));
                    }
                    if (!string.IsNullOrEmpty(POSITION_DEGREE))
                    {
                        com.Parameters.Add(new OracleParameter("POSITION_DEGREE", POSITION_DEGREE));
                    }
                    if (!string.IsNullOrEmpty(SALARY))
                    {
                        com.Parameters.Add(new OracleParameter("SALARY", SALARY));
                    }
                    if (!string.IsNullOrEmpty(POSITION_SALARY))
                    {
                        com.Parameters.Add(new OracleParameter("POSITION_SALARY", POSITION_SALARY));
                    }
                    if (!string.IsNullOrEmpty(REF_DOC))
                    {
                        com.Parameters.Add(new OracleParameter("REF_DOC", REF_DOC));
                    }
                    using (OracleDataAdapter da = new OracleDataAdapter(com))
                    {
                        da.Fill(dt);
                    }
                }

            }

            return dt;
        }

        public int INSERT_PS_POSI_AND_SALARY()
        {
            int id = 0;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO PS_POSI_AND_SALARY (UOC_ID,START_DATE,PAS_NAME,NO_POSITION,POSITION_TYPE,POSITION_DEGREE,SALARY,POSITION_SALARY,REF_DOC) VALUES (:UOC_ID,:START_DATE,:PAS_NAME,:NO_POSITION,:POSITION_TYPE,:POSITION_DEGREE,:SALARY,:POSITION_SALARY,:REF_DOC)", con))
                {
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    com.Parameters.Add(new OracleParameter("PAS_NAME", PAS_NAME));
                    com.Parameters.Add(new OracleParameter("NO_POSITION", NO_POSITION));
                    com.Parameters.Add(new OracleParameter("POSITION_TYPE", POSITION_TYPE));
                    com.Parameters.Add(new OracleParameter("POSITION_DEGREE", POSITION_DEGREE));
                    com.Parameters.Add(new OracleParameter("SALARY", SALARY));
                    com.Parameters.Add(new OracleParameter("POSITION_SALARY", POSITION_SALARY));
                    com.Parameters.Add(new OracleParameter("REF_DOC", REF_DOC));
                    id = com.ExecuteNonQuery();

                }
            }
            return id;
        }

        public bool UPDATE_PS_POSI_AND_SALARY()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();

                string query = "Update PS_POSI_AND_SALARY Set";
                query += " UOC_ID = :UOC_ID ,";
                query += " START_DATE = :START_DATE ,";
                query += " PAS_NAME = :PAS_NAME ,";
                query += " NO_POSITION = :NO_POSITION ,";
                query += " POSITION_TYPE = :POSITION_TYPE ,";
                query += " POSITION_DEGREE = :POSITION_DEGREE ,";
                query += " SALARY = :SALARY ,";
                query += " POSITION_SALARY = :POSITION_SALARY ,";
                query += " REF_DOC = :REF_DOC ";
                query += " where PAS_ID = :PAS_ID ";

                using (OracleCommand com = new OracleCommand(query, con))
                {                
                    com.Parameters.Add(new OracleParameter("UOC_ID", UOC_ID));
                    com.Parameters.Add(new OracleParameter("START_DATE", START_DATE));
                    com.Parameters.Add(new OracleParameter("PAS_NAME", PAS_NAME));
                    com.Parameters.Add(new OracleParameter("NO_POSITION", NO_POSITION));
                    com.Parameters.Add(new OracleParameter("POSITION_TYPE", POSITION_TYPE));
                    com.Parameters.Add(new OracleParameter("POSITION_DEGREE", POSITION_DEGREE));
                    com.Parameters.Add(new OracleParameter("SALARY", SALARY));
                    com.Parameters.Add(new OracleParameter("POSITION_SALARY", POSITION_SALARY));
                    com.Parameters.Add(new OracleParameter("REF_DOC", REF_DOC));
                    com.Parameters.Add(new OracleParameter("PAS_ID", PAS_ID));

                    if (com.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }

        public bool DELETE_PS_POSI_AND_SALARY()
        {
            bool result = false;
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("DELETE PS_POSI_AND_SALARY WHERE PAS_ID = :PAS_ID", con))
                {
                    com.Parameters.Add(new OracleParameter("PAS_ID", PAS_ID));
                    if (com.ExecuteNonQuery() >= 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }

} 