using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections;
using System.Data.OracleClient;
using System.Data;
using System.Text;
using Rmutto.Connection;
using Personnel.Class;
using System.Web.UI;

namespace Personnel
{
    public partial class reportGP7_admin : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
                    lb1.Text = id.ToString();
                }
                else { Response.Redirect("listGP7-admin.aspx"); }
            }

            OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();

            string strConnString = null;

            DataSet dsMain = new DataSet();
            DataTable dtMain = null;
            StringBuilder strSQLMain = new StringBuilder();
            strConnString = "DATA SOURCE=ORCL_RMUTTO;PASSWORD=Zxcvbnm;PERSIST SECURITY INFO=True;USER ID=Personnel";
            strSQLMain.Append("SELECT CITIZEN_ID,");
            strSQLMain.Append("(SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) PREFIX_NAME,");
            strSQLMain.Append("STF_FNAME,");
            strSQLMain.Append("STF_LNAME,");
            strSQLMain.Append("BIRTHDAY,");
            strSQLMain.Append("DATE_INWORK,");
            strSQLMain.Append("(SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE REF_STAFFTYPE.STAFFTYPE_ID = UOC_STAFF.STAFFTYPE_ID) STAFFTYPE_ID,");
            strSQLMain.Append("FATHER_NAME || '  ' || FATHER_LNAME FATHER_NAME,");
            strSQLMain.Append("MOTHER_NAME || '  ' || MOTHER_LNAME MOTHER_NAME,");
            strSQLMain.Append("MOTHER_ONAME,");
            strSQLMain.Append("COUPLE_NAME || '  ' || COUPLE_LNAME COUPLE_NAME,");
            strSQLMain.Append("COUPLE_ONAME");
            strSQLMain.Append(" FROM UOC_STAFF WHERE UOC_ID = " + Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "");
            objConn.ConnectionString = strConnString;
            var _with1 = objCmd;
            _with1.Connection = objConn;
            _with1.CommandText = strSQLMain.ToString();
            _with1.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsMain, "myDataGP7");
            dtMain = dsMain.Tables[0];

            DataSet dsStudy = new DataSet();
            DataTable dtStudy = null;
            StringBuilder strSQLStudy = new StringBuilder();
            strSQLStudy.Append("SELECT UNIV_NAME,");
            strSQLStudy.Append("TO_CHAR(START_DATE,'MON YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') START_DATE,");
            strSQLStudy.Append("TO_CHAR(END_DATE,'MON YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') END_DATE,");
            strSQLStudy.Append("QUALIFICATION");
            strSQLStudy.Append(" FROM PS_STUDY WHERE UOC_ID = " + Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "");
            strSQLStudy.Append(" ORDER BY STUDY_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with2 = objCmd;
            _with2.Connection = objConn;
            _with2.CommandText = strSQLStudy.ToString();
            _with2.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsStudy, "myDataStudy");
            dtStudy = dsStudy.Tables[0];

            DataSet dsProLicense = new DataSet();
            DataTable dtProLicense = null;
            StringBuilder strSQLProLicense = new StringBuilder();
            strSQLProLicense.Append("SELECT LICENSE_NAME,");
            strSQLProLicense.Append("DEPARTMENT,");
            strSQLProLicense.Append("LICENSE_NUMBER,");
            strSQLProLicense.Append("TO_CHAR(START_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') START_DATE");
            strSQLProLicense.Append(" FROM PS_PRO_LICENSE WHERE UOC_ID = " + Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "");
            strSQLProLicense.Append(" ORDER BY PRO_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with3 = objCmd;
            _with3.Connection = objConn;
            _with3.CommandText = strSQLProLicense.ToString();
            _with3.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsProLicense, "myDataProLicense");
            dtProLicense = dsProLicense.Tables[0];

            DataSet dsTraining = new DataSet();
            DataTable dtTraining = null;
            StringBuilder strSQLTraining = new StringBuilder();
            strSQLTraining.Append("SELECT TRAINING_NAME,");
            strSQLTraining.Append("TO_CHAR(START_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') START_DATE,");
            strSQLTraining.Append("TO_CHAR(END_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') END_DATE,");
            strSQLTraining.Append("DEPARTMENT");
            strSQLTraining.Append(" FROM PS_TRAINING WHERE UOC_ID = " + Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "");
            strSQLTraining.Append(" ORDER BY TRAINING_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with4 = objCmd;
            _with4.Connection = objConn;
            _with4.CommandText = strSQLTraining.ToString();
            _with4.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsTraining, "myDataTraining");
            dtTraining = dsTraining.Tables[0];

            DataSet dsPunish = new DataSet();
            DataTable dtPunish = null;
            StringBuilder strSQLPunish = new StringBuilder();
            strSQLPunish.Append("SELECT YEAR,");
            strSQLPunish.Append("PUNISH_NAME,");
            strSQLPunish.Append("REF_DOC");
            strSQLPunish.Append(" FROM PS_PUNISHMENT WHERE UOC_ID = " + Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "");
            strSQLPunish.Append(" ORDER BY PUNISH_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with5 = objCmd;
            _with5.Connection = objConn;
            _with5.CommandText = strSQLPunish.ToString();
            _with5.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsPunish, "myDataPunish");
            dtPunish = dsPunish.Tables[0];


            DataSet dsPositionAndSalary = new DataSet();
            DataTable dtPositionAndSalary = null;
            StringBuilder strSQLPositionAndSalary = new StringBuilder();
            strSQLPositionAndSalary.Append("SELECT TO_CHAR(START_DATE,'DD/MM/YYYY','NLS_CALENDAR=''THAI BUDDHA''NLS_DATE_LANGUAGE=THAI') START_DATE,");
            strSQLPositionAndSalary.Append("PAS_NAME,");
            strSQLPositionAndSalary.Append("NO_POSITION,");
            strSQLPositionAndSalary.Append("POSITION_TYPE,");
            strSQLPositionAndSalary.Append("POSITION_DEGREE,");
            strSQLPositionAndSalary.Append("SALARY,");
            strSQLPositionAndSalary.Append("POSITION_SALARY,");
            strSQLPositionAndSalary.Append("REF_DOC");
            strSQLPositionAndSalary.Append(" FROM PS_POSI_AND_SALARY WHERE UOC_ID = " + Int32.Parse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString())) + "");
            strSQLPositionAndSalary.Append(" ORDER BY PAS_ID ASC");
            objConn.ConnectionString = strConnString;
            var _with6 = objCmd;
            _with6.Connection = objConn;
            _with6.CommandText = strSQLPositionAndSalary.ToString();
            _with6.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(dsPositionAndSalary, "myDataPositionAndSalary");
            dtPositionAndSalary = dsPositionAndSalary.Tables[0];


            dtAdapter = null;
            objConn.Close();
            objConn = null;

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/Report/CR/personGP7.rpt"));

            rpt.SetDataSource(dtMain);
            rpt.Subreports["psStudy"].Database.Tables[0].SetDataSource(dtStudy);
            rpt.Subreports["psProLicense"].Database.Tables[0].SetDataSource(dtProLicense);
            rpt.Subreports["dsTraining"].Database.Tables[0].SetDataSource(dtTraining);
            rpt.Subreports["psPunish"].Database.Tables[0].SetDataSource(dtPunish);
            rpt.Subreports["psPositionAndSalary"].Database.Tables[0].SetDataSource(dtPositionAndSalary);

            CrystalReportViewer1.ReportSource = rpt;

        }
    }
}