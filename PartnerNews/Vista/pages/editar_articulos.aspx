<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editar_articulos.aspx.cs" Inherits="PartnerNews.Vista.pages.editar_articulos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=device-width,initial-scale=1" />
	<title>AVAYA - Partner News - Crear Articulos</title>
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
    <script type="text/javascript" src="../js/ckeditor.js"></script>
    <script type="text/javascript" src="../js/jquery_editor.js"></script>
    <script type="text/javascript" src="../js/funciones.js"></script>
    <script type="text/javascript" src="../js/crear_articulos.js"></script>
    <script type="text/javascript" src="../js/editar_articulos.js"></script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtCkEditor.ClientID %>',
                { filebrowserImageUploadUrl: 'Upload.ashx' }); //path to "Upload.ashx"
        });
    </script>

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
            <h2>Edit Article</h2>
            <h3>Partner News</h3>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
              <label class="col-md-4 control-label" for="article_title">Title</label>  
              <div class="col-md-4">
                  <input id="article_title" name="article_title" placeholder="placeholder" class="form-control input-md" type="text"/>
              </div>
            </div>
            <div class="form-group">
               <label class="col-md-4 control-label" for="article_language">Content</label>
            </div>
        </div>            
        <form id="form1" runat="server">
            <div>
               <asp:TextBox ID="txtCkEditor" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
        </form>
        
        <div class="form-horizontal">
            <div class="form-group">
              <label class="col-md-4 control-label" for="article_language">Language</label>
              <div class="col-md-4">
                <select id="article_language" name="article_language" class="form-control">
                  <option value=""></option>
                  <option value="1">English</option>
                  <option value="2">Spanish</option>
                  <option value="3">Portuguese</option>
                </select>
              </div>
            </div>

            <div class="form-group">
              <label class="col-md-4 control-label" for="article_section">Section</label>
              <div class="col-md-4">
                <select id="article_section" name="article_section" class="form-control">
                    <!-- ajax -->   
                </select>
              </div>
            </div>

            <div class="form-group" id="section_detail" style="display:none;">
              <label class="col-md-4 control-label" for="article_section_detail">Child Section</label>
              <div class="col-md-4">
                <select id="article_section_detail" name="article_section_detail" class="form-control">
                   <!-- ajax -->   
                </select>
              </div>
            </div>

            <div class="form-group">
                <label class="col-md-4 control-label" for="checkboxes">Editions</label>
                
                <div class="col-md-4" id="ediciones">
                   <!-- ajax -->   
                </div>
            </div>

            <div class="form-group">
                <label class="col-md-4 control-label" for="checkboxes">Top New</label>
                <div class="col-md-4">
                  <div class="checkbox">
                    <label for="checkboxes-0">
                      <input name="article_top_new" id="article_top_new" type="checkbox"/></label>
	              </div>
                </div>
            </div>

            <div class="form-group">
                <label class="col-md-4 control-label" for="checkboxes">Editorial</label>
                <div class="col-md-4">
                  <div class="checkbox">
                    <label for="checkboxes-0">
                      <input name="article_editorial" id="article_editorial" type="checkbox"/></label>
	              </div>
                </div>
            </div>

            <div class="form-group">
                <label class="col-md-4 control-label" for="checkboxes">Outstanding</label>
                <div class="col-md-4">
                  <div class="checkbox">
                    <label for="checkboxes-0">
                      <input name="article_outstanding" id="article_outstanding" type="checkbox"/></label>
	              </div>
                </div>
            </div>

            <div class="form-group">
                <label class="col-md-4 control-label" for="checkboxes">Visible</label>
                <div class="col-md-4">
                  <div class="checkbox">
                    <label for="checkboxes-0">
                      <input name="article_visible" id="article_visible" type="checkbox" checked="checked"/></label>
	              </div>
                </div>
            </div>

            <br />
            <div class="form-group">
              <div class="col-md-4">
                <button id="btn_edit_article" name="btn_edit_article" class="btn btn-danger">Edit Article</button>
              </div>
            </div>
        </div>  
	 </div>
    </section>
</body>
</html>
