<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Personnel.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $('#ContentPlaceHolder1_xx,#datePassword').datetimepicker({
                yearOffset: 543,
                format: "d/m/Y",
                formatDate: "d/m/Y"
            });
        });
    </script>
    <script type="text/javascript">
        function ShowHidePassword() {
            var txt = $('#<%=tbPasswordOld.ClientID%>');
            if (txt.prop("type") == "password") {
                txt.prop("type", "text");
                $("label[for='cbShowHidePassword']").text("Hide Password");
            }
            else {
                txt.prop("type", "password");
                $("label[for='cbShowHidePassword']").text("Show Password");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-header"><img src="Image/change_password.png" />เปลี่ยนรหัสผ่าน</div>

    <p class="text-danger"><asp:Literal runat="server" ID="ErrorMessage" /></p>
    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                <div class="login_popup_in2" style="margin-bottom:60px";>              
                <div class="ps-box-i0">

                    <div class="ps-box-ct10">
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuChangePassword">
                        <div>รหัสผ่านเก่า</div>
                        <div id="divPassOld" runat="server" class="well">
                            <asp:TextBox ID="tbPasswordOld" TextMode="Password" runat="server" CssClass="form-control" placeHolder="รหัสผ่านเก่า" MaxLength="25"></asp:TextBox>
                            <asp:RequiredFieldValidator id="RqIDold" runat="server" ControlToValidate="tbPasswordOld" CssClass="text-danger" ErrorMessage="กรุณากรอกรหัสผ่านเก่า" />
                        </div>
                        <div>รหัสผ่านใหม่</div>
                        <div class="well">
                            <asp:TextBox ID="tbPasswordNew" TextMode="Password" runat="server" CssClass="form-control" placeHolder="รหัสผ่านใหม่" MaxLength="25"></asp:TextBox>
                            <asp:RequiredFieldValidator id="RqIDnew" runat="server" ControlToValidate="tbPasswordOld" CssClass="text-danger" ErrorMessage="กรุณากรอกรหัสผ่านใหม่" />
                        </div>
                        <div>รหัสผ่านใหม่อีกครั้ง</div>
                        <div class="well">
                            <asp:TextBox ID="tbPasswordNewAgain" TextMode="Password" runat="server" CssClass="form-control" placeHolder="รหัสผ่านใหม่อีกครั้ง" MaxLength="25"></asp:TextBox>
                            <asp:RequiredFieldValidator id="RqIDnewAgain" runat="server" ControlToValidate="tbPasswordOld" CssClass="text-danger" ErrorMessage="กรุณากรอกรหัสผ่านใหม่อีกครั้ง" />
                            <asp:CompareValidator runat="server" ControlToCompare="tbPasswordNew" ControlToValidate="tbPasswordNewAgain" CssClass="text-danger" Display="Dynamic" ErrorMessage="รหัสผ่านใหม่และรหัสผ่านใหม่อีกครั้งไม่ตรงกัน" />
                        </div>
                        <asp:LinkButton ID="lbuChangePassword" runat="server" OnClick="lbuChangePassword_Click" CssClass="btn btn-primary"><img src="Image/Small/key.png" class="icon_left"/>เปลี่ยนรหัสผ่าน</asp:LinkButton>
                        <div style="margin-top:20px; margin-left:20px">
                            <asp:Label ID="Label12X" runat="server" CssClass="cerror"></asp:Label>
                        </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

</asp:Content>