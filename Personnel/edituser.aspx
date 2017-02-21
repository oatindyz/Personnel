<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="edituser.aspx.cs" Inherits="Personnel.edituser" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            //Initialize Select2 Elements
            $(".select2").select2();

            //Datemask dd/mm/yyyy
            $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            //Datemask2 mm/dd/yyyy
            $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
            //Money Euro
            $("[data-mask]").inputmask();

            //Date range picker
            $('#reservation').daterangepicker();
            //Date range picker with time picker
            $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' });
            //Date range as a button
            $('#daterange-btn').daterangepicker(
                {
                    ranges: {
                        'Today': [moment(), moment()],
                        'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                        'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                        'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                        'This Month': [moment().startOf('month'), moment().endOf('month')],
                        'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                    },
                    startDate: moment().subtract(29, 'days'),
                    endDate: moment()
                },
            function (start, end) {
                $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            }
            );

            //iCheck for checkbox and radio inputs
            $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                checkboxClass: 'icheckbox_minimal-blue',
                radioClass: 'iradio_minimal-blue'
            });
            //Red color scheme for iCheck
            $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
                checkboxClass: 'icheckbox_minimal-red',
                radioClass: 'iradio_minimal-red'
            });
            //Flat red color scheme for iCheck
            $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });

            //Colorpicker
            $(".my-colorpicker1").colorpicker();
            //color picker with addon
            $(".my-colorpicker2").colorpicker();

            //Timepicker
            $(".timepicker").timepicker({
                showInputs: false
            });
        });
    </script>

    <script type = "text/javascript">
    function DisableButton() {
        document.getElementById("<%=btnUpdatePerson.ClientID %>").disabled = true;
    }
    window.onbeforeunload = DisableButton;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="ps-header">
            <img src="Image/Small/edit.png" />แก้ไขข้อมูลบุคลากร
            <span style="text-align:right; float:right;"><a href="default.aspx">
            <img src="Image/Small/back.png" />ย้อนกลับ</a></span>
        </div>
        <div id="notification" runat="server"></div>

        <div class="panel panel-default">
            <div class="panel-body">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View0" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 400px;">รหัสประจำตัวประชาชน
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lbCitizenID" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">มหาวิทยาลัย
                                         <asp:CheckBox ID="cbUniv" runat="server" AutoPostBack="true" OnCheckedChanged="cbUniv_CheckedChanged" />
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lbUniv" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlUniv" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Visible="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">คำนำหน้าชื่อ(ยึดตามบัตรประชาชน)
                                        <asp:CheckBox ID="cbPrefixName" runat="server" AutoPostBack="true" OnCheckedChanged="cbPrefixName_CheckedChanged" />
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lbPrefixName" runat="server"></asp:Label>
                                        <asp:DropDownList ID="ddlPrefixName" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1" Visible="false"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อ
                                        <asp:CheckBox ID="cbName" runat="server" AutoPostBack="true" OnCheckedChanged="cbName_CheckedChanged" />
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lbName" runat="server"></asp:Label>
                                        <asp:TextBox ID="tbName" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">นามสกุล
                                        <asp:CheckBox ID="cbLastName" runat="server" AutoPostBack="true" OnCheckedChanged="cbLastName_CheckedChanged" />
                                    </td>
                                    <td class="col2">
                                        <asp:Label ID="lbLastName" runat="server"></asp:Label>
                                        <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เพศ</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGender" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันเกิด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbBirthday" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">บ้านเลขที่<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbHomeAdd" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">หมู่</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbMoo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ถนน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbStreet" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">จังหวัด<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control input-sm select2" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" AutoPostBack="true" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เขต/อำเภอ<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-sm select2" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">แขวง/ตำบล<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlSubDistrict" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">หมายเลขโทรศัพท์ที่ทำงาน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbTelephone" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">รหัสไปรษณีย์<span id="spZip" runat="server"/></td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbZipcode" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สัญชาติ<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlNation" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="View1" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 400px;">ประเภทบุคลากร</td>
                                    <td class="col2">
                                        <asp:Label ID="lbStaffType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระยะเวลาจ้าง</td>
                                    <td class="col2">
                                        <asp:Label ID="lbTimeContact" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทเงินจ้าง</td>
                                    <td class="col2">
                                        <asp:Label ID="lbBudget" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทบุคลากรย่อย</td>
                                    <td class="col2">
                                        <asp:Label ID="lbSubStafftype" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งบริหาร</td>
                                    <td class="col2">
                                        <asp:Label ID="lbAdminPosition" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPosition" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งในสายงาน</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPositionWork" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">คณะ/หน่วยงานที่สังกัด หรือเทียบเท่า</td>
                                    <td class="col2">
                                        <asp:Label ID="lbDepartment" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่เข้าทำงานครั้งแรก</td>
                                    <td class="col2">
                                        <asp:Label ID="lbDateInwork" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:Label ID="lbDateStartThisU" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สาขางานที่เชี่ยวชาญ</td>
                                    <td class="col2">
                                        <asp:Label ID="lbSpecialName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">กลุ่มสาขาวิชาที่สอน(ISCED)</td>
                                    <td class="col2">
                                        <asp:Label ID="lbTeachISCED" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับการศึกษาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradLev" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">หลักสูตรที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradCURR" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">กลุ่มสาขาวิชาที่จบสูงสุด(ISCED)</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradISCED" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สาขาวิชาที่จบสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradProg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อสถาบันที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradUniv" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเทศที่จบการศึกษาสูงสุด</td>
                                    <td class="col2">
                                        <asp:Label ID="lbGradCountry" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 400px;">ความพิการ</td>
                                    <td class="col2">
                                        <asp:Label ID="lbDeform" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เลขที่ตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:Label ID="lbSitNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เงินเดือนปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:Label ID="lbSalary" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เงินประจำตำแหน่งที่ได้รับ</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPositionSalary" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ศาสนา</td>
                                    <td class="col2">
                                        <asp:Label ID="lbReligion" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทการดำรงตำแหน่งปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:Label ID="lbMovementType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่มีผลบังคับใช้ตามข้อมูล"การเข้าสู่ตำแหน่งปัจจุบัน"</td>
                                    <td class="col2">
                                        <asp:Label ID="lbMovementDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เครื่องราชอิสริยาภรณ์สูงสุดที่ได้รับ</td>
                                    <td class="col2">
                                        <asp:Label ID="lbDecoration" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่1</td>
                                    <td class="col2">
                                        <asp:Label ID="lbResult1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่1</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPercentSalary1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่2</td>
                                    <td class="col2">
                                        <asp:Label ID="lbResult2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่2</td>
                                    <td class="col2">
                                        <asp:Label ID="lbPercentSalary2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <div>
                            <div class="ps-div-title-red">ทำการบันทึกข้อมูลบุคลากรสำเร็จ</div>
                            <div style="color: #808080; margin-top: 10px; text-align: center;">
                                ระบบได้ทำการบันทึกข้อมูลบุคลากรเรียบร้อยแล้ว
                            </div>
                            <div style="text-align: center; margin-top: 10px;">
                                <a href="Default.aspx" class="ps-button btn btn-primary"><img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    <div style="text-align: center;">
        <asp:Button ID="btnSelectView0" runat="server" CssClass="btn btn-primary" OnClick="lbuSelectView0_Click" Text="หน้าที่ 1"></asp:Button>
        <asp:Button ID="btnSelectView1" runat="server" CssClass="btn btn-primary" OnClick="lbuSelectView1_Click" Text="หน้าที่ 2"></asp:Button>
        <asp:Button ID="btnSelectView2" runat="server" CssClass="btn btn-primary" OnClick="lbuSelectView2_Click" Text="หน้าที่ 3"></asp:Button>
        <asp:Button ID="btnUpdatePerson" runat="server" CssClass="btn btn-success" OnClick="lbuUpdatePerson_Click" Text="บันทึก"></asp:Button>
    </div>
</asp:Content>
