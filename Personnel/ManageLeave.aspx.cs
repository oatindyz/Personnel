using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Personnel.Class;
using System.IO;
using System.Data.OracleClient;
using System.Data;

namespace Personnel
{
    public partial class ManageLeave : System.Web.UI.Page
    {
        int id = 0;
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
                else if(genderID == "2")
                {
                    lbuSelectGiveBirth.Visible = true;
                    lbuSelectHelpGiveBirth.Visible = false;
                    lbuSelectOrdain.Visible = false;
                    lbuSelectHuj.Visible = false;
                }
            }
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
    }
}