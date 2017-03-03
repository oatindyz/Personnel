<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageInsig.aspx.cs" Inherits="Personnel.ManageInsig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

            $('#ContentPlaceHolder1_tbGetDate,#ContentPlaceHolder1_tbStartDate12,#ContentPlaceHolder1_tbEndDate12,#ContentPlaceHolder1_tbStartDate14').datetimepicker({
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <asp:Panel ID="Panel1" runat="server">
            <div class="ps-header">
                <img src="Image/Small/medal.png" />จัดการข้อมูลเครื่องราชฯ
                <span style="text-align: right; float: right;"><a href="listInsig-admin.aspx">
                    <img src="Image/Small/back.png" />ย้อนกลับ</a></span>
            </div>
            <div style="text-align: center;">
                <div class="ps-header">
                    <img src="Image/Small/add.png" class="icon_left" />เพิ่มข้อมูลเครื่องราชฯ
                </div>
                <div class="panel-body">
                    <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                        <tr>
                            <td class="col1" style="width: 400px;">
                                <img src="Image/Small/person2.png" class="icon_left" />ชื่อ</td>
                            <td class="col2">
                                <asp:Label ID="lbName" runat="server"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ประเภทบุคลากร</td>
                            <td class="col2">
                                <asp:Label ID="lbStafftype" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">ระดับตำแหน่ง</td>
                            <td class="col2">
                                <asp:Label ID="lbPosition" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">คณะ/หน่วยงานที่สังกัด</td>
                            <td class="col2">
                                <asp:Label ID="lbDepartment" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เครื่องราชฯชั้นล่าสุด</td>
                            <td class="col2">
                                <asp:Label ID="lbLastInsig" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เงินเดือน</td>
                            <td class="col2">
                                <asp:Label ID="lbSalary" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เงินประจำตำแหน่ง</td>
                            <td class="col2">
                                <asp:Label ID="lbPositionSalary" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">เครื่องราชฯชั้นถัดไปที่ได้รับ</td>
                            <td class="col2">
                                <asp:DropDownList ID="ddlInsigItem" runat="server" CssClass="form-control" required="required" TabIndex="1"></asp:DropDownList>
                                <asp:Label ID="lbHighEnd" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">วันที่ได้รับชั้นเครื่องราชฯ</td>
                            <td class="col2">
                                <asp:TextBox ID="tbGetDate" runat="server" CssClass="form-control input-sm" required="required" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                    <div style="text-align: center; margin-top: 10px;">
                        <asp:Button ID="btnSaveInsig" runat="server" CssClass="btn btn-success ekknidRight" Text="บันทึก" OnClick="btnSaveInsig_Click"></asp:Button>
                        <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="if (!confirm('คุณต้องการจะลบใช่หรือไม่ ?')) return false;" CssClass="btn btn-danger" Text="ลบเครื่องราชฯชั้นล่าสุด" OnClick="btnDelete_Click"></asp:LinkButton>
                    </div>
                </div>

                <div id="divLoadInsig" runat="server" class="dataTable_wrapper ekknidTop">
                    <div class="ps-header">
                        <img src="Image/Small/list.png" />ข้อมูล
                    </div>
                    <div style="margin-top: 10px; overflow-x: auto; width: 100%;">
                        <asp:GridView ID="GridViewInsig" runat="server" Style="margin-left: auto; margin-right: auto;"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            DataKeyNames="INSIG_ID"
                            OnPageIndexChanging="myGridViewInsig_PageIndexChanging" PageSize="12" CssClass="table table-striped table-bordered table-condensed" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="ลำดับที่" ControlStyle-CssClass="center100">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อชั้นเครื่องราชฯ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProUOC_ID11" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.INSIG_ITEM_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="วันที่ได้รับชั้นเครื่องราชฯ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbGetDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.INSIG_GET_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbGetDate" runat="server" CssClass="date1 form-control input-sm" Text='<%# DataBinder.Eval(Container, "DataItem.INSIG_ITEM_ID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

            </div>
        </asp:Panel>

    </div>
</asp:Content>
