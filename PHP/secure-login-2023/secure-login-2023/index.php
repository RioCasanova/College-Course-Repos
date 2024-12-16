<?php
session_start();
if(isset($_SESSION['xgsnwirhfvndsjds'])) {
	$txtMsg = "You are now logged in"; // optional
	
}else {

	header("Location:login.php");// NOT optional. This is what protects this page from unautheticated users. This happens everythime you login to a banksite, your email, NAIT portal, Facebook, etc. If the session does not exist, redirect user to the login page !!!!!!
	// Note WHERE this happens: The user would be redirected BEFORE any output to the browser.
}
?>
<!DOCTYPE html>
<html>
<head>
<title>Welcome Authenticated User</title>
</head>

<body>
<h2>Welcome Authenticated User to the Home Page</h2>
<?php  echo $txtMsg; ?>

</body>
</html>

