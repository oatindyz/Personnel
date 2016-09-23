<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="Personnel.testpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-header">
        <img src="Image/Small/edit.png" />test
    </div>
    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control input-sm select2" DataSourceID="SqlDataSource1" DataValueField="PERSON_ROLE_ID" DataTextField="PERSON_ROLE_NAME" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_PERSON_ROLE&quot;"></asp:SqlDataSource>
</asp:Content>
