﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="Personnel.Access" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="icon" href="Image/favicon.ico" />
    <title>ระบบบุคลากร - มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</title>
    <link rel="stylesheet" type="text/css" href="CSS/Master.css" />
    <link href="CSS/Access.css" rel="stylesheet" />

    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- daterange picker -->
    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker-bs3.css" />
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="plugins/iCheck/all.css" />
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="plugins/colorpicker/bootstrap-colorpicker.min.css" />
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="plugins/timepicker/bootstrap-timepicker.min.css" />
    <!-- Select2 -->
    <link rel="stylesheet" href="plugins/select2/select2.min.css" />

    <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <!-- Select2 -->
    <script src="plugins/select2/select2.full.min.js"></script>
    <!-- InputMask -->
    <script src="plugins/input-mask/jquery.inputmask.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <!-- date-range-picker -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
    <script src="plugins/daterangepicker/daterangepicker.js"></script>
    <!-- bootstrap color picker -->
    <script src="plugins/colorpicker/bootstrap-colorpicker.min.js"></script>
    <!-- bootstrap time picker -->
    <script src="plugins/timepicker/bootstrap-timepicker.min.js"></script>
    <!-- SlimScroll 1.3.0 -->
    <script src="plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- iCheck 1.0.1 -->
    <script src="plugins/iCheck/icheck.min.js"></script>
    <!-- FastClick -->
    <script src="plugins/fastclick/fastclick.min.js"></script>
    
    <!-- Page script -->
    <script src="jquery.datetimepicker.js"></script>
    <!-- -->

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
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57)) {
                $("#errmsg").html("Digits Only").show().fadeOut("slow");
                return false;
            }
            return true;
        }
    </script>

    <script type="text/javascript">
        function RefreshUpdatePanel() {
            if (this.value.length != 13) return false;
            if (this.value.length == 13) __doPostBack('<%= tbUsername.ClientID %>', ''); return true;
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
                                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">
                                    <div class="well input-group date">
                                        <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" MaxLength="13" placeHolder="รหัสประชาชน" onkeyup="RefreshUpdatePanel();" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="tbUsername_TextChanged" required="required" TabIndex="1"></asp:TextBox>
                                        <div class="input-group-addon"><span class="glyphicon glyphicon-user"></span></div>
                                    </div>
                                    <div>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="LabelTop" runat="server" CssClass="cerror"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="well input-group date" data-provide="datepicker" data-date-format="mm/dd/yyyy">
                                        <asp:UpdatePanel ID="UpdatetbPassword" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" CssClass="form-control" placeHolder="รหัสผ่าน" MaxLength="25" required="required" TabIndex="1"></asp:TextBox>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="tbPassword" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <div class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></div>
                                    </div>
                                    <div>
                                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-info" OnClick="btnLogin_Click" Text="เข้าสู่ระบบ" />
                                    </div>
                                    <div>
                                        <asp:UpdatePanel ID="UpdateLabel12X" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="LabelBottom" runat="server" CssClass="cerror"></asp:Label>
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
