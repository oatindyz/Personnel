<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataManager.aspx.cs" Inherits="Personnel.DataManager" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="ps-header">
            <img src="Image/Small/wrench.png" />แก้ไขข้อมูลตัวเลือก (Dropdown List)
        </div>
        <div style="text-align: center;">
            <div class="ps-box-il" style="vertical-align: top; margin-right: 10px;">
                <div class="ps-box-i0">
                    <div class="ps-box-hd10"><img src="Image/Small/person2.png" class="icon_left"/>จัดการข้อมูลบุคลากร</div>
                </div>
                <div class="ps-box-i0">
                    <div class="ps-box-ct10" style="text-align: left;">
                        <div style="display: inline-block; vertical-align: top; margin-right: 10px;">
                            <div><a href="ManageTimecontact-admin.aspx" class="ps-link" ><img src="Image/Small/wrench.png" class="icon_left"/>ระยะเวลาจ้าง</a></div>
                        </div>
 
                    </div>
                </div>
            </div>
        </div>
        <div class="ps-separator"></div>  
    </div>
</asp:Content>