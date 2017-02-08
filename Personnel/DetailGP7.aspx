<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailGP7.aspx.cs" Inherits="Personnel.DetailGP7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default_page_style">

        <div class="ps-header">
            <img src="Image/Small/person2.png" />ข้อมูลก.พ.7
        </div>

        <div class="panel panel-default">
            <div class="panel-body">
                <div id="divLoad1" runat="server" class="dataTable_wrapper" style="width: 100%; margin: auto;">
                    <div id="divTab2" runat="server" style="text-align: center; margin-top: 15px">
                        <div style="display: inline-block; margin-right: 20px;">
                            <table class="table table-striped table-bordered table-hover">
                                <tr>
                                    <td class="col1" style="width: 350px;">ชื่อบิดา</td>
                                    <td class="col2">
                                        <asp:Label ID="lbCitizenID" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">นามสกุลบิดา</td>
                                    <td class="col2">
                                        <asp:Label ID="lbUniv" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อมารดา</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPrefixName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">นามสกุลมารดา</td>
                                    <td class="col2">
                                        <asp:Label ID="lbName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">นามสกุลมารดาเดิม</td>
                                    <td class="col2">
                                        <asp:Label ID="lbLastName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อคู่สมรส</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGender" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">นามสกุลคู่สมรส</td>
                                    <td class="col2">
                                        <asp:Label ID="lbBirthday" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">นามสกุลเดิมคู่สมรสเดิม</td>
                                    <td class="col2">
                                        <asp:Label ID="lbHomeAdd" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>