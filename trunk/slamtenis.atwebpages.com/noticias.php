<?php require_once 'rss/rss_fetch.inc';
define('MAGPIE_OUTPUT_ENCODING', 'UTF-8');
define('MAGPIE_INPUT_ENCODING', 'UTF-8');
define('MAGPIE_DETECT_ENCODING', false); 
$url = 'http://www.lawebdeltenis.net/index.php?format=feed&type=rss';
$rss = fetch_rss($url);
?>

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
				
				<?php 
				$items = array_slice($rss->items, 0);
				$cont = 0;
				while(!empty($items[$cont])){
					echo '<ul>';
					echo '<li class="cat-item cat-item-87" style="display:none">';
					echo '<div id="rssTitleTemplate">';
					echo $items[$cont]['title'].'<br />';
					echo '<a class="Titulos" href="' . $items[$cont]['link'] . '">' . $items[$cont]['description'] . '</a>';
					echo '</div>';
					echo '</li>';
                	echo '<li>';
					echo '<div id="rssBodyTemplate">';
					echo '<a href="' . $items[$cont]['link'] . '"><b style="color: #003399">' . $items[$cont]['title'] . '</b></a>';
					echo '<b>&nbsp;&nbsp;&nbsp; <span class="style1">' . $items[$cont]['pubdate'] . '</span></b>';
					echo '<br /><br />';
					echo '<font size="-1">' . $items[$cont]['description'] . '</font><br /><br /><hr /><br/></div></li>';
					echo '</ul>';
					$cont++;
				}
				?>
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
