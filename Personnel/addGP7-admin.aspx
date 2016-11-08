<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addGP7-admin.aspx.cs" Inherits="Personnel.addGP7_admin" MaintainScrollPositionOnPostback="true" %>

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

            $('#ContentPlaceHolder1_tbYear13').datetimepicker({
                timepicker: false,
                format: 'Y',
                lang: 'th',
                onChangeMonth: thaiYear,
                onShow: thaiYear,
                yearOffset: 543,
                closeOnDateSelect: true,
            });
            $('document').ready(function () {
                $(".date3").datetimepicker({
                    timepicker: false,
                    format: 'Y',
                    lang: 'th',
                    onChangeMonth: thaiYear,
                    onShow: thaiYear,
                    yearOffset: 543,
                    closeOnDateSelect: true,
                });
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

            $('#ContentPlaceHolder1_tbStartDate10,#ContentPlaceHolder1_tbEndDate10').datetimepicker({
                timepicker: false,
                format: 'm/Y',
                lang: 'th',
                onChangeMonth: thaiYear,
                onShow: thaiYear,
                yearOffset: 543,
                closeOnDateSelect: true,
            });
            $('document').ready(function () {
                $(".date2").datetimepicker({
                    timepicker: false,
                    format: 'm/Y',
                    lang: 'th',
                    onChangeMonth: thaiYear,
                    onShow: thaiYear,
                    yearOffset: 543,
                    closeOnDateSelect: true,
                });
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

            $('#ContentPlaceHolder1_tbStartDate11,#ContentPlaceHolder1_tbStartDate12,#ContentPlaceHolder1_tbEndDate12,#ContentPlaceHolder1_tbStartDate14').datetimepicker({
                timepicker: false,
                format: 'd/m/Y',
                lang: 'th',
                onChangeMonth: thaiYear,
                onShow: thaiYear,
                yearOffset: 543,
                closeOnDateSelect: true,
            });
            $('document').ready(function () {
                $(".date1").datetimepicker({
                    timepicker: false,
                    format: 'd/m/Y',
                    lang: 'th',
                    onChangeMonth: thaiYear,
                    onShow: thaiYear,
                    yearOffset: 543,
                    closeOnDateSelect: true,
                });
            });
        });
    </script>
    <script type = "text/javascript">
    function DisableButton() {
        document.getElementById("<%=btnSave1.ClientID %>").disabled = true;
        document.getElementById("<%=btnSave2.ClientID %>").disabled = true;
        document.getElementById("<%=btnSave3.ClientID %>").disabled = true;
        document.getElementById("<%=btnSave4.ClientID %>").disabled = true;
        document.getElementById("<%=btnSave5.ClientID %>").disabled = true;
        document.getElementById("<%=btnSave6.ClientID %>").disabled = true;
    }
    window.onbeforeunload = DisableButton;
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:HiddenField ID="HF1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/add.png" />เพิ่มข้อมูล ก.พ.7
            <span style="text-align:right; float:right;"><a href="listGP7-admin.aspx">
            <img src="Image/Small/back.png" />ย้อนกลับ</a></span>
        </div>
        <div id="notification" runat="server"></div>

        <div id="divTab" runat="server" class="ps-tab-container" style="text-align: center;">
            <asp:LinkButton ID="lbuTab1" runat="server" OnClick="lbuTab1_Click" CssClass="ps-tab-unselected">ข้อมูลพื้นฐาน</asp:LinkButton>
            <asp:LinkButton ID="lbuTab2" runat="server" OnClick="lbuTab2_Click" CssClass="ps-tab-unselected">ประวัติการศึกษา</asp:LinkButton>
            <asp:LinkButton ID="lbuTab3" runat="server" OnClick="lbuTab3_Click" CssClass="ps-tab-unselected">ใบอนุญาตประกอบวิชาชีพ</asp:LinkButton>
            <asp:LinkButton ID="lbuTab4" runat="server" OnClick="lbuTab4_Click" CssClass="ps-tab-unselected">ประวัติการฝึกอบรม</asp:LinkButton>
            <asp:LinkButton ID="lbuTab5" runat="server" OnClick="lbuTab5_Click" CssClass="ps-tab-unselected">โทษทางวินัย</asp:LinkButton>
            <asp:LinkButton ID="lbuTab6" runat="server" OnClick="lbuTab6_Click" CssClass="ps-tab-unselected">ตำแหน่งและเงินเดือน</asp:LinkButton>
        </div>

        <div id="divTab1" runat="server" class="panel panel-default">
            <div class="panel-body">
                <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                    <tr>
                        <td class="col1" style="width: 400px;">ชื่อบิดา<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbFatherName" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลบิดา<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbFatherLastName" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อมารดา<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbMotherName" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลมารดา<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbMotherLastName" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลมารดาเดิม</td>
                        <td class="col2">
                            <asp:TextBox ID="tbMotherOldLastName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ชื่อคู่สมรส</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCoupleName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลคู่สมรส</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCoupleLastName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">นามสกุลเดิมคู่สมรสเดิม</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCoupleOldLastName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:Button ID="btnSave1" runat="server" OnClick="btnSave1_Click" CssClass="btn btn-success" Text="บันทึก"></asp:Button>
                </div>
            </div>
        </div>

        <div id="divTab2" runat="server" class="panel panel-default">
            <div class="panel-body">
                <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                    <tr>
                        <td class="col1" style="width: 400px;">สถานศึกษา<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbUnivName10" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตั้งแต่ - ถึง (เดือน ปี)<span class="ps-lb-red" />*</td>
                        <td class="col2">

                            <div class="input-daterange input-group">
                                <asp:TextBox ID="tbStartDate10" runat="server" CssClass="input-sm form-control" required="required" TabIndex="1"></asp:TextBox>
                                <span class="input-group-addon">ถึง</span>
                                <asp:TextBox ID="tbEndDate10" runat="server" CssClass="input-sm form-control" required="required" TabIndex="1"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วุฒิ (สาขาวิชาเอก)<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCertificate10" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:Button ID="btnSave2" runat="server" OnClick="btnSave2_Click" CssClass="btn btn-success" Text="บันทึก"></asp:Button>
                </div>
                <div style="margin-top: 10px; overflow-x: auto; width: 100%;">
                    <asp:GridView ID="GridViewStudy" runat="server" Style="margin-left: auto; margin-right: auto;"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="STUDY_ID"
                        OnRowEditing="modEditCommand1"
                        OnRowCancelingEdit="modCancelCommand1"
                        OnRowUpdating="modUpdateCommand1"
                        OnRowDeleting="modDeleteCommand1"
                        OnRowDataBound="GridViewStudy_RowDataBound1"
                        OnPageIndexChanging="myGridViewStudy_PageIndexChanging1" PageSize="15" CssClass="ps-table-1" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="STUDY_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudyID10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.STUDY_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOC_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudyUOC_ID10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UOC_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="สถานศึกษา">
                                <ItemTemplate>
                                    <asp:Label ID="lblUNIV_NAME10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UNIV_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtUNIV_NAME10" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.UNIV_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตั้งแต่">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTART_DATE10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.START_DATE", "{0:MMM - yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSTART_DATE10" runat="server" CssClass="date2 form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.START_DATE", "{0:MM/yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ถึง">
                                <ItemTemplate>
                                    <asp:Label ID="lblEND_DATE10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.END_DATE", "{0:MMM - yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEND_DATE10" runat="server" CssClass="date2 form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.END_DATE", "{0:MM/yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วุฒิ">
                                <ItemTemplate>
                                    <asp:Label ID="lblQUALIFICATION10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QUALIFICATION") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtQUALIFICATION10" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.QUALIFICATION") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" ItemStyle-Width="50px"/>
                            <asp:TemplateField HeaderText="ลบ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" Width="50px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>

        <div id="divTab3" runat="server" class="panel panel-default">
            <div class="panel-body">
                <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                    <tr>
                        <td class="col1" style="width: 400px;">ชื่อใบอนุญาต<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbLicenseName11" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">หน่วยงาน<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbDepartment11" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เลขที่ใบอนุญาต<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbLicenseNumber11" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">วันที่มีผลบังคับใช้ (วัน เดือน ปี)<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbStartDate11" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:Button ID="btnSave3" runat="server" OnClick="btnSave3_Click" CssClass="btn btn-success" Text="บันทึก"></asp:Button>
                </div>
                <div style="margin-top: 10px; overflow-x: auto; width: 100%;">
                    <asp:GridView ID="GridViewLicense" runat="server" Style="margin-left: auto; margin-right: auto;"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="PRO_ID"
                        OnRowEditing="modEditCommand2"
                        OnRowCancelingEdit="modCancelCommand2"
                        OnRowUpdating="modUpdateCommand2"
                        OnRowDeleting="modDeleteCommand2"
                        OnRowDataBound="GridViewLicense_RowDataBound2"
                        OnPageIndexChanging="myGridViewLicense_PageIndexChanging2" PageSize="15" CssClass="ps-table-1" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="PRO_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblProID11" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PRO_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOC_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblProUOC_ID11" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UOC_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อใบอนุญาต">
                                <ItemTemplate>
                                    <asp:Label ID="lblLICENSE_NAME11" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LICENSE_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLICENSE_NAME11" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.LICENSE_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หน่วยงาน">
                                <ItemTemplate>
                                    <asp:Label ID="lblDEPARTMENT11" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DEPARTMENT") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDEPARTMENT11" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.DEPARTMENT") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เลขที่ใบอนุญาต">
                                <ItemTemplate>
                                    <asp:Label ID="lblLICENSE_NUMBER11" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LICENSE_NUMBER") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLICENSE_NUMBER11" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.LICENSE_NUMBER") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่มีผลบังคับใช้ (วัน เดือน ปี)">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTART_DATE11" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.START_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSTART_DATE11" runat="server" CssClass="date1 form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.START_DATE", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" ItemStyle-Width="50px"/>
                            <asp:TemplateField HeaderText="ลบ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" Width="50px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>

        <div id="divTab4" runat="server" class="panel panel-default">
            <div class="panel-body">
                <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                    <tr>
                        <td class="col1" style="width: 400px;">หลักสูตรฝึกอบรม<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbCourse12" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตั้งแต่ - ถึง (วัน เดือน ปี)<span class="ps-lb-red" />*</td>
                        <td class="col2">

                            <div class="input-daterange input-group">
                                <asp:TextBox ID="tbStartDate12" runat="server" CssClass="input-sm form-control" required="required" TabIndex="1"></asp:TextBox>
                                <span class="input-group-addon">ถึง</span>
                                <asp:TextBox ID="tbEndDate12" runat="server" CssClass="input-sm form-control" required="required" TabIndex="1"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">หน่วยงานที่จัดฝึกอบรม<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbDepartment12" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:Button ID="btnSave4" runat="server" OnClick="btnSave4_Click" CssClass="btn btn-success" Text="บันทึก"></asp:Button>
                </div>
                <div style="margin-top: 10px; overflow-x: auto; width: 100%;">
                    <asp:GridView ID="GridViewTraining" runat="server" Style="margin-left: auto; margin-right: auto;"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="TRAINING_ID"
                        OnRowEditing="modEditCommand3"
                        OnRowCancelingEdit="modCancelCommand3"
                        OnRowUpdating="modUpdateCommand3"
                        OnRowDeleting="modDeleteCommand3"
                        OnRowDataBound="GridViewTraining_RowDataBound3"
                        OnPageIndexChanging="myGridViewTraining_PageIndexChanging3" PageSize="15" CssClass="ps-table-1" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="TRAINING_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblTrainingID12" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TRAINING_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOC_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblTrainingUOC_ID12" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UOC_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หลักสูตรฝึกอบรม">
                                <ItemTemplate>
                                    <asp:Label ID="lblTRAINING_NAME12" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TRAINING_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTRAINING_NAME12" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.TRAINING_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตั้งแต่">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTART_DATE12" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.START_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSTART_DATE12" runat="server" CssClass="date1 form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.START_DATE", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ถึง">
                                <ItemTemplate>
                                    <asp:Label ID="lblEND_DATE12" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.END_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEND_DATE12" runat="server" CssClass="date1 form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.END_DATE", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หน่วยงานที่จัดฝึกอบรม">
                                <ItemTemplate>
                                    <asp:Label ID="lblDEPARTMENT12" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DEPARTMENT") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDEPARTMENT12" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.DEPARTMENT") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>                          
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" ItemStyle-Width="50px"/>
                            <asp:TemplateField HeaderText="ลบ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" Width="50px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>

        <div id="divTab5" runat="server" class="panel panel-default">
            <div class="panel-body">
                <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                    <tr>
                        <td class="col1" style="width: 400px;">พ.ศ.<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbYear13" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">รายการ<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbPunishName13" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เอกสารอ้างอิง<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbRefDoc13" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:Button ID="btnSave5" runat="server" OnClick="btnSave5_Click" CssClass="btn btn-success" Text="บันทึก"></asp:Button>
                </div>
                <div style="margin-top: 10px; overflow-x: auto; width: 100%;">
                    <asp:GridView ID="GridViewPunish" runat="server" Style="margin-left: auto; margin-right: auto;"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="PUNISH_ID"
                        OnRowEditing="modEditCommand4"
                        OnRowCancelingEdit="modCancelCommand4"
                        OnRowUpdating="modUpdateCommand4"
                        OnRowDeleting="modDeleteCommand4"
                        OnRowDataBound="GridViewPunish_RowDataBound4"
                        OnPageIndexChanging="myGridViewPunish_PageIndexChanging4" PageSize="15" CssClass="ps-table-1" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="PUNISH_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPUNISH_ID13" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PUNISH_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOC_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPunishUOC_ID13" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UOC_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="พ.ศ.">
                                <ItemTemplate>
                                    <asp:Label ID="lblYEAR13" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR", "{0:yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtYEAR13" runat="server" CssClass="date3 form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.YEAR", "{0:yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รายการ">
                                <ItemTemplate>
                                    <asp:Label ID="lblPUNISH_NAME13" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PUNISH_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPUNISH_NAME13" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.PUNISH_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เอกสารอ้างอิง">
                                <ItemTemplate>
                                    <asp:Label ID="lblREF_DOC13" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REF_DOC") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtREF_DOC13" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.REF_DOC") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>                          
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" ItemStyle-Width="50px"/>
                            <asp:TemplateField HeaderText="ลบ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" Width="50px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>

        <div id="divTab6" runat="server" class="panel panel-default">
            <div class="panel-body">
                <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                    <tr>
                        <td class="col1" style="width: 400px;">วัน เดือน ปี<span class="ps-lb-red" />*</td>
                        <td class="col2">
                            <asp:TextBox ID="tbStartDate14" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่ง</td>
                        <td class="col2">
                            <asp:TextBox ID="tbName14" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เลขที่ตำแหน่ง</td>
                        <td class="col2">
                            <asp:TextBox ID="tbNoPosition14" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ตำแหน่งประเภท</td>
                        <td class="col2">
                            <asp:TextBox ID="tbPosiType14" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">ระดับ</td>
                        <td class="col2">
                            <asp:TextBox ID="tbPosiDegree14" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เงินเดือน</td>
                        <td class="col2 input-group date">
                            <asp:TextBox ID="tbSalary14" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event)"></asp:TextBox><span class="input-group-addon">.00</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เงินประจำตำแหน่ง</td>
                        <td class="col2 input-group date">
                            <asp:TextBox ID="tbPosiSalary14" runat="server" CssClass="form-control input-sm" onkeypress="return isNumberKey(event)"></asp:TextBox><span class="input-group-addon">.00</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="col1">เอกสารอ้างอิง</td>
                        <td class="col2">
                            <asp:TextBox ID="tbRefDoc14" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 10px;">
                    <asp:Button ID="btnSave6" runat="server" OnClick="btnSave6_Click" CssClass="btn btn-success" Text="บันทึก"></asp:Button>
                </div>
                <div style="margin-top: 10px; overflow-x: auto; width: 100%;">
                    <asp:GridView ID="GridViewPosiSalary" runat="server" Style="margin-left: auto; margin-right: auto;"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="PAS_ID"
                        OnRowEditing="modEditCommand5"
                        OnRowCancelingEdit="modCancelCommand5"
                        OnRowUpdating="modUpdateCommand5"
                        OnRowDeleting="modDeleteCommand5"
                        OnRowDataBound="GridViewPosiSalary_RowDataBound5"
                        OnPageIndexChanging="myGridViewPosiSalary_PageIndexChanging5" PageSize="15" CssClass="ps-table-1" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="PAS_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPAS_ID14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PAS_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOC_ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosiSalaryUOC_ID14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UOC_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วัน เดือน ปี">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTART_DATE14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.START_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSTART_DATE14" runat="server" CssClass="date1 form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.START_DATE", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ตำแหน่ง">
                                <ItemTemplate>
                                    <asp:Label ID="lblPAS_NAME14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PAS_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPAS_NAME14" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.PAS_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เลขที่ตำแหน่ง">
                                <ItemTemplate>
                                    <asp:Label ID="lblNO_POSITION14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NO_POSITION") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNO_POSITION14" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.NO_POSITION") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="ตำแหน่งประเภท">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOSITION_TYPE14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_TYPE") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPOSITION_TYPE14" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_TYPE") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ระดับ">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOSITION_DEGREE14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NO_POSITION") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPOSITION_DEGREE14" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_DEGREE") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เงินเดือน">
                                <ItemTemplate>
                                    <asp:Label ID="lblSALARY14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SALARY") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSALARY14" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.SALARY") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เงินประจำตำแหน่ง">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOSITION_SALARY14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_SALARY") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPOSITION_SALARY14" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.POSITION_SALARY") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เอกสารอ้างอิง">
                                <ItemTemplate>
                                    <asp:Label ID="lblREF_DOC14" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REF_DOC") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtREF_DOC14" runat="server" CssClass="form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.REF_DOC") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>                      
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" ItemStyle-Width="50px"/>
                            <asp:TemplateField HeaderText="ลบ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" Width="50px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
