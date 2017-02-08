<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestEditData.aspx.cs" Inherits="Personnel.RequestEditData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function EnableUniv(source) {
            document.getElementById('<%= ddlUniv.ClientID %>').disabled = !source.checked;
        }
        function EnablePrefixName(source) {
            document.getElementById('<%= ddlPrefixName.ClientID %>').disabled = !source.checked;
        }
        function EnableName(source) {
            document.getElementById('<%= tbName.ClientID %>').disabled = !source.checked;
        }
        function EnableLastName(source) {
            document.getElementById('<%= tbLastName.ClientID %>').disabled = !source.checked;
        }
        function EnableGender(source) {
            document.getElementById('<%= ddlGender.ClientID %>').disabled = !source.checked;
        }
        function EnableBirthday(source) {
            document.getElementById('<%= tbBirthday.ClientID %>').disabled = !source.checked;
        }
        function EnableStafftype(source) {
            document.getElementById('<%= ddlStafftype.ClientID %>').disabled = !source.checked;
        }
        function EnableTimeContact(source) {
            document.getElementById('<%= ddlTimeContact.ClientID %>').disabled = !source.checked;
        }
        function EnableBudget(source) {
            document.getElementById('<%= ddlBudget.ClientID %>').disabled = !source.checked;
        }
        function EnableSubStafftype(source) {
            document.getElementById('<%= ddlSubStafftype.ClientID %>').disabled = !source.checked;
        }
        function EnableAdminPosition(source) {
            document.getElementById('<%= ddlAdminPosition.ClientID %>').disabled = !source.checked;
        }
        function EnablePosition(source) {
            document.getElementById('<%= ddlPosition.ClientID %>').disabled = !source.checked;
        }
        function EnablePositionWork(source) {
            document.getElementById('<%= tbPositionWork.ClientID %>').disabled = !source.checked;
        }
        function EnableDepartment(source) {
            document.getElementById('<%= ddlDepartment.ClientID %>').disabled = !source.checked;
        }
        function EnableDateInwork(source) {
            document.getElementById('<%= tbDateInwork.ClientID %>').disabled = !source.checked;
        }
        function EnableDateStartThisU(source) {
            document.getElementById('<%= tbDateStartThisU.ClientID %>').disabled = !source.checked;
        }
        function EnableSpecialName(source) {
            document.getElementById('<%= tbSpecialName.ClientID %>').disabled = !source.checked;
        }
        function EnableTeachISCED(source) {
            document.getElementById('<%= ddlTeachISCED.ClientID %>').disabled = !source.checked;
        }
        function EnableGradLev(source) {
            document.getElementById('<%= ddlGradLev.ClientID %>').disabled = !source.checked;
        }
        function EnableGradCURR(source) {
            document.getElementById('<%= tbGradCURR.ClientID %>').disabled = !source.checked;
        }
        function EnableGradISCED(source) {
            document.getElementById('<%= ddlGradISCED.ClientID %>').disabled = !source.checked;
        }
        function EnableGradProg(source) {
            document.getElementById('<%= ddlGradProg.ClientID %>').disabled = !source.checked;
        }
        function EnableGradUniv(source) {
            document.getElementById('<%= tbGradUniv.ClientID %>').disabled = !source.checked;
        }
        function EnableGradCountry(source) {
            document.getElementById('<%= ddlGradCountry.ClientID %>').disabled = !source.checked;
        }
        function EnableReligion(source) {
            document.getElementById('<%= ddlReligion.ClientID %>').disabled = !source.checked;
        }
    </script>

    <script type="text/javascript">
        $(function () {
            var thaiYear = function (ct) {
                var leap = 3;
                var dayWeek = ["พฤ.", "ศ.", "ส.", "อา.", "จ.", "อ.", "พ."];
                if (ct) {
                    var yearL = new Date(ct).getFullYear() - 543;
                    leap = (((yearL % 4 == 0) && (yearL % 100 != 0)) || (yearL % 400 == 0)) ? 2 : 3;
                    if (leap == 2) {
                        dayWeek = ["ศ.", "ส.", "อา.", "จ.", "อ.", "พ.", "พฤ."];
                    }
                }
                this.setOptions({
                    i18n: { th: { dayOfWeek: dayWeek } }, dayOfWeekStart: leap,
                })
            };

            $('#ContentPlaceHolder1_tbBirthday,#ContentPlaceHolder1_tbDateInwork,#ContentPlaceHolder1_tbDateStartThisU').datetimepicker({
                timepicker: false,
                format: 'd/m/Y',
                lang: 'th',
                onChangeMonth: thaiYear,
                onShow: thaiYear,
                yearOffset: 543,
                closeOnDateSelect: true,
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/comment.png" />คำร้องขอการแก้ไขข้อมูล
        </div>

        <div class="panel panel-default">
            <div class="panel-body">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View0" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbUniv" runat="server" onclick="EnableUniv(this);" /></td>
                                    <td class="col1" style="width: 400px;">มหาวิทยาลัย</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlUniv" runat="server" CssClass="form-control input-sm select2" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbPrefixName" runat="server" onclick="EnablePrefixName(this);" /></td>
                                    <td class="col1">คำนำหน้าชื่อ(ยึดตามบัตรประชาชน)</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlPrefixName" runat="server" CssClass="form-control input-sm select2" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbName" runat="server" onclick="EnableName(this);" /></td>
                                    <td class="col1">ชื่อ</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbName" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbLastName" runat="server" onclick="EnableLastName(this);" /></td>
                                    <td class="col1">นามสกุล</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbGender" runat="server" onclick="EnableGender(this);" /></td>
                                    <td class="col1">เพศ</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control input-sm select2" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbBirthday" runat="server" onclick="EnableBirthday(this);" /></td>
                                    <td class="col1">วันเกิด</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbBirthday" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                            
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbStafftype" runat="server" onclick="EnableStafftype(this);" /></td>
                                    <td class="col1" style="width: 400px;">ประเภทบุคลากร</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlStafftype" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbTimeContact" runat="server" onclick="EnableTimeContact(this);" /></td>
                                    <td class="col1">ระยะเวลาจ้าง</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlTimeContact" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbBudget" runat="server" onclick="EnableBudget(this);" /></td>
                                    <td class="col1">ประเภทเงินจ้าง</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlBudget" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbSubStafftype" runat="server" onclick="EnableSubStafftype(this);" /></td>
                                    <td class="col1">ประเภทบุคลากรย่อย</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlSubStafftype" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbAdminPosition" runat="server" onclick="EnableAdminPosition(this);" /></td>
                                    <td class="col1">ตำแหน่งบริหาร</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlAdminPosition" runat="server" CssClass="form-control input-sm select2" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbPosition" runat="server" onclick="EnablePosition(this);" /></td>
                                    <td class="col1">ระดับตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbPositionWork" runat="server" onclick="EnablePositionWork(this);" /></td>
                                    <td class="col1">ตำแหน่งในสายงาน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPositionWork" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbDepartment" runat="server" onclick="EnableDepartment(this);" /></td>
                                    <td class="col1">คณะ/หน่วยงานที่สังกัด หรือเทียบเท่า</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbDateInwork" runat="server" onclick="EnableDateInwork(this);" /></td>
                                    <td class="col1">วันที่เข้าทำงานครั้งแรก</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbDateInwork" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbDateStartThisU" runat="server" onclick="EnableDateStartThisU(this);" /></td>
                                    <td class="col1">วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbDateStartThisU" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbSpecialName" runat="server" onclick="EnableSpecialName(this);" /></td>
                                    <td class="col1">สาขางานที่เชี่ยวชาญ</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbSpecialName" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbTeachISCED" runat="server" onclick="EnableTeachISCED(this);" /></td>
                                    <td class="col1">กลุ่มสาขาวิชาที่สอน(ISCED)<span id="spTeachISCED" runat="server" /></td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlTeachISCED" runat="server" CssClass="form-control input-sm select2" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbGradLev" runat="server" onclick="EnableGradLev(this);" /></td>
                                    <td class="col1">ระดับการศึกษาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradLev" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbGradCURR" runat="server" onclick="EnableGradCURR(this);" /></td>
                                    <td class="col1">หลักสูตรที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbGradCURR" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbGradISCED" runat="server" onclick="EnableGradISCED(this);" /></td>
                                    <td class="col1">กลุ่มสาขาวิชาที่จบสูงสุด(ISCED)<span id="spGradISCED" runat="server" /></td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradISCED" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbGradProg" runat="server" onclick="EnableGradProg(this);" /></td>
                                    <td class="col1">สาขาวิชาที่จบสูงสุด<span id="spGradProg" runat="server" /></td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradProg" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbGradUniv" runat="server" onclick="EnableGradUniv(this);" /></td>
                                    <td class="col1">ชื่อสถาบันที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbGradUniv" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbGradCountry" runat="server" onclick="EnableGradCountry(this);" /></td>
                                    <td class="col1">ประเทศที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradCountry" runat="server" CssClass="form-control input-sm select2" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 10px;">
                                        <asp:CheckBox ID="cbReligion" runat="server" onclick="EnableReligion(this);" /></td>
                                    <td class="col1">ศาสนา</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlReligion" runat="server" CssClass="form-control input-sm select2" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="View1" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr id="tr4_lb4Univ" runat="server" visible="false">
                                    <td class="col1">มหาวิทยาลัย</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Univ" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4PrefixName" runat="server" visible="false">
                                    <td class="col1">คำนำหน้าชื่อ(ยึดตามบัตรประชาชน)</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4PrefixName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Name" runat="server" visible="false">
                                    <td class="col1">ชื่อ</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Name" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4LastName" runat="server" visible="false">
                                    <td class="col1">นามสกุล</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4LastName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Gender" runat="server" visible="false">
                                    <td class="col1">เพศ</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Gender" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Birthday" runat="server" visible="false">
                                    <td class="col1">วันเกิด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Birthday" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr id="tr4_lb4Stafftype" runat="server" visible="false">
                                    <td class="col1" style="width: 400px;">ประเภทบุคลากร</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Stafftype" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4TimeContact" runat="server" visible="false">
                                    <td class="col1">ระยะเวลาจ้าง</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4TimeContact" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Budget" runat="server" visible="false">
                                    <td class="col1">ประเภทเงินจ้าง</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Budget" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4SubStafftype" runat="server" visible="false">
                                    <td class="col1">ประเภทบุคลากรย่อย</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4SubStafftype" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4AdminPosition" runat="server" visible="false">
                                    <td class="col1">ตำแหน่งบริหาร</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4AdminPosition" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Position" runat="server" visible="false">
                                    <td class="col1">ระดับตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Position" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4PositionWork" runat="server" visible="false">
                                    <td class="col1">ตำแหน่งในสายงาน</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4PositionWork" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Department" runat="server" visible="false">
                                    <td class="col1">คณะ/หน่วยงานที่สังกัด หรือเทียบเท่า</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Department" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4DateInwork" runat="server" visible="false">
                                    <td class="col1">วันที่เข้าทำงานครั้งแรก</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4DateInwork" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4DateStartThisU" runat="server" visible="false">
                                    <td class="col1">วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4DateStartThisU" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4SpecialName" runat="server" visible="false">
                                    <td class="col1">สาขางานที่เชี่ยวชาญ</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4SpecialName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4TeachISCED" runat="server" visible="false">
                                    <td class="col1">กลุ่มสาขาวิชาที่สอน(ISCED)</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4TeachISCED" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradLev" runat="server" visible="false">
                                    <td class="col1">ระดับการศึกษาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradLev" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradCURR" runat="server" visible="false">
                                    <td class="col1">หลักสูตรที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradCURR" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradISCED" runat="server" visible="false">
                                    <td class="col1">กลุ่มสาขาวิชาที่จบสูงสุด(ISCED)</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradISCED" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradProg" runat="server" visible="false">
                                    <td class="col1">สาขาวิชาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradProg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradUniv" runat="server" visible="false">
                                    <td class="col1">ชื่อสถาบันที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradUniv" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradCountry" runat="server" visible="false">
                                    <td class="col1">ประเทศที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradCountry" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr id="tr4_lb4Religion" runat="server" visible="false">
                                    <td class="col1">ศาสนา</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Religion" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                     <asp:View ID="View2" runat="server">
                        <div>
                            <div class="ps-div-title-red">บันทึกการร้องขอแก้ไขข้อมูลบุคลากรสำเร็จ</div>
                            <div style="color: #808080; margin-top: 10px; text-align: center;">
                                ระบบได้ทำการบันทึกคำร้องการแก้ไขข้อมูลบุคลากรเรียบร้อยแล้ว
                            </div>
                            <div style="text-align: center; margin-top: 10px;">
                                <a href="Default.aspx" class="ps-button btn btn-primary">
                                    <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
    <div style="text-align: center;">
        <asp:Button ID="btnReally" runat="server" CssClass="btn btn-success" OnClick="btnReally_Click" Text="ยืนยัน"></asp:Button>
        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click" Text="ย้อนกลับ"></asp:Button>
        <asp:Button ID="btnAddPerson" runat="server" CssClass="btn btn-success" OnClick="lbuAddPerson_Click" Text="บันทึก"></asp:Button>
    </div>
</asp:Content>
