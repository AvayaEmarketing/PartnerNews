<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ver_ediciones.aspx.cs" Inherits="PartnerNews.Vista.pages.ver_ediciones" %>

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
    <style>
        .dataTables_wrapper {
            width:100%!important;
        }
    </style>

   <%-- <link href="../css/bootstrap-modal.css" rel="stylesheet" type="text/css"/>--%>

    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/modernizr.js"></script>
    <script type="text/javascript" src="../js/MatchMedia.js"></script>
    <script type="text/javascript" src="../js/enquire.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap-dialog.js"></script>
    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../js/DT_bootstrap.js"></script>
   
    <script type="text/javascript" src="../js/bootstrap-modal.js"></script>
    <script type="text/javascript" src="../js/funciones.js"></script>
    <script type="text/javascript" src="../js/ver_ediciones.js"></script>


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
                        <a class="linked_menu" href="#" id="gotoArticles">
                            <div class="btn_menu">
                                <img src="../images/site.jpg" /><br class="dissapear_br" />
                                Articles
                            </div>
                        </a>
                        <a class="linked_menu" href="#" id="gotoEditions">
                            <div class="btn_menu">
                                <img src="../images/site.jpg" /><br class="dissapear_br" />
                                Editions
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
                 <h2>Version Editions</h2>
                 <h3>Partner News</h3>
             </div>
             <div class="form-horizontal">
                 <div class="form-group">
                     
                     <div class="col-md-4">
                         <button id="createEditions" name="createEditions" class="btn btn-danger">Create Editions</button>
                     </div>
                 </div>
             </div>
                <table id="datatables" cellpadding="0" cellspacing="0" border="0" style="width: 100%; text-align: center;" class="table table-striped table-bordered">
                    <thead id="thead">
                        <tr>
                            <th class="sorting" width="15%">Edition </th>
                            <th class="sorting" width="15%">Version </th>
                            <th class="sorting" width="15%">Touch</th>
                            <th class="sorting" width="15%">Language</th>
                            <th width="5%">View</th>
                            <th width="5%">Edit</th>
                            <th width="5%">Delete</th>
                            <th width="5%">Publish</th>
                        </tr>
                    </thead>
                    <tbody id="tbody">
                    
                    </tbody>
                    <tfoot>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
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
