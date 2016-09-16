<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="Personnel.Access" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="icon" href="Image/favicon.ico" />
    <title>ระบบบุคลากร - มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</title>
    <link rel="stylesheet" type="text/css" href="CSS/Master.css" />
    <link href="CSS/Access.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <script type="text/javascript">
        function ShowHidePassword() {
            var txt = $('#<%=tbPassword.ClientID%>');
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
    <script type="text/javascript">
        function RefreshUpdatePanel() {
            if (this.value.length == 13) __doPostBack('<%= tbUsername.ClientID %>', '');
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="login_popup">
            <div class="login_popup_in_access">
                <div class="login_popup_in2">
                    <div class="ps-box-il" style="width: 400px;">
                        <div class="ps-box-i0">
                            <div class="ps-box-ct10-cen">
                                <img class="login_logo" src="Image/RMUTTO.png" />
                                <div class="t1">ระบบบุคลากร</div>
                                <div class="t2">มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</div>
                            </div>
                        </div>
                        <div class="ps-box-i0">
                            <div class="ps-box-ct10-cen">
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuLogin">
                                    <div class="well input-group date">
                                        <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" MaxLength="13" placeHolder="รหัสประชาชน" onkeyup="RefreshUpdatePanel();" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="tbUsername_TextChanged"></asp:TextBox>
                                        <div class="input-group-addon"><span class="glyphicon glyphicon-user"></span></div>
                                    </div>
                                    <div class="well input-group date" data-provide="datepicker" data-date-format="mm/dd/yyyy">
                                        <asp:UpdatePanel ID="UpdatetbPassword" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" CssClass="form-control" placeHolder="รหัสผ่าน" MaxLength="25"></asp:TextBox>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="tbPassword" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <div class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></div>
                                    </div>
                                    <div>
                                        <asp:LinkButton ID="lbuLogin" runat="server" OnClick="lbuLogin_Click" CssClass="ps-button" Style="font-size: 16px; margin-top: 2px;"><img src="Image/Small/key.png" class="icon_left"/>เข้าสู่ระบบ</asp:LinkButton>
                                    </div>
                                    <div>
                                        <asp:UpdatePanel ID="UpdateLabel12X" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="Label12X" runat="server" CssClass="cerror"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="ps-box-i0">
                        <div class="ps-box-hd10-cen">
                            <img src="Image/Small/web.png" class="icon_left" />เว็บไซต์ในสถาบัน</div>
                        <div class="ps-box-ct10-cen">
                            <div class="web-link">
                                <a href="http://www.rmutto.ac.th">บางพระ</a>
                                <a href="http://www.chan.rmutto.ac.th">จันทบุรี</a>
                                <a href="http://www.cpc.rmutto.ac.th">จักรพงษภูวนารถ</a>
                                <a href="http://www.uthen.rmutto.ac.th">อุเทนถวาย</a>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
