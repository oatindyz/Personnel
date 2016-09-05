<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="Personnel._404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel8" runat="server" Height="400px">
        <div id="notfound">
            <div>
                <div class="ps-div-title-red">แจ้งเตือน</div>
                <div style="color: #808080; margin-top: 10px; text-align: center;">
                    ไม่มีหน้าดังกล่าวในระบบ โปรดลองใหม่อีกครั้ง!
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <a href="Default.aspx" class="ps-button">
                        <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
