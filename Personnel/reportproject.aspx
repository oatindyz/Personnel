<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reportproject.aspx.cs" Inherits="Personnel.reportproject" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/copy.png" />ออกรายงานข้อมูลอบรม/สัมมนา/ดูงาน
        </div>
    <div style="margin-bottom:10px">
        <asp:LinkButton ID="lbuExport" runat="server" CssClass="ps-button" OnClick="lbuExport_Click"><img src="Image/Small/word.png" class="icon_left"/>ออกรายงาน WORD</asp:LinkButton>
    </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <table id="tb" runat="server" style="width: 100%">
                    <tr>
                        <td colspan="4"  style="width: 100px; text-align: center;">
                            <img src="http://localhost:8712/Image/RMUTTO.png" width="100" height="160" class="centered" style="text-align: center; margin: auto" /></td>
                    </tr>
                    <tr>
                        <td colspan="4"  style="width: 100px; text-align: center;"><strong>แบบรายงานการฝึกอบรม/สัมมนา/ดูงาน</strong></td>
                    </tr>
                    <tr>
                        <td colspan="4"  style="width: 100px; text-align: center;"><strong>มหาวิทยาลัยเทคโนโลยีราชมงคลตะวันออก</strong></td>
                    </tr>
                    <tr>
                        <td colspan="4"  style="width: 100px; text-align: center;"><strong>***********************************************************</strong></td>
                    </tr>
                    <tr>
                        <td><strong>1.</strong></td>
                        <td ><strong>ชื่อ-สกุล : &nbsp;&nbsp;&nbsp;&nbsp; </strong>
                            <asp:Label ID="lbName" runat="server"></asp:Label></td>
                        <td ><strong>ตำแหน่ง : &nbsp;&nbsp;&nbsp;&nbsp; </strong>
                            <asp:Label ID="lbPosition" runat="server"></asp:Label></td>
                        <td ><strong>ระดับ : &nbsp;&nbsp;&nbsp;&nbsp; </strong>
                            <asp:Label ID="lbDegree" runat="server" Text="-"></asp:Label></td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td colspan="3" ><strong>สังกัด : &nbsp;&nbsp;&nbsp;&nbsp; </strong>
                            <asp:Label ID="lbDepartment" runat="server" CssClass="underline"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>2.</strong></td>
                        <td colspan="3" ><strong>ชื่อโครงการฝึกอบรม/สัมมนา/ดูงาน :
                            <asp:Label ID="lbNameProject" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td><strong>3.</strong></td>
                        <td colspan="3" ><strong>สถานที่ฝึกอบรม/สัมมนา/ดูงาน :
                            <asp:Label ID="lbAddressProject" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td colspan="3" ><strong>ระยะเวลาการฝึกอบรม/สัมมนา/ดูงาน ตั้งแต่วันที่  :
                            <asp:Label ID="lbDateStart" runat="server"></asp:Label>
                            ถึงวันที่  :
                            <asp:Label ID="lbDateEnd" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td colspan="3" ><strong>รวมเวลา :
                            <asp:Label ID="lbcalYear" runat="server"></asp:Label>
                            ปี
                            <asp:Label ID="lbcalMonth" runat="server"></asp:Label>
                            : เดือน
                            <asp:Label ID="lbcalDay" runat="server"></asp:Label>
                            : วัน ค่าใช้จ่ายตลอดโครงการ  :
                            <asp:Label ID="lbExpense" runat="server"></asp:Label>
                            บาท</strong></td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td colspan="3" ><strong>แหล่งงบประมาณที่ได้รับการสนับสนุน : </strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbFunding" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>4.</strong></td>
                        <td colspan="3" ><strong>ประกาศนียบัตรที่ได้รับ : </strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbCertificate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>5.</strong></td>
                        <td colspan="3" ><strong>สรุปผลการอบรม/สัมมนา/ดูงาน</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbSummaryProject" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>6.</strong></td>
                        <td colspan="3" ><strong>ผลที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbResultProject" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>7.</strong></td>
                        <td colspan="3" ><strong>การนำผลงานที่ได้รับจากการฝึกอบรม/สัมมนา/ดูงาน</strong></td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td colspan="3" ><strong>7.1 ด้านการเรียนการสอน</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbResultTeaching" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td colspan="3" ><strong>7.2 ด้านการวิจัย</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbResultResearching" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td colspan="3" ><strong>7.3 ด้านการบริการวิชาการ</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbResultAcademic" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td ></td>
                        <td colspan="3" ><strong>7.4 ด้านอื่นๆ</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbResultOther" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>8.</strong></td>
                        <td colspan="3" ><strong>ปัญหาอุปสรรคในการฝึกอบรม/สัมมนา/ดูงาน</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbDifficultyProject" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>9.</strong></td>
                        <td colspan="3" ><strong>ความคิดเห็น/ข้อเสนอแนะอื่นๆ</strong></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3">
                            <asp:Label ID="lbCounsel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td colspan="3" style="text-align: center;">ลงชื่อ..............................................ผู้รายงาน</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td colspan="3" style="text-align: center;">(...............................................)</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td colspan="3" style="text-align: center;">........../............/...........</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div style="text-align: center; margin-top: 10px;">
        <a href="listproject.aspx" class="btn btn-info">ย้อนกลับ</a>
    </div>
</asp:Content>
