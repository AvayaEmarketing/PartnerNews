﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Version.aspx.cs" Inherits="PartnerNews.Vista.pages.Version" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=device-width,initial-scale=1" />
	<title>AVAYA - Demand Generation Campaigns</title>
    <link href="../css/bootstrap.css" rel="stylesheet"/>
   	<link rel="stylesheet" href="../css/header_style.css"/>
    <link rel="stylesheet" href="../css/styles.css"/>
    <link href="../css/bootstrap-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../css/DT_bootstrap.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="../js/jquery.js"></script>
     <script type="text/javascript" src="../js/modernizr.js"></script>
    <script type="text/javascript" src="../js/MatchMedia.js"></script>
    <script type="text/javascript" src="../js/enquire.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap-dialog.js"></script>
    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../js/DT_bootstrap.js"></script>
    <script type="text/javascript" src="../js/funciones.js"></script>
    <script type="text/javascript" src="../js/Version.js"></script>

</head>
	
<body>
    <header>
		<div id="menu_top">
            <div id="inner_menu_top">
                <div id="logo_p_n">
                    <img src="../images/site-30.jpg" />
                </div>
                <div id="buttons_menu_top">
                    <div class="btn_menu_info">
                        Bienvenido<br />
                        <span class="name">Juan Carlos Muñoz Rojas</span><br />
                        <a href="#" id="goHome">Home</a> - <a href="#" id="logOut">Log Out</a>
                    </div>
                    <div id="menu_container">
                        <a class="linked_menu" href="#">
                            <div class="btn_menu">
                                <img src="../images/site-31.jpg" /><br class="dissapear_br" />
                                My Info
     
                            </div>
                        </a>
                        <a class="linked_menu" href="#">
                            <div class="btn_menu">
                                <img src="../images/site-32.jpg" /><br class="dissapear_br" />
                                My History
   
                            </div>
                        </a>
                        <a class="linked_menu" href="#">
                            <div class="btn_menu">
                                <img src="../images/site.jpg" /><br class="dissapear_br" />
                                Edit Seetings
   
                            </div>
                        </a>
                    </div>
                </div>
                <div id="logo_avaya">
                    <img src="../images/site-34.jpg" /><br />
                    March 21 - 2014&nbsp;&nbsp;&nbsp;&nbsp;
 
                </div>
            </div>
        </div>
    </header>
    <section style="position:relative;top:30px;">
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
                                <label class="col-lg-5 control-label" for="month_version" id="selmonth">Month </label>
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
                                <label class="col-lg-5 control-label" for="year_version" id="selyear">Select year </label>
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
                                <div class="controls" id="btnCreate">
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
