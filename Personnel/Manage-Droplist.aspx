<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage-Droplist.aspx.cs" Inherits="Personnel.Manage_Droplist" MaintainScrollPositionOnPostback="true" %>

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
            $('#dataTables-Univ,#dataTables-Title,#dataTables-Gender,#dataTables-Province,#dataTables-Amphur,#dataTables-Tambon,#dataTables-Nation,#dataTables-Stafftype,#dataTables-TimeContact,#dataTables-Budget,#dataTables-SubStafftype,#dataTables-AdminPosition,#dataTables-Position,#dataTables-Department,#dataTables-TeachISCED,#dataTables-GradLev,#dataTables-GradProg,#dataTables-Deform,#dataTables-Religion,#dataTables-MovementType').DataTable({
                responsive: true
            });
        });
        $(document).ready(function () {
            $('#dataTables-GradProg').DataTable({
                responsive: true
            });
        });
    </script>
    <style>
        body {
            font-family: "Lato", sans-serif;
            transition: background-color .5s;
        }

        .sidenav {
            height: 100%;
            width: 0;
            position: fixed;
            z-index: 1;
            top: 0;
            left: 0;
            background-color: #111;
            overflow-x: hidden;
            transition: 0.5s;
            padding-top: 60px;
        }

        .sidenav a {
            padding: 8px 8px 8px 32px;
            text-decoration: none;
            font-size: 16px;
            color: #818181;
            display: block;
            transition: 0.3s
        }

        .sidenav a:hover, .offcanvas a:focus{
            color: #f1f1f1;
        }

        .sidenav .closebtn {
            position: absolute;
            top: 0;
            right: 25px;
            font-size: 36px;
            margin-left: 50px;
        }

        #main {
            transition: margin-left .5s;
            padding: 16px;
        }

        @media screen and (max-height: 450px) {
          .sidenav {padding-top: 15px;}
          .sidenav a {font-size: 18px;}
        }
    </style>
    <script>
        function openNav() {
            document.getElementById("mySidenav").style.width = "235px";
        }

        function closeNav() {
            document.getElementById("mySidenav").style.width = "0";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mySidenav" class="sidenav">
        <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
        <a>
            <asp:LinkButton ID="lbuMenuUniv" runat="server" OnClick="lbuMenuUniv_Click"><img src="Image/Small/wrench.png" class="icon_left"/> มหาวิทยาลัย</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuTitle" runat="server" OnClick="lbuMenuTitle_Click"><img src="Image/Small/wrench.png" class="icon_left"/> คำนำหน้าชื่อ</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuGender" runat="server" OnClick="lbuMenuGender_Click"><img src="Image/Small/wrench.png" class="icon_left"/> เพศ</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuProvince" runat="server" OnClick="lbuMenuProvince_Click"><img src="Image/Small/wrench.png" class="icon_left"/> จังหวัด</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuAmphur" runat="server" OnClick="lbuMenuAmphur_Click"><img src="Image/Small/wrench.png" class="icon_left"/> อำเภอ</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuTambon" runat="server" OnClick="lbuMenuTambon_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ตำบล</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuNation" runat="server" OnClick="lbuMenuNation_Click"><img src="Image/Small/wrench.png" class="icon_left"/> สัญชาติ</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuStafftype" runat="server" OnClick="lbuMenuStafftype_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ประเภทบุคลากร</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuTimeContact" runat="server" OnClick="lbuMenuTimeContact_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ระยะเวลาจ้าง</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuBudget" runat="server" OnClick="lbuMenuBudget_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ประเภทเงินจ้าง</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuSubStafftype" runat="server" OnClick="lbuMenuSubStafftype_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ประเภทบุคลากรย่อย</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuAdminPosition" runat="server" OnClick="lbuMenuAdminPosition_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ตำแหน่งบริหาร</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuPosition" runat="server" OnClick="lbuMenuPosition_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ระดับตำแหน่ง</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuDepartment" runat="server" OnClick="lbuMenuDepartment_Click"><img src="Image/Small/wrench.png" class="icon_left"/> คณะ/หน่วยงานที่สังกัด</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuTeachISCED" runat="server" OnClick="lbuMenuTeachISCED_Click"><img src="Image/Small/wrench.png" class="icon_left"/> กลุ่มสาขาวิชา</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuGradLev" runat="server" OnClick="lbuMenuGradLev_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ระดับการศึกษา</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuGradProg" runat="server" OnClick="lbuMenuGradProg_Click"><img src="Image/Small/wrench.png" class="icon_left"/> สาขาวิชา</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuDeform" runat="server" OnClick="lbuMenuDeform_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ความพิการ</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuReligion" runat="server" OnClick="lbuMenuReligion_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ศาสนา</asp:LinkButton></a>
        <a>
            <asp:LinkButton ID="lbuMenuMovementType" runat="server" OnClick="lbuMenuMovementType_Click"><img src="Image/Small/wrench.png" class="icon_left"/> ประเภทการดำรงตำแหน่งปัจจุบัน</asp:LinkButton></a>
    </div>
    <div id="divShowMenu" runat="server" class="ps-header">
    <img src="Image/Small/wrench.png" /><asp:Label ID="Label20" runat="server" Text="&#9776; เลือกเมนู" onclick="openNav()" style="font-size: 20px; cursor: pointer"></asp:Label></div>
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ORCL %>" ProviderName="<%$ ConnectionStrings:ORCL.ProviderName %>" SelectCommand="SELECT * FROM &quot;TB_STATUS_ACTIVE&quot;"></asp:SqlDataSource>

        <asp:Panel ID="Panel1" runat="server" CssClass="divpan">
            <div id="divheader1" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="lbMenuHeader" runat="server" Text="มหาวิทยาลัย"></asp:Label></div>
            <div id="divInsertUniv" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสมหาวิทยาลัย<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdUniv" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อมหาวิทยาลัย<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameUniv" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusUniv" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertUniv" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertUniv_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateUniv" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateUniv_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearUniv" runat="server" CssClass="btn btn-success" OnClick="lbuClearUniv_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadUniv" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Univ">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสมหาวิทยาลัย</th>
                            <th>ชื่อมหาวิทยาลัย</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterUniv" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbUnivID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UNIV_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbUnivName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UNIV_NAME_TH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbUnivStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlUnivStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditUniv" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditUniv" />
                                    <asp:LinkButton ID="lnkDeleteUniv" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteUniv" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" CssClass="divpan">
            <div id="divheader2" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label1" runat="server" Text="คำนำหน้าชื่อ"></asp:Label></div>
            <div id="divInsertTitle" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสคำนำหน้าชื่อ<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdTitle" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อคำนำหน้า<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameTitle" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusTitle" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertTitle" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertTitle_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateTitle" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateTitle_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearTitle" runat="server" CssClass="btn btn-success" OnClick="lbuClearTitle_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadTitle" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Title">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสคำนำหน้าชื่อ</th>
                            <th>ชื่อคำนำหน้า</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterTitle" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbTitleID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PREFIX_NAME_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbTitleName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbTitleStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlTitleStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditTitle" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditTitle" />
                                    <asp:LinkButton ID="lnkDeleteTitle" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteTitle" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" CssClass="divpan">
            <div id="divheader3" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label2" runat="server" Text="เพศ"></asp:Label></div>
            <div id="divInsertGender" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสเพศ<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdGender" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อเพศ<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameGender" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusGender" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertGender" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertGender_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateGender" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateGender_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearGender" runat="server" CssClass="btn btn-success" OnClick="lbuClearGender_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadGender" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Gender">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสเพศ</th>
                            <th>ชื่อเพศ</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterGender" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbGenderID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GENDER_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbGenderName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GENDER_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbGenderStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlGenderStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditGender" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditGender" />
                                    <asp:LinkButton ID="lnkDeleteGender" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteGender" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel4" runat="server" CssClass="divpan">
            <div id="divheader4" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label3" runat="server" Text="จังหวัด"></asp:Label></div>
            <div id="divInsertProvince" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสจังหวัด<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdProvince" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อจังหวัด<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameProvince" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusProvince" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertProvince" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertProvince_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateProvince" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateProvince_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearProvince" runat="server" CssClass="btn btn-success" OnClick="lbuClearProvince_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadProvince" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Province">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสจังหวัด</th>
                            <th>ชื่อจังหวัด</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterProvince" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbProvinceID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROVINCE_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbProvinceName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROVINCE_NAME_TH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbProvinceStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlProvinceStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditProvince" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditProvince" />
                                    <asp:LinkButton ID="lnkDeleteProvince" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteProvince" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel5" runat="server" CssClass="divpan">
            <div id="divheader5" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label4" runat="server" Text="เขต/อำเภอ"></asp:Label></div>
            <div id="divInsertAmphur" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสเขต/อำเภอ<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdAmphur" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อเขต/อำเภอ<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameAmphur" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusAmphur" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertAmphur" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertAmphur_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateAmphur" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateAmphur_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearAmphur" runat="server" CssClass="btn btn-success" OnClick="lbuClearAmphur_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadAmphur" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Amphur">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสเขต/อำเภอ</th>
                            <th>ชื่อเขต/อำเภอ</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterAmphur" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbAmphurID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DISTRICT_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbAmphurName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DISTRICT_NAME_TH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbAmphurStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlAmphurStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditAmphur" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditAmphur" />
                                    <asp:LinkButton ID="lnkDeleteAmphur" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteAmphur" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel6" runat="server" CssClass="divpan">
            <div id="divheader6" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label5" runat="server" Text="แขวง/ตำบล"></asp:Label></div>
            <div id="divInsertTambon" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสแขวง/ตำบล<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdTambon" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อแขวง/ตำบล<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameTambon" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusTambon" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertTambon" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertTambon_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateTambon" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateTambon_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearTambon" runat="server" CssClass="btn btn-success" OnClick="lbuClearTambon_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadTambon" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Tambon">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสแขวง/ตำบล</th>
                            <th>ชื่อแขวง/ตำบล</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterTambon" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbTambonID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUB_DISTRICT_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbTambonName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUB_DISTRICT_NAME_TH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbTambonStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlTambonStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditTambon" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditTambon" />
                                    <asp:LinkButton ID="lnkDeleteTambon" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteTambon" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel7" runat="server" CssClass="divpan">
            <div id="divheader7" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label6" runat="server" Text="สัญชาติ/ประเทศ"></asp:Label></div>
            <div id="divInsertNation" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสสัญชาติ/ประเทศ<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdNation" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อสัญชาติ/ประเทศ<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameNation" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusNation" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertNation" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertNation_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateNation" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateNation_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearNation" runat="server" CssClass="btn btn-success" OnClick="lbuClearNation_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadNation" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Nation">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสสัญชาติ/ประเทศ</th>
                            <th>ชื่อสัญชาติ/ประเทศ</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterNation" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbNationID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NATION_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbNationName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NATION_NAME_ENG") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbNationStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlNationStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditNation" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditNation" />
                                    <asp:LinkButton ID="lnkDeleteNation" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteNation" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel8" runat="server" CssClass="divpan">
            <div id="divheader8" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label7" runat="server" Text="ประเภทบุคลากร"></asp:Label></div>
            <div id="divInsertStafftype" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสประเภทบุคลากร<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdStafftype" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อประเภทบุคลากร<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameStafftype" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusStafftype" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertStafftype" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertStafftype_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateStafftype" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateStafftype_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearStafftype" runat="server" CssClass="btn btn-success" OnClick="lbuClearStafftype_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadStafftype" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Stafftype">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสประเภทบุคลากร</th>
                            <th>ชื่อประเภทบุคลากร</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterStafftype" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbStafftypeID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STAFFTYPE_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbStafftypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STAFFTYPE_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbStafftypeStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlStafftypeStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditStafftype" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditStafftype" />
                                    <asp:LinkButton ID="lnkDeleteStafftype" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteStafftype" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>
        
        <asp:Panel ID="Panel9" runat="server" CssClass="divpan">
            <div id="divheader9" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label8" runat="server" Text="ระยะเวลาจ้าง"></asp:Label></div>
            <div id="divInsertTimeContact" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสระยะเวลาจ้าง<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdTimeContact" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อระยะเวลาจ้าง<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameTimeContact" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusTimeContact" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertTimeContact" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertTimeContact_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateTimeContact" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateTimeContact_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearTimeContact" runat="server" CssClass="btn btn-success" OnClick="lbuClearTimeContact_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadTimeContact" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-TimeContact">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสระยะเวลาจ้าง</th>
                            <th>ชื่อระยะเวลาจ้าง</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterTimeContact" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbTimeContactID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TIME_CONTACT_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbTimeContactName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TIME_CONTACT_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbTimeContactStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlTimeContactStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditTimeContact" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditTimeContact" />
                                    <asp:LinkButton ID="lnkDeleteTimeContact" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteTimeContact" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel10" runat="server" CssClass="divpan">
            <div id="divheader10" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label9" runat="server" Text="ประเภทเงินจ้าง"></asp:Label></div>
            <div id="divInsertBudget" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสประเภทเงินจ้าง<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdBudget" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อประเภทเงินจ้าง<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameBudget" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusBudget" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertBudget" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertBudget_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateBudget" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateBudget_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearBudget" runat="server" CssClass="btn btn-success" OnClick="lbuClearBudget_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadBudget" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Budget">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสประเภทเงินจ้าง</th>
                            <th>ชื่อประเภทเงินจ้าง</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterBudget" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbBudgetID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BUDGET_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbBudgetName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BUDGET_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbBudgetStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlBudgetStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditBudget" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditBudget" />
                                    <asp:LinkButton ID="lnkDeleteBudget" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteBudget" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel11" runat="server" CssClass="divpan">
            <div id="divheader11" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label10" runat="server" Text="ประเภทบุคลากรย่อย"></asp:Label></div>
            <div id="divInsertSubStafftype" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสประเภทบุคลากรย่อย<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdSubStafftype" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อประเภทบุคลากรย่อย<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameSubStafftype" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusSubStafftype" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertSubStafftype" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertSubStafftype_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateSubStafftype" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateSubStafftype_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearSubStafftype" runat="server" CssClass="btn btn-success" OnClick="lbuClearSubStafftype_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadSubStafftype" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-SubStafftype">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสประเภทบุคลากรย่อย</th>
                            <th>ชื่อประเภทบุคลากรย่อย</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterSubStafftype" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbSubStafftypeID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUBSTAFFTYPE_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbSubStafftypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUBSTAFFTYPE_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbSubStafftypeStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlSubStafftypeStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditSubStafftype" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditSubStafftype" />
                                    <asp:LinkButton ID="lnkDeleteSubStafftype" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteSubStafftype" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel12" runat="server" CssClass="divpan">
            <div id="divheader12" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label11" runat="server" Text="ตำแหน่งบริหาร"></asp:Label></div>
            <div id="divInsertAdminPosition" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสตำแหน่งบริหาร<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdAdminPosition" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อตำแหน่งบริหาร<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameAdminPosition" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusAdminPosition" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertAdminPosition" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertAdminPosition_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateAdminPosition" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateAdminPosition_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearAdminPosition" runat="server" CssClass="btn btn-success" OnClick="lbuClearAdminPosition_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadAdminPosition" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-AdminPosition">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสตำแหน่งบริหาร</th>
                            <th>ชื่อตำแหน่งบริหาร</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterAdminPosition" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbAdminPositionID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ADMIN_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbAdminPositionName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ADMIN_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbAdminPositionStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlAdminPositionStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditAdminPosition" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditAdminPosition" />
                                    <asp:LinkButton ID="lnkDeleteAdminPosition" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteAdminPosition" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel13" runat="server" CssClass="divpan">
            <div id="divheader13" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label12" runat="server" Text="ระดับตำแหน่ง"></asp:Label></div>
            <div id="divInsertPosition" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสระดับตำแหน่ง<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdPosition" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อระดับตำแหน่ง<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNamePosition" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusPosition" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertPosition" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertPosition_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdatePosition" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdatePosition_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearPosition" runat="server" CssClass="btn btn-success" OnClick="lbuClearPosition_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadPosition" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Position">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสระดับตำแหน่ง</th>
                            <th>ชื่อระดับตำแหน่ง</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterPosition" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbPositionID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POSITION_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbPositionName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POSITION_NAME_TH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbPositionStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlPositionStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditPosition" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditPosition" />
                                    <asp:LinkButton ID="lnkDeletePosition" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeletePosition" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel14" runat="server" CssClass="divpan">
            <div id="divheader14" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label13" runat="server" Text="คณะ/หน่วยงานที่สังกัด"></asp:Label></div>
            <div id="divInsertDepartment" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสคณะ/หน่วยงานที่สังกัด<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdDepartment" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อคณะ/หน่วยงานที่สังกัด<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameDepartment" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusDepartment" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertDepartment" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertDepartment_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateDepartment" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateDepartment_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearDepartment" runat="server" CssClass="btn btn-success" OnClick="lbuClearDepartment_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadDepartment" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Department">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสคณะ/หน่วยงานที่สังกัด</th>
                            <th>ชื่อคณะ/หน่วยงานที่สังกัด</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterDepartment" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbDepartmentID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FAC_ID") %>'></asp:Label>
                                </td>
                                <td style="width:550px">
                                    <asp:Label ID="lbDepartmentName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FAC_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbDepartmentStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlDepartmentStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditDepartment" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditDepartment" />
                                    <asp:LinkButton ID="lnkDeleteDepartment" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteDepartment" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel15" runat="server" CssClass="divpan">
            <div id="divheader15" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label14" runat="server" Text="กลุ่มสาขาวิชา"></asp:Label></div>
            <div id="divInsertTeachISCED" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสกลุ่มสาขาวิชา<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdTeachISCED" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อกลุ่มสาขาวิชา<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameTeachISCED" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusTeachISCED" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertTeachISCED" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertTeachISCED_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateTeachISCED" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateTeachISCED_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearTeachISCED" runat="server" CssClass="btn btn-success" OnClick="lbuClearTeachISCED_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadTeachISCED" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-TeachISCED">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสกลุ่มสาขาวิชา</th>
                            <th>ชื่อกลุ่มสาขาวิชา</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterTeachISCED" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbTeachISCEDID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ISCED_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbTeachISCEDName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ISCED_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbTeachISCEDStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlTeachISCEDStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditTeachISCED" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditTeachISCED" />
                                    <asp:LinkButton ID="lnkDeleteTeachISCED" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteTeachISCED" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel16" runat="server" CssClass="divpan">
            <div id="divheader16" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label15" runat="server" Text="ระดับการศึกษา"></asp:Label></div>
            <div id="divInsertGradLev" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสระดับการศึกษา<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdGradLev" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อระดับการศึกษา<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameGradLev" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusGradLev" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertGradLev" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertGradLev_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateGradLev" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateGradLev_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearGradLev" runat="server" CssClass="btn btn-success" OnClick="lbuClearGradLev_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadGradLev" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-GradLev">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสระดับการศึกษา</th>
                            <th>ชื่อระดับการศึกษา</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterGradLev" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbGradLevID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LEV_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbGradLevName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LEV_NAME_TH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbGradLevStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlGradLevStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditGradLev" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditGradLev" />
                                    <asp:LinkButton ID="lnkDeleteGradLev" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteGradLev" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel17" runat="server" CssClass="divpan">
            <div id="divheader17" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label16" runat="server" Text="สาขาวิชา"></asp:Label></div>
            <div id="divInsertGradProg" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสสาขาวิชา<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdGradProg" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อสาขาวิชา<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameGradProg" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusGradProg" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertGradProg" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertGradProg_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateGradProg" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateGradProg_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearGradProg" runat="server" CssClass="btn btn-success" OnClick="lbuClearGradProg_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadGradProg" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-GradProg">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสสาขาวิชา</th>
                            <th>ชื่อสาขาวิชา</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterGradProg" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbGradProgID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROGRAM_ID_NEW") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbGradProgName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROGRAM_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbGradProgStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlGradProgStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditGradProg" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditGradProg" />
                                    <asp:LinkButton ID="lnkDeleteGradProg" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteGradProg" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel18" runat="server" CssClass="divpan">
            <div id="divheader18" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label17" runat="server" Text="ความพิการ"></asp:Label></div>
            <div id="divInsertDeform" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสความพิการ<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdDeform" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อความพิการ<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameDeform" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusDeform" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertDeform" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertDeform_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateDeform" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateDeform_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearDeform" runat="server" CssClass="btn btn-success" OnClick="lbuClearDeform_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadDeform" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Deform">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสความพิการ</th>
                            <th>ชื่อความพิการ</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterDeform" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbDeformID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DEFORM_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbDeformName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DEFORM_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbDeformStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlDeformStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditDeform" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditDeform" />
                                    <asp:LinkButton ID="lnkDeleteDeform" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteDeform" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel19" runat="server" CssClass="divpan">
            <div id="divheader19" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label18" runat="server" Text="ศาสนา"></asp:Label></div>
            <div id="divInsertReligion" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสศาสนา<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdReligion" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อศาสนา<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameReligion" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusReligion" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertReligion" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertReligion_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateReligion" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateReligion_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearReligion" runat="server" CssClass="btn btn-success" OnClick="lbuClearReligion_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadReligion" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-Religion">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสศาสนา</th>
                            <th>ชื่อศาสนา</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterReligion" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbReligionID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RELIGION_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbReligionName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RELIGION_NAME_TH") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbReligionStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlReligionStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditReligion" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditReligion" />
                                    <asp:LinkButton ID="lnkDeleteReligion" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteReligion" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel20" runat="server" CssClass="divpan">
            <div id="divheader20" runat="server" class="ps-header" visible="false">
                <img src="Image/Small/wrench.png" /><asp:Label ID="Label19" runat="server" Text="ประเภทการดำรงตำแหน่งปัจจุบัน"></asp:Label></div>
            <div id="divInsertMovementType" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/Add.png" />เพิ่มข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover">
                    <tr>
                        <td>รหัสประเภทการดำรงตำแหน่งปัจจุบัน<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertIdMovementType" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>ชื่อประเภทการดำรงตำแหน่งปัจจุบัน<span class="ps-lb-red" />*<br />
                            <asp:TextBox ID="tbInsertNameMovementType" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"/>
                        </td>
                        <td>สถานะการใช้งาน<span class="ps-lb-red" />*<br />
                            <asp:DropDownList ID="ddlInsertStatusMovementType" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"/>
                        </td>
                        <td>จัดการข้อมูล:<br />
                            <asp:Button ID="btnInsertMovementType" runat="server" CssClass="btn btn-primary ekknidRight" OnClick="btnInsertMovementType_Click" Text="เพิ่มข้อมูล" />
                            <asp:Button ID="btnUpdateMovementType" runat="server" CssClass="btn btn-info ekknidRight" OnClick="btnUpdateMovementType_Click" Text="อัพเดทข้อมูล" />
                            <asp:LinkButton ID="lbuClearMovementType" runat="server" CssClass="btn btn-success" OnClick="lbuClearMovementType_Click" Text="ล้างข้อมูล" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divLoadMovementType" runat="server" class="dataTable_wrapper" visible="false">
                <div class="ps-header">
                    <img src="Image/Small/list.png" />ข้อมูล
                </div>
                <table class="table table-striped table-bordered table-hover" id="dataTables-MovementType">
                    <thead>
                        <tr>
                            <th>ลำดับที่</th>
                            <th>รหัสประเภทการดำรงตำแหน่งปัจจุบัน</th>
                            <th>ชื่อประเภทการดำรงตำแหน่งปัจจุบัน</th>
                            <th>สถานะการใช้งาน</th>
                            <th>จัดการข้อมูล</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="myRepeaterMovementType" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex +1 %></td>
                                <td>
                                    <asp:Label ID="lbMovementTypeID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MOVEMENT_TYPE_ID") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbMovementTypeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MOVEMENT_TYPE_NAME") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbMovementTypeStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS_NAME") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlMovementTypeStatus" runat="server" CssClass="form-control input-sm select2" Width="100%" DataSourceID="SqlDataSource1" DataValueField="STATUS_ID" DataTextField="STATUS_NAME" SelectedValue='<%# DataBinder.Eval(Container.DataItem, "STATUS_ID") %>' Visible="false"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEditMovementType" Text="แก้ไข" runat="server" CssClass="btn btn-warning" OnClick="OnEditMovementType" />
                                    <asp:LinkButton ID="lnkDeleteMovementType" Text="ลบ" runat="server" CssClass="btn btn-danger" OnClick="OnDeleteMovementType" OnClientClick="return confirm('คุณต้องการที่จะลบใช่หรือไม่?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </asp:Panel>

    </div>
</asp:Content>
