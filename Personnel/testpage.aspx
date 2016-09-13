<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="Personnel.testpage" %>
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
        <img src="Image/Small/edit.png" />แก้ไขข้อมูลบุคลากร</div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">บุคลากรภายในมหาวิทยาลัย</div>
                <div class="panel-body">
                    <div class="dataTable_wrapper">
                        <asp:Repeater ID="myRepeater" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>
                                            <th>ลำดับที่</th>
                                            <th>ชื่อ-สกุล</th>
                                            <th>ประเภทบุครากร</th>
                                            <th>คณะ/หน่วยงาน</th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td style="text-align: left"><%# DataBinder.Eval(Container.DataItem, "UOC_ID") %></td>
                                        <td style="text-align: left"><%# DataBinder.Eval(Container.DataItem, "NAME") %></td>
                                        <td style="text-align: left"><%# DataBinder.Eval(Container.DataItem, "STAFF_NAME") %></td>
                                        <td style="text-align: left"><%# DataBinder.Eval(Container.DataItem, "FAC_NAME") %></td>
                                    </tr>
                                </tbody>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
