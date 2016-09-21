﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adduser-admin.aspx.cs" Inherits="Personnel.adduser_admin" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $('#ContentPlaceHolder1_tbBirthday,#ContentPlaceHolder1_tbDateInwork,#ContentPlaceHolder1_tbDateStartThisU').datetimepicker({
                yearOffset: 543,
                format: "d/m/Y",
                formatDate: "d/m/Y"
            });
        });
    </script>
    <script type="text/javascript">
        function validateFields() {

            var message = "";
            var error = false;

            var citizen = document.getElementById("<%=tbCitizenID.ClientID %>");
            var name = document.getElementById("<%=tbName.ClientID %>");

            if ((/\S+/.test(citizen.value)) == false) { message += "กรุณากรอก รหัสบัตรประชาชน" + "<br>"; error = true; }
            if ((/\S+/.test(name.value)) == false) { message += "กรุณากรอก ชื่อ" + "<br>"; error = true; }

            if (error) {
                document.getElementById("validationSummary").innerHTML = message;
                document.getElementById("validationSummary").style.display = "block";
                document.getElementById("validationSummary").style.color = "red";
                return false;
            } else {
                document.getElementById("validationSummary").innerHTML = "";
                document.getElementById("validationSummary").style.display = "none";
                return true;
            }
        }
    </script>
    <!-- for Seach Dropdown-List -->
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/jquery.searchabledropdown-1.0.8.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
        $("select").searchable({
          maxListSize: 200, // if list size are less than maxListSize, show them all
          maxMultiMatch: 300, // how many matching entries should be displayed
          exactMatch: false, // Exact matching on search
          wildcards: true, // Support for wildcard characters (*, ?)
          ignoreCase: true, // Ignore case sensitivity
          latency: 200, // how many millis to wait until starting search
          warnMultiMatch: 'top {0} matches ...', 
          warnNoMatch: 'no matches ...', 
          zIndex: 'auto'
              });
           });
    </script>
    <!-- for Seach Dropdown-List -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/add.png" />เพิ่มข้อมูลบุคลากร
        </div>
        <div id="notification" runat="server"></div>
        <div id="validationSummary" style="display: none; float: left"></div>

        <div class="panel panel-default">
            <div class="panel-body">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View0" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 400px;">รหัสประจำตัวประชาชน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbCitizenID" runat="server" CssClass="ps-textbox" MaxLength="13"></asp:TextBox><span class="ps-lb-red">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">มหาวิทยาลัย</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlUniv" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">คำนำหน้าชื่อ(ยึดตามบัตรประชาชน)</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlPrefixName" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อ</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbName" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="ps-lb-red">*</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">นามสกุล</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbLastName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เพศ</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันเกิด</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbBirthday" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">บ้านเลขที่</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbHomeAdd" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">หมู่</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbMoo" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ถนน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbStreet" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">จังหวัด</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlProvince" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">อำเภอ</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำบล</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlSubDistrict" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">หมายเลขโทรศัพท์ที่ทำงาน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbTelephone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">รหัสไปรษณีย์</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbZipcode" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สัญชาติ</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlNation" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="View1" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 400px;">ประเภทบุคลากร</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlStafftype" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระยะเวลาจ้าง</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlTimeContact" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทเงินจ้าง</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlBudget" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlSubStafftype" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlSubStafftype_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งบริหาร</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlAdminPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งในสายงาน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPositionWork" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">คณะ/หน่วยงานที่สังกัด หรือเทียบเท่า</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่เข้าทำงานครั้งแรก</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbDateInwork" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbDateStartThisU" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สาขางานที่เชี่ยวชาญ</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbSpecialName" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">กลุ่มสาขาวิชาที่สอน(ISCED)</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlTeachISCED" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับการศึกษาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradLev" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">หลักสูตรที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbGradCURR" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">กลุ่มสาขาวิชาที่จบสูงสุด(ISCED)</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradISCED" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สาขาวิชาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradProg" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อสถาบันที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbGradUniv" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเทศที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradCountry" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 400px;">ความพิการ</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlDeform" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เลขที่ตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbSitNo" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เงินเดือนปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbSalary" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เงินประจำตำแหน่งที่ได้รับ</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPositionSalary" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ศาสนา</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlReligion" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทการดำรงตำแหน่งปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlMovementType" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่มีผลบังคับใช้ตามข้อมูล"การเข้าสู่ตำแหน่งปัจจุบัน"</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbMovementDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เครื่องราชอิสริยาภรณ์สูงสุดที่ได้รับ</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbDecoration" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่1</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbResult1" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่1</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPercentSalary1" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่2</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbResult2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่2</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPercentSalary2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <div>
                            <div class="ps-div-title-red">ทำการบันทึกข้อมูลบุคลากรสำเร็จ</div>
                            <div style="color: #808080; margin-top: 10px; text-align: center;">
                                ระบบได้ทำการบันทึกข้อมูลบุคลากรเรียบร้อยแล้ว
                            </div>
                            <div style="text-align: center; margin-top: 10px;">
                                <a href="Default.aspx" class="ps-button">
                                    <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
    <div style="text-align: center;">
        <asp:LinkButton ID="lbuSelectView0" runat="server" CssClass="ps-button" OnClick="lbuSelectView0_Click">หน้าที่ 1<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
        <asp:LinkButton ID="lbuSelectView1" runat="server" CssClass="ps-button" OnClick="lbuSelectView1_Click"><img src="Image/Small/back.png" class="icon_left"/>หน้าที่ 2<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
        <asp:LinkButton ID="lbuSelectView2" runat="server" CssClass="ps-button" OnClick="lbuSelectView2_Click"><img src="Image/Small/back.png" class="icon_left"/>หน้าที่ 3</asp:LinkButton>
        <asp:LinkButton ID="lbuAddPerson" runat="server" CssClass="ps-button" OnClick="lbuAddPerson_Click"><img src="Image/Small/save.png" class="icon_left"/>เพิ่มข้อมูลบุคลากร</asp:LinkButton>
    </div>
</asp:Content>
