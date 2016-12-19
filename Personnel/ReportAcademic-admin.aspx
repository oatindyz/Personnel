<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportAcademic-admin.aspx.cs" Inherits="Personnel.ReportAcademic_admin" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/copy.png" />จำนวนบุคลากรสายวิชาการ จำแนกตามประเภทบุคลากร คณะ และ XxX
        </div>
        <div>
            <asp:DropDownList ID="ddlView" runat="server" CssClass="form-control input-sm select2" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div style="text-align:center; margin:auto; margin-top:10px;">
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        </div>
        <div style="text-align:center; margin:auto; margin-top:10px;">
            <asp:LinkButton ID="lbuExport" runat="server" CssClass="ps-button" OnClick="lbuExport_Click"><img src="Image/Small/excel.png" class="icon_left"/>Export</asp:LinkButton>
        </div>
    </div>
</asp:Content>
