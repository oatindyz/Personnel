<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="edituser-admin.aspx.cs" Inherits="Personnel.edituser_admin" %>

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
            $('#Table1').DataTable({
                responsive: true
            });
        });
    </script>
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
        <img src="Image/Small/edit.png" />แก้ไขข้อมูลบุคลากร
    </div>
    <div id="notification" runat="server"></div>

    <div class="col-lg-12">
        <div class="panel panel-default">
            <div id="divTitle" runat="server" class="panel-heading">บุคลากรภายในมหาวิทยาลัย</div>
            <div class="panel-body">
                <div id="divLoad" runat="server" class="dataTable_wrapper">
                    <asp:HiddenField ID="hfuocID" runat="server" />
                    <table class="table table-striped table-bordered table-hover" id="dataTables-example"/>
                    <asp:Table ID="Table1" runat="server" CssClass="table table-striped table-bordered table-hover" Style="display: inline-block;"></asp:Table>
                </div>

            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View0" runat="server">
                <div style="text-align: center;">
                    <div style="margin-bottom: 20px"></div>
                    <div style="display: inline-block; margin-right: 10px; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">รหัสประจำตัวประชาชน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbCitizenID" runat="server" CssClass="ps-textbox" MaxLength="13"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">มหาวิทยาลัย</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlUniv" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlUniv_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">คำนำหน้าชื่อ(ยึดตามบัตรประชาชน)</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPrefixName" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbName" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">นามสกุล</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbLastName" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เพศ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันเกิด</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbBirthday" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">บ้านเลขที่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbHomeAdd" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">หมู่</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbMoo" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ถนน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbStreet" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">จังหวัด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">อำเภอ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ps-dropdown" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำบล</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlSubDistrict" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">หมายเลขโทรศัพท์ที่ทำงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbTelephone" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">รหัสไปรษณีย์</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbZipcode" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สัญชาติ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlNation" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                        </table>
                        <div style="text-align: center; margin-top: 10px;">
                            <a href="edituser-admin.aspx" class="ps-button"><img src="Image/Small/back.png" class="icon_left" />ย้อนกลับ</a>
                            <asp:LinkButton ID="lbuNextToView1" runat="server" CssClass="ps-button" OnClick="lbuNextToView1_Click"><img src="Image/Small/next.png" class="icon_left"/>ถัดไป</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View1" runat="server">
                <div style="text-align: center;">
                    <div style="margin-bottom: 20px"></div>
                    <div style="display: inline-block; margin-right: 10px; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">ประเภทบุคลากร</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlStafftype" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ระยะเวลาจ้าง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTimeContact" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภทเงินจ้าง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlBudget" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภทตำแหน่ง</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlSubStafftype" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งบริหาร</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlAdminPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งทางวิชาการ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlPosition" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ตำแหน่งในสายงาน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPositionWork" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">คณะ/หน่วยงานที่สังกัด หรือเทียบเท่า</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันที่เข้าทำงานครั้งแรก</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbDateInwork" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbDateStartThisU" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สาขางานที่เชี่ยวชาญ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSpecialName" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">กลุ่มสาขาวิชาที่สอน(ISCED)</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlTeachISCED" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ระดับการศึกษาที่จบสูงสุด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlGradLev" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">หลักสูตรที่จบการศึกษาสูงสุด</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbGradCURR" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">กลุ่มสาขาวิชาที่จบสูงสุด(ISCED)</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlGradISCED" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">สาขาวิชาที่จบสูงสุด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlGradProg" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ชื่อสถาบันที่จบการศึกษาสูงสุด</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbGradUniv" runat="server" CssClass="ps-textbox"></asp:TextBox><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเทศที่จบการศึกษาสูงสุด</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlGradCountry" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                        </table>
                        <div style="text-align: center; margin-top: 10px;">
                            <asp:LinkButton ID="lbuBackToView0" runat="server" CssClass="ps-button" OnClick="lbuBackToView0_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                            <asp:LinkButton ID="lbuNextToView2" runat="server" CssClass="ps-button" OnClick="lbuNextToView2_Click"><img src="Image/Small/next.png" class="icon_left"/>ถัดไป</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div style="text-align: center;">
                    <div style="margin-bottom: 20px"></div>
                    <div style="display: inline-block; margin-right: 10px; vertical-align: top;">
                        <table class="ps-table-1">
                            <tr>
                                <td class="col1">ความพิการ</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlDeform" runat="server" CssClass="ps-dropdown"></asp:DropDownList><span class="textred">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เลขที่ตำแหน่ง</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSitNo" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เงินเดือนปัจจุบัน</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbSalary" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เงินประจำตำแหน่งที่ได้รับ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPositionSalary" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ศาสนา</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlReligion" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ประเภทการดำรงตำแหน่งปัจจุบัน</td>
                                <td class="col2">
                                    <asp:DropDownList ID="ddlMovementType" runat="server" CssClass="ps-dropdown"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">วันที่มีผลบังคับใช้ตามข้อมูล"การเข้าสู่ตำแหน่งปัจจุบัน"</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbMovementDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">เครื่องราชอิสริยาภรณ์สูงสุดที่ได้รับ</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbDecoration" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่1</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbResult1" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่1</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPercentSalary1" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่2</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbResult2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่2</td>
                                <td class="col2">
                                    <asp:TextBox ID="tbPercentSalary2" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <div style="text-align: center; margin-top: 10px;">
                        <asp:LinkButton ID="lbuBackToView1" runat="server" CssClass="ps-button" OnClick="lbuBackToView1_Click"><img src="Image/Small/back.png" class="icon_left"/>ย้อนกลับ</asp:LinkButton>
                        <asp:LinkButton ID="lbuAddPerson" runat="server" CssClass="ps-button" OnClick="lbuAddPerson_Click"><img src="Image/Small/save.png" class="icon_left"/>เพิ่มข้อมูลบุคลากร</asp:LinkButton>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div>
                    <div class="ps-div-title-red">ทำการเพิ่มข้อมูลบุคลากรสำเร็จ</div>
                    <div style="color: #808080; margin-top: 10px; text-align: center;">
                        ระบบจะมีการส่งแจ้งเตือนรหัสผ่านสำหรับบุคลากรใหม่ โดยสามารถเข้าไปตรวจสอบได้ที่อีเมลของตัวเอง เพื่อไว้สำหรับเข้าสู่ระบบในเว็บไซต์นี้
                    </div>
                    <div style="text-align: center; margin-top: 10px;">
                        <a href="Default.aspx" class="ps-button">
                            <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>

            </div>
        </div>
    </div>

</asp:Content>
