<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addproject-admin.aspx.cs" Inherits="Personnel.addproject_admin" MaintainScrollPositionOnPostback="true" %>

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

            $('#ContentPlaceHolder1_tbStartDate,#ContentPlaceHolder1_tbEndDate').datetimepicker({
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/add.png" />เพิ่มข้อมูลการพัฒนาความรู้และทักษะวิชาชีพ
        </div>
        <div id="notification" runat="server"></div>

        <div id="Notsuccess" runat="server" class="panel panel-default">
            <div class="panel-body">
                <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                    <tr>
                        <td class="col1" style="width: 400px;">ปีงบประมาณ</td>
                        <td class="col2">
                            <asp:Label ID="lbYear" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อ - สกุล<span class="ps-lb-red">*</span></td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlNameLastName" runat="server" CssClass="form-control input-sm select2" AutoPostBack="true" OnSelectedIndexChanged="ddlNameLastName_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สังกัด</td>
                        <td class="col2">
                            <asp:Label ID="lbDepartment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ประเภท<span class="ps-lb-red">*</span></td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control input-sm select2"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วุฒิการศึกษา</td>
                        <td class="col2">
                            <asp:Label ID="lbGradCURR" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งทางวิชาการ<span class="ps-lb-red">*</span></td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control input-sm select2"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">จำนวน</td>
                        <td class="col2">
                            <asp:TextBox ID="tbQuanltity" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เรื่อง</td>
                        <td class="col2">
                            <asp:TextBox ID="tbProjectName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ประเภทการอบรม<span class="ps-lb-red">*</span></td>
                        <td class="col2">
                            <asp:DropDownList ID="ddlCategoryCountry" runat="server" CssClass="form-control input-sm select2 ekknidRight" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoryCountry_SelectedIndexChanged" Width="200px"></asp:DropDownList>
                            <asp:DropDownList ID="ddlCategoryCountrySub" runat="server" CssClass="form-control input-sm select2" Width="200px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">สถานที่</td>
                        <td class="col2">
                            <asp:TextBox ID="tbAddressProject" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่เริ่มโครงการ - วันที่สิ้นสุดโครงการ<span class="ps-lb-red">*</span></td>
                        <td class="col2 input-group">
                            <asp:TextBox ID="tbStartDate" runat="server" CssClass="form-control input-sm" Width="200px" Placeholder="วันที่เริ่มโครงการ"></asp:TextBox>
                            <asp:TextBox ID="tbEndDate" runat="server" CssClass="form-control input-sm ekknidLeft" Width="200px" Placeholder="วันที่สิ้นสุดโครงการ"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">จำนวนเงินที่ใช้ในการพัฒนา</td>
                        <td class="col2 input-group">
                            <asp:TextBox ID="tbExpenses" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event)"></asp:TextBox><span class="input-group-addon">.00</span>
                        </td>
                    </tr>
                </table>

                <div style="text-align: center; margin-top: 10px;">
                    <a href="listproject-admin.aspx" class="btn btn-info">ย้อนกลับ</a>
                    <asp:Button ID="btnAddProject" runat="server" CssClass="btn btn-success" OnClick="btnAddProject_Click" Text="บันทึก"></asp:Button>
                </div>
            </div>
        </div>

        <div id="success" runat="server">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="ps-div-title-red">ทำการบันทึกข้อมูการพัฒนาความรู้และทักษะวิชาชีพสำเร็จ</div>
                    <div style="color: #808080; margin-top: 10px; text-align: center;">
                        ระบบได้ทำการบันทึกข้อมูลการพัฒนาความรู้และทักษะวิชาชีพเรียบร้อยแล้ว
                    </div>
                    <div style="text-align: center; margin-top: 10px;">
                        <a href="Default.aspx" class="ps-button btn btn-primary">
                            <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
