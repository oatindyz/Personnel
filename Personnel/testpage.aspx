<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="Personnel.testpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-header">
        <img src="Image/Small/edit.png" />แก้ไขข้อมูลบุคลากร
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">บุคลากรภายในมหาวิทยาลัย</div>
                <div class="panel-body">
                    <div class="dataTable_wrapper">
                        <asp:HiddenField ID="hfuocID" runat="server" />
                        <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>ลำดับที่</th>
                                    <th>ชื่อ-สกุล</th>
                                    <th>ประเภทบุครากร</th>
                                    <th>คณะ/หน่วยงาน</th>
                                    <th>แก้ไข</th>
                                </tr>
                            </thead>
                            <asp:Repeater ID="myRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td style="text-align: left"><%# DataBinder.Eval(Container.DataItem, "UOC_ID") %></td>
                                        <td style="text-align: left"><%# DataBinder.Eval(Container.DataItem, "NAME") %></td>
                                        <td style="text-align: left"><%# DataBinder.Eval(Container.DataItem, "STAFF_NAME") %></td>
                                        <td style="text-align: left"><%# DataBinder.Eval(Container.DataItem, "FAC_NAME") %></td>
                                        <td><button id="btn1" runat="server" onserverclick="doIt">edit</button></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>

                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="View0" runat="server">
                                <table class="ps-table-1">
                                    <tr>
                                        <td class="col1">รหัสประจำตัวประชาชน</td>
                                        <td class="col2">
                                            <asp:TextBox ID="tbCitizenID" runat="server" CssClass="ps-textbox" MaxLength="13"></asp:TextBox><span class="textred">*</span>
                                        </td>
                                    </tr>
                                </table>

                            </asp:View>
                        </asp:MultiView>


                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>