<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Personnel.Default" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col1 {
            text-align: right;
        }

        .col2 {
            text-align: left;
        }

        .textred {
            color: red;
        }
    </style>
    <script>
        $(function () {
            $("#ContentPlaceHolder1_tbBirthday,#ContentPlaceHolder1_tbDateInwork").datepicker($.datepicker.regional["th"]);
        });
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <h1>ยินดีต้อบรับเข้าสู่ระบบบุคลากร</h1>
        <p>มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</p>
    </div>


</asp:Content>
