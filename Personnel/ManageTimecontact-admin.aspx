<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageTimecontact-admin.aspx.cs" Inherits="Personnel.ManageTimecontact_admin" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divpan {
            text-align: center;
        }

        .center1 {
            display: inline-block;
        }
    </style>
    <script type = "text/javascript">
    function DisableButton() {
        document.getElementById("<%=lbuSubmit.ClientID %>").disabled = true;
    }
    window.onbeforeunload = DisableButton;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="divpan" DefaultButton="lbuSearch">
        <div>
            <div class="ps-header">
                <img src="Image/Small/search.png" />ค้นหาข้อมูล
            </div>
            <div>
                รหัสระยะเวลาจ้าง :&nbsp<asp:TextBox ID="txtSearchIDtimecon" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="2"></asp:TextBox>
                ชื่อระยะเวลาจ้าง :&nbsp<asp:TextBox ID="txtSearchNametimecon" runat="server" CssClass="ps-textbox" Width="230px" MaxLength="255"></asp:TextBox>
                <asp:LinkButton ID="lbuSearch" runat="server" OnClick="lbuSearch_Click" CssClass="ps-button"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                <asp:LinkButton ID="lbuRefresh" runat="server" OnClick="lbuRefresh_Click" CssClass="ps-button"><img src="Image/Small/refresh.png" class="icon_left"/>รีเฟรช</asp:LinkButton>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="divpan" DefaultButton="lbuSubmit">
        <div>
            <div class="ps-header">
                <img src="Image/Small/Add.png" />เพิ่มข้อมูล
            </div>
            <div>
                <table class="center1">
                    <tr>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">รหัสระยะเวลาจ้าง :</td>
                        <td style="text-align: left; width: 100px;">
                            <asp:TextBox ID="txtInsertIDtimecon" runat="server" CssClass="ps-textbox" MaxLength="2" Width="230px"></asp:TextBox></td>
                        <td style="margin-left: auto; margin-right: auto; text-align: center">ชื่อระยะเวลาจ้าง :</td>
                        <td style="text-align: left; width: 100px;">
                            <asp:TextBox ID="txtInsertNametimecon" runat="server" CssClass="ps-textbox" MaxLength="255" Width="230px"></asp:TextBox></td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lbuSubmit" runat="server" OnClick="lbuSubmit_Click" CssClass="ps-button"><img src="Image/Small/save.png" class="icon_left"/>ตกลง</asp:LinkButton></td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lbuCancel" runat="server" OnClick="lbuCancel_Click" CssClass="ps-button"><img src="Image/Small/cancel.png" class="icon_left"/>ยกเลิก</asp:LinkButton></td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <div class="ps-header">
                <img src="Image/Small/list.png" />ข้อมูล
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" Style="margin-left: auto; margin-right: auto; text-align: center;"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        DataKeyNames="TIME_CONTACT_ID"
                        OnRowEditing="modEditCommand"
                        OnRowCancelingEdit="modCancelCommand"
                        OnRowUpdating="modUpdateCommand"
                        OnRowDeleting="modDeleteCommand"
                        OnRowDataBound="GridView1_RowDataBound"
                        OnPageIndexChanging="myGridViewTimecontact_PageIndexChanging" PageSize="15" CssClass="ps-table-1">
                        <Columns>
                            <asp:TemplateField HeaderText="รหัสระยะเวลาจ้าง" ControlStyle-Width="350">
                                <ItemTemplate>
                                    <asp:Label ID="lblIDtimeconEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIME_CONTACT_ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtIDtimeconEdit" MaxLength="10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIME_CONTACT_ID") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อระยะเวลาจ้าง" ControlStyle-Width="350">
                                <ItemTemplate>
                                    <asp:Label ID="lblNametimeconEdit" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIME_CONTACT_NAME") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNametimeconEdit" MaxLength="100" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIME_CONTACT_NAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="แก้ไข" />
                            <asp:TemplateField HeaderText="ลบ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton1" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Gridview1" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
</asp:Content>