using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Drawing;
using System.Web.UI.HtmlControls;
using Personnel.Class;
using System.IO;
using System.Data.OracleClient;
using System.Data;

namespace Personnel
{
    public partial class ManageLeave : System.Web.UI.Page
    {
        int id = 0;
        private int businessBeforeDay = 3;
        private int restBeforeDay = 3;
        private int giveBirthAfterDay = 30;
        private int helpGiveBirthAfterDay = 30;
        private int ordainBeforeDay = 60;
        private int hujBeforeDay = 60;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
            }
            else { Response.Redirect("listLeave-admin.aspx"); }

            if (!IsPostBack)
            {
                string IdRecieve = MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString());
                string genderID = DatabaseManager.ExecuteString("SELECT GENDER_ID FROM UOC_STAFF WHERE UOC_ID = '" + IdRecieve + "'");
                if (genderID == "1")
                {
                    lbuSelectGiveBirth.Visible = false;
                    lbuSelectHelpGiveBirth.Visible = true;
                    lbuSelectOrdain.Visible = true;
                    lbuSelectHuj.Visible = true;
                }
                else if (genderID == "2")
                {
                    lbuSelectGiveBirth.Visible = true;
                    lbuSelectHelpGiveBirth.Visible = false;
                    lbuSelectOrdain.Visible = false;
                    lbuSelectHuj.Visible = false;
                }
                BindDDL();
                CreateLeaveAuto();
                BindManage();
            }
        }

        protected void BindDDL()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT UOC_ID,(SELECT FULLNAME || ' ' || STF_FNAME || ' ' || STF_LNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) NAME, (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME FROM UOC_STAFF", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        ddlS1BossLowID.Items.Clear();
                        ddlS1BossHighID.Items.Clear();
                        while (reader.Read())
                        {
                            ddlS1BossLowID.Items.Add(new ListItem(reader.GetValue(1).ToString() + " | " + reader.GetValue(2).ToString(), reader.GetValue(0).ToString() + ""));
                            ddlS1BossHighID.Items.Add(new ListItem(reader.GetValue(1).ToString() + " | " + reader.GetValue(2).ToString(), reader.GetValue(0).ToString() + ""));
                        }
                        ddlS1BossLowID.Items.Insert(0, new ListItem("--กรุณาเลือก--", ""));
                        ddlS1BossHighID.Items.Insert(0, new ListItem("--กรุณาเลือก--", ""));
                    }
                }
            }
        }

        protected void CreateLeaveAuto()
        {
            if (DatabaseManager.ExecuteInt("SELECT COUNT(*) FROM TB_LEAVE_CLAIM WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND YEAR = " + Util.BudgetYear()) == 0)
            {
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("INSERT INTO TB_LEAVE_CLAIM (LEAVE_CLAIM_ID, UOC_ID, YEAR, SICK_NOW, SICK_MAX, BUSINESS_NOW, BUSINESS_MAX, REST_NOW, REST_MAX, REST_SAVE, REST_SAVE_FIX, REST_THIS, REST_THIS_FIX, GB_NOW, GB_MAX, HGB_NOW, HGB_MAX, ORDAIN_NOW, ORDAIN_MAX, HUJ_NOW, HUJ_MAX) VALUES (SEQ_LEV_CLAIM_ID.NEXTVAL, :UOC_ID, :YEAR, :SICK_NOW, :SICK_MAX, :BUSINESS_NOW, :BUSINESS_MAX, :REST_NOW, :REST_MAX, :REST_SAVE, :REST_SAVE_FIX, :REST_THIS, :REST_THIS_FIX, :GB_NOW, :GB_MAX, :HGB_NOW, :HGB_MAX, :ORDAIN_NOW, :ORDAIN_MAX, :HUJ_NOW, :HUJ_MAX)", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
                        com.Parameters.AddWithValue("YEAR", Util.BudgetYear());
                        int v1 = 0;
                        int v2 = 10;
                        int v30 = 30;
                        int v60 = 60;
                        int v45 = 45;
                        int v120 = 120;
                        com.Parameters.AddWithValue("SICK_NOW", v1);
                        com.Parameters.AddWithValue("SICK_MAX", v60);
                        com.Parameters.AddWithValue("BUSINESS_NOW", v1);
                        com.Parameters.AddWithValue("BUSINESS_MAX", v45);
                        com.Parameters.AddWithValue("REST_NOW", v1);
                        com.Parameters.AddWithValue("REST_MAX", v2);
                        com.Parameters.AddWithValue("REST_SAVE", v1);
                        com.Parameters.AddWithValue("REST_SAVE_FIX", v1);
                        com.Parameters.AddWithValue("REST_THIS", v2);
                        com.Parameters.AddWithValue("REST_THIS_FIX", v2);
                        com.Parameters.AddWithValue("GB_NOW", v1);
                        com.Parameters.AddWithValue("GB_MAX", v30);
                        com.Parameters.AddWithValue("HGB_NOW", v1);
                        com.Parameters.AddWithValue("HGB_MAX", v30);
                        com.Parameters.AddWithValue("ORDAIN_NOW", v1);
                        com.Parameters.AddWithValue("ORDAIN_MAX", v120);
                        com.Parameters.AddWithValue("HUJ_NOW", v1);
                        com.Parameters.AddWithValue("HUJ_MAX", v120);                        
                        com.ExecuteNonQuery();
                    }
                }
            }
        }

        protected void lbuSelectSick_Click(object sender, EventArgs e)
        {
            ClearNotification();
            hfLeaveTypeID.Value = "1";
            hfLeaveTypeName.Value = "ลาป่วย";
            MV1.ActiveViewIndex = 1;
            HideAllFromFill();

            HeaderName.Visible = true;
            lbHeaderName.Text = "ลาป่วย";

            trS1Reason.Visible = true;
            trS1Contact.Visible = true;
            trS1Phone.Visible = true;
            trS1DrCer.Visible = true;
        }
        protected void lbuSelectBusiness_Click(object sender, EventArgs e)
        {
            ClearNotification();
            hfLeaveTypeID.Value = "2";
            hfLeaveTypeName.Value = "ลากิจ";
            MV1.ActiveViewIndex = 1;
            HideAllFromFill();

            HeaderName.Visible = true;
            lbHeaderName.Text = "ลากิจ";

            trS1Reason.Visible = true;
            trS1Contact.Visible = true;
            trS1Phone.Visible = true;
        }
        protected void lbuSelectRest_Click(object sender, EventArgs e)
        {
            ClearNotification();
            hfLeaveTypeID.Value = "4";
            hfLeaveTypeName.Value = "ลาพักผ่อน";
            MV1.ActiveViewIndex = 1;
            HideAllFromFill();

            HeaderName.Visible = true;
            lbHeaderName.Text = "ลาพักผ่อน";

            trS1Contact.Visible = true;
            trS1Phone.Visible = true;
        }
        protected void lbuSelectGiveBirth_Click(object sender, EventArgs e)
        {
            ClearNotification();
            hfLeaveTypeID.Value = "3";
            hfLeaveTypeName.Value = "ลาคลอดบุตร";
            MV1.ActiveViewIndex = 1;
            HideAllFromFill();

            HeaderName.Visible = true;
            lbHeaderName.Text = "ลาคลอดบุตร";

            trS1Reason.Visible = true;
            trS1Contact.Visible = true;
            trS1Phone.Visible = true;
        }
        protected void lbuSelectHelpGiveBirth_Click(object sender, EventArgs e)
        {
            ClearNotification();
            hfLeaveTypeID.Value = "5";
            hfLeaveTypeName.Value = "ลาไปช่วยเหลือภริยาที่คลอดบุตร";

            HeaderName.Visible = true;
            lbHeaderName.Text = "ลาไปช่วยเหลือภริยาที่คลอดบุตร";

            MV1.ActiveViewIndex = 1;
            HideAllFromFill();
            trS1WifeName.Visible = true;
            trS1GBDate.Visible = true;
            trS1Contact.Visible = true;
            trS1Phone.Visible = true;

        }
        protected void lbuSelectOrdain_Click(object sender, EventArgs e)
        {
            ClearNotification();
            hfLeaveTypeID.Value = "6";
            hfLeaveTypeName.Value = "ลาไปอุปสมบท";

            HeaderName.Visible = true;
            lbHeaderName.Text = "ลาไปอุปสมบท";

            MV1.ActiveViewIndex = 1;
            HideAllFromFill();
            trS1Ordained.Visible = true;
            trS1TempleName.Visible = true;
            trS1TempleLocation.Visible = true;
            trS1OrdainDate.Visible = true;
            trS1Phone.Visible = true;
        }
        protected void lbuSelectHuj_Click(object sender, EventArgs e)
        {
            ClearNotification();
            hfLeaveTypeID.Value = "7";
            hfLeaveTypeName.Value = "ลาไปประกอบพิธีฮัจญ์";

            HeaderName.Visible = true;
            lbHeaderName.Text = "ลาไปประกอบพิธีฮัจญ์";

            MV1.ActiveViewIndex = 1;
            HideAllFromFill();
            trS1Hujed.Visible = true;
        }

        private void HideAllFromFill()
        {
            trS1WifeName.Visible = false;
            trS1GBDate.Visible = false;
            trS1Ordained.Visible = false;
            trS1TempleName.Visible = false;
            trS1TempleLocation.Visible = false;
            trS1OrdainDate.Visible = false;
            trS1Hujed.Visible = false;
            trS1Reason.Visible = false;
            trS1Contact.Visible = false;
            trS1Phone.Visible = false;
            trS1DrCer.Visible = false;
        }

        protected void lbuS1Check_Click(object sender, EventArgs e)
        {
            ClearNotification();

            trS2BirthDate.Visible = false;
            trS2WorkInDate.Visible = false;
            trS2WifeName.Visible = false;
            trS2GBDate.Visible = false;
            trS2Ordained.Visible = false;
            trS2TempleName.Visible = false;
            trS2TempleLocation.Visible = false;
            trS2OrdainDate.Visible = false;
            trS2Hujed.Visible = false;
            trS2Reason.Visible = false;
            trS2Contact.Visible = false;
            trS2Phone.Visible = false;
            trS2DrCer.Visible = false;
            trS2RestSave.Visible = false;
            trS2RestLeft.Visible = false;
            trS2RestTotal.Visible = false;

            if (hfLeaveTypeID.Value == "1")
            {
                trS2Reason.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
                trS2DrCer.Visible = true;
            }
            else if (hfLeaveTypeID.Value == "2")
            {
                trS2Reason.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            }
            else if (hfLeaveTypeID.Value == "3")
            {
                trS2Reason.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            }
            else if (hfLeaveTypeID.Value == "4")
            {
                trS2RestSave.Visible = true;
                trS2RestLeft.Visible = true;
                trS2RestTotal.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            }
            else if (hfLeaveTypeID.Value == "5")
            {
                trS2WifeName.Visible = true;
                trS2GBDate.Visible = true;
                trS2Contact.Visible = true;
                trS2Phone.Visible = true;
            }
            else if (hfLeaveTypeID.Value == "6")
            {
                trS2BirthDate.Visible = true;
                trS2WorkInDate.Visible = true;
                trS2Ordained.Visible = true;
                trS2TempleName.Visible = true;
                trS2TempleLocation.Visible = true;
                trS2OrdainDate.Visible = true;
                trS2Phone.Visible = true;
            }
            else if (hfLeaveTypeID.Value == "7")
            {
                trS2BirthDate.Visible = true;
                trS2WorkInDate.Visible = true;
                trS2Hujed.Visible = true;
            }

            if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "")
            {
                ChangeNotification("danger", "กรุณากรอกวันที่ให้ถูกต้อง");
                return;
            }
            else
            {
                DateTime dtFromDate = DateTime.Parse(tbS1FromDate.Text);
                DateTime dtToDate = DateTime.Parse(tbS1ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                int fromToNowtotalDay = (int)(dtFromDate - DateTime.Today).TotalDays;
                if (totalDay <= 0)
                {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                if ((DateTime.Today - dtFromDate).TotalDays >= 90)
                {
                    ChangeNotification("danger", "ไม่สามารถลาย้อนหลังมากกว่า 3 เดือน");
                    return;
                }
                if ((dtFromDate - DateTime.Today).TotalDays >= 90)
                {
                    ChangeNotification("danger", "ไม่สามารถลาล่วงหน้ามากกว่า 3 เดือน");
                    return;
                }
                if (dtFromDate.DayOfWeek == DayOfWeek.Saturday || dtFromDate.DayOfWeek == DayOfWeek.Sunday || dtToDate.DayOfWeek == DayOfWeek.Saturday || dtToDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    ChangeNotification("danger", "ไม่สามารถเรื่มหรือจบการลาในวันเสาร์หรือาทิตย์ได้");
                    return;
                }
                int sick_now = -1;
                int sick_max = -1;
                int business_now = -1;
                int business_max = -1;
                int huj_now = -1;
                int huj_max = -1;
                int ordain_now = -1;
                int ordain_max = -1;
                {
                    OracleConnection.ClearAllPools();
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        con.Open();
                        using (OracleCommand com = new OracleCommand("SELECT SICK_NOW, SICK_MAX, BUSINESS_NOW, BUSINESS_MAX, HUJ_NOW, HUJ_MAX, ORDAIN_NOW, ORDAIN_MAX FROM TB_LEAVE_CLAIM WHERE YEAR = " + Util.BudgetYear() + " AND UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "'", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    sick_now = reader.GetInt32(0);
                                    sick_max = reader.GetInt32(1);
                                    business_now = reader.GetInt32(2);
                                    business_max = reader.GetInt32(3);
                                    huj_now = reader.GetInt32(4);
                                    huj_max = reader.GetInt32(5);
                                    ordain_now = reader.GetInt32(6);
                                    ordain_max = reader.GetInt32(7);
                                }
                            }
                        }

                    }
                }
                if (hfLeaveTypeID.Value == "1")
                {
                    if (sick_now + totalDay > sick_max)
                    {
                        ChangeNotification("danger", "ไม่สามารถลาป่วยได้มากกว่า " + sick_max + " วัน คุณลาไปแล้ว " + sick_now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (sick_now + totalDay) + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "2")
                {
                    if (fromToNowtotalDay < businessBeforeDay)
                    {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + businessBeforeDay + " วัน");
                        return;
                    }
                    else if (business_now + totalDay > business_max)
                    {
                        ChangeNotification("danger", "ไม่สามารถลากิจได้มากกว่า " + business_max + " วัน คุณลาไปแล้ว " + business_now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (business_now + totalDay) + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "3")
                {
                    DateTime dt1 = DateTime.Today.AddDays(-giveBirthAfterDay);
                    if ((dtFromDate - dt1).TotalDays < 0)
                    {
                        ChangeNotification("danger", "ไม่สามารถลาย้อนหลังได้มากกว่า " + giveBirthAfterDay + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "4")
                {
                    if (fromToNowtotalDay < restBeforeDay)
                    {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + restBeforeDay + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "5")
                {
                    DateTime dt1 = DateTime.Today.AddDays(-helpGiveBirthAfterDay);
                    if ((dtFromDate - dt1).TotalDays < 0)
                    {
                        ChangeNotification("danger", "ไม่สามารถลาย้อนหลังได้มากกว่า " + helpGiveBirthAfterDay + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "6")
                {
                    if (fromToNowtotalDay < ordainBeforeDay)
                    {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + ordainBeforeDay + " วัน");
                        return;
                    }
                    else if (huj_now + totalDay > huj_max)
                    {
                        ChangeNotification("danger", "ไม่สามารถลาไปอุปสมบทได้มากกว่า " + ordain_max + " วัน คุณลาไปแล้ว " + ordain_now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (ordain_now + totalDay) + " วัน");
                        return;
                    }
                }
                if (hfLeaveTypeID.Value == "7")
                {
                    if (fromToNowtotalDay < hujBeforeDay)
                    {
                        ChangeNotification("danger", "ต้องลาล่วงหน้ามากกว่า " + hujBeforeDay + " วัน");
                        return;
                    }
                    else if (huj_now + totalDay > huj_max)
                    {
                        ChangeNotification("danger", "ไม่สามารถลาไปประกอบพิธีฮัจญ์ได้มากกว่า " + huj_max + " วัน คุณลาไปแล้ว " + huj_now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (huj_now + totalDay) + " วัน");
                        return;
                    }
                }

                {

                    OracleConnection.ClearAllPools();
                    using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                    {
                        con.Open();
                        using (OracleCommand com = new OracleCommand("SELECT LEAVE_ID FROM TB_LEAVE WHERE " + Util.DatabaseToDateSearch(tbS1FromDate.Text) + " <= TO_DATE AND " + Util.DatabaseToDateSearch(tbS1ToDate.Text) + " >= FROM_DATE AND UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND BUDGET_YEAR = " + Util.BudgetYear() + "", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    LeaveData leaveData = new LeaveData();
                                    leaveData.Load(reader.GetInt32(0));
                                    ChangeNotification("danger", "ไม่สามารถลาได้ พบวันลาซ้อนทับกัน (รหัสการลา " + leaveData.LeaveID + ", " + leaveData.FromDate.Value.ToLongDateString() + " ถึง " + leaveData.ToDate.Value.ToLongDateString() + ")");
                                    return;
                                }
                            }
                        }
                        using (OracleCommand com = new OracleCommand("SELECT TO_DATE FROM TB_LEAVE WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND LEAVE_TYPE_ID = " + hfLeaveTypeID.Value + " AND EXTRACT(YEAR FROM FROM_DATE) = " + Util.BudgetYear() + "", con))
                        {
                            using (OracleDataReader reader = com.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    DateTime dtLastToDate = reader.GetDateTime(0);
                                    if ((dtFromDate - dtLastToDate).TotalDays <= 0)
                                    {
                                        ChangeNotification("danger", "ไม่สามารถลาก่อนวันที่ลาล่าสุดได้ (" + dtLastToDate.ToLongDateString() + ")");
                                        return;
                                    }
                                }
                            }
                        }

                    }
                }

            }

            if (hfLeaveTypeID.Value == "1" || hfLeaveTypeID.Value == "2" || hfLeaveTypeID.Value == "3")
            {
                if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "")
                {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                if (tbS1Reason.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกเหตุผล");
                    return;
                }
                if (tbS1Contact.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกติดต่อได้ที่");
                    return;
                }
                if (tbS1Phone.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกเบอร์โทรศัพท์");
                    return;
                }
                if (hfLeaveTypeID.Value == "1")
                {
                    DateTime dtFromDate = DateTime.Parse(tbS1FromDate.Text);
                    DateTime dtToDate = DateTime.Parse(tbS1ToDate.Text);
                    int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                    if (totalDay >= 30 && !FileUpload1.HasFile)
                    {
                        ChangeNotification("danger", "คุณต้องมีใบรับรองแพทย์เมื่อทำการลาเกิน 30 วัน ลาครั้งนี้ " + totalDay + " วัน");
                        return;
                    }
                }
            }
            if (hfLeaveTypeID.Value == "4")
            {
                if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "")
                {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                if (tbS1Contact.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกติดต่อได้ที่");
                    return;
                }
                if (tbS1Phone.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกเบอร์โทรศัพท์");
                    return;
                }
                DateTime dtFromDate = DateTime.Parse(tbS1FromDate.Text);
                DateTime dtToDate = DateTime.Parse(tbS1ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                int max = DatabaseManager.ExecuteInt("SELECT REST_MAX FROM TB_LEAVE_CLAIM WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND YEAR = " + Util.BudgetYear());
                int now = DatabaseManager.ExecuteInt("SELECT REST_NOW FROM TB_LEAVE_CLAIM WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND YEAR = " + Util.BudgetYear());
                if (now + totalDay > max)
                {
                    ChangeNotification("danger", "ปีนี้คุณไม่สามารถลาพักผ่อนเกิน " + max + " วันได้ ลาไปแล้ว " + now + " วัน ครั้งนี้ " + totalDay + " วัน รวม " + (totalDay + now) + " วัน");
                    return;
                }
            }
            if (hfLeaveTypeID.Value == "5")
            {
                if (tbS1WifeFirstName.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกชื่อจริงภริยา");
                    return;
                }
                if (tbS1WifeLastName.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกนามสกุลภริยา");
                    return;
                }
                if (tbS1GBDate.Text == "")
                {
                    ChangeNotification("danger", "วันที่คลอดบุตรไม่ถูกต้อง");
                    return;
                }
                if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "")
                {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                if (tbS1Contact.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกติดต่อได้ที่");
                    return;
                }
                if (tbS1Phone.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกเบอร์โทรศัพท์");
                    return;
                }
            }
            if (hfLeaveTypeID.Value == "6")
            {
                if (!rbS1OrdainedT.Checked && !rbS1OrdainedF.Checked)
                {
                    ChangeNotification("danger", "กรุณาเลือกการอุปสมบท");
                    return;
                }
                if (tbS1TempleName.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกชื่อวัด");
                    return;
                }
                if (tbS1TempleLocation.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกสถานที่");
                    return;
                }
                if (tbS1OrdainDate.Text == "")
                {
                    ChangeNotification("danger", "วันที่อุปสมบทไม่ถูกต้อง");
                    return;
                }
                if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "")
                {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
                if (tbS1Phone.Text == "")
                {
                    ChangeNotification("danger", "กรุณากรอกเบอร์โทรศัพท์");
                    return;
                }
            }
            if (hfLeaveTypeID.Value == "7")
            {
                if (!rbS1HujedT.Checked && !rbS1HujedF.Checked)
                {
                    ChangeNotification("danger", "กรุณาเลือกการไปประกอบพิธีฮัจย์");
                    return;
                }
                if (tbS1FromDate.Text == "" || tbS1ToDate.Text == "")
                {
                    ChangeNotification("danger", "วันที่ไม่ถูกต้อง");
                    return;
                }
            }

            {

                MV1.ActiveViewIndex = 2;
                Session["LeaveSickFileUpload"] = FileUpload1;

                string leavedDate = "ไม่เคยลา";
                DateTime? lastFromDate = null;
                DateTime? lastToDate = null;
                int lastTotalDay = 0;

                int pastTotalDay = DatabaseManager.ExecuteInt("SELECT NVL(SUM(TOTAL_DAY),0) FROM TB_LEAVE WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND LEAVE_TYPE_ID = " + hfLeaveTypeID.Value + " AND EXTRACT(YEAR FROM FROM_DATE) = " + Util.BudgetYear() + "");

                OracleConnection.ClearAllPools();
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT FROM_DATE, TO_DATE, TOTAL_DAY FROM TB_LEAVE WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND LEAVE_TYPE_ID = " + hfLeaveTypeID.Value + " AND EXTRACT(YEAR FROM FROM_DATE) = " + Util.BudgetYear() + " ORDER BY LEAVE_ID DESC", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lastFromDate = reader.GetDateTime(0);
                                lastToDate = reader.GetDateTime(1);
                                lastTotalDay = (int)(lastToDate.Value - lastFromDate.Value).TotalDays + 1;
                                leavedDate = lastFromDate.Value.ToLongDateString() + " ถึง " + lastToDate.Value.ToLongDateString() + " รวม " + lastTotalDay + " วัน ";
                            }
                            else
                            {
                                lastTotalDay = 0;
                            }
                        }
                    }
                }

                int restSave = -1;
                int restLeft = -1;
                int restTotal = -1;
                OracleConnection.ClearAllPools();
                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT REST_SAVE, REST_THIS FROM TB_LEAVE_CLAIM WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "' AND YEAR = " + Util.BudgetYear(), con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                restSave = reader.GetInt32(0);
                                restLeft = reader.GetInt32(1);
                                restTotal = restSave + restLeft;
                            }
                        }
                    }
                }

                using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
                {
                    con.Open();
                    using (OracleCommand com = new OracleCommand("SELECT STF_FNAME || ' ' || STF_LNAME NAME, POSITION_WORK, (SELECT ADMIN_NAME FROM REF_ADMIN WHERE REF_ADMIN.ADMIN_ID = UOC_STAFF.ADMIN_POSITION_ID) ADMIN_POSITION_NAME, (SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME, BIRTHDAY, DATE_INWORK FROM UOC_STAFF WHERE UOC_ID = '" + MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()) + "'", con))
                    {
                        using (OracleDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;

                                lbS2PSName.Text = reader.GetValue(i).ToString(); ++i;
                                lbS2PSPos.Text = reader.GetValue(i).ToString(); ++i;
                                lbS2PSAPos.Text = reader.GetValue(i).ToString(); ++i;
                                lbS2PSDept.Text = reader.GetValue(i).ToString(); ++i;
                                lbS2PSBirthDate.Text = reader.GetValue(i).ToString(); ++i;
                                lbS2PSWorkInDate.Text = reader.GetValue(i).ToString(); ++i;
                            }
                        }
                    }
                }
                lbS2RestSave.Text = restSave + " วัน";
                lbS2RestLeft.Text = restLeft + " วัน";
                lbS2RestTotal.Text = restTotal + " วัน";
                lbS2WifeName.Text = tbS1WifeFirstName.Text + " " + tbS1WifeLastName.Text;
                lbS2GBDate.Text = tbS1GBDate.Text;
                lbS2Ordained.Text = rbS1OrdainedT.Checked ? "เคย" : "ไม่เคย";
                lbS2TempleName.Text = tbS1TempleName.Text;
                lbS2TempleLocation.Text = tbS1TempleLocation.Text;
                lbS2OrdainDate.Text = tbS1OrdainDate.Text;
                lbS2Hujed.Text = rbS1HujedT.Checked ? "เคย" : "ไม่เคย";
                lbS2LastFTTDate.Text = leavedDate;
                lbS2LeaveTypeName.Text = hfLeaveTypeName.Value;
                DateTime dtFromDate = DateTime.Parse(tbS1FromDate.Text);
                DateTime dtToDate = DateTime.Parse(tbS1ToDate.Text);
                int totalDay = (int)(dtToDate - dtFromDate).TotalDays + 1;
                lbS2FTTDate.Text = dtFromDate.ToLongDateString() + " ถึง " + dtToDate.ToLongDateString() + " รวม " + totalDay + " วัน";
                lbS2Statistic.Text = "ลามาแล้ว " + pastTotalDay + " วัน / ลาครั้งนี้ " + totalDay + " วัน / รวม " + (pastTotalDay + totalDay) + " วัน";
                lbS2Reason.Text = tbS1Reason.Text;
                lbS2Contact.Text = tbS1Contact.Text;
                lbS2Phone.Text = tbS1Phone.Text;
                lbS2BossLowID.Text = ddlS1BossLowID.SelectedItem.ToString();
                lbS2BossLowComment.Text = tbS1BossLowComment.Text;
                lbS2BossHighID.Text = ddlS1BossHighID.SelectedItem.ToString();
                lbS2BossHighComment.Text = tbS1BossHighComment.Text;
                lbS2OfficerComment.Text = tbS1OfficerComment.Text;
 
                string drCer;
                if (FileUpload1.HasFile)
                {
                    lbS2DrCer.Text = "มี";
                    FileInfo fi = new FileInfo(FileUpload1.FileName);
                    drCer = Util.RandomFileName() + fi.Extension;
                }
                else
                {
                    lbS2DrCer.Text = "ไม่มี";
                    drCer = "";
                }
                PersonnelSystem ps = PersonnelSystem.GetPersonnelSystem(this);
                UOC_STAFF loginPerson = ps.LoginPerson;

                LeaveData leaveData = new LeaveData();
                leaveData.LeaveTypeID = int.Parse(hfLeaveTypeID.Value);
                leaveData.UOC_ID = MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString());
                leaveData.RequestDate = DateTime.Now;
                leaveData.FromDate = dtFromDate;
                leaveData.ToDate = dtToDate;
                leaveData.TotalDay = totalDay;
                leaveData.Reason = tbS1Reason.Text;
                leaveData.Contact = tbS1Contact.Text;
                leaveData.Telephone = tbS1Phone.Text;
                if (lastFromDate.HasValue)
                {
                    leaveData.LastFromDate = lastFromDate;
                    leaveData.LastToDate = lastToDate;
                }
                leaveData.LastTotalDay = lastTotalDay;

                leaveData.DocterCertificationFileName = drCer;
                leaveData.CountPast = pastTotalDay;
                leaveData.CountNow = totalDay;
                leaveData.CountTotal = pastTotalDay + totalDay;
                leaveData.RestLeft = restLeft;
                leaveData.RestSave = restSave;
                leaveData.RestTotal = restTotal;
                leaveData.WifeFirstName = tbS1WifeFirstName.Text;
                leaveData.WifeLastName = tbS1WifeLastName.Text;
                if (hfLeaveTypeID.Value == "5")
                    leaveData.GiveBirthDate = DateTime.Parse(tbS1GBDate.Text);
                leaveData.Ordained = rbS1OrdainedT.Checked ? 1 : 0;
                leaveData.TempleName = tbS1TempleName.Text;
                leaveData.TempleLocation = tbS1TempleLocation.Text;
                if (hfLeaveTypeID.Value == "6")
                    leaveData.OrdainDate = DateTime.Parse(tbS1OrdainDate.Text);
                leaveData.Hujed = rbS1HujedT.Checked ? 1 : 0;

                leaveData.BossLowID = Convert.ToInt32(ddlS1BossLowID.SelectedValue);
                leaveData.BossLowComment = tbS1BossLowComment.Text;
                leaveData.BossHighID = Convert.ToInt32(ddlS1BossHighID.SelectedValue);
                leaveData.BossHighComment = tbS1BossHighComment.Text;
                leaveData.OfficerID = loginPerson.UOC_ID;
                leaveData.OfficerComment = tbS1OfficerComment.Text;
                //leaveData.UOC_Department = lbS2PSDept.Text;

                Session["LeaveData"] = leaveData;

                hfFileUploadName.Value = drCer;
            }
        }

        protected void lbuS1Back_Click(object sender, EventArgs e)
        {
            MV1.ActiveViewIndex = 0;
            ClearNotification();

            string IdRecieve = MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString());
            string genderID = DatabaseManager.ExecuteString("SELECT GENDER_ID FROM UOC_STAFF WHERE UOC_ID = '" + IdRecieve + "'");
            if (genderID == "1")
            {
                lbuSelectGiveBirth.Visible = false;
                lbuSelectHelpGiveBirth.Visible = true;
                lbuSelectOrdain.Visible = true;
                lbuSelectHuj.Visible = true;
            }
            else if (genderID == "2")
            {
                lbuSelectGiveBirth.Visible = true;
                lbuSelectHelpGiveBirth.Visible = false;
                lbuSelectOrdain.Visible = false;
                lbuSelectHuj.Visible = false;
            }
        }

        protected void lbuS2Back_Click(object sender, EventArgs e)
        {
            MV1.ActiveViewIndex = 1;
            ClearNotification();
        }

        protected void lbuS2Finish_Click(object sender, EventArgs e)
        {
            LeaveData leaveData = (LeaveData)(Session["LeaveData"]);

            if (hfLeaveTypeID.Value == "1")
            {
                leaveData.AddLeaveSick();
                FileUpload fu = (FileUpload)Session["LeaveSickFileUpload"];
                if (fu.HasFile)
                {
                    fu.SaveAs(Server.MapPath("Upload/DrCer/" + hfFileUploadName.Value));
                }
                leaveData.ExecuteAllow();
            }
            else if (hfLeaveTypeID.Value == "2")
            {
                leaveData.AddLeaveBusiness();
            }
            else if (hfLeaveTypeID.Value == "3")
            {
                leaveData.AddLeaveGiveBirth();
            }
            else if (hfLeaveTypeID.Value == "4")
            {
                leaveData.AddLeaveRest();
            }
            else if (hfLeaveTypeID.Value == "5")
            {
                leaveData.AddLeaveHelpGiveBirth();
            }
            else if (hfLeaveTypeID.Value == "6")
            {
                leaveData.AddLeaveOrdain();
            }
            else if (hfLeaveTypeID.Value == "7")
            {
                leaveData.AddLeaveHuj();
            }

            ClearNotification();
            MV1.ActiveViewIndex = 3;
        }

        protected void lbuBackMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void lbuHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveHistory.aspx");
        }

        #region ViewState DataTable

        private DataTable GetViewState()
        {
            //Gets the ViewState
            return (DataTable)ViewState["ManageLeave"];
        }

        private void SetViewState(DataTable data)
        {
            //Sets the ViewState
            ViewState["ManageLeave"] = data;
        }

        #endregion

        protected void BindManage()
        {
            ClassLeave MLeave = new ClassLeave();
            DataTable dt = MLeave.SELECT_Leave("",MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()));
            GridViewLeave.DataSource = dt;
            GridViewLeave.DataBind();
            SetViewState(dt);
        }

        protected void modDeleteCommand(Object sender, GridViewDeleteEventArgs e)
        {
            ClassLeave Cleave = new ClassLeave();
            int id = Convert.ToInt32(GridViewLeave.DataKeys[e.RowIndex].Value);
            
            int LeaveTypeID = DatabaseManager.ExecuteInt("SELECT LEAVE_TYPE_ID FROM TB_LEAVE WHERE LEAVE_ID = '" + id + "'");
            int TotalDay = DatabaseManager.ExecuteInt("SELECT TOTAL_DAY FROM TB_LEAVE WHERE LEAVE_ID = '" + id + "'");
            int BudgetYear = DatabaseManager.ExecuteInt("SELECT BUDGET_YEAR FROM TB_LEAVE WHERE LEAVE_ID = '" + id + "'");
            int UOC_ID = DatabaseManager.ExecuteInt("SELECT UOC_ID FROM TB_LEAVE WHERE LEAVE_ID = '" + id + "'");

            OracleConnection.ClearAllPools();
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                if (LeaveTypeID == 1)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET SICK_NOW = SICK_NOW - " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 2)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET BUSINESS_NOW = BUSINESS_NOW - " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 3)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET GB_NOW = GB_NOW - " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 4)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET REST_NOW = REST_NOW - " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 5)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET HGB_NOW = HGB_NOW - " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 6)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET ORDAIN_NOW = ORDAIN_NOW - " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
                else if (LeaveTypeID == 7)
                {
                    using (OracleCommand com = new OracleCommand("UPDATE TB_LEAVE_CLAIM SET HUJ_NOW = HUJ_NOW - " + TotalDay + " WHERE YEAR = " + BudgetYear + " AND UOC_ID = :UOC_ID", con))
                    {
                        com.Parameters.AddWithValue("UOC_ID", UOC_ID);
                        com.ExecuteNonQuery();
                    }
                }
            }

            Cleave.LEAVE_ID = id;
            Cleave.DELETE_LEAVE();
            
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ลบข้อมูลเรียบร้อย')", true);

            GridViewLeave.EditIndex = -1;
            BindManage();
        }

        protected void GridViewLeave_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("DeleteButton1");
                lb.Attributes.Add("onclick", "return confirm('คุณต้องการจะลบใช่หรือไม่ ?');");
            }
        }

        protected void myGridViewLeave_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewLeave.PageIndex = e.NewPageIndex;
            GridViewLeave.DataSource = GetViewState();
            GridViewLeave.DataBind();
        }

        private void ChangeNotification(string type)
        {
            switch (type)
            {
                case "info": notification.Attributes["class"] = "alert alert_info"; break;
                case "success": notification.Attributes["class"] = "alert alert_success"; break;
                case "warning": notification.Attributes["class"] = "alert alert_warning"; break;
                case "danger": notification.Attributes["class"] = "alert alert_danger"; break;
                default: notification.Attributes["class"] = null; break;
            }
        }
        private void ChangeNotification(string type, string text)
        {
            switch (type)
            {
                case "info": notification.Attributes["class"] = "alert alert_info"; break;
                case "success": notification.Attributes["class"] = "alert alert_success"; break;
                case "warning": notification.Attributes["class"] = "alert alert_warning"; break;
                case "danger": notification.Attributes["class"] = "alert alert_danger"; break;
                default: notification.Attributes["class"] = null; break;
            }
            notification.InnerHtml = text;
        }
        private void ClearNotification()
        {
            notification.Attributes["class"] = null;
            notification.InnerHtml = "";
        }
        private void AddNotification(string text)
        {
            notification.InnerHtml += text;
        }
    }
}