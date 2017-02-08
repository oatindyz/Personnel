﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listrequest-admin.aspx.cs" Inherits="Personnel.listrequest_admin" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- for Menu List -->
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <script src="bower_components/metisMenu/dist/metisMenu.min.js"></script>
    <script src="bower_components/datatables/media/js/jquery.dataTables.min.js"></script>
    <script src="bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.min.js"></script>
    <script src="dist/js/sb-admin-2.js"></script>
    <!-- for Menu List -->

    <script>
        $(document).ready(function () {
            $('#dataTables-example').DataTable({
                responsive: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-header">
        <img src="Image/book_edit.png" />จัดการข้อมูลคำร้องการแก้ไขข้อมูล
    </div>
    <div id="notification" runat="server"></div>

    <div id="Dp1" runat="server" class="panel panel-default">
        <div class="panel-body">
            <div class="panel-body">
                <div id="divLoad" runat="server" class="dataTable_wrapper">
                    <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                        <thead>
                            <tr>
                                <th>ลำดับที่</th>
                                <th>ชื่อ-สกุล</th>
                                <th>ประเภทบุคลากร</th>
                                <th>คณะ/หน่วยงาน</th>
                                <th><img src="Image/Small/document-edit.png" class="icon_left" />จัดการข้อมูล</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="myRepeater" runat="server" OnItemCommand="myRepeater_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.ItemIndex +1 %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "NAME") %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "STAFF_NAME") %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "FAC_NAME") %></td>
                                    <td>
                                        <a><asp:LinkButton ID="lbuEdit" CommandName="Edit" runat="server" CommandArgument='<%#Personnel.MyCrypto.GetEncryptedQueryString(DataBinder.Eval(Container.DataItem, "ID_EDIT").ToString()) %>' class="btn btn-warning">จัดการข้อมูล</asp:LinkButton></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>