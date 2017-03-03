using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;

namespace Personnel.Class
{
    public class LeaveData
    {
        public bool HasData = true;
        public UOC_STAFF Person;

        public int LeaveID;
        public int LeaveTypeID;
        public string UOC_ID;
        public DateTime? RequestDate;
        public DateTime? FromDate;
        public DateTime? ToDate;
        public int TotalDay;
        public string Reason;
        public string Contact;
        public string Telephone;
        public DateTime? LastFromDate;
        public DateTime? LastToDate;
        public int LastTotalDay;
        public string DocterCertificationFileName;
        public int CountPast;
        public int CountNow;
        public int CountTotal;
        public int BudgetYear;
        public int RestSave;
        public int RestLeft;
        public int RestTotal;
        public string WifeFirstName;
        public string WifeLastName;
        public DateTime? GiveBirthDate;
        public int Ordained;
        public string TempleName;
        public string TempleLocation;
        public DateTime? OrdainDate;
        public int Hujed;
        public int BossLowID;
        public string BossLowComment;
        public int BossHighID;
        public string BossHighComment;
        public int OfficerID;
        public string OfficerComment;

        public string LeaveTypeName;

        public void Load(int ID)
        {
            HasData = false;
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT TB_LEAVE.*, (SELECT LEAVE_TYPE_NAME FROM TB_LEAVE_TYPE WHERE TB_LEAVE_TYPE.LEAVE_TYPE_ID = TB_LEAVE.LEAVE_TYPE_ID) LEAVE_TYPE_NAME FROM TB_LEAVE WHERE LEAVE_ID = " + ID, con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HasData = true;
                            int i = 1;
                            LeaveID = ID;
                            LeaveTypeID = reader.GetInt32(i++);
                            UOC_ID = reader.GetValue(i).ToString(); ++i;

                            if (reader.IsDBNull(i))
                            {
                                RequestDate = null;
                            }
                            else
                            {
                                RequestDate = reader.GetDateTime(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i))
                            {
                                FromDate = null;
                            }
                            else
                            {
                                FromDate = reader.GetDateTime(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i))
                            {
                                ToDate = null;
                            }
                            else
                            {
                                ToDate = reader.GetDateTime(i);
                            }
                            ++i;

                            TotalDay = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            Reason = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            Contact = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            Telephone = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            if (reader.IsDBNull(i))
                            {
                                LastFromDate = null;
                            }
                            else
                            {
                                LastFromDate = reader.GetDateTime(i);
                            }
                            ++i;

                            if (reader.IsDBNull(i))
                            {
                                LastToDate = null;
                            }
                            else
                            {
                                LastToDate = reader.GetDateTime(i);
                            }
                            ++i;

                            LastTotalDay = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            DocterCertificationFileName = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            CountPast = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            CountNow = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            CountTotal = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            BudgetYear = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            RestSave = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            RestLeft = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            RestTotal = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            WifeFirstName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            WifeLastName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            if (reader.IsDBNull(i))
                            {
                                GiveBirthDate = null;
                            }
                            else
                            {
                                GiveBirthDate = reader.GetDateTime(i);
                            }
                            ++i;

                            Ordained = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            TempleName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            TempleLocation = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;

                            if (reader.IsDBNull(i))
                            {
                                OrdainDate = null;
                            }
                            else
                            {
                                OrdainDate = reader.GetDateTime(i);
                            }
                            ++i;

                            Hujed = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;

                            BossLowID = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            BossLowComment = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            BossHighID = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            BossHighComment = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            OfficerID = reader.IsDBNull(i) ? -1 : reader.GetInt32(i); ++i;
                            OfficerComment = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                            LeaveTypeName = reader.IsDBNull(i) ? null : reader.GetString(i); ++i;
                        }
                    }
                }

                Person = DatabaseManager.GetOUC_STAFF(UOC_ID);
            }
        }  
        public void Update()
        {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE SET LEAVE_TYPE_ID = :LEAVE_TYPE_ID", con))
                {
                    com.Parameters.AddWithValue("", "");
                    com.ExecuteNonQuery();
                }
            }
        }
        public void AddLeaveSick()
        {
            AddLeave3K();
        }
        public void AddLeaveBusiness()
        {
            AddLeave3K();
        }
        public void AddLeaveGiveBirth()
        {
            AddLeave3K();
        }
        public void AddLeave3K()
        {
            OracleConnection.ClearAllPools();
            LeaveID = DatabaseManager.ExecuteSequence("SEQ_LEV_DATA");
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO TB_LEAVE (LEAVE_ID, LEAVE_TYPE_ID, UOC_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, TELEPHONE, LAST_FROM_DATE, LAST_TO_DATE, LAST_TOTAL_DAY, DR_CER_FILE_NAME, COUNT_PAST, COUNT_NOW, COUNT_TOTAL, BUDGET_YEAR, BOSS_LOW_ID, BOSS_LOW_COMMENT, BOSS_HIGH_ID, BOSS_HIGH_COMMENT, OFFICER_ID, OFFICER_COMMENT) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :UOC_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :REASON, :CONTACT, :TELEPHONE, :LAST_FROM_DATE, :LAST_TO_DATE, :LAST_TOTAL_DAY, :DR_CER_FILE_NAME, :COUNT_PAST, :COUNT_NOW, :COUNT_TOTAL, :BUDGET_YEAR, :BOSS_LOW_ID, :BOSS_LOW_COMMENT, :BOSS_HIGH_ID, :BOSS_HIGH_COMMENT, :OFFICER_ID, :OFFICER_COMMENT)", con))
                {
                    com.Parameters.AddWithValue("LEAVE_ID", LeaveID);
                    com.Parameters.AddWithValue("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                    com.Parameters.AddWithValue("REQ_DATE", RequestDate);
                    com.Parameters.AddWithValue("FROM_DATE", FromDate);
                    com.Parameters.AddWithValue("TO_DATE", ToDate);
                    com.Parameters.AddWithValue("TOTAL_DAY", TotalDay);
                    com.Parameters.AddWithValue("REASON", Reason);
                    com.Parameters.AddWithValue("CONTACT", Contact);
                    com.Parameters.AddWithValue("TELEPHONE", Telephone);
                    if (LastFromDate.HasValue)
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", LastFromDate.Value);
                        com.Parameters.AddWithValue("LAST_TO_DATE", LastToDate.Value);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", DBNull.Value);
                        com.Parameters.AddWithValue("LAST_TO_DATE", DBNull.Value);
                    }
                    com.Parameters.AddWithValue("LAST_TOTAL_DAY", LastTotalDay);
                    com.Parameters.AddWithValue("DR_CER_FILE_NAME", DocterCertificationFileName);
                    com.Parameters.AddWithValue("COUNT_PAST", CountPast);
                    com.Parameters.AddWithValue("COUNT_NOW", CountNow);
                    com.Parameters.AddWithValue("COUNT_TOTAL", CountTotal);
                    BudgetYear = Util.BudgetYear();
                    com.Parameters.AddWithValue("BUDGET_YEAR", BudgetYear);
                    com.Parameters.AddWithValue("BOSS_LOW_ID", BossLowID);
                    com.Parameters.AddWithValue("BOSS_LOW_COMMENT", BossLowComment);
                    com.Parameters.AddWithValue("BOSS_HIGH_ID", BossHighID);
                    com.Parameters.AddWithValue("BOSS_HIGH_COMMENT", BossHighComment);
                    com.Parameters.AddWithValue("OFFICER_ID", OfficerID);
                    com.Parameters.AddWithValue("OFFICER_COMMENT", OfficerComment);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void AddLeaveRest()
        {
            OracleConnection.ClearAllPools();
            LeaveID = DatabaseManager.ExecuteSequence("SEQ_LEV_DATA");
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO LEV_DATA (LEAVE_ID, LEAVE_TYPE_ID, UOC_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, TELEPHONE, LAST_FROM_DATE, LAST_TO_DATE, LAST_TOTAL_DAY, COUNT_PAST, COUNT_NOW, COUNT_TOTAL, REST_SAVE, REST_LEFT, REST_TOTAL, BUDGET_YEAR, BOSS_LOW_ID, BOSS_LOW_COMMENT, BOSS_HIGH_ID, BOSS_HIGH_COMMENT, OFFICER_ID, OFFICER_COMMENT) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :UOC_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :REASON, :CONTACT, :TELEPHONE, :LAST_FROM_DATE, :LAST_TO_DATE, :LAST_TOTAL_DAY, :COUNT_PAST, :COUNT_NOW, :COUNT_TOTAL, :REST_SAVE, :REST_LEFT, :REST_TOTAL, :BUDGET_YEAR, :BOSS_LOW_ID, :BOSS_LOW_COMMENT, :BOSS_HIGH_ID, :BOSS_HIGH_COMMENT, :OFFICER_ID, :OFFICER_COMMENT)", con))
                {
                    com.Parameters.AddWithValue("LEAVE_ID", LeaveID);
                    com.Parameters.AddWithValue("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                    com.Parameters.AddWithValue("REQ_DATE", RequestDate);
                    com.Parameters.AddWithValue("FROM_DATE", FromDate);
                    com.Parameters.AddWithValue("TO_DATE", ToDate);
                    com.Parameters.AddWithValue("TOTAL_DAY", TotalDay);
                    com.Parameters.AddWithValue("REASON", Reason);
                    com.Parameters.AddWithValue("CONTACT", Contact);
                    com.Parameters.AddWithValue("TELEPHONE", Telephone);
                    if (LastFromDate.HasValue)
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", LastFromDate.Value);
                        com.Parameters.AddWithValue("LAST_TO_DATE", LastToDate.Value);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", null);
                        com.Parameters.AddWithValue("LAST_TO_DATE", null);
                    }
                    com.Parameters.AddWithValue("LAST_TOTAL_DAY", LastTotalDay);
                    com.Parameters.AddWithValue("COUNT_PAST", CountPast);
                    com.Parameters.AddWithValue("COUNT_NOW", CountNow);
                    com.Parameters.AddWithValue("COUNT_TOTAL", CountTotal);
                    com.Parameters.AddWithValue("REST_SAVE", RestSave);
                    com.Parameters.AddWithValue("REST_LEFT", RestLeft);
                    com.Parameters.AddWithValue("REST_TOTAL", RestTotal);
                    com.Parameters.AddWithValue("BUDGET_YEAR", Util.BudgetYear());
                    com.Parameters.AddWithValue("BOSS_LOW_ID", BossLowID);
                    com.Parameters.AddWithValue("BOSS_LOW_COMMENT", BossLowComment);
                    com.Parameters.AddWithValue("BOSS_HIGH_ID", BossHighID);
                    com.Parameters.AddWithValue("BOSS_HIGH_COMMENT", BossHighComment);
                    com.Parameters.AddWithValue("OFFICER_ID", OfficerID);
                    com.Parameters.AddWithValue("OFFICER_COMMENT", OfficerComment);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void AddLeaveHelpGiveBirth()
        {

            OracleConnection.ClearAllPools();
            LeaveID = DatabaseManager.ExecuteSequence("SEQ_LEV_DATA");
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO TB_LEAVE (LEAVE_ID, LEAVE_TYPE_ID, UOC_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, TELEPHONE, LAST_FROM_DATE, LAST_TO_DATE, LAST_TOTAL_DAY, COUNT_PAST, COUNT_NOW, COUNT_TOTAL, WIFE_FN, WIFE_LN, GB_DATE, BUDGET_YEAR, ) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :UOC_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :REASON, :CONTACT, :TELEPHONE, :LAST_FROM_DATE, :LAST_TO_DATE, :LAST_TOTAL_DAY, :COUNT_PAST, :COUNT_NOW, :COUNT_TOTAL, :WIFE_FN, :WIFE_LN, :GB_DATE, :BUDGET_YEAR, )", con))
                {
                    com.Parameters.AddWithValue("LEAVE_ID", LeaveID);
                    com.Parameters.AddWithValue("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                    com.Parameters.AddWithValue("REQ_DATE", RequestDate);
                    com.Parameters.AddWithValue("FROM_DATE", FromDate);
                    com.Parameters.AddWithValue("TO_DATE", ToDate);
                    com.Parameters.AddWithValue("TOTAL_DAY", TotalDay);
                    com.Parameters.AddWithValue("REASON", Reason);
                    com.Parameters.AddWithValue("CONTACT", Contact);
                    com.Parameters.AddWithValue("TELEPHONE", Telephone);
                    if (LastFromDate.HasValue)
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", LastFromDate.Value);
                        com.Parameters.AddWithValue("LAST_TO_DATE", LastToDate.Value);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", null);
                        com.Parameters.AddWithValue("LAST_TO_DATE", null);
                    }
                    com.Parameters.AddWithValue("LAST_TOTAL_DAY", LastTotalDay);
                    com.Parameters.AddWithValue("COUNT_PAST", CountPast);
                    com.Parameters.AddWithValue("COUNT_NOW", CountNow);
                    com.Parameters.AddWithValue("COUNT_TOTAL", CountTotal);
                    com.Parameters.AddWithValue("WIFE_FN", WifeFirstName);
                    com.Parameters.AddWithValue("WIFE_LN", WifeLastName);
                    com.Parameters.AddWithValue("GB_DATE", GiveBirthDate);
                    com.Parameters.AddWithValue("BUDGET_YEAR", Util.BudgetYear());
                    com.Parameters.AddWithValue("BOSS_LOW_ID", BossLowID);
                    com.Parameters.AddWithValue("BOSS_LOW_COMMENT", BossLowComment);
                    com.Parameters.AddWithValue("BOSS_HIGH_ID", BossHighID);
                    com.Parameters.AddWithValue("BOSS_HIGH_COMMENT", BossHighComment);
                    com.Parameters.AddWithValue("OFFICER_ID", OfficerID);
                    com.Parameters.AddWithValue("OFFICER_COMMENT", OfficerComment);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void AddLeaveOrdain()
        {
            OracleConnection.ClearAllPools();
            LeaveID = DatabaseManager.ExecuteSequence("SEQ_LEV_DATA");
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO LEV_DATA (LEAVE_ID, LEAVE_TYPE_ID, UOC_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, TELEPHONE, LAST_FROM_DATE, LAST_TO_DATE, LAST_TOTAL_DAY, COUNT_PAST, COUNT_NOW, COUNT_TOTAL, OD_ED, TP_NAME, TP_LOC, OD_DATE, BUDGET_YEAR, BOSS_LOW_ID, BOSS_LOW_COMMENT, BOSS_HIGH_ID, BOSS_HIGH_COMMENT, OFFICER_ID, OFFICER_COMMENT) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :UOC_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :REASON, :CONTACT, :TELEPHONE, :LAST_FROM_DATE, :LAST_TO_DATE, :LAST_TOTAL_DAY, :COUNT_PAST, :COUNT_NOW, :COUNT_TOTAL, :OD_ED, :TP_NAME, :TP_LOC, :OD_DATE, :BUDGET_YEAR, :BOSS_LOW_ID, :BOSS_LOW_COMMENT, :BOSS_HIGH_ID, :BOSS_HIGH_COMMENT, :OFFICER_ID, :OFFICER_COMMENT)", con))
                {
                    com.Parameters.AddWithValue("LEAVE_ID", LeaveID);
                    com.Parameters.AddWithValue("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                    com.Parameters.AddWithValue("REQ_DATE", RequestDate);
                    com.Parameters.AddWithValue("FROM_DATE", FromDate);
                    com.Parameters.AddWithValue("TO_DATE", ToDate);
                    com.Parameters.AddWithValue("TOTAL_DAY", TotalDay);
                    com.Parameters.AddWithValue("REASON", Reason);
                    com.Parameters.AddWithValue("CONTACT", Contact);
                    com.Parameters.AddWithValue("TELEPHONE", Telephone);
                    if (LastFromDate.HasValue)
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", LastFromDate.Value);
                        com.Parameters.AddWithValue("LAST_TO_DATE", LastToDate.Value);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", null);
                        com.Parameters.AddWithValue("LAST_TO_DATE", null);
                    }
                    com.Parameters.AddWithValue("LAST_TOTAL_DAY", LastTotalDay);
                    com.Parameters.AddWithValue("COUNT_PAST", CountPast);
                    com.Parameters.AddWithValue("COUNT_NOW", CountNow);
                    com.Parameters.AddWithValue("COUNT_TOTAL", CountTotal);
                    com.Parameters.AddWithValue("OD_ED", Ordained);
                    com.Parameters.AddWithValue("TP_NAME", TempleName);
                    com.Parameters.AddWithValue("TP_LOC", TempleLocation);
                    com.Parameters.AddWithValue("OD_DATE", OrdainDate);
                    com.Parameters.AddWithValue("BUDGET_YEAR", Util.BudgetYear());
                    com.Parameters.AddWithValue("BOSS_LOW_ID", BossLowID);
                    com.Parameters.AddWithValue("BOSS_LOW_COMMENT", BossLowComment);
                    com.Parameters.AddWithValue("BOSS_HIGH_ID", BossHighID);
                    com.Parameters.AddWithValue("BOSS_HIGH_COMMENT", BossHighComment);
                    com.Parameters.AddWithValue("OFFICER_ID", OfficerID);
                    com.Parameters.AddWithValue("OFFICER_COMMENT", OfficerComment);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void AddLeaveHuj()
        {
            OracleConnection.ClearAllPools();
            LeaveID = DatabaseManager.ExecuteSequence("SEQ_LEV_DATA");
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("INSERT INTO LEV_DATA (LEAVE_ID, LEAVE_TYPE_ID, UOC_ID, REQ_DATE, FROM_DATE, TO_DATE, TOTAL_DAY, REASON, CONTACT, TELEPHONE, LAST_FROM_DATE, LAST_TO_DATE, LAST_TOTAL_DAY, COUNT_PAST, COUNT_NOW, COUNT_TOTAL, HUJ_ED, BUDGET_YEAR, BOSS_LOW_ID, BOSS_LOW_COMMENT, BOSS_HIGH_ID, BOSS_HIGH_COMMENT, OFFICER_ID, OFFICER_COMMENT) VALUES (:LEAVE_ID, :LEAVE_TYPE_ID, :UOC_ID, :REQ_DATE, :FROM_DATE, :TO_DATE, :TOTAL_DAY, :REASON, :CONTACT, :TELEPHONE, :LAST_FROM_DATE, :LAST_TO_DATE, :LAST_TOTAL_DAY, :COUNT_PAST, :COUNT_NOW, :COUNT_TOTAL, :HUJ_ED, :BUDGET_YEAR, :BOSS_LOW_ID, :BOSS_LOW_COMMENT, :BOSS_HIGH_ID, :BOSS_HIGH_COMMENT, :OFFICER_ID, :OFFICER_COMMENT)", con))
                {
                    com.Parameters.AddWithValue("LEAVE_ID", LeaveID);
                    com.Parameters.AddWithValue("LEAVE_TYPE_ID", LeaveTypeID);
                    com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                    com.Parameters.AddWithValue("REQ_DATE", RequestDate);
                    com.Parameters.AddWithValue("FROM_DATE", FromDate);
                    com.Parameters.AddWithValue("TO_DATE", ToDate);
                    com.Parameters.AddWithValue("TOTAL_DAY", TotalDay);
                    com.Parameters.AddWithValue("REASON", Reason);
                    com.Parameters.AddWithValue("CONTACT", Contact);
                    com.Parameters.AddWithValue("TELEPHONE", Telephone);
                    if (LastFromDate.HasValue)
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", LastFromDate.Value);
                        com.Parameters.AddWithValue("LAST_TO_DATE", LastToDate.Value);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("LAST_FROM_DATE", null);
                        com.Parameters.AddWithValue("LAST_TO_DATE", null);
                    }
                    com.Parameters.AddWithValue("LAST_TOTAL_DAY", LastTotalDay);
                    com.Parameters.AddWithValue("COUNT_PAST", CountPast);
                    com.Parameters.AddWithValue("COUNT_NOW", CountNow);
                    com.Parameters.AddWithValue("COUNT_TOTAL", CountTotal);
                    com.Parameters.AddWithValue("HUJ_ED", Hujed);
                    com.Parameters.AddWithValue("BUDGET_YEAR", Util.BudgetYear());
                    com.Parameters.AddWithValue("BOSS_LOW_ID", BossLowID);
                    com.Parameters.AddWithValue("BOSS_LOW_COMMENT", BossLowComment);
                    com.Parameters.AddWithValue("BOSS_HIGH_ID", BossHighID);
                    com.Parameters.AddWithValue("BOSS_HIGH_COMMENT", BossHighComment);
                    com.Parameters.AddWithValue("OFFICER_ID", OfficerID);
                    com.Parameters.AddWithValue("OFFICER_COMMENT", OfficerComment);
                    com.ExecuteNonQuery();
                }
            }
        }

        public void ExecuteAllow()
        {
            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                if (LeaveTypeID == 1)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET SICK_NOW = SICK_NOW + " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 2)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET BUSINESS_NOW = BUSINESS_NOW + " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 3)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET GB_NOW = GB_NOW + " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 4)
                {
                    int _restSave = DatabaseManager.ExecuteInt("SELECT REST_SAVE FROM TB_LEAVE_CLAIM WHERE UOC_ID = '" + UOC_ID + "' AND YEAR = " + BudgetYear);
                    int _restThis = DatabaseManager.ExecuteInt("SELECT REST_THIS FROM TB_LEAVE_CLAIM WHERE UOC_ID = '" + UOC_ID + "' AND YEAR = " + BudgetYear);
                    _restSave -= TotalDay;
                    if (_restSave < 0)
                    {
                        _restThis += _restSave;
                        _restSave = 0;
                    }
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET REST_NOW = REST_NOW + " + TotalDay + ", REST_SAVE = " + _restSave + ", REST_THIS = " + _restThis + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 5)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET HGB_NOW = HGB_NOW + " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 6)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET ORDAIN_NOW = ORDAIN_NOW + " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 7)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET HUJ_NOW = HUJ_NOW + " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}