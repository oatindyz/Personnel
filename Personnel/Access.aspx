<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="Personnel.Access" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script>
        $(function () {
            $('#ContentPlaceHolder1_xx,#datePassword').datetimepicker({
                yearOffset: 543,
                format:"d/m/Y",
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

    <style type="text/css">
        .col1 {
            text-align: right;
        }

        .col2 {
            text-align: left;
        }

        .textred {
            color: red;
        }

        .center {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" CssClass="center">
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
                            <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" MaxLength="13" placeHolder="รหัสประชาชน" onkeypress="return isNumberKey(event)"></asp:TextBox>
                        </div>

                        <div class="well input-group date" data-provide="datepicker" data-date-format="mm/dd/yyyy">
                            <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" CssClass="form-control" placeHolder="รหัสผ่าน" MaxLength="20"></asp:TextBox>
                        <div class="input-group-addon"><span id="datePassword" class="glyphicon glyphicon-calendar"></span></div>
                            <asp:CheckBox ID="ShowHide" runat="server" onclick="ShowHidePassword();" />แสดงรหัสผ่าน
                        </div>
                        
                
                        <div class="well">
                            <asp:LinkButton ID="lbuLogin" runat="server" OnClick="lbuLogin_Click" CssClass="ps-button" Style="font-size: 16px; margin-top: 2px;"><img src="Image/Small/key.png" class="icon_left"/>เข้าสู่ระบบ</asp:LinkButton>
                        </div>
                        <div>
                            <asp:Label ID="Label12X" runat="server" CssClass="cerror"></asp:Label>
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
                    </asp:Panel>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>