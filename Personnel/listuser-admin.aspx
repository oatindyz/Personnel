<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listuser-admin.aspx.cs" Inherits="Personnel.listuser_admin" %>
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
        <img src="Image/book_edit.png" />บุคลากรภายในมหาวิทยาลัย
        <span style="text-align:right; float:right;"><a href="adduser-admin.aspx" id="cbAdminPersonAdd" runat="server">
        <img src="Image/Small/add.png" />เพิ่มข้อมูลบุคลากร</a></span>
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
                                <th>ประเภทบุครากร</th>
                                <th>คณะ/หน่วยงาน</th>
                                <th>ดูข้อมูล</th>
                                <th>แก้ไขข้อมูล</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="myRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# DataBinder.Eval(Container.DataItem, "UOC_ID") %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "NAME") %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "STAFF_NAME") %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "FAC_NAME") %></td>
                                    <td><a href="previewuser-admin.aspx?id=<%#Personnel.MyCrypto.GetEncryptedQueryString(DataBinder.Eval(Container.DataItem, "UOC_ID").ToString()) %>">
                                        <img src="Image/Small/next.png" class="icon_left" />ดู</a></td>
                                    <td><a href="edituser-admin.aspx?id=<%#Personnel.MyCrypto.GetEncryptedQueryString(DataBinder.Eval(Container.DataItem, "UOC_ID").ToString()) %>">
                                        <img src="Image/Small/next.png" class="icon_left" />แก้ไข</a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>