<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Personnel.Profile" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .c1 {
            background-color: #ffffff;
            min-height: 200px;
            padding: 5px;
        }
        .c1 a {
            border: 1px solid transparent;
            display: inline-block;
            margin: 2px;
        }
        .c1 a:hover {
            border: 1px solid #ffffff;
        }
        .c1 img {
            max-height: 190px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default_page_style">

        <div class="ps-header">
            <img src="Image/Small/document.png" />ข้อมูลผู้ใช้งาน
        </div>

        <div class="panel panel-default">
            <div class="panel-body">
                <div id="divLoad1" runat="server" class="dataTable_wrapper" style="width: 100%; margin: auto;">
                    <div id="divTitle" runat="server" class="panel-heading" style="background-color: #f0f0f0; color: #000000; padding: 5px 10px;">
                        <img src="Image/Small/document.png" />
                        ข้อมูลส่วนตัว
                    </div>
                    <table class="ps-table-x16">
                        <tr>
                            <td class="col1">คำนำหน้า</td>
                            <td class="col2">
                                <asp:Label ID="lbPrefix" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="col1">ชื่อ</td>
                            <td class="col2">
                                <asp:Label ID="lbName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="col1">นามสกุล</td>
                            <td class="col2">
                                <asp:Label ID="lbLastName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="col1">เพศ</td>
                            <td class="col2">
                                <asp:Label ID="lbGender" runat="server"></asp:Label></td>
                        </tr>
                    </table>

                    <div id="div1" runat="server" class="panel-heading" style="background-color: #f0f0f0; color: #000000; padding: 5px 10px;">
                        <img src="Image/Small/location.png" />
                        ข้อมูลที่อยู่
                    </div>
                    <table class="ps-table-x16">
                        <tr>
                            <td class="col1">บ้านเลขที่</td>
                            <td class="col2">
                                <asp:Label ID="lbHomeAdd" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="col1">หมู่</td>
                            <td class="col2">
                                <asp:Label ID="lbMoo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="col1">ถนน</td>
                            <td class="col2">
                                <asp:Label ID="lbStreet" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="col1">จังหวัด</td>
                            <td class="col2">
                                <asp:Label ID="lbProvince" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="col1">อำเภอ</td>
                            <td class="col2">
                                <asp:Label ID="lbDistrict" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="col1">ตำบล</td>
                            <td class="col2">
                                <asp:Label ID="lbSubDistrict" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="col1">รหัสไปรษณีย์</td>
                            <td class="col2">
                                <asp:Label ID="lbZipcode" runat="server"></asp:Label></td>
                        </tr>
                    </table>

                    <div class="ps-separator"></div>
                    <div class="ps-box-hd10">
                        <img src="Image/Small/image.png" />รูปภาพ
                    </div>
                    <div class="ps-box-ct10">
                        <div style="background-color: #f0f0f0; color: #000000; padding: 5px 10px;" id="id1" runat="server">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:LinkButton ID="lbuUploadPicture" runat="server" OnClick="lbuUploadPicture_Click" CssClass="ps-button"><img src="Image/Small/upload.png" class="icon_left"/>อัพโหลด</asp:LinkButton>
                        </div>
                        <div class="c1" id="profile_images" runat="server">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
