<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="Personnel._404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .body {
            background-image: url("Image/githubdotcom.jpg");
            height: 180%;
            background-size: 100% 100%;
            background-repeat: no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel8" runat="server" Height="400px">
        <div id="notfound" class="">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="ps-div-title-red">แจ้งเตือน</div>
                    <div style="color: #808080; margin-top: 10px; text-align: center;">
                        ไม่มีหน้าดังกล่าวในระบบ โปรดลองใหม่อีกครั้ง!
                    </div>
                    <div style="text-align: center; margin-top: 10px;">
                        <a href="Default.aspx" class="ps-button btn btn-primary">
                            <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>
</asp:Content>
