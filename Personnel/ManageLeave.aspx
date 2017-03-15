<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageLeave.aspx.cs" Inherits="Personnel.ManageLeave" %>

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

            $('#ContentPlaceHolder1_tbS1FromDate,#ContentPlaceHolder1_tbS1ToDate').datetimepicker({
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
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/document-create.png" />จัดการข้อมูลการลา
            <span style="text-align: right; float: right;"><a href="listLeave-admin.aspx">
                <img src="Image/Small/back.png" />ย้อนกลับ</a></span>
        </div>

        <asp:HiddenField ID="hfLeaveTypeID" runat="server" />
        <asp:HiddenField ID="hfLeaveTypeName" runat="server" />

        <div id="notification" runat="server"></div>

        <asp:MultiView ID="MV1" runat="server" ActiveViewIndex="0">
            <asp:View ID="MV1_V1" runat="server">
                <div>
                    <div class="ps-div-title-red">กรุณาเลือกการลา</div>
                    <div style="text-align: center;">
                        <asp:LinkButton ID="lbuSelectSick" runat="server" CssClass="ps-button" OnClick="lbuSelectSick_Click"><img src="Image/Small/document-create.png" class="icon_left" />ลาป่วย</asp:LinkButton>
                        <asp:LinkButton ID="lbuSelectBusiness" runat="server" CssClass="ps-button" OnClick="lbuSelectBusiness_Click"><img src="Image/Small/document-create.png" class="icon_left" />ลากิจ</asp:LinkButton>
                        <asp:LinkButton ID="lbuSelectRest" runat="server" CssClass="ps-button" OnClick="lbuSelectRest_Click"><img src="Image/Small/document-create.png" class="icon_left" />ลาพักผ่อน</asp:LinkButton>
                        <asp:LinkButton ID="lbuSelectGiveBirth" runat="server" CssClass="ps-button" OnClick="lbuSelectGiveBirth_Click"><img src="Image/Small/document-create.png" class="icon_left" />ลาคลอดบุตร</asp:LinkButton>
                        <asp:LinkButton ID="lbuSelectHelpGiveBirth" runat="server" CssClass="ps-button" OnClick="lbuSelectHelpGiveBirth_Click"><img src="Image/Small/document-create.png" class="icon_left" />ลาไปช่วยเหลือภริยาที่คลอดบุตร</asp:LinkButton>
                        <asp:LinkButton ID="lbuSelectOrdain" runat="server" CssClass="ps-button" OnClick="lbuSelectOrdain_Click"><img src="Image/Small/document-create.png" class="icon_left" />ลาไปอุปสมบท</asp:LinkButton>
                        <asp:LinkButton ID="lbuSelectHuj" runat="server" CssClass="ps-button" OnClick="lbuSelectHuj_Click"><img src="Image/Small/document-create.png" class="icon_left" />ลาไปประกอบพิธีฮัจญ์</asp:LinkButton>
                    </div>
                </div>

                <div id="divLoadLeave" runat="server" class="dataTable_wrapper ekknidTop">
                    <div class="ps-header">
                        <img src="Image/Small/list.png" />ข้อมูล
                    </div>
                    <div style="margin-top: 10px; overflow-x: auto; width: 100%;">
                        <asp:GridView ID="GridViewLeave" runat="server" Style="margin-left: auto; margin-right: auto;"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            DataKeyNames="LEAVE_ID"
                            OnRowDeleting="modDeleteCommand"
                            OnRowDataBound="GridViewLeave_RowDataBound"
                            OnPageIndexChanging="myGridViewLeave_PageIndexChanging" PageSize="10" CssClass="table table-striped table-bordered table-condensed" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="ลำดับที่" ControlStyle-CssClass="center100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ประเภทการลา">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProUOC_ID11" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LEAVE_TYPE_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="วันที่บันทึกการลา">
                                    <ItemTemplate>
                                        <asp:Label ID="lbReqDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.REQ_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="วันที่ทำการลา">
                                    <ItemTemplate>
                                        <asp:Label ID="lbDateLeave" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DATE_LEAVE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ลบ">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete" Width="50px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="MV1_V2" runat="server">
                <div>
                    <div class="ps-header">
                        <img src="Image/Small/document.png" class="icon_left" />กรุณากรอกข้อมูลการลา
                    </div>
                    <table class="table table-striped table-bordered table-hover" style="margin: 0 auto;">

                        <tr id="HeaderName" runat="server" visible="false" style="text-align: center;">
                            <th colspan="2" style="text-align: center;">
                                <asp:Label ID="lbHeaderName" runat="server" Text="?" Style="text-align: center;"></asp:Label>
                            </th>
                        </tr>

                        <tr id="trS1WifeName" runat="server">
                            <td class="col1">
                                <img src="Image/Small/person2.png" class="icon_left" />ชื่อภริยา</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1WifeFirstName" runat="server" CssClass="form-control input-sm" placeHolder="ชื่อจริง" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                                <asp:TextBox ID="tbS1WifeLastName" runat="server" CssClass="form-control input-sm" placeHolder="นามสกุล" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trS1GBDate" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />
                                คลอดบุตรวันที่</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1GBDate" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trS1Ordained" runat="server">
                            <td class="col1">
                                <img src="Image/Small/question.png" class="icon_left" />
                                การอุปสมบท</td>
                            <td class="col2">
                                <asp:RadioButton ID="rbS1OrdainedT" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="เคย" />
                                <asp:RadioButton ID="rbS1OrdainedF" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="ไม่เคย" />
                            </td>
                        </tr>
                        <tr id="trS1TempleName" runat="server">
                            <td class="col1">
                                <img src="Image/Small/bell.png" class="icon_left" />
                                ชื่อวัด</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1TempleName" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trS1TempleLocation" runat="server">
                            <td class="col1">
                                <img src="Image/Small/location.png" class="icon_left" />
                                สถานที่</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1TempleLocation" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trS1OrdainDate" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />
                                อุปสมบทวันที่</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1OrdainDate" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trS1Hujed" runat="server">
                            <td class="col1">
                                <img src="Image/Small/question.png" class="icon_left" />
                                การไปประกอบพิธฮัจย์</td>
                            <td class="col2">
                                <asp:RadioButton ID="rbS1HujedT" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="เคย" />
                                <asp:RadioButton ID="rbS1HujedF" runat="server" CssClass="radio_button radio_button_default" GroupName="ordained" Text="ไม่เคย" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />วันที่ลา</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1FromDate" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                                <span style="width: 10px; display: inline-block;"></span>
                                <span style="color: #808080;">ถึง </span>
                                <asp:TextBox ID="tbS1ToDate" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trS1Reason" runat="server">
                            <td class="col1">
                                <img src="Image/Small/a.png" class="icon_left" />เหตุผล</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1Reason" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trS1Contact" runat="server">
                            <td class="col1">
                                <img src="Image/Small/comment.png" class="icon_left" />ติดต่อได้ที่</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1Contact" runat="server" CssClass="form-control input-sm" Style="width: 200px;" placeHolder="สถานที่" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trS1Phone" runat="server">
                            <td class="col1">
                                <img src="Image/Small/phone.png" class="icon_left" />เบอร์โทรศัพท์</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1Phone" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trS1DrCer" runat="server">
                            <td class="col1">
                                <img src="Image/Small/clip.png" class="icon_left" />ใบรับรองแพทย์</td>
                            <td class="col2">
                                <asp:FileUpload ID="FileUpload1" runat="server" required="required" TabIndex="1" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/person2.png" class="icon_left" />ผู้บังคับบัญชา</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlS1BossLowID" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/a.png" class="icon_left" />ความเห็นผู้บังคับบัญชา</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1BossLowComment" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/person2.png" class="icon_left" />ผู้อนุมัติ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlS1BossHighID" runat="server" CssClass="form-control input-sm select2" required="required" TabIndex="1"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/a.png" class="icon_left" />ความเห็นผู้อนุมัติ</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1BossHighComment" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/a.png" class="icon_left" />ความเห็นเจ้าหน้าที่</td>
                            <td class="col2">
                                <asp:TextBox ID="tbS1OfficerComment" runat="server" CssClass="form-control input-sm" Style="width: 200px;" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div style="text-align: center; margin-top: 10px;">
                        <asp:Button ID="lbuS1Back2" runat="server" CssClass="btn btn-default ekknidRight" OnClick="lbuS1Back_Click" Text="ย้อนกลับ"></asp:Button>
                        <asp:Button ID="lbuS1Check2" runat="server" CssClass="btn btn-default" OnClick="lbuS1Check_Click" Text="ต่อไป"></asp:Button>
                    </div>

                </div>


            </asp:View>
            <asp:View ID="MV1_V3" runat="server">
                <div>
                    <div class="ps-header">
                        <img src="Image/Small/document.png" class="icon_left" />ข้อมูลการลา
                    </div>
                    <div class="ps-div-title-red"></div>
                    <table class="table table-striped table-bordered table-hover" style="margin: 0 auto;">
                        <tr>
                            <td class="col1" style="width: 400px;">ประเภทการลา</td>
                            <td class="col2">
                                <asp:Label ID="lbS2LeaveTypeName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/person2.png" class="icon_left" />ชื่อ</td>
                            <td class="col2">
                                <asp:Label ID="lbS2PSName" runat="server"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ตำแหน่ง</td>
                            <td class="col2">
                                <asp:Label ID="lbS2PSPos" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ระดับ</td>
                            <td class="col2">
                                <asp:Label ID="lbS2PSAPos" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">สังกัด</td>
                            <td class="col2">
                                <asp:Label ID="lbS2PSDept" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2BirthDate" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />
                                เกิดวันที่</td>
                            <td class="col2">
                                <asp:Label ID="lbS2PSBirthDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2WorkInDate" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />
                                เข้ารับราชการเมื่อวันที่</td>
                            <td class="col2">
                                <asp:Label ID="lbS2PSWorkInDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2RestSave" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />วันลาพักผ่อนสะสม</td>
                            <td class="col2">
                                <asp:Label ID="lbS2RestSave" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2RestLeft" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />
                                มีสิทธิลาประจำปีนี้อีก</td>
                            <td class="col2">
                                <asp:Label ID="lbS2RestLeft" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2RestTotal" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />
                                รวม</td>
                            <td class="col2">
                                <asp:Label ID="lbS2RestTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2WifeName" runat="server">
                            <td class="col1">
                                <img src="Image/Small/person2.png" class="icon_left" />
                                ชื่อภริยา</td>
                            <td class="col2">
                                <asp:Label ID="lbS2WifeName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2GBDate" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />
                                คลอดบุตรวันที่</td>
                            <td class="col2">
                                <asp:Label ID="lbS2GBDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2Ordained" runat="server">
                            <td class="col1">
                                <img src="Image/Small/question.png" class="icon_left" />
                                การอุปสมบท</td>
                            <td class="col2">
                                <asp:Label ID="lbS2Ordained" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2TempleName" runat="server">
                            <td class="col1">
                                <img src="Image/Small/bell.png" class="icon_left" />
                                ชื่อวัด</td>
                            <td class="col2">
                                <asp:Label ID="lbS2TempleName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2TempleLocation" runat="server">
                            <td class="col1">
                                <img src="Image/Small/location.png" class="icon_left" />
                                สถานที่</td>
                            <td class="col2">
                                <asp:Label ID="lbS2TempleLocation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2OrdainDate" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />
                                อุปสมบทวันที่</td>
                            <td class="col2">
                                <asp:Label ID="lbS2OrdainDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2Hujed" runat="server">
                            <td class="col1">
                                <img src="Image/Small/question.png" class="icon_left" />
                                การไปประกอบพิธีฮัจย์</td>
                            <td class="col2">
                                <asp:Label ID="lbS2Hujed" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2LastFTTDate" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />
                                ลาล่าสุด</td>
                            <td class="col2">
                                <asp:Label ID="lbS2LastFTTDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />วันที่ลา</td>
                            <td class="col2">
                                <asp:Label ID="lbS2FTTDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2Statistic" runat="server">
                            <td class="col1">
                                <img src="Image/Small/calendar.png" class="icon_left" />สถิติการลา</td>
                            <td class="col2">
                                <asp:Label ID="lbS2Statistic" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2Reason" runat="server">
                            <td class="col1">
                                <img src="Image/Small/a.png" class="icon_left" />เหตุผล</td>
                            <td class="col2">
                                <asp:Label ID="lbS2Reason" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2Contact" runat="server">
                            <td class="col1">
                                <img src="Image/Small/a.png" class="icon_left" />ติดต่อได้ที่</td>
                            <td class="col2">
                                <asp:Label ID="lbS2Contact" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2Phone" runat="server">
                            <td class="col1">
                                <img src="Image/Small/phone.png" class="icon_left" />เบอร์โทรศัพท์</td>
                            <td class="col2">
                                <asp:Label ID="lbS2Phone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trS2DrCer" runat="server">
                            <td class="col1">
                                <img src="Image/Small/clip.png" class="icon_left" />ใบรับรองแพทย์</td>
                            <td class="col2">
                                <asp:Label ID="lbS2DrCer" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/person2.png" class="icon_left" />ผู้บังคับบัญชา</td>
                            <td class="col2">
                                <asp:Label ID="lbS2BossLowID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/a.png" class="icon_left" />ความเห็นผู้บังคับบัญชา</td>
                            <td class="col2">
                                <asp:Label ID="lbS2BossLowComment" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/person2.png" class="icon_left" />ผู้อนุมัติ</td>
                            <td class="col2">
                                <asp:Label ID="lbS2BossHighID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/a.png" class="icon_left" />ความเห็นผู้อนุมัติ</td>
                            <td class="col2">
                                <asp:Label ID="lbS2BossHighComment" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <img src="Image/Small/a.png" class="icon_left" />ความเห็นเจ้าหน้าที่</td>
                            <td class="col2">
                                <asp:Label ID="lbS2OfficerComment" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>

                    <div style="text-align: center; margin-top: 10px;">
                        <asp:Button ID="lbuS2Back2" runat="server" CssClass="btn btn-default ekknidRight" OnClick="lbuS2Back_Click" Text="ย้อนกลับ"></asp:Button>
                        <asp:Button ID="lbuS2Finish2" runat="server" CssClass="btn btn-default" OnClick="lbuS2Finish_Click" Text="ยืนคำขอลา"></asp:Button>
                    </div>
                </div>
            </asp:View>

            <asp:View ID="VX_F" runat="server">
                <div class="ps-div-title-red">บันทึกการลาสำเร็จ</div>
                <div style="text-align: center; color: #808080; margin-bottom: 10px;">ระบบได้บันทึกข้อมูลการลาเรียบร้อยแล้ว<br /></div>
                <div style="text-align: center; margin-bottom: 10px;">
                    <asp:Button ID="lbuBackMain" runat="server" CssClass="btn btn-default ekknidRight" OnClick="lbuBackMain_Click" Text="กลับหน้าหลัก"></asp:Button>
                </div>
            </asp:View>

        </asp:MultiView>
        <div class="ps-separator"></div>

    </div>

    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfSql2" runat="server" />
    <asp:HiddenField ID="hfFileUploadName" runat="server" />

</asp:Content>
