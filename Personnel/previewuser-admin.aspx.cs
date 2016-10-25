using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Text;
using Personnel.Class;

namespace Personnel
{
    public partial class previewuser_admin : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int.TryParse(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"].ToString()), out id);
                    ReadSelectID();
                }
            }
        }

        private void ReadSelectID()
        {
            using (OracleConnection con = new OracleConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (OracleCommand com = new OracleCommand("SELECT CITIZEN_ID,(SELECT UNIV_NAME_TH FROM REF_UNIV WHERE REF_UNIV.UNIV_ID = UOC_STAFF.UNIV_ID) UNIV_NAME,(SELECT FULLNAME FROM REF_PREFIX_NAME WHERE UOC_STAFF.PREFIX_NAME = REF_PREFIX_NAME.PREFIX_NAME_ID) PREFIX_NAME,STF_FNAME,STF_LNAME,(SELECT GENDER_NAME FROM REF_GENDER WHERE REF_GENDER.GENDER_ID = UOC_STAFF.GENDER_ID) GENDER_NAME,BIRTHDAY,HOMEADD,MOO,STREET,(SELECT PROVINCE_NAME_TH FROM REF_PROVINCE WHERE REF_PROVINCE.PROVINCE_ID = UOC_STAFF.PROVINCE_ID) PROVINCE_NAME,(SELECT DISTRICT_NAME_TH FROM REF_DISTRICT WHERE REF_DISTRICT.DISTRICT_ID = UOC_STAFF.DISTRICT_ID) DISTRICT_NAME,(SELECT SUB_DISTRICT_NAME_TH FROM REF_SUB_DISTRICT WHERE REF_SUB_DISTRICT.SUB_DISTRICT_ID = UOC_STAFF.SUB_DISTRICT_ID) SUB_DISTRICT_NAME,TELEPHONE,ZIPCODE,(SELECT NATION_NAME_ENG FROM REF_NATION WHERE REF_NATION.NATION_ID = UOC_STAFF.NATION_ID) NATION_NAME,(SELECT STAFFTYPE_NAME FROM REF_STAFFTYPE WHERE REF_STAFFTYPE.STAFFTYPE_ID = UOC_STAFF.STAFFTYPE_ID) STAFFTYPE_NAME,(SELECT TIME_CONTACT_NAME FROM REF_TIME_CONTACT WHERE REF_TIME_CONTACT.TIME_CONTACT_ID = UOC_STAFF.TIME_CONTACT_ID) TIME_CONTACT_NAME,(SELECT BUDGET_NAME FROM REF_BUDGET WHERE REF_BUDGET.BUDGET_ID = UOC_STAFF.BUDGET_ID) BUDGET_NAME,(SELECT SUBSTAFFTYPE_NAME FROM REF_SUBSTAFFTYPE WHERE REF_SUBSTAFFTYPE.SUBSTAFFTYPE_ID = UOC_STAFF.SUBSTAFFTYPE_ID) SUBSTAFFTYPE_NAME,(SELECT ADMIN_NAME FROM REF_ADMIN WHERE REF_ADMIN.ADMIN_ID = UOC_STAFF.ADMIN_POSITION_ID) ADMIN_POSITION_NAME,(SELECT POSITION_NAME_TH FROM REF_POSITION WHERE REF_POSITION.POSITION_ID = UOC_STAFF.POSITION_ID) POSITION_NAME,POSITION_WORK,(SELECT FAC_NAME FROM REF_FAC WHERE REF_FAC.FAC_ID = UOC_STAFF.DEPARTMENT_ID) DEPARTMENT_NAME,DATE_INWORK,DATE_START_THIS_U,SPECIAL_NAME,(SELECT ISCED_NAME FROM REF_ISCED WHERE REF_ISCED.ISCED_ID = UOC_STAFF.TEACH_ISCED_ID) TEACH_ISCED_NAME,(SELECT LEV_NAME_TH FROM REF_LEV WHERE REF_LEV.LEV_ID = UOC_STAFF.GRAD_LEV_ID) GRAD_LEV_NAME,GRAD_CURR,(SELECT ISCED_NAME FROM REF_ISCED WHERE REF_ISCED.ISCED_ID = UOC_STAFF.GRAD_ISCED_ID) GRAD_ISCED_NAME,(SELECT PROGRAM_NAME FROM REF_PROGRAM WHERE REF_PROGRAM.PROGRAM_ID_NEW = UOC_STAFF.GRAD_PROG) GRAD_PROG,GRAD_UNIV,(SELECT NATION_NAME_ENG FROM REF_NATION WHERE REF_NATION.NATION_ID = UOC_STAFF.GRAD_COUNTRY_ID) GRAD_COUNTRY_NAME,(SELECT DEFORM_NAME FROM REF_DEFORM WHERE REF_DEFORM.DEFORM_ID = UOC_STAFF.DEFORM_ID) DEFORM_NAME,SIT_NO,SALARY,POSITION_SALARY,(SELECT RELIGION_NAME_TH FROM REF_RELIGION WHERE REF_RELIGION.RELIGION_ID = UOC_STAFF.RELIGION_ID) RELIGION_NAME_TH,(SELECT MOVEMENT_TYPE_NAME FROM REF_MOVEMENT_TYPE WHERE REF_MOVEMENT_TYPE.MOVEMENT_TYPE_ID = UOC_STAFF.MOVEMENT_TYPE_ID) MOVEMENT_TYPE_NAME,MOVEMENT_DATE,DECORATION,RESULT1,PERCENT_SALARY1,RESULT2,PERCENT_SALARY2 FROM UOC_STAFF WHERE UOC_ID = '" + id + "'", con))
                {
                    using (OracleDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            lbCitizenID.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbUniv.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPrefixName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbLastName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbGender.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbBirthday.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbHomeAdd.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbMoo.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbStreet.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbProvince.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDistrict.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbSubDistrict.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbTelephone.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbZipcode.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbNation.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                            lbStaffType.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbTimeContact.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbBudget.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbSubStafftype.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbAdminPosition.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPosition.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPositionWork.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDepartment.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDateInwork.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDateStartThisU.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbSpecialName.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbTeachISCED.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbGradLev.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbGradCURR.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbGradISCED.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbGradProg.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbGradUniv.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbGradCountry.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                            lbDeform.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbSitNo.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbSalary.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPositionSalary.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbReligion.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbMovementType.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbMovementDate.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbDecoration.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbResult1.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPercentSalary1.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbResult2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;
                            lbPercentSalary2.Text = reader.IsDBNull(i) ? "" : reader.GetString(i); ++i;

                        }
                    }
                }
            }
        }


    }
}