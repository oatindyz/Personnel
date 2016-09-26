using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
using System.Text;
namespace Personnel.Class
{
    public class DatabaseManager
    {

        public static readonly string PROVIDER = "System.Data.OracleClient";
        public static readonly string DATA_SOURCE = "203.158.140.67";
        public static readonly string PORT = "1521";
        public static readonly string SID = "orcl";
        public static readonly string USER_ID = "PERSONNEL";
        public static readonly string PASSWORD = "Zxcvbnm";
        public static readonly string CONNECTION_STRING = @"Data Source = " + DATA_SOURCE + ":" + PORT + "/" + SID + ";USER ID=" + USER_ID + ";PASSWORD=" + PASSWORD + ";";

        public static void ExecuteNonQuery(string sql)
        {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                }
            }
        }
        public static int ExecuteInt(string sql)
        {
            OracleConnection.ClearAllPools();
            int output = -1;
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand(sql, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            return output;
        }
        public static string ExecuteString(string sql)
        {
            OracleConnection.ClearAllPools();
            string output = null;
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand(sql, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output = reader.GetValue(0).ToString();
                        }
                    }
                }
            }
            return output;
        }
        public static int ExecuteSequence(string seq_name)
        {
            OracleConnection.ClearAllPools();
            int seq;
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT " + seq_name + ".NEXTVAL FROM DUAL", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        reader.Read();
                        seq = int.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            return seq;
        }
        public static void ExeDDL2String(DropDownList ddl ,string sql)
        {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand(sql, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ddl.Items.Add(new ListItem(reader.GetString(0) + " | " + reader.GetString(1), reader.GetString(0) + ""));
                        }
                    }
                }
            }
        }
        public static void ExeDDL2Int(DropDownList ddl, string sql)
        {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand(sql, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ddl.Items.Add(new ListItem(reader.GetInt32(0) + " | " + reader.GetString(1), reader.GetInt32(0) + ""));
                        }
                    }
                }
            }
        }
        public static void ExeDDLselectNameAndLast(DropDownList ddl, string sql)
        {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand(sql, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ddl.Items.Add(new ListItem(reader.GetString(1), reader.GetInt32(0) + ""));
                        }
                    }
                }
            }
        }
        public static void BindDropDownNon(DropDownList ddl, string sql, string text, string value)
        {
            OracleConnection.ClearAllPools();
            ddl.DataSource = CreateSQLDataSource(sql);
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
        }
        public static void BindDropDown(DropDownList ddl, string sql, string text, string value, string first)
        {
            OracleConnection.ClearAllPools();
            ddl.DataSource = CreateSQLDataSource(sql);
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(first, ""));
        }
        public static void BindGridView(GridView gv, string sql)
        {
            OracleConnection.ClearAllPools();
            SqlDataSource sds = CreateSQLDataSource(sql);
            gv.DataSource = sds;
            gv.DataBind();
        }
        public static SqlDataSource CreateSQLDataSource(string sql)
        {
            return new SqlDataSource("System.Data.OracleClient", CONNECTION_STRING, sql);
        }
        public static bool ValidatePasswordFirst(string personID, string password)
        {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID, BIRTHDAY FROM UOC_STAFF", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(0) == personID && reader.GetString(1) == password)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool ValidatePasswordNotFirst(string personID, string password)
        {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID, PASSWORD FROM UOC_STAFF", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(0) == personID && reader.GetString(1) == password)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }   
        //...
        public static UOC_STAFF GetOUC_STAFF(string CITIZEN_ID)
        {
            OracleConnection.ClearAllPools();

            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand(

                   "SELECT UOC_ID," +
                   "CITIZEN_ID," +
                   "YEAR," +
                   "UNIV_ID," +
                   "(SELECT UNIV_NAME_TH FROM REF_UNIV WHERE REF_UNIV.UNIV_ID = UOC_STAFF.UNIV_ID) UNIV_NAME," +
                   "PREFIX_NAME," +
                   "(SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) PREFIX_NAME," +
                   "STF_FNAME," +
                   "STF_LNAME," +
                   "GENDER_ID," +
                   "(SELECT GENDER_NAME FROM REF_GENDER WHERE REF_GENDER.GENDER_ID = UOC_STAFF.GENDER_ID) GENDER_NAME," +
                   "BIRTHDAY," +
                   "HOMEADD," +
                   "MOO," +
                   "STREET," +
                   "SUB_DISTRICT_ID," +
                   "(SELECT SUB_DISTRICT_NAME_TH FROM REF_SUB_DISTRICT WHERE REF_SUB_DISTRICT.SUB_DISTRICT_ID = UOC_STAFF.SUB_DISTRICT_ID) SUB_DISTRICT_NAME," +
                   "DISTRICT_ID," +
                   "(SELECT DISTRICT_NAME_TH FROM REF_DISTRICT WHERE REF_DISTRICT.DISTRICT_ID = UOC_STAFF.DISTRICT_ID) DISTRICT_NAME," +
                   "PROVINCE_ID," +
                   "(SELECT PROVINCE_NAME_TH FROM REF_PROVINCE WHERE REF_PROVINCE.PROVINCE_ID = UOC_STAFF.PROVINCE_ID) PROVINCE_NAME," +
                   "TELEPHONE," +
                   "ZIPCODE," +
                   "NATION_ID," +
                   "(SELECT NATION_NAME_ENG FROM REF_NATION WHERE REF_NATION.NATION_ID = UOC_STAFF.NATION_ID) NATION_NAME," +
                   "STAFFTYPE_ID," +
                   "(SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE REF_STAFFTYPE.STAFFTYPE_ID = UOC_STAFF.STAFFTYPE_ID) STAFFTYPE_NAME," +
                   "TIME_CONTACT_ID," +
                   "(SELECT TIME_CONTACT_NAME FROM REF_TIME_CONTACT WHERE REF_TIME_CONTACT.TIME_CONTACT_ID = UOC_STAFF.TIME_CONTACT_ID) TIME_CONTACT_NAME," +
                   "BUDGET_ID," +
                   "(SELECT BUDGET_NAME FROM REF_BUDGET WHERE REF_BUDGET.BUDGET_ID = UOC_STAFF.BUDGET_ID) BUDGET_NAME," +
                   "SUBSTAFFTYPE_ID," +
                   "(SELECT SUBSTAFFTYPE_NAME FROM REF_SUBSTAFFTYPE WHERE REF_SUBSTAFFTYPE.SUBSTAFFTYPE_ID = UOC_STAFF.SUBSTAFFTYPE_ID) SUBSTAFFTYPE_NAME," +
                   "ADMIN_POSITION_ID," +
                   "(SELECT ADMIN_NAME FROM REF_ADMIN WHERE REF_ADMIN.ADMIN_ID = UOC_STAFF.ADMIN_POSITION_ID) ADMIN_POSITION_NAME," +
                   "POSITION_ID," +
                   "(SELECT POSITION_NAME_TH FROM REF_POSITION WHERE REF_POSITION.POSITION_ID = UOC_STAFF.POSITION_ID) POSITION_NAME," +
                   "POSITION_WORK," +
                   "DEPARTMENT_ID," +
                   "(SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME," +
                   "DATE_INWORK," +
                   "DATE_START_THIS_U," +
                   "SPECIAL_NAME," +
                   "TEACH_ISCED_ID," +
                   "(SELECT ISCED_NAME FROM REF_ISCED WHERE REF_ISCED.ISCED_ID = UOC_STAFF.TEACH_ISCED_ID) TEACH_ISCED_NAME," +
                   "GRAD_LEV_ID," +
                   "(SELECT LEV_NAME_TH FROM REF_LEV WHERE REF_LEV.LEV_ID = UOC_STAFF.GRAD_LEV_ID) GRAD_LEV_NAME," +
                   "GRAD_CURR," +
                   "GRAD_ISCED_ID," +
                   "(SELECT ISCED_NAME FROM REF_ISCED WHERE REF_ISCED.ISCED_ID = UOC_STAFF.GRAD_ISCED_ID) GRAD_ISCED_NAME," +
                   "(SELECT PROGRAM_NAME FROM REF_PROGRAM WHERE REF_PROGRAM.PROGRAM_ID_NEW = UOC_STAFF.GRAD_PROG) GRAD_PROG," +
                   "GRAD_UNIV," +
                   "GRAD_COUNTRY_ID," +
                   "(SELECT NATION_NAME_ENG FROM REF_NATION WHERE REF_NATION.NATION_ID = UOC_STAFF.GRAD_COUNTRY_ID) GRAD_COUNTRY_NAME," +
                   "DEFORM_ID," +
                   "(SELECT DEFORM_NAME FROM REF_DEFORM WHERE REF_DEFORM.DEFORM_ID = UOC_STAFF.DEFORM_ID) DEFORM_NAME," +
                   "SIT_NO," +
                   "SALARY," +
                   "POSITION_SALARY," +
                   "RELIGION_ID," +
                   "(SELECT RELIGION_NAME FROM REF_RELIGION WHERE REF_RELIGION.RELIGION_ID = UOC_STAFF.RELIGION_ID) RELIGION_NAME," +
                   "MOVEMENT_TYPE_ID," +
                   "(SELECT MOVEMENT_TYPE_NAME FROM REF_MOVEMENT_TYPE WHERE REF_MOVEMENT_TYPE.MOVEMENT_TYPE_ID = UOC_STAFF.MOVEMENT_TYPE_ID) MOVEMENT_TYPE_NAME," +
                   "MOVEMENT_DATE," +
                   "DECORATION," +
                   "RESULT1," +
                   "PERCENT_SALARY1," +
                   "RESULT2," +
                   "PERCENT_SALARY2," +
                   "PASSWORD," +
                   "ST_LOGIN_ID," +
                   "(SELECT ST_LOGIN_NAME FROM TB_STATUS_LOGIN WHERE TB_STATUS_LOGIN.ST_LOGIN_ID = UOC_STAFF.ST_LOGIN_ID) ST_LOGIN_NAME," +
                   "CAMPUS_ID," +
                   "(SELECT CAMPUS_NAME FROM TB_CAMPUS WHERE TB_CAMPUS.CAMPUS_ID = UOC_STAFF.CAMPUS_ID) CAMPUS_NAME," +
                   "FACULTY_ID," +
                   "(SELECT FACULTY_NAME FROM TB_FACULTY WHERE TB_FACULTY.FACULTY_ID = UOC_STAFF.FACULTY_ID) FACULTY_NAME," +
                   "DIVISION_ID," +
                   "(SELECT DIVISION_NAME FROM TB_DIVISION WHERE TB_DIVISION.DIVISION_ID = UOC_STAFF.DIVISION_ID) DIVISION_NAME," +
                   "WORK_DIVISION_ID," +
                   "(SELECT WORK_NAME FROM TB_WORK_DIVISION WHERE TB_WORK_DIVISION.WORK_ID = UOC_STAFF.WORK_DIVISION_ID) WORK_NAME," +
                   "PERSON_ROLE_ID," +
                   "(SELECT PERSON_ROLE_NAME FROM TB_PERSON_ROLE WHERE TB_PERSON_ROLE.PERSON_ROLE_ID = UOC_STAFF.PERSON_ROLE_ID) PERSON_ROLE_NAME" +
                   " FROM UOC_STAFF WHERE CITIZEN_ID = '" + CITIZEN_ID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            UOC_STAFF uoc_staff = new UOC_STAFF();
                            int i = 0;
                            uoc_staff.UOC_ID = reader.GetInt32(i++);
                            uoc_staff.CITIZEN_ID = reader.GetValue(i++).ToString();
                            uoc_staff.YEAR = reader.GetValue(i++).ToString();
                            uoc_staff.UNIV_ID = reader.GetValue(i++).ToString();
                            uoc_staff.UNIV_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.PREFIX_ID = reader.GetValue(i++).ToString();
                            uoc_staff.PREFIX_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.STF_FNAME = reader.GetValue(i++).ToString();
                            uoc_staff.STF_LNAME = reader.GetValue(i++).ToString();
                            uoc_staff.GENDER_ID = reader.GetValue(i++).ToString();
                            uoc_staff.GENDER_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.BIRTHDAY = reader.GetValue(i++).ToString();
                            uoc_staff.HOMEADD = reader.GetValue(i++).ToString();
                            uoc_staff.MOO = reader.GetValue(i++).ToString();
                            uoc_staff.STREET = reader.GetValue(i++).ToString();
                            uoc_staff.SUB_DISTRICT_ID = reader.GetValue(i++).ToString();
                            uoc_staff.SUB_DISTRICT_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.DISTRICT_ID = reader.GetValue(i++).ToString();
                            uoc_staff.DISTRICT_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.PROVINCE_ID = reader.GetValue(i++).ToString();
                            uoc_staff.PROVINCE_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.TELEPHONE = reader.GetValue(i++).ToString();
                            uoc_staff.ZIPCODE = reader.GetValue(i++).ToString();
                            uoc_staff.NATION_ID = reader.GetValue(i++).ToString();
                            uoc_staff.NATION_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.STAFFTYPE_ID = reader.GetValue(i++).ToString();
                            uoc_staff.STAFFTYPE_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.TIME_CONTACT_ID = reader.GetValue(i++).ToString();
                            uoc_staff.TIME_CONTACT_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.BUDGET_ID = reader.GetValue(i++).ToString();
                            uoc_staff.BUDGET_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.SUBSTAFFTYPE_ID = reader.GetValue(i++).ToString();
                            uoc_staff.SUBSTAFFTYPE_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.ADMIN_POSITION_ID = reader.GetValue(i++).ToString();
                            uoc_staff.ADMIN_POSITION_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.POSITION_ID = reader.GetValue(i++).ToString();
                            uoc_staff.POSITION_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.POSITION_WORK = reader.GetValue(i++).ToString();
                            uoc_staff.DEPARTMENT_ID = reader.GetValue(i++).ToString();
                            uoc_staff.DEPARTMENT_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.DATE_INWORK = reader.GetValue(i++).ToString();
                            uoc_staff.DATE_START_THIS_U = reader.GetValue(i++).ToString();
                            uoc_staff.SPECIAL_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.TEACH_ISCED_ID = reader.GetValue(i++).ToString();
                            uoc_staff.TEACH_ISCED_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.GRAD_LEV_ID = reader.GetValue(i++).ToString();
                            uoc_staff.GRAD_LEV_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.GRAD_CURR = reader.GetValue(i++).ToString();
                            uoc_staff.GRAD_ISCED_ID = reader.GetValue(i++).ToString();
                            uoc_staff.GRAD_ISCED_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.GRAD_PROG = reader.GetValue(i++).ToString();
                            uoc_staff.GRAD_UNIV = reader.GetValue(i++).ToString();
                            uoc_staff.GRAD_COUNTRY_ID = reader.GetValue(i++).ToString();
                            uoc_staff.GRAD_COUNTRY_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.DEFORM_ID = reader.GetValue(i++).ToString();
                            uoc_staff.DEFORM_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.SIT_NO = reader.GetValue(i++).ToString();
                            uoc_staff.SALARY = reader.GetValue(i++).ToString();
                            uoc_staff.POSITION_SALARY = reader.GetValue(i++).ToString();
                            uoc_staff.RELIGION_ID = reader.GetValue(i++).ToString();
                            uoc_staff.RELIGION_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.MOVEMENT_TYPE_ID = reader.GetValue(i++).ToString();
                            uoc_staff.MOVEMENT_TYPE_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.MOVEMENT_DATE = reader.GetValue(i++).ToString();
                            uoc_staff.DECORATION = reader.GetValue(i++).ToString();
                            uoc_staff.RESULT1 = reader.GetValue(i++).ToString();
                            uoc_staff.PERCENT_SALARY1 = reader.GetValue(i++).ToString();
                            uoc_staff.RESULT2 = reader.GetValue(i++).ToString();
                            uoc_staff.PERCENT_SALARY2 = reader.GetValue(i++).ToString();
                            uoc_staff.PASSWORD = reader.GetValue(i++).ToString();
                            uoc_staff.ST_LOGIN_ID = reader.GetInt32(i++);
                            uoc_staff.ST_LOGIN_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.CAMPUS_ID = reader.IsDBNull(i++) ? 0 : reader.GetInt32(i++);
                            uoc_staff.CAMPUS_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.FACULTY_ID = reader.IsDBNull(i++) ? 0 : reader.GetInt32(i++);
                            uoc_staff.FACULTY_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.DIVISION_ID = reader.IsDBNull(i++) ? 0 : reader.GetInt32(i++);
                            uoc_staff.DIVISION_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.WORK_DIVISION_ID = reader.IsDBNull(i++) ? 0 : reader.GetInt32(i++);
                            uoc_staff.WORK_DIVISION_NAME = reader.GetValue(i++).ToString();
                            uoc_staff.PERSON_ROLE_ID = reader.GetInt32(i++);
                            uoc_staff.PERSON_ROLE_NAME = reader.GetValue(i++).ToString();

                            return uoc_staff;
                        }
                    }
                }
            }
            return null;
        }

        public static string GetPersonImageFileName(string citizenID)
        {
            OracleConnection.ClearAllPools();
            string fileName = "";
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT URL FROM PS_PERSON_IMAGE WHERE CITIZEN_ID = '" + citizenID + "' AND PRESENT = 1", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileName = reader.GetValue(0).ToString();
                        }
                    }
                }
            }
            return fileName;
        }
        public static string[] GetPersonImageFileNames(string citizenID)
        {
            OracleConnection.ClearAllPools();
            List<string> fileNameList = new List<string>();
            using (OracleConnection con = new OracleConnection(CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT URL FROM PS_PERSON_IMAGE WHERE CITIZEN_ID = '" + citizenID + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileNameList.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            return fileNameList.ToArray();
        }

    }
}