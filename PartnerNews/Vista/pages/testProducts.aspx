<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testProducts.aspx.cs" Inherits="PartnerNews.testProducts" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta name="viewport" content="width=device-width,initial-scale=1" />
	<title>Admin Version - Partner News</title>
    <link href="../css/bootstrap.css" rel="stylesheet"/>
   	<link rel="stylesheet" href="../css/header_style.css"/>
    <link rel="stylesheet" href="../css/styles.css"/>
    <link href="../css/bootstrap-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../css/DT_bootstrap.css" rel="stylesheet" type="text/css"/>
    <style>

        .thumbnail {
            display: block;
            padding: 4px;
            line-height: 20px;
            border: 1px solid #ddd;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            -webkit-box-shadow: 0 1px 3px rgba(0,0,0,0.055);
            -moz-box-shadow: 0 1px 3px rgba(0,0,0,0.055);
            box-shadow: 0 1px 3px rgba(0,0,0,0.055);
            -webkit-transition: all .2s ease-in-out;
            -moz-transition: all .2s ease-in-out;
            -o-transition: all .2s ease-in-out;
            transition: all .2s ease-in-out;
        }

        .product-price {
            display: inline-block;
            width: 48%;
            vertical-align: top;
            background-color: #2A4C7A;
            color: #FFF;
            font-weight: bold;
            line-height: 28px;
            text-align: center;
        }

        .shop-single-product a.button {
            width: 48%;
            padding: 0;
            font-weight: normal;
            font-size: 12px;
            line-height: 25px;
            text-align: center;
        }

        img {
            height: auto;
            max-width: 100%;
            }

        a.button {
            font-size: 100%;
            margin: 0;
            line-height: 1em;
            cursor: pointer;
            position: relative;
            font-family: inherit;
            text-decoration: none;
            overflow: visible;
            padding: 6px 10px;
            font-weight: bold;
            -webkit-border-radius: 2px;
            border-radius: 2px;
            left: auto;
            text-shadow: 0 1px 0 #ffffff;
            color: #5e5e5e;
            text-shadow: 0 1px 0 rgba(255,255,255,0.8);
            border: 1px solid #c7c0c7;
            background: #f7f6f7;
            background: -webkit-gradient(linear,left top,left bottom,from(#f7f6f7),to(#dfdbdf));
            background: -webkit-linear-gradient(#f7f6f7,#dfdbdf);
            background: -moz-linear-gradient(center top,#f7f6f7 0%,#dfdbdf 100%);
            background: -moz-gradient(center top,#f7f6f7 0%,#dfdbdf 100%);
            white-space: nowrap;
            display: inline-block;
            -webkit-box-shadow: inset 0 -1px 0 rgba(0,0,0,0.075), inset 0 1px 0 rgba(255,255,255,0.3), 0 1px 2px rgba(0,0,0,0.1);
            -moz-box-shadow: inset 0 -1px 0 rgba(0,0,0,0.075), inset 0 1px 0 rgba(255,255,255,0.3), 0 1px 2px rgba(0,0,0,0.1);
            box-shadow: inset 0 -1px 0 rgba(0,0,0,0.075), inset 0 1px 0 rgba(255,255,255,0.3), 0 1px 2px rgba(0,0,0,0.1);
            }
    </style>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/enquire.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap-dialog.js"></script>
    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../js/DT_bootstrap.js"></script>
    <script type="text/javascript" src="../js/funciones.js"></script>
    <script type="text/javascript" src="../js/admin_version.js"></script>

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
    <section style="position:relative;top:180px;">
    <div class="container">
        <div class="wpv-single-product">

            <div class="row">
                <div class="span3">
                    <div class="thumbnail product-images">
                        <div class="images">

                            <a href="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_02.jpg" itemprop="image" class="woocommerce-main-image zoom" title="shirt_02" data-rel="prettyPhoto">
                                <img width="300" height="300" src="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_02-300x300.jpg" class="attachment-shop_single wp-post-image" alt="shirt_02" title="shirt_02"/></a>

                        </div>

                        <div class="row-fluid">
                            <div class="product-gallery">

                                <div class="span4">
                                    <a href="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_06.jpg" class="zoom" rel="prettyPhoto[product-gallery]">
                                        <img alt="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_06-wpcf_80x80.jpg" title="" class="alignleft" src="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_06-wpcf_80x80.jpg"/></a>
                                </div>

                                <div class="span4">
                                    <a href="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_05.jpg" class="zoom" rel="prettyPhoto[product-gallery]">
                                        <img alt="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_05-wpcf_80x80.jpg" title="" class="alignleft" src="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_05-wpcf_80x80.jpg"/></a>
                                </div>

                                <div class="span4">
                                    <a href="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_07.jpg" class="zoom" rel="prettyPhoto[product-gallery]">
                                        <img alt="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_07-wpcf_80x80.jpg" title="" class="alignleft" src="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_07-wpcf_80x80.jpg"/></a>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="span6">
                    <h1>Hand Drawn T-shirt</h1>
                    <span class="product-price"><span class="amount">£15</span></span>
                    <div class="well">
                        <p>
                            <i class="icon-tags"></i>Category: <a href="http://ref.wp-types.com/bootcommerce/product-category/featured/">Featured</a>, <a href="http://ref.wp-types.com/bootcommerce/product-category/t-shirts/">T-shirts</a>
                        </p>
                        <p>
                            <i class="icon-user"></i>Gender: <a href="http://ref.wp-types.com/bootcommerce/gender/children/">Children</a>, <a href="http://ref.wp-types.com/bootcommerce/gender/men/">Men</a>
                        </p>
                        <p>
                            <i class="icon-glass"></i>Style: <span class="label">Casual</span> <span class="label"></span><span class="label"></span>
                        </p>
                    </div>
                    <p>
                    </p>
                    <p>Try our hand drawn t-shirt. This is created using natural paints by some of our finest artists. Please contact us if you want a customized drawing. And send your rough sketches or ideas in a JPEG file format. </p>
                    <p>The fabric is designed for painting. So you don’t need to worry about the colors of your shirt becoming faded from laundry or hand washing.</p>
                    <p>Try this now! </p>

                    <p></p>
                    <div class="buy-options">




                        <form class="cart" method="post" enctype="multipart/form-data">

                            <div class="quantity buttons_added">
                                <input type="button" value="-" class="minus"><input type="number" step="1" min="1" name="quantity" value="1" title="Qty" class="input-text qty text" size="4"><input type="button" value="+" class="plus"></div>
                            <input type="hidden" name="add-to-cart" value="86">

                            <button type="submit" class="single_add_to_cart_button button alt">Add to cart</button>

                        </form>



                    </div>
                </div>
            </div>
            <div class="inline_docxdiv">
                <div class="element_helper_10" style="position: relative; top: -413px; left: 805px;">
                    <span class="ico-wrapper display-explanation" data-identification="10" data-title="Single product" title="Display Explanation">
                        <i class="icon-question-sign inline-doc-question-sign"></i><span>Display Explanation</span>
                    </span>
                    <a class="ico-wrapper display-source" data-title="Single product" title="Show the content template source" target="_blank" href="http://ref.wp-types.com/bootcommerce/wp-admin/post.php?post=10&amp;action=edit">
                        <i class="icon-file-alt"></i><span>View source</span>
                    </a>
                </div>
            </div>
        </div>








        <div class="related-products product-list clearfix">
            <h2>Related products</h2>
            <!-- wpv-loop-start -->
            <div class="row">
	            <div class="col-sm-6 col-lg-3">
		            <div class="shop-single-product thumbnail">
                        <a href="http://ref.wp-types.com/bootcommerce/product/coloured-shirts/">
                            <img width="300" height="300" src="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_071-300x300.jpg" class="attachment-shop_single wp-post-image" alt="shirt_07" title="shirt_07"></a>
                        <h3><a href="http://ref.wp-types.com/bootcommerce/product/coloured-shirts/">Coloured Shirts</a></h3>
                        <span class="product-price"><del><span class="amount">$30.000</span></del> <ins><span class="amount">$21.000</span></ins></span>
                        <a href="http://ref.wp-types.com/bootcommerce/product/coloured-shirts/" rel="nofollow" data-product_id="379" data-product_sku="717" class="button add_to_cart_button product_type_variable">Detalles</a>
                    </div>
	            </div>
	            <div class="col-sm-6 col-lg-3">
		             <div class="shop-single-product thumbnail">
                        <a href="http://ref.wp-types.com/bootcommerce/product/wooden-bracelet/">
                            <img width="300" height="300" src="http://ref.wp-types.com/bootcommerce/files/2012/07/accs_09-300x300.jpg" class="attachment-shop_single wp-post-image" alt="accs_09" title="accs_09"></a>
                        <h3><a href="http://ref.wp-types.com/bootcommerce/product/wooden-bracelet/">Wooden Bracelet</a></h3>
                        <span class="product-price"><del><span class="amount">$29.000</span></del> <ins><span class="amount">$19.000</span></ins></span>
                        <a href="/bootcommerce/product/hand-drawn-t-shirt/?add-to-cart=80" rel="nofollow" data-product_id="80" data-product_sku="112" class="button add_to_cart_button product_type_simple">Detalles</a>
                    </div>
	            </div>
	            <div class="col-sm-6 col-lg-3">
		            <div class="shop-single-product thumbnail">
                        <a href="http://ref.wp-types.com/bootcommerce/product/classic-t-shirt/">
                            <img width="300" height="300" src="http://ref.wp-types.com/bootcommerce/files/2012/07/shirt_01-300x300.jpg" class="attachment-shop_single wp-post-image" alt="shirt_01" title="shirt_01"></a>
                        <h3><a href="http://ref.wp-types.com/bootcommerce/product/classic-t-shirt/">Classic T-Shirt</a></h3>
                        <span class="product-price"><span class="amount">$20.000</span></span>
                        <a href="/bootcommerce/product/hand-drawn-t-shirt/?add-to-cart=84" rel="nofollow" data-product_id="84" data-product_sku="216" class="button add_to_cart_button product_type_simple">Detalles</a>
                    </div>
	            </div>	
	            <div class="col-sm-6 col-lg-3">
		            <div class="shop-single-product thumbnail">
                        <a href="http://ref.wp-types.com/bootcommerce/product/tooth-necklace/">
                            <img width="300" height="300" src="http://ref.wp-types.com/bootcommerce/files/2012/07/accs_03-300x300.jpg" class="attachment-shop_single wp-post-image" alt="accs_03" title="accs_03"></a>
                        <h3><a href="http://ref.wp-types.com/bootcommerce/product/tooth-necklace/">Tooth Necklace</a></h3>
                        <span class="product-price"><span class="amount">$29.000</span></span>
                        <a href="/bootcommerce/product/hand-drawn-t-shirt/?add-to-cart=67" rel="nofollow" data-product_id="67" data-product_sku="317" class="button add_to_cart_button product_type_simple">Detalles</a>
                    </div>
	            </div>	
            </div>

            

            <!-- wpv-loop-end -->
        </div>
    </div>
     
    </section>
</body>
</html>
