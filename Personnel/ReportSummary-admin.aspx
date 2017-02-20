<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportSummary-admin.aspx.cs" Inherits="Personnel.ReportSummary_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <script>
        $(function () {
            //Initialize Select2 Elements
            $(".select2").select2();

            //Datemask dd/mm/yyyy
            $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            //Datemask2 mm/dd/yyyy
            $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
            //Money Euro
            $("[data-mask]").inputmask();

            //Date range picker
            $('#reservation').daterangepicker();
            //Date range picker with time picker
            $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' });
            //Date range as a button
            $('#daterange-btn').daterangepicker(
                {
                    ranges: {
                        'Today': [moment(), moment()],
                        'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                        'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                        'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                        'This Month': [moment().startOf('month'), moment().endOf('month')],
                        'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                    },
                    startDate: moment().subtract(29, 'days'),
                    endDate: moment()
                },
            function (start, end) {
                $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            }
            );

            //iCheck for checkbox and radio inputs
            $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                checkboxClass: 'icheckbox_minimal-blue',
                radioClass: 'iradio_minimal-blue'
            });
            //Red color scheme for iCheck
            $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
                checkboxClass: 'icheckbox_minimal-red',
                radioClass: 'iradio_minimal-red'
            });
            //Flat red color scheme for iCheck
            $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });

            //Colorpicker
            $(".my-colorpicker1").colorpicker();
            //color picker with addon
            $(".my-colorpicker2").colorpicker();

            //Timepicker
            $(".timepicker").timepicker({
                showInputs: false
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/search.png" />ค้นหาข้อมูล
        </div>
        <div class="form-group">
            <asp:Label ID="lbCampus" runat="server">วิทยาเขต</asp:Label>
            <asp:DropDownList ID="ddlCampus" runat="server" CssClass="form-control input-sm select2" AutoPostBack="true" Width="250px"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lbDepartment" runat="server">คณะ</asp:Label>
            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control input-sm select2" AutoPostBack="true" Width="250px"></asp:DropDownList>
        </div>
        <div>
            <asp:LinkButton ID="lbuAdd" runat="server" CssClass="ps-button" OnClick="lbuAdd_Click"><img src="Image/Small/add.png" class="icon_left"/>เพิ่ม</asp:LinkButton>
        </div>
        <div class="ps-header">
            <img src="Image/Small/list.png" />ข้อมูล
        </div>
        

        <div>
        <asp:Table ID="Table1" runat="server"></asp:Table>
        </div>

        <div style="text-align:center; margin:auto; margin-top:10px;">
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        </div>
        
    </div>
</asp:Content>
