<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Personnel.ChangePassword" MaintainScrollPositionOnPostback="true"%>

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

                <div class="login_popup_in2" style="margin-bottom:60px";>              
                <div class="ps-box-i0">

                    <div class="ps-box-ct10">
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuChangePassword">
                        <div id="TitleDivNamePassOld" runat="server">รหัสผ่านเก่า</div>
                        <div id="divPassOld" runat="server" class="well">
                            <asp:TextBox ID="tbPasswordOld" TextMode="Password" runat="server" CssClass="form-control" placeHolder="รหัสผ่านเก่า" required="true" MaxLength="25"></asp:TextBox>
                        </div>
                        <div id="TitleDivNamePassNew" runat="server">รหัสผ่านใหม่</div>
                        <div class="well">
                            <asp:TextBox ID="tbPasswordNew" TextMode="Password" runat="server" CssClass="form-control" placeHolder="รหัสผ่านใหม่" MaxLength="25"></asp:TextBox>
                        </div>
                        <div id="TitleDivNamePassNewAgain" runat="server">รหัสผ่านใหม่อีกครั้ง</div>
                        <div class="well">
                            <asp:TextBox ID="tbPasswordNewAgain" TextMode="Password" runat="server" CssClass="form-control" placeHolder="รหัสผ่านใหม่อีกครั้ง" MaxLength="25"></asp:TextBox>
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