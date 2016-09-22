<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testpage1.aspx.cs" Inherits="Personnel.testpage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
$('form').bootstrap3Validate(function(e, data) {
	e.preventDefault();
    alert(JSON.stringify(data));
});
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ps-header">
        <img src="Image/Small/edit.png" />แก้ไขข้อมูลบุคลากร
    </div>
       <div class='container'>
	<div class="row">
		<div class="col-lg-12">
			<small>
				<p>you can not open this file with browser directly because of JQuery and Bootstrap CDN links</p>
				<ul>
					<li><b>Use PHP:</b>$ php -S 0.0.0.0:8000 <b> then open </b> http://localhost:8000</li>
					<li><b>Use Python2:</b>$ python -m SimpleHTTPServer <b> then open </b> http://localhost:8000</li>
					<li><b>Use Python3:</b>$ python -m http.server 8000 <b> then open </b> http://localhost:8000</li>
					<li>Or use any HTTP server that you want (Just copy the file somewhere)</li>
				</ul>
			</small>
		</div>
	</div>

	<div class="row">
		<div class="col-md-3">
			<div class="well">

				<!-- sample form1 -->
				<form>
					<feildset>
						<div class="form-group">
							<label class="control-label">Email:</label>
							<input data-title="Please use valid Email address" name="email" class="form-control" data-require="" placeholder="Subscriber email" data-regex="email" />
						</div>
						<div class="form-group">
							<label class="control-label">Gender:</label>
							<select data-title="Please select gender" name="gender" class="form-control" required>
								<option value="">Choose</option>
								<option value="mail">Male</option>
								<option value="female">Female</option>
							</select>
						</div>
						<div class="form-group">
							<label class="control-label">Password:</label>
							<input data-title="Please enter valid password" required name="name" class="form-control" placeholder="Subscriber name" />
						</div>
						<div class="alert alert-danger">

						</div>
						<div class="form-group text-center">
							<button class="btn btn-default" type="submit">Submit</button>
						</div>
					</feildset>
				</form>


			</div>
		</div>
		<div class="col-md-3">
			<div class="well">

				<!-- sample form2 -->
				<form>
					<feildset>
						<div class="form-group" style="margin: 0">
							<div class="checkbox">
								<label>
									<!-- we use 'data-required' not 'required' for checkbox, beacuse in non-script mode, browser force user to check them all -->
									<input data-title="Select First, Second or Third" data-required='' name="item" type="checkbox" value="1" />First
								</label>
							</div>
						</div>
						<div class="form-group" style="margin: 0">
							<div class="checkbox">
								<label>
									<input data-required='' name="item" type="checkbox" value="2" />Second
								</label>
							</div>
						</div>
						<div class="form-group" style="margin: 0">
							<div class="checkbox">
								<label>
									<input data-required='' name="item" type="checkbox" value="3" />Third
								</label>
							</div>
						</div>
						<div class="form-group">
							<label class="control-label">Name:</label>
							<input data-title="Please enter your name" name="email" class="form-control" required placeholder="Your name" data-regex="^(?![0-9]).*?$" />
							<!-- ^(?![0-9]).*?$   means should not start with number -->
						</div>
						<div class="form-group">
							<label class="control-label">Date:</label>
							<input data-title="Please enter your name" name="date" class="form-control" required placeholder="Date plz!" type="date" />
						</div>
						<div class="alert alert-danger">

						</div>
						<div class="form-group text-center">
							<button class="btn btn-default" type="submit">Submit</button>
						</div>
					</feildset>


				</form>
			</div>
		</div>
		<div class="col-md-3">
			<div class="well">

				<!-- sample form3 -->
				<form>
					<feildset>
						<div class="form-group">
							<label class="control-label">Zip code:</label>
							<input data-title="Should be numeric with at least 6 number" name="zip" class="form-control" required data-regex="^[0-9]{6,20}$" />
						</div>
						<div class="alert alert-danger">

						</div>
						<div class="form-group text-center">
							<button class="btn btn-default" type="submit">Submit</button>
						</div>
					</feildset>


				</form>
			</div>
		</div>
	</div>

</div>

</asp:Content>
