<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Personnel.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div>
        <div class="ps-header"><img src="Image/change_password.png" />เปลี่ยนรหัสผ่าน</div>
        <div>

                <div class="ps-box-i0">
                    <div class="ps-box-ct10">
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuChangePassword">
                        <div class="well">
                            <label for="current_password" class="control-label">รหัสผ่านเก่า</label>
                            <asp:TextBox ID="tbPasswordOld" runat="server" CssClass="form-control" placeHolder="รหัสผ่านเก่า"></asp:TextBox>
                        </div>
                        <div class="well">
                            <label for="new_password_again" class="control-label">รหัสผ่านใหม่</label>
                            <asp:TextBox ID="tbPasswordNew" runat="server" CssClass="form-control" placeHolder="รหัสผ่านใหม่"></asp:TextBox>
                        </div>
                        <div class="well">
                            <label for="confirm_password" class="control-label">รหัสผ่านใหม่อีกครั้ง</label>
                            <asp:TextBox ID="tbPasswordNewAgain" runat="server" CssClass="form-control" placeHolder="รหัสผ่านใหม่อีกครั้ง"></asp:TextBox>
                        </div>
                        <asp:LinkButton ID="lbuChangePassword" runat="server" OnClick="lbuChangePassword_Click" CssClass="btn btn-primary"><img src="Image/Small/key.png" class="icon_left"/>เปลี่ยนรหัสผ่าน</asp:LinkButton>
                        <div style="margin-top:20px; margin-left:20px">
                            <asp:Label ID="Label12X" runat="server" CssClass="cerror"></asp:Label>
                        </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        

        <div class="ps-separator"></div>
        
    </div>
</asp:Content>
