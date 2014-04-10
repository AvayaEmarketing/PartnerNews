<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Version.aspx.cs" Inherits="PartnerNews.Vista.pages.Version" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=device-width,initial-scale=1" />
	<title>AVAYA - Demand Generation Campaigns</title>
    <link href="../css/bootstrap.css" rel="stylesheet"/>
   	<link rel="stylesheet" href="../css/header_style.css"/>
    <link rel="stylesheet" href="../css/version.css"/>
    <link href="../css/bootstrap-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../css/DT_bootstrap.css" rel="stylesheet" type="text/css"/>
    <%--<link href="../css/bootstrap-only-message.css" rel="stylesheet" type="text/css" />--%>

    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap-dialog.js"></script>
    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../js/DT_bootstrap.js"></script>
    <script type="text/javascript" src="../js/Version.js"></script>

</head>
	
<body>
    <header>
		<div id="header">
			<div id="lefth">
				<table id="head" cellpadding="0" cellspacing="0" border="0">
					<tr>
						<td class="date" align="center">
							<span style="font-size:23px; color:#979797;" id="date">Mon</span><br />
							<span style="color:#fff;" >14-</span><span style="color:#fff;" id="month">12</span>
						</td>
						<td class="welcome">
							Welcome<br/>
							<span style="color:#FFFFFF;" id="userName">Sutanito Godinez<br/></span>
							Last Seen: 23/03/13
						</td>
						<td class="headBtn" align="center">
							<img src="../images/menu-18.png"/><br />
							<span class="btn2">My Info</span>
						</td>
						<td class="headBtn" align="center">
							<img src="../images/menu-19.png"/><br />
							<span class="btn2">Favorites</span>
						</td>
						<td class="headBtn" align="center">
							<img src="../images/menu-20.png"/><br />
							<span class="btn2">Edit Settings</span>
						</td>
						<td class="headBtn" align="center">
							<img src="../images/menu-21.png"  align="My Info"/><br />
							<span class="btn2">Sections</span><br />
						</td>
					</tr>
				</table>
			</div>
			<div id="righth">
				<div id="login">
					<img src="../images/logo-alpha.png" alt="" />
					<span class="btn2">Home</span> | <span class="btn2" id="logout">Log Out</span>
				</div>
			</div>
		</div>
    </header>
    <section style="position:relative;top:180px;">
    <div class="container">
        <div class="contentheader">
            <h2>Create New Version</h2>
            <h3>Partner News</h3>
        </div>

            <div class="form-horizontal">

                    <div class="row clearfix">
                        <div class="col-md-4 column">
                            <!-- aqui empieza la primera columna -->
                            <div class="form-group">
                                <label class="col-lg-5 control-label" for="month_version">Select Month </label>
                                <div class="col-lg-5">
                                    <select id="month_version" class="form-control">
                                        <option value="" selected="selected"></option>
                                        <option value="1">January</option>
                                        <option value="2">February</option>
                                        <option value="3">March</option>
                                        <option value="4">April</option>
                                        <option value="5">May</option>
                                        <option value="6">June</option>
                                        <option value="7">July</option>
                                        <option value="8">August</option>
                                        <option value="9">September</option>
                                        <option value="10">October</option>
                                        <option value="11">November</option>
                                        <option value="12">December</option>
                                    </select>
                                </div>
                            </div>
                            </div>
                            <div class="col-md-4 column">
                            <div class="form-group">
                                <label class="col-lg-5 control-label" for="year_version">Select year </label>
                                <div class="col-lg-5">
                                    <select id="year_version" class="form-control">
                                        <option value="" selected="selected"></option>
                                        <option value="2014">2014</option>
                                        <option value="2015">2015</option>
                                        <option value="2016">2016</option>
                                        <option value="2017">2017</option>
                                    </select>
                                </div>
                            </div>
                            </div>
                            <div class="col-md-4 column">
                            <div class="control-group">
                                <div class="controls">
                                    <button style="top: 0 !important;" type="submit" class="btn btn-danger" id="Register">Create</button>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
    
	 </div>
     <div class="container">
            <div class="contentheader">
                <h2>Versions</h2>
                <h3>Partner News</h3>
            </div>

            <table id="datatables" cellpadding="0" cellspacing="0" border="0" style="width: 100%; text-align: center;" class="table table-striped table-bordered">
                <thead id="thead">
                    <tr>
                        <th class="sorting" width="15%">Name </th>
                        <th class="sorting" width="10%">Details T1</th>
                        <th class="sorting" width="10%">Details T2</th>
                    </tr>
                </thead>
                <tbody id="tbody">
                    
                </tbody>
                <tfoot>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </tfoot>
            </table>
     </div>
                    
            
    
    </section>
</body>
</html>
