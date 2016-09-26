<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="previewproject-admin.aspx.cs" Inherits="Personnel.previewproject_admin" MaintainScrollPositionOnPostback="true" %>

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
            <img src="Image/Small/search.png" />ดูข้อมูลอบรม/สัมมนา/ดูงาน
        </div>
        <div id="notification" runat="server"></div>

        <div id="Notsuccess" runat="server" class="panel panel-default">
            <div class="panel-body">
                <table class="table table-striped table-bordered table-hover ps-table-1">
                    <tr>
                        <td class="col1" style="width: 400px;">ชื่อ - สกุล:</td>
                        <td class="col2">
                            <asp:Label ID="lbName" runat="server" CssClass="ekknidRight"></asp:Label></td>
                    </tr>
                    <tr>

                        <td class="col1">ตำแหน่ง :</td>
                        <td class="col2">
                            <asp:Label ID="lbPosition" runat="server" CssClass="ekknidRight"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">สังกัด :</td>
                        <td class="col2">
                            <asp:Label ID="lbDepartment" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">ประเภทโครงการ :</td>
                        <td class="col2">
                            <asp:Label ID="lbCATEGORY_ID" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อโครงการ :</td>
                        <td class="col2">
                            <asp:Label ID="lbPROJECT_NAME" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">สถานที่จัดโครงการ :</td>
                        <td class="col2">
                            <asp:Label ID="lbADDRESS_PROJECT" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่เริ่มโครงการ - วันที่สิ้นสุดโครงการ :</td>
                        <td class="col2">
                            <asp:Label ID="lbDateStart" runat="server"></asp:Label>
                            <asp:Label ID="lb1" runat="server" CssClass="ekknidLeft ekknidRight"> - </asp:Label>
                            <asp:Label ID="lbDateEnd" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ค่าใช้จ่ายตลอดโครงการ :</td>
                        <td class="col2">
                            <asp:Label ID="lbEXPENSES" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">แหล่งงบประมาณสนับสนุน :</td>
                        <td class="col2">
                            <asp:Label ID="lbFUNDING" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">ประกาศนียบัตรที่ได้รับ :</td>
                        <td class="col2">
                            <asp:Label ID="lbCERTIFICATE" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">สรุปผลโครงการ :</td>
                        <td class="col2">
                            <asp:Label ID="lbSUMMARIZE_PROJECT" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">ผลที่ได้รับจากโครงการ :</td>
                        <td class="col2">
                            <asp:Label ID="lbRESULT_TEACHING" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">การนำผลที่ได้รับจากโครงการด้านการเรียนการสอน :</td>
                        <td class="col2">
                            <asp:Label ID="lbRESULT_ACADEMIC" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">การนำผลที่ได้รับจากโครงการด้านการวิจัย :</td>
                        <td class="col2">
                            <asp:Label ID="lbDIFFICULTY_PROJECT" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">การนำผลที่ได้รับจากโครงการด้านบริการวิชาการ :</td>
                        <td class="col2">
                            <asp:Label ID="lbRESULT_PROJECT" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">การนำผลที่ได้รับจากโครงการด้านอื่นๆ :</td>
                        <td class="col2">
                            <asp:Label ID="lbRESULT_RESEARCHING" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">ปัญหาอุปสรรคในโครงการ :</td>
                        <td class="col2">
                            <asp:Label ID="lbRESULT_OTHER" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="col1">ข้อเสนอแนะอื่นๆ :</td>
                        <td class="col2">
                            <asp:Label ID="lbCOUNSEL" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <div style="text-align: center; width: 100%">
                <div>
                    <asp:Label ID="lbNameapprove" runat="server" CssClass="ekknidRight">การอนุมัติ<span class="ps-lb-red">*</span></asp:Label>
                    <asp:DropDownList ID="ddlApprove" runat="server" CssClass="" Width="200px" required="required" TabIndex="1"></asp:DropDownList>
                </div>
            </div>
            <div style="text-align: center; margin-top: 20px; margin-bottom: 20px">
                <a href="listproject-admin.aspx" class="btn btn-info ekknidRight">ย้อนกลับ</a>
                <asp:Button ID="btnUpdateProject" runat="server" CssClass="btn btn-success ekknidRight" OnClick="btnUpdateProject_Click" Text="บันทึก"></asp:Button>
                <asp:LinkButton ID="lbuEdit" runat="server" class="btn btn-warning ekknidRight" OnClick="lbuEdit_Click">แก้ไข</asp:LinkButton>
                <asp:LinkButton ID="lbuDelete" runat="server" class="btn btn-danger" OnClientClick="javascript:if(!confirm('คุณต้องการที่จะลบใช่หรือไม่'))return false;" OnClick="lbuDelete_Click">ลบ</asp:LinkButton>
            </div>
        </div>
    </div>

    <div id="success" runat="server">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="ps-div-title-red">ทำการบันทึกข้อมูลอบรม/สัมมนา/ดูงานสำเร็จ</div>
                <div style="color: #808080; margin-top: 10px; text-align: center;">
                    ระบบได้ทำการบันทึกข้อมูลอบรม/สัมมนา/ดูงานเรียบร้อยแล้ว
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <a href="listproject-admin.aspx" class="ps-button btn btn-primary">ย้อนกลับ</a>
                </div>
            </div>
        </div>
    </div>

    <div id="delete" runat="server">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="ps-div-title-red">ทำการลบข้อมูลอบรม/สัมมนา/ดูงานสำเร็จ</div>
                <div style="color: #808080; margin-top: 10px; text-align: center;">
                    ระบบได้ทำการลบข้อมูลอบรม/สัมมนา/ดูงานเรียบร้อยแล้ว
                </div>
                <div style="text-align: center; margin-top: 10px;">
                    <a href="listproject-admin.aspx" class="ps-button btn btn-primary">ย้อนกลับ</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
