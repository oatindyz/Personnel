<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="managerole-admin.aspx.cs" Inherits="Personnel.managerole_admin" %>

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
        <img src="Image/book_edit.png" />จัดการสิทธิใช้งานระบบ
    </div>
    <div id="notification" runat="server"></div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL_RMUTTO %>" ProviderName="<%$ ConnectionStrings:ORCL_RMUTTO.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_PERSON_ROLE&quot;"></asp:SqlDataSource>
    <div id="Dp1" runat="server" class="panel panel-default">
        <div class="panel-body">
            <div class="panel-body">
                <div id="divLoad" runat="server" class="dataTable_wrapper">
                    <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                        <thead>
                            <tr>
                                <th>ลำดับที่</th>
                                <th>ชื่อ-สกุล</th>
                                <th>คณะ/หน่วยงาน</th>
                                <th>สิทธิการใช้งานระบบ</th>
                                <th>
                                    <img src="Image/Small/save.png" class="icon_left" />แก้ไข</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="myRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><asp:Label ID="lbID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UOC_ID") %>'></asp:Label></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "NAME") %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "FAC_NAME") %></td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control input-sm select2" DataSourceID="SqlDataSource1" DataValueField="PERSON_ROLE_ID" DataTextField="PERSON_ROLE_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "PERSON_ROLE_ID") %>' ></asp:DropDownList></td>
                                    <td style="text-align:center;"><asp:Button ID="btn1" runat="server" CssClass="btn btn-primary" Text="บันทึก" OnClick="btn1_Click"/></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</asp:Content>
