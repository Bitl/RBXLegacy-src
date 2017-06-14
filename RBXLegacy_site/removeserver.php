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

$sql="SELECT * FROM games";

$result=$con->query($sql);
if (!$result)
{
  printf("Error: %s\n", $con->error);
}

while($row = mysqli_fetch_array($result, MYSQLI_ASSOC)) 
{
$ip = base64_decode($row['ip']);
if($_SERVER['REMOTE_ADDR'] == $ip)
{
$delsql="DELETE FROM games
WHERE id = $row[id]";

$resultdel=$con->query($delsql);
if (!$resultdel)
{
  printf("Error: %s\n", $con->error);
}
}
}

$con->close();
?>
<div id="Container">
				<div id="Header">
					<div id="Banner">
						<center><div id="Logo"><a id="logo" title="RBXLegacy" href="index.php" style="display:inline-block;cursor:pointer;"><img src="images/Logo.png" border="0" id="img" alt="Origins06"/></a></div></center>
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
			<h2>Games</h2>
				<div id="ElementInsert">
					<center>
						<h3>Server has been deleted.</h3>
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