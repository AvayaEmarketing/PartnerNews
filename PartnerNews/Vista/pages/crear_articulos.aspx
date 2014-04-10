<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crear_articulos.aspx.cs" Inherits="PartnerNews.Vista.pages.crear_articulos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=device-width,initial-scale=1" />
	<title>AVAYA - Partner News - Crear Articulos</title>
    <link href="../css/bootstrap.css" rel="stylesheet"/>
   	<link rel="stylesheet" href="../css/header_style.css"/>
    <link rel="stylesheet" href="../css/version.css"/>
    <link href="../css/bootstrap-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../css/DT_bootstrap.css" rel="stylesheet" type="text/css"/>
    <%--<link href="../css/bootstrap-only-message.css" rel="stylesheet" type="text/css" />--%>
    <style>
        #form1 {
            margin-bottom:15px;
            
        }
    </style>

    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap-dialog.js"></script>
    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../js/DT_bootstrap.js"></script>
    <script type="text/javascript" src="../js/crear_articulos.js"></script>
    <script type="text/javascript" src="../js/ckeditor.js"></script>
    <script type="text/javascript" src="../js/jquery_editor.js"></script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtCkEditor.ClientID %>',
                { filebrowserImageUploadUrl: 'Upload.ashx' }); //path to “Upload.ashx”
        });
    </script>

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
            <h2>Create Article</h2>
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
                <button id="btn_create_article" name="btn_create_article" class="btn btn-danger">Create Article</button>
              </div>
            </div>





            
  

        </div>  
	 </div>
          
                    
            
    
    </section>
</body>
</html>
