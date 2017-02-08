<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="managerequestlist.aspx.cs" Inherits="Personnel.managerequestlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/comment.png" />จัดการข้อมูลคำร้องการแก้ไขข้อมูล
        </div>

        <div class="panel panel-default">
            <div class="panel-body">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View0" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 33%; text-align:center;">
                                        <b>คำนิยาม</b>
                                    </td>
                                    <td class="col2" style="width: 33%; text-align:center;">
                                        <b>รายการข้อมูลบุคลากรปัจจุบัน</b>
                                    </td>
                                    <td class="col2" style="width: 33%; text-align:center;">
                                        <b>รายการข้อมูลคำร้องที่ขอแก้ไขข้อมูล</b>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Univ" runat="server" visible="false">
                                    <td class="col1" style="width: 33%">มหาวิทยาลัย</td>
                                    <td class="col2" style="width: 33%">
                                        <asp:Label ID="lb4Univ" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2" style="width: 33%">
                                        <asp:Label ID="lb4Univ2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4PrefixName" runat="server" visible="false">
                                    <td class="col1">คำนำหน้าชื่อ(ยึดตามบัตรประชาชน)</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4PrefixName" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4PrefixName2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Name" runat="server" visible="false">
                                    <td class="col1">ชื่อ</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Name" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Name2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4LastName" runat="server" visible="false">
                                    <td class="col1">นามสกุล</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4LastName" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4LastName2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Gender" runat="server" visible="false">
                                    <td class="col1">เพศ</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Gender" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                         <asp:Label ID="lb4Gender2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Birthday" runat="server" visible="false">
                                    <td class="col1">วันเกิด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Birthday" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Birthday2" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr id="tr4_lb4Stafftype" runat="server" visible="false">
                                    <td class="col1" style="width: 400px;">ประเภทบุคลากร</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Stafftype" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Stafftype2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4TimeContact" runat="server" visible="false">
                                    <td class="col1">ระยะเวลาจ้าง</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4TimeContact" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4TimeContact2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Budget" runat="server" visible="false">
                                    <td class="col1">ประเภทเงินจ้าง</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Budget" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                         <asp:Label ID="lb4Budget2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4SubStafftype" runat="server" visible="false">
                                    <td class="col1">ประเภทบุคลากรย่อย</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4SubStafftype" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4SubStafftype2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4AdminPosition" runat="server" visible="false">
                                    <td class="col1">ตำแหน่งบริหาร</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4AdminPosition" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                         <asp:Label ID="lb4AdminPosition2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Position" runat="server" visible="false">
                                    <td class="col1">ระดับตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Position" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Position2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4PositionWork" runat="server" visible="false">
                                    <td class="col1">ตำแหน่งในสายงาน</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4PositionWork" runat="server"></asp:Label>
                                    </td>
                                     <td class="col2">
                                         <asp:Label ID="lb4PositionWork2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4Department" runat="server" visible="false">
                                    <td class="col1">คณะ/หน่วยงานที่สังกัด หรือเทียบเท่า</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Department" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Department2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4DateInwork" runat="server" visible="false">
                                    <td class="col1">วันที่เข้าทำงานครั้งแรก</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4DateInwork" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4DateInwork2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4DateStartThisU" runat="server" visible="false">
                                    <td class="col1">วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4DateStartThisU" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4DateStartThisU2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4SpecialName" runat="server" visible="false">
                                    <td class="col1">สาขางานที่เชี่ยวชาญ</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4SpecialName" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4SpecialName2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4TeachISCED" runat="server" visible="false">
                                    <td class="col1">กลุ่มสาขาวิชาที่สอน(ISCED)</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4TeachISCED" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4TeachISCED2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradLev" runat="server" visible="false">
                                    <td class="col1">ระดับการศึกษาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradLev" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradLev2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradCURR" runat="server" visible="false">
                                    <td class="col1">หลักสูตรที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradCURR" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradCURR2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradISCED" runat="server" visible="false">
                                    <td class="col1">กลุ่มสาขาวิชาที่จบสูงสุด(ISCED)</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradISCED" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradISCED2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradProg" runat="server" visible="false">
                                    <td class="col1">สาขาวิชาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradProg" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                         <asp:Label ID="lb4GradProg2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradUniv" runat="server" visible="false">
                                    <td class="col1">ชื่อสถาบันที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradUniv" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradUniv2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4GradCountry" runat="server" visible="false">
                                    <td class="col1">ประเทศที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradCountry" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4GradCountry2" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr id="tr4_lb4Religion" runat="server" visible="false">
                                    <td class="col1">ศาสนา</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4Religion" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                         <asp:Label ID="lb4Religion2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>   
                        </div>
                        <div style="text-align: center; margin-bottom:10px; margin-top:10px;">
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnBack_Click" Text="ย้อนกลับ"></asp:Button>
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger ekknidRight" OnClick="btnCancel_Click" Text="ยกเลิก" OnClientClick="javascript:if(!confirm('คุณต้องการที่จะยกเลิกใช่หรือไม่'))return false;"></asp:Button>
                            <asp:Button ID="btnConfirm" runat="server" CssClass="btn btn-success ekknidRight" OnClick="btnConfirm_Click" Text="บันทึก"></asp:Button>
                        </div>
                     </asp:View>
                     <asp:View ID="View1" runat="server">
                        <div>
                            <div class="ps-div-title-red">บันทึกคำร้องขอแก้ไขข้อมูลบุคลากรสำเร็จ</div>
                            <div style="color: #808080; margin-top: 10px; text-align: center;">
                                ระบบได้ทำการแก้ไขข้อมูลบุคลากรเรียบร้อยแล้ว
                            </div>
                            <div style="text-align: center; margin-top: 10px;">
                                <a href="Default.aspx" class="ps-button btn btn-primary">
                                    <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                            </div>
                        </div>
                    </asp:View>
                     <asp:View ID="View2" runat="server">
                        <div>
                            <div class="ps-div-title-red">บันทึกการยกเลิกคำร้องแก้ไขข้อมูลบุคลากรสำเร็จ</div>
                            <div style="color: #808080; margin-top: 10px; text-align: center;">
                                ระบบได้ทำการยกเลิกคำร้องนี้เรียบร้อยแล้ว
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

</asp:Content>
