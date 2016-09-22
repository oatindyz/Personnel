﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adduser-admin.aspx.cs" Inherits="Personnel.adduser_admin" MaintainScrollPositionOnPostback="true" %>

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

    <script>
        function keyup(obj, e) {
            var keynum;
            var keychar;
            var id = '';
            if (window.event) {// IE
                keynum = e.keyCode;
            }
            else if (e.which) {// Netscape/Firefox/Opera
                keynum = e.which;
            }
            keychar = String.fromCharCode(keynum);


            var tagInput = document.getElementById('<%= tbCitizenID.ClientID %>').value;

            if (obj.value.length == 13) {

                if (checkID(tagInput)) {
                    nextObj.focus();
                }
                else {
                    alert('รหัสประจำตัวประชาชนไม่ถูกต้อง');
                    document.getElementById('<%= tbCitizenID.ClientID %>').value = "";
                    nextObj.focus();
                }

            }
        }
        function checkID(id) {
            if (id.length != 13) return false;
            for (i = 0, sum = 0; i < 12; i++)
                sum += parseFloat(id.charAt(i)) * (13 - i);
            if ((11 - sum % 11) % 10 != parseFloat(id.charAt(12)))
                return false;
            return true;

        }
    </script>

    <script type="text/javascript">
        function ValidateDate(sender, args) {
            var dateString = document.getElementById(sender.controltovalidate).value;
            var regex = /(((0|1)[1-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;
            if (regex.test(dateString)) {
                var parts = dateString.split("/");
                var dt = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
                args.IsValid = (dt.getDate() == parts[0] && dt.getMonth() + 1 == parts[1] && dt.getFullYear() == parts[2]);
            } else {
                args.IsValid = false;
            }
        }
    </script>

    <script type="text/javascript">
        $(function () {
            var thaiYear = function (ct) {
                var leap = 3;
                var dayWeek = ["พฤ.", "ศ.", "ส.", "อา.", "จ.", "อ.", "พ."];
                if (ct) {
                    var yearL = new Date(ct).getFullYear() - 543;
                    leap = (((yearL % 4 == 0) && (yearL % 100 != 0)) || (yearL % 400 == 0)) ? 2 : 3;
                    if (leap == 2) {
                        dayWeek = ["ศ.", "ส.", "อา.", "จ.", "อ.", "พ.", "พฤ."];
                    }
                }
                this.setOptions({
                    i18n: { th: { dayOfWeek: dayWeek } }, dayOfWeekStart: leap,
                })
            };

            $('#ContentPlaceHolder1_tbBirthday,#ContentPlaceHolder1_tbDateInwork,#ContentPlaceHolder1_tbDateStartThisU').datetimepicker({
                timepicker: false,
                format: 'd/m/Y',
                lang: 'th',
                onChangeMonth: thaiYear,
                onShow: thaiYear,
                yearOffset: 543,
                closeOnDateSelect: true,
            });
        });
    </script>

    <script>
        function SelectNoTeach(selectElement) {
            var selectedOption = selectElement.selectedIndex;
            if (selectedOption == 2)
                document.getElementById('<%=ddlTeachISCED.ClientID%>').disabled = true;
            else
                document.getElementById('<%=ddlTeachISCED.ClientID%>').disabled = false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/add.png" />เพิ่มข้อมูลบุคลากร
        </div>
        <div id="notification" runat="server"></div>

        <div class="panel panel-default">
            <div class="panel-body">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View0" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 400px;">รหัสประจำตัวประชาชน<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbCitizenID" runat="server" CssClass="form-control input-sm" MaxLength="13" onkeypress="return isNumberKey(event)" onkeyup="keyup(this,event)" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">มหาวิทยาลัย</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlUniv" runat="server" CssClass="form-control input-sm select2"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">คำนำหน้าชื่อ(ยึดตามบัตรประชาชน)</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlPrefixName" runat="server" CssClass="form-control input-sm select2"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อ<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbName" runat="server" CssClass="form-control input-sm" onkeyup="Check_txt(this,event)" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">นามสกุล<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เพศ</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control input-sm select2"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันเกิด<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbBirthday" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">บ้านเลขที่</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbHomeAdd" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                    <td class="col1">อำเภอ<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-sm select2" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำบล<span class="ps-lb-red" />*</td>
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
                                    <td class="col1">รหัสไปรษณีย์<span class="ps-lb-red" />*</td>
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
                                    <td class="col1" style="width: 400px;">ประเภทบุคลากร<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlStafftype" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระยะเวลาจ้าง<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlTimeContact" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทเงินจ้าง<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlBudget" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทตำแหน่ง<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlSubStafftype" runat="server" CssClass="form-control input-sm select2" onchange="SelectNoTeach(this)" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งบริหาร<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlAdminPosition" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับตำแหน่ง<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ตำแหน่งในสายงาน</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPositionWork" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">คณะ/หน่วยงานที่สังกัด หรือเทียบเท่า<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่เข้าทำงานครั้งแรก<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbDateInwork" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่เข้าทำงาน ณ สถานที่ปัจจุบัน<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbDateStartThisU" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สาขางานที่เชี่ยวชาญ</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbSpecialName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">กลุ่มสาขาวิชาที่สอน(ISCED)</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlTeachISCED" runat="server" CssClass="form-control input-sm select2"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ระดับการศึกษาที่จบสูงสุด<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradLev" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">หลักสูตรที่จบการศึกษาสูงสุด<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbGradCURR" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">กลุ่มสาขาวิชาที่จบสูงสุด(ISCED)<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradISCED" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">สาขาวิชาที่จบสูงสุด<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradProg" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อสถาบันที่จบการศึกษาสูงสุด<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbGradUniv" runat="server" CssClass="form-control input-sm" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเทศที่จบการศึกษาสูงสุด<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlGradCountry" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1" style="width: 400px;">ความพิการ<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlDeform" runat="server" CssClass="form-control input-sm select2" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เลขที่ตำแหน่ง</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbSitNo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เงินเดือนปัจจุบัน</td>
                                    <td class="col2 input-group date">
                                        <asp:TextBox ID="tbSalary" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event)"></asp:TextBox><span class="input-group-addon">.00</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เงินประจำตำแหน่งที่ได้รับ</td>
                                    <td class="col2 input-group date">
                                        <asp:TextBox ID="tbPositionSalary" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event)"></asp:TextBox><span class="input-group-addon">.00</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ศาสนา</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlReligion" runat="server" CssClass="form-control input-sm select2"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ประเภทการดำรงตำแหน่งปัจจุบัน</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlMovementType" runat="server" CssClass="form-control input-sm select2"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันที่มีผลบังคับใช้ตามข้อมูล"การเข้าสู่ตำแหน่งปัจจุบัน"</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbMovementDate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">เครื่องราชอิสริยาภรณ์สูงสุดที่ได้รับ</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbDecoration" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่1</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbResult1" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่1</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPercentSalary1" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ข้อความระดับผลการประเมิณรอบงานที่2</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbResult2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ร้อยละการเลื่อนขั้นเงินเดือนตามผลการประเมินรอบที่2</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPercentSalary2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
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
                                <a href="Default.aspx" class="ps-button">
                                    <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
    <div style="text-align: center;">
        <asp:Button ID="btnSelectView0" runat="server" CssClass="btn btn-primary" OnClick="lbuSelectView0_Click" Text="หน้าที่ 1"></asp:Button>
        <asp:Button ID="btnSelectView1" runat="server" CssClass="btn btn-primary" OnClick="lbuSelectView1_Click" Text="หน้าที่ 2"></asp:Button>
        <asp:Button ID="btnSelectView2" runat="server" CssClass="btn btn-primary" OnClick="lbuSelectView2_Click" Text="หน้าที่ 3"></asp:Button>
        <asp:Button ID="btnAddPerson" runat="server" CssClass="btn btn-primary" OnClick="lbuAddPerson_Click" Text="เพิ่มข้อมูลบุคลากร"></asp:Button>
    </div>
</asp:Content>
