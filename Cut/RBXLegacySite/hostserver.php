<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" id="pee">
<head>
<title>RBXLegacy</title>
<link rel="stylesheet" type="text/css" href="css/RBXLegacy_normal.css" title="normal"/>
<link rel="stylesheet" type="text/css" href="css/RBXLegacy_dark.css" title="dark">
<link rel="stylesheet" type="text/css" href="css/RBXLegacy_normalOrigins06.css" title="normalorigins06"/>
<link rel="stylesheet" type="text/css" href="css/RBXLegacy_darkOrigins06.css" title="darkorigins06">
<link rel="stylesheet" type="text/css" href="css/RBXLegacy_classic.css" title="classic">
<link rel="stylesheet" type="text/css" href="css/RBXLegacy_classicdark.css" title="classicdark"> 
<link rel="Shortcut Icon" type="image/ico" href="images/rbxlegacyicon.ico"/>
<script type="text/javascript" src="js/js_funcs.js"></script>
</head>
<body onload="set_style_from_cookie()">
<div id="Container">
				<div id="Header">
					<div id="Banner">
						<center><div id="Logo"><a id="logo" title="RBXLegacy" href="index.php" style="display:inline-block;cursor:pointer;"><img src="images/Logo.png" border="0" id="img" alt="RBXLegacy"/></a></div></center>
					</div>
					<div class="Navigation">
						<span><a id="Games" class="MenuItem" href="games.php">Games</a></span>
						<span class="Separator"> | </span>
						<span><a id="HostServer" class="MenuItem" href="hostserver.php">Host Server</a></span>
 					</div>
				</div>
				<div id="Body">
					
	<div id="SplashContainer">
		<div id="MainPanel">
			<center>
			<div id="genlink"><b>alert text</b></div>
			</center>
		</div>
		<div id="MainPanel">
			<center>
			<h2>Host Server</h2>
			<b>* = Required</b>
				<div id="ElementInsert">
					<form action="getservercode.php" method="post">
						<center>
							<h3>Server Name: *</h3>
							<input type="text" name="name" /><br><br>
							<h3>Map Name: *</h3>
							<input type="text" name="map" /><br><br>
							<h3>IP Address: *</h3>
							<input type="text" name="ip" value=<?php print $_SERVER['REMOTE_ADDR']; ?> /><br><br>
							<h3>Client: *</h3>
							<input type="text" name="client" value="2008" /><br><br>
							<h3>RBXLegacy Version: *</h3>
							<input type="text" name="version" value="1.17" /><br><br>
							<h3>Port: *</h3>
							<input type="text" name="port" value="53640"/><br><br>
							<h3>Player Limit: *</h3>
							<input type="text" name="playerlimit" value="12"/><br><br>
							<input type="submit" value="Get server code"/>
						</center>
					</form>
				</div>
			</center>
		</div>
	</div>
	</div>
	
	<div id="Footer">
	RBXLegacy does not knowingly host copyrighted content. If you host a server, we store your IP address, but it is not publicly distributed to users on the site.
	</div>
			</div>
	</body>
</html>
