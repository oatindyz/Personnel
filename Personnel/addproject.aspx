<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addproject.aspx.cs" Inherits="Personnel.addproject" MaintainScrollPositionOnPostback="true" %>

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
            <img src="Image/Small/add.png" />เพิ่มข้อมูลอบรม/สัมมนา/ดูงาน
        </div>
        <div id="notification" runat="server"></div>

        <div id="Notsuccess" runat="server" class="panel panel-default">
            <div class="panel-body">
                <table style="width: 97%;">
                    <tr>
                        <td>
                            <div class="form-group">
                                <asp:Label ID="lbCategoryID" runat="server">ประเภทโครงการ<span class="ps-lb-red" />*</asp:Label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control input-sm select2 ekknidRight" required="required" TabIndex="1"></asp:DropDownList>
                            </div>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:Label ID="lbCountry" runat="server">ประเภทการอบรม<span class="ps-lb-red" />*</asp:Label>
                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control input-sm select2 ekknidRight" required="required" TabIndex="1"></asp:DropDownList>
                            </div>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:Label ID="lbTypeProject" runat="server">รูปแบบประเภทการอบรม<span class="ps-lb-red" />*</asp:Label>
                                <asp:DropDownList ID="ddlSubCountry" runat="server" CssClass="form-control input-sm select2 ekknidRight" required="required" TabIndex="1"></asp:DropDownList>
                            </div>
                        </td>
                        <td>
                            <div class="form-group">
                                <asp:Label ID="lbFile" runat="server">แนบไฟล์ .pdf (รูปภาพ,เอกสาร ประกอบการอบรม)<span class="ps-lb-red" />*</asp:Label>
                                <asp:FileUpload ID="FUdocument" runat="server" Width="250px" required="required" TabIndex="1"/>
                            </div>
                        </td>
                    </tr>
                </table>
                
                <div class="form-group">
                    <asp:Label ID="lbProjectName" runat="server">ชื่อโครงการ<span class="ps-lb-red" />*</asp:Label>
                    <asp:TextBox ID="tbProjectName" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbAddressProject" runat="server">สถานที่จัดโครงการ<span class="ps-lb-red" />*</asp:Label>
                    <asp:TextBox ID="tbAddressProject" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbStartDateEndDate" runat="server">วันที่เริ่มโครงการ - วันที่สิ้นสุดโครงการ<span class="ps-lb-red" />*</asp:Label>
                    <div class="input-group form-group date">
                        <asp:TextBox ID="tbStartDate" runat="server" CssClass="form-control input-sm" Width="200px" Placeholder="วันที่เริ่มโครงการ" required="required" TabIndex="1"></asp:TextBox>
                        <asp:TextBox ID="tbEndDate" runat="server" CssClass="form-control input-sm ekknidLeft" Width="200px" Placeholder="วันที่สิ้นสุดโครงการ" required="required" TabIndex="1"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbExpenses" runat="server">ค่าใช้จ่ายตลอดโครงการ<span class="ps-lb-red" />*</asp:Label>
                    <div class="form-group input-group date">
                        <asp:TextBox ID="tbExpenses" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event)" required="required" TabIndex="1"></asp:TextBox><span class="input-group-addon">.00</span>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbFunding" runat="server">แหล่งงบประมาณสนับสนุน</asp:Label>
                    <asp:TextBox ID="tbFunding" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbCertificate" runat="server">ประกาศนียบัตรที่ได้รับ(ถ้ามี)</asp:Label>
                    <asp:TextBox ID="tbCertificate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div class="form-group">
                                <asp:Label ID="lbSummarizeProject" runat="server">สรุปผลโครงการ</asp:Label>
                                <asp:TextBox ID="tbSummarizeProject" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="50px" Width="95%" Placeholder="สรุปผลโครงการ"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lbResultTeaching" runat="server">การนำผลที่ได้รับจากโครงการด้านการเรียนการสอน</asp:Label>
                                <asp:TextBox ID="tbResultTeaching" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="50px" Width="95%" Placeholder="การนำผลที่ได้รับจากโครงการด้านการเรียนการสอน"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lbResultAcademic" runat="server">การนำผลที่ได้รับจากโครงการด้านการบริการวิชาการ</asp:Label>
                                <asp:TextBox ID="tbResultAcademic" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="50px" Width="95%" Placeholder="การนำผลที่ได้รับจากโครงการด้านการบริการวิชาการ"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lbDifficultyProject" runat="server">ปัญหาอุปสรรคในโครงการ</asp:Label>
                                <asp:TextBox ID="tbDifficultyProject" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="50px" Width="95%" Placeholder="ปัญหาอุปสรรคในโครงการ"></asp:TextBox>
                            </div>
                        </td>

                        <td>
                            <div class="form-group">
                                <asp:Label ID="lbResultProject" runat="server">ผลที่ได้รับจากโครงการ</asp:Label>
                                <asp:TextBox ID="tbResultProject" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="50px" Placeholder="ผลที่ได้รับจากโครงการ"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lbResultResearching" runat="server">การนำผลที่ได้รับจากโครงการด้านการวิจัย</asp:Label>
                                <asp:TextBox ID="tbResultResearching" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="50px" Placeholder="การนำผลที่ได้รับจากโครงการด้านการวิจัย"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lbResultOther" runat="server">การนำผลที่ได้รับจากโครงการด้านอื่นๆ</asp:Label>
                                <asp:TextBox ID="tbResultOther" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="50px" Placeholder="การนำผลที่ได้รับจากโครงการด้านอื่นๆ"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lbCounsel" runat="server">ข้อเสนอแนะอื่นๆ</asp:Label>
                                <asp:TextBox ID="tbCounsel" runat="server" TextMode="MultiLine" CssClass="form-control input-sm" Height="50px" Placeholder="ข้อเสนอแนะอื่นๆ"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                </table>

                <div style="text-align: center; margin-top: 10px;">
                    <a href="listproject.aspx" class="btn btn-info">ย้อนกลับ</a>
                    <asp:Button ID="btnAddProject" runat="server" CssClass="btn btn-success" OnClick="btnAddProject_Click" Text="บันทึก"></asp:Button>
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
                        <a href="Default.aspx" class="ps-button btn btn-primary">
                            <img src="Image/Small/home3.png" class="icon_left" />กลับหน้าหลัก</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
