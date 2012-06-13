<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr" lang="en-US">
<head profile="http://gmpg.org/xfn/11">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Slam Tenis</title>

<link rel="stylesheet" href="css/reset.css" type="text/css" media="screen" />
<link rel="stylesheet" href="css/default.css" type="text/css" media="screen" />
<link rel="stylesheet" href="css/style.css"type="text/css" media="screen" />

    <style type="text/css">
    .Titulos
    {
        cursor: pointer;
        color: #3B5998;
        text-decoration: none;
    }
    .style1
    {
        color: #CCCCCC;
    }
</style>
	 <?php
	/*	$noticias = simplexml_load_file('http://ar.noticias.yahoo.com/rss/tenis');   
		$fp = fopen("Noticias.xml","a");
		fwrite($fp, "Nombre: Noticias \t $noticias" . PHP_EOL);
		fclose($fp);*/
    ?> 
    <script language="javascript" src="js/rss.js"></script>
	<script type="text/javascript">
		window.onload = function()
		{
			ReadRSS('Noticias.xml','rssBodyTemplate','rssTitleTemplate');
		}
	</script>


	<style type="text/css">.recentcomments a{display:inline !important;padding:0 !important;margin:0 !important;}
        .style1
        {
            color: #000000;
        }
    </style>
</head>
<body>


<!-- wrapper start -->
<div id="wrapper">
    <div id="bottom_frame">
        <div id="top_frame">
            <div id="top_container">
    <!-- header start -->
	    <div id="header">
			    <h1  id="blog_title">
                    <span class="style1">Slam Tennis</span>
                </h1>
		        <h2>Sistema de Administracion de Torneos de Tenis</h2>
		    <div id="menu">
			    <ul>
				     <li class="menu_first">
                        <a href="index.php">Inicio</a></li>
				    <li class="page_item page-item-2">
                        <a href="noticias.php">
                        Noticias</a></li>
                    <li class="page_item page-item-16">
                        <a href="nosotros.php">
                        Información</a></li>
                    <li class="page_item page-item-18">
                        <a href="descargas.php">
                        Descargas</a></li>
			    </ul>
		    </div>
	    </div>

	    <div id="container" class="clearfix">	       
            <div id="content">
		        

    <div>
			<div id="sidebar_main" class="clearfix">
            <ul>
                <li>
                <h2>Noticias</h2>
                <ul>
                	<li class="cat-item cat-item-87" style="display:none">
                	    <div id="rssTitleTemplate">
		                    (::Title::)<br/>
		                    <a class="Titulos" href="(::Link::)">(::Description::)</a>
	                    </div>
                	</li>
                	<li>
                	    <div id="rssBodyTemplate">
		                    <a href="(::Link::)"><b style="color: #003399">(::Title::)</b></a> 
		                    <b>&nbsp;&nbsp;&nbsp; <span class="style1">(::Pubdate::)</span></b>
		                    <br/>
		                    <br />
		                    <font size="-1">(::Description::)</font>
		                    <br />
		                    <br />
		                    <hr />
		                    <br/>
	                    </div>
                	</li>
                </ul>
                </li>
            </ul>
			</div>
    		</div>
    	

            </div>
	    </div>
    	
	    <div id="footer" class="clearfix">&nbsp;<div class="credit">
				    Copyright © 2012 2012 				    
				    <br/>				
				    <div class="footer_c">
				    </div>
		    </div>
	    </div>
    </div>
    </div></div></div>
<!-- wrapper end -->
<br/>
<br/>
</body>
</html>
