<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="edituser.aspx.cs" Inherits="Personnel.edituser" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="ps-header">
            <img src="Image/Small/edit.png" />แก้ไขข้อมูลบุคลากร
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View0" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 400px;">รหัสประจำตัวประชาชน</td>
                                    <td class="col2">
                                        <asp:Label ID="lbCitizenID" runat="server"></asp:Label>
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
                                        <asp:TextBox ID="tbName" runat="server" CssClass="ps-textbox"></asp:TextBox>
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
                                        <asp:Label ID="lbStaffType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระยะเวลาจ้าง</td>
                                    <td class="col2">
                                        <asp:Label ID="lbTimeContact" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทเงินจ้าง</td>
                                    <td class="col2">
                                        <asp:Label ID="lbBudget" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:Label ID="lbSubStafftype" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งบริหาร</td>
                                    <td class="col2">
                                        <asp:Label ID="lbAdminPosition" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPosition" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งในสายงาน</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPositionWork" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">คณะ/หน่วยงานที่สังกัด หรือเทียบเท่า</td>
                                    <td class="col2">
                                        <asp:Label ID="lbDepartment" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่เข้าทำงานครั้งแรก</td>
                                    <td class="col2">
                                        <asp:Label ID="lbDateInwork" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:Label ID="lbDateStartThisU" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สาขางานที่เชี่ยวชาญ</td>
                                    <td class="col2">
                                        <asp:Label ID="lbSpecialName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">กลุ่มสาขาวิชาที่สอน(ISCED)</td>
                                    <td class="col2">
                                        <asp:Label ID="lbTeachISCED" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับการศึกษาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradLev" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">หลักสูตรที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradCURR" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">กลุ่มสาขาวิชาที่จบสูงสุด(ISCED)</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradISCED" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สาขาวิชาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradProg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อสถาบันที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradUniv" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเทศที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradCountry" runat="server"></asp:Label>
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
                                        <asp:Label ID="lbDeform" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เลขที่ตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:Label ID="lbSitNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เงินเดือนปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:Label ID="lbSalary" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เงินประจำตำแหน่งที่ได้รับ</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPositionSalary" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ศาสนา</td>
                                    <td class="col2">
                                        <asp:Label ID="lbReligion" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทการดำรงตำแหน่งปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:Label ID="lbMovementType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่มีผลบังคับใช้ตามข้อมูล"การเข้าสู่ตำแหน่งปัจจุบัน"</td>
                                    <td class="col2">
                                        <asp:Label ID="lbMovementDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เครื่องราชอิสริยาภรณ์สูงสุดที่ได้รับ</td>
                                    <td class="col2">
                                        <asp:Label ID="lbDecoration" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่1</td>
                                    <td class="col2">
                                        <asp:Label ID="lbResult1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่1</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPercentSalary1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่2</td>
                                    <td class="col2">
                                        <asp:Label ID="lbResult2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่2</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPercentSalary2" runat="server"></asp:Label>
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
    <div style="text-align: center;">
        <asp:LinkButton ID="lbuSelectView0" runat="server" CssClass="ps-button" OnClick="lbuSelectView0_Click">หน้าที่ 1<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
        <asp:LinkButton ID="lbuSelectView1" runat="server" CssClass="ps-button" OnClick="lbuSelectView1_Click"><img src="Image/Small/back.png" class="icon_left"/>หน้าที่ 2<img src="Image/Small/next.png" class="icon_right"/></asp:LinkButton>
        <asp:LinkButton ID="lbuSelectView2" runat="server" CssClass="ps-button" OnClick="lbuSelectView2_Click"><img src="Image/Small/back.png" class="icon_left"/>หน้าที่ 3</asp:LinkButton>
        <asp:LinkButton ID="lbuUpdatePerson" runat="server" CssClass="ps-button" OnClick="lbuUpdatePerson_Click"><img src="Image/Small/save.png" class="icon_left"/>แก้ไขข้อมูลบุคลากร</asp:LinkButton>
    </div>
</asp:Content>
