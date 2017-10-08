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
<?php
$con = new mysqli("localhost", "root", "", "rbxlegacy_games");

if (mysqli_connect_errno()) 
{
    printf("Connect failed: %s\n", mysqli_connect_error());
}

$namefixed = mysqli_real_escape_string($con,$_POST['name']);
$ipcrypt = base64_encode($_POST['ip']);
$clientcrypt = base64_encode($_POST['client']);
$portcrypt = base64_encode($_POST['port']);
date_default_timezone_set('America/Phoenix');
$date = date('m/d/Y h:i:s a', time());

$sql="INSERT INTO games (name, map, ip, port, client, version, playerlimit, date)

VALUES

('$namefixed','$_POST[map]','$ipcrypt','$portcrypt','$clientcrypt','$_POST[version]','$_POST[playerlimit]','$date')";

if (!$con->query($sql))
{
  printf("Error: %s\n", $con->error);
}

$con->close();

$port=$_POST['port'];
$playerlimit=$_POST['playerlimit'];
?>
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
				<div id="ElementInsert">
					<center>
						<h3>Start up your server by using the RBXLegacy Launcher and launching Studio with your intended map, then paste this into the command bar.</h3>
						<h3>You can also configure your Launcher to the same settings as the server.</h3>
						<div id="genlink"><b>dofile('rbxasset://scripts/CSMPFunctions.lua'); _G.CSServer(<?php echo $port ?>,<?php echo $playerlimit ?>);</b></div>
					</center>
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
