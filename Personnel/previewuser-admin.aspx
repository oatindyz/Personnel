<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="previewuser-admin.aspx.cs" Inherits="Personnel.previewuser_admin" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default_page_style">

        <div class="ps-header">
            <img src="Image/Small/person2.png" />ข้อมูลบุคลากร
            <span style="text-align:right; float:right;"><a href="listuser-admin.aspx">
            <img src="Image/Small/back.png" />ย้อนกลับ</a></span>
        </div>

        <div class="panel panel-default">
            <div class="panel-body">
                <div id="divLoad1" runat="server" class="dataTable_wrapper" style="width: 100%; margin: auto;">
                    <div class="panel panel-default">
                        <div id="divTab2" runat="server" style="text-align: center; margin-top:15px">
                            <div style="display: inline-block; margin-right: 20px;">
                                <table class="table table-striped table-bordered table-hover">
                                    <tr>
                                        <td class="col1" style="width: 350px;">รหัสประจำตัวประชาชน</td>
                                        <td class="col2">
                                            <asp:Label ID="lbCitizenID" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">มหาวิทยาลัย</td>
                                        <td class="col2">
                                            <asp:Label ID="lbUniv" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">คำนำหน้าชื่อ(ยึดตามบัตรประชาชน)</td>
                                        <td class="col2">
                                            <asp:Label ID="lbPrefixName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">ชื่อ</td>
                                        <td class="col2">
                                            <asp:Label ID="lbName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">นามสกุล</td>
                                        <td class="col2">
                                            <asp:Label ID="lbLastName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">เพศ</td>
                                        <td class="col2">
                                            <asp:Label ID="lbGender" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">วันเกิด</td>
                                        <td class="col2">
                                            <asp:Label ID="lbBirthday" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">บ้านเลขที่</td>
                                        <td class="col2">
                                            <asp:Label ID="lbHomeAdd" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">หมู่</td>
                                        <td class="col2">
                                            <asp:Label ID="lbMoo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">ถนน</td>
                                        <td class="col2">
                                            <asp:Label ID="lbStreet" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">จังหวัด</td>
                                        <td class="col2">
                                            <asp:Label ID="lbProvince" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">อำเภอ</td>
                                        <td class="col2">
                                            <asp:Label ID="lbDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">ตำบล</td>
                                        <td class="col2">
                                            <asp:Label ID="lbSubDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">หมายเลขโทรศัพท์ที่ทำงาน</td>
                                        <td class="col2">
                                            <asp:Label ID="lbTelephone" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">รหัสไปรษณีย์</td>
                                        <td class="col2">
                                            <asp:Label ID="lbZipcode" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">สัญชาติ</td>
                                        <td class="col2">
                                            <asp:Label ID="lbNation" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <!-- -->
                                    <tr>
                                        <td class="col1">ประเภทบุคลากร</td>
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

                                    <!-- -->
                                    <tr>
                                        <td class="col1">ความพิการ</td>
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
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
