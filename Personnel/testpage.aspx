﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="Personnel.testpage" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .col1 {
            text-align: right;
        }
        .col2 {
            text-align: left;
        }
        .ttt{
            table-layout: fixed;
        }
        .ttt td {
            overflow: hidden;
        }
    </style>
    <script>
        function toggle(source, type) {
            var checkboxes = document.getElementsByName(type);
            var vSource = document.getElementById(source);
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].firstChild.checked = vSource.checked;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header"><img src="Image/Small/medal.png" />รายชื่อผู้มีสิทธิ์ได้รับเครื่องราชฯ</div>
        <div style="text-align: center;">
            <div class="ps-div-title-red"><img src="Image/Small/search.png" class="icon_left"/>ค้นหาข้อมูล</div>
            <table class="ps-table-1" style="display: inline-block; text-align: left;">
                <tr>
                    <td class="col1"></td>
                    <td class="col2">
                        <asp:LinkButton ID="lbuSearch" runat="server" CssClass="ps-button" OnClick="lbuSearch_Click"><img src="Image/Small/search.png" class="icon_left"/>ค้นหาผู้ที่เข้าเกณฑ์</asp:LinkButton>
                        <asp:LinkButton ID="lbuSearchAll" runat="server" CssClass="ps-button" OnClick="lbuSearchAll_Click"><img src="Image/Small/search.png" class="icon_left"/>ค้นหาทั้งหมด</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div class="ps-separator"></div>
        <asp:LinkButton ID="lbuSend" runat="server" CssClass="ps-button" OnClick="lbuSend_Click"><img src='Image/Small/send-email.png' class='icon_left'/>ส่งการแจ้งเตือน</asp:LinkButton>
        <div style="overflow-x:auto; width: 1500px;">
            <asp:Table ID="Table1" runat="server" CssClass="ps-table-1 ttt" style="margin-top: 10px;"></asp:Table>
        </div>
        <asp:HiddenField ID="hf1" runat="server" />
    </div>
</asp:Content>