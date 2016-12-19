<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Personnel.Default" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .complete_center {
            font-size: 16px;
        }
        /*.ps-box-il-ms {
            margin-right: 20px;
            margin-bottom: 20px;
            vertical-align: top;
        }*/
        .c1 {
            font-size: 64px;
            text-align: center;
            color: #a0a0a0;
            margin-top: 50px;
        }
        .c2 {
            font-size: 23px;
            color: #808080;
            margin-top: 50px;
            text-align: center;
        }
        .c2_2 {
            display: inline-block;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="c1">
            ยินดีต้อนรับสู่ระบบบุคลากร
        </div>
        <div class="c2">
            <div class="c2_2">
                <div>
                กดปุ่ม <img src="Image/x32/menu.png" /> เพื่อเลือกเมนูการใช้งาน
            </div>
            </div>
            
        </div>
        <div class="ps-separator" style="margin-top: 50px;"></div>
    
    <!-- Carousel
    ================================================== -->
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
      <!-- Indicators -->
      <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
      </ol>
      <div class="carousel-inner" role="listbox">
        <div class="item active">
          <img class="first-slide" src="Image/rmutto_1280x480.jpg" alt="First slide">
          <div class="container">
            <div class="carousel-caption">
              <!--<h1>Example headline.</h1>
              <p>Note: If you're viewing this page via a <code>file://</code> URL, the "next" and "previous" Glyphicon buttons on the left and right might not load/display properly due to web browser security rules.</p>
              <p><a class="btn btn-lg btn-primary" href="#" role="button">Sign up today</a></p>-->
            </div>
          </div>
        </div>
        <div class="item">
          <img class="second-slide" src="Image/rmutto_1280x480.jpg" alt="Second slide">
          <div class="container">
            <div class="carousel-caption">
              <!--<h1>Another example headline.</h1>
              <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
              <p><a class="btn btn-lg btn-primary" href="#" role="button">Learn more</a></p>-->
            </div>
          </div>
        </div>
        <div class="item">
          <img class="third-slide" src="Image/rmutto_1280x480.jpg" alt="Third slide">
          <div class="container">
            <div class="carousel-caption">
              <!--<h1>One more for good measure.</h1>
              <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
              <p><a class="btn btn-lg btn-primary" href="#" role="button">Browse gallery</a></p>-->
            </div>
          </div>
        </div>
      </div>
      <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
      </a>
      <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>

        <span class="sr-only">Next</span>
      </a>
    </div><!-- /.carousel -->
    </div>
</asp:Content>
