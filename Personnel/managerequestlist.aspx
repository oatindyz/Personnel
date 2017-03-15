<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="managerequestlist.aspx.cs" Inherits="Personnel.managerequestlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/comment.png" />จัดการข้อมูลคำร้องการแก้ไขข้อมูล
            <span style="text-align: right; float: right;"><a href="listrequest-admin.aspx">
            <img src="Image/Small/back.png" />ย้อนกลับ</a></span>
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
                                        <asp:DropDownList ID="ddlUniv" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Visible="false" Enabled="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="tr4_lb4PrefixName" runat="server" visible="false">
                                    <td class="col1">คำนำหน้าชื่อ(ยึดตามบัตรประชาชน)</td>
                                    <td class="col2">
                                        <asp:Label ID="lb4PrefixName" runat="server"></asp:Label>
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lb4PrefixName2" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlPrefixName" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Visible="false" Enabled="false"></asp:DropDownList>
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
                            </table>   
                        </div>
                        <div style="text-align: center; margin-bottom:10px; margin-top:10px;">
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnBack_Click" Text="ย้อนกลับ"></asp:Button>
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger ekknidRight" OnClick="btnCancel_Click" Text="ยกเลิกข้อมูล" OnClientClick="javascript:if(!confirm('คุณต้องการที่จะยกเลิกใช่หรือไม่'))return false;"></asp:Button>
                            <asp:Button ID="btnConfirm" runat="server" CssClass="btn btn-success ekknidRight" OnClick="btnConfirm_Click" Text="บันทึกข้อมูล"></asp:Button>
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
