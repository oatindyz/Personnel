<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reportproject-fliter-admin.aspx.cs" Inherits="Personnel.reportproject_fliter_admin" MaintainScrollPositionOnPostback="true" %>

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

    <style>
        .ppp {
            text-align: center;
        }
        .ppp table {
            text-align: center;
        }

        .ppp th {
            text-align: center;
        }

        .ppp td {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/copy.png" />ออกรายงานข้อมูลอบรม/สัมมนา/ดูงาน
        </div>
        <div id="notification" runat="server"></div>
        <div id="Dp1" runat="server" class="panel panel-default">
            <div class="panel-body">
                <div class="panel-body">
                    <div style="text-align: center;">
                        <table style="text-align: left; margin:auto;" class="ps-table-1">
                            <tr>
                                <td>ปีงบประมาณ</td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>สังกัด</td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control select2"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>ประเภท</td>
                                <td>
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>ประเภทการอบรม</td>
                                <td>
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>รูปแบบประเภทการอบรม</td>
                                <td>
                                    <asp:DropDownList ID="ddlSubCountry" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>วันที่เข้าร่วม - วันสิ้นสุดโครงการ</td>
                                <td>
                                    <asp:TextBox ID="tbStartDate" runat="server" CssClass="ps-textbox ekknidRight"></asp:TextBox><asp:TextBox ID="tbEndDate" runat="server" CssClass="ps-textbox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="text-align:center; margin:auto; margin-top:10px">
                        <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button ekknidRight ekknidTop"><img src="Image/Small/search.png" class="icon_left"/>แสดงผล</asp:LinkButton>
                        <asp:LinkButton ID="lbuExport" runat="server" CssClass="ps-button" OnClick="lbuExport_Click"><img src="Image/Small/excel.png" class="icon_left"/>ออกรายงาน Excel</asp:LinkButton>
                    </div>
                    <div style="margin-top: 10px; overflow-x:auto;">
                        <asp:Panel ID="Panel1" runat="server" CssClass="ppp"></asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
