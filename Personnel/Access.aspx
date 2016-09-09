<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="Personnel.Access" MaintainScrollPositionOnPostback="true" %>

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
    <script>
        function SubmitContent(value) {
            document.getElementById('myspan').style.visibility = 'hidden';
            document.getElementById('myspan').style.visibility = 'visible';

            var poststr = "User=" + encodeURI(document.getElementById('CITIZEN_ID').value);
            CallPOSTRequest('ajax2.php', poststr);

        }
    </script>
    <script type="text/javascript">
        function Numbers(e) {
            var keynum;
            var keychar;
            var numcheck;
            if (window.event) {// IE
                keynum = e.keyCode;
            }
            else if (e.which) {// Netscape/Firefox/Opera
                keynum = e.which;
            }
            if (keynum == 13 || keynum == 8 || typeof (keynum) == "undefined") {
                return true;
            }
            keychar = String.fromCharCode(keynum);
            numcheck = /^[0-9]$/;
            return numcheck.test(keychar);
        }

        function keyup(obj, e) {
            var keynum;
            var keychar;
            var id = '';
            if (window.event) {// IE
                keynum = e.keyCode;
            }
            else if (e.which) {// Netscape/Firefox/Opera
                keynum = e.which;
            }
            keychar = String.fromCharCode(keynum);

            var tagInput = document.getElementById('CITIZEN_ID').value;

            if (obj.value.length == 13) {

                if (checkID(tagInput)) {
                    SubmitContent();
                    nextObj.focus();
                }
                else {
                    alert('รหัสประชาชนไม่ถูกต้อง');
                    document.getElementById('CITIZEN_ID').value = "";
                    nextObj.focus();
                }

            }
        }

        function checkID(id) {
            if (id.length != 13) return false;
            for (i = 0, sum = 0; i < 12; i++)
                sum += parseFloat(id.charAt(i)) * (13 - i);
            if ((11 - sum % 11) % 10 != parseFloat(id.charAt(12)))
                return false;
            return true;

        }
    </script>

    <script type="text/javascript">
        function RefreshUpdatePanel() {
            __doPostBack('<%= tbUsername.ClientID %>', '').value().length == 13;
        };
    </script>

    <style type="text/css">
        .center {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" CssClass="center">
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
                                <asp:Panel ID="Panel2" runat="server" DefaultButton="lbuLogin">
                                    <div class="well">
                                        <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" MaxLength="13" placeHolder="รหัสประชาชน" onkeyup="RefreshUpdatePanel();" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="tbUsername_TextChanged"></asp:TextBox>
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
                                        <div class="input-group-addon"><span id="datePassword" class="glyphicon glyphicon-calendar"></span></div>
                                        <asp:CheckBox ID="ShowHide" runat="server" onclick="ShowHidePassword();" />แสดงรหัสผ่าน
                                    </div>

                                    <div class="well">
                                        <asp:LinkButton ID="lbuLogin" runat="server" OnClick="lbuLogin_Click" CssClass="ps-button" Style="font-size: 16px; margin-top: 2px;"><img src="Image/Small/key.png" class="icon_left"/>เข้าสู่ระบบ</asp:LinkButton>
                                    </div>
                                    <div>
                                        <asp:UpdatePanel ID="UpdateLabel12X" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="Label12X" runat="server" CssClass="cerror"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="ps-box-i0">
                                        <div class="ps-box-hd10-cen">
                                            <img src="Image/Small/web.png" class="icon_left" />เว็บไซต์ในสถาบัน
                                        </div>
                                        <div class="ps-box-ct10-cen">
                                            <div class="web-link">
                                                <a href="http://www.rmutto.ac.th">บางพระ</a>
                                                <a href="http://www.chan.rmutto.ac.th">จันทบุรี</a>
                                                <a href="http://www.cpc.rmutto.ac.th">จักรพงษภูวนารถ</a>
                                                <a href="http://www.uthen.rmutto.ac.th">อุเทนถวาย</a>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
