<?php 

include("/home/username/data/data.php");

$username = isset($_POST['username']) ? $_POST['username']:'';
$password = isset($_POST['password']) ? $_POST['password']:'';
$msg = ""; 

if(isset($_POST['mysubmit'])){
	if (($username == $username_good) && (password_verify($password, $pw_enc))){

		session_start(); // starts a session, or continues an existing session; MUST be here when using sessions
		$_SESSION['yourrandomsession-xyz'] = session_id(); // the name of the session: Best if its a randomly typed value (no spaces, special chars) and then copied throughout. This way, its doubtful that the user has an existing session from a previous site they visited. Don' call it 'login', or 'name' or anything else common.
		// MAKE SURE YOU CREATE YOUR OWN SESSIONS VARIABLE NAME OR ELSE OTHER STUDENT WILL BE GRANTED ACCESS IF THEY CREATE THE SAME ONE WITH THEIR SCRIPT.
		//$msg = "Welcome " . $username;
		header("Location:welcome.php"); // redirects user to welcome page
	}else {
		
		if($username != "" && $password !=""){
			$msg = "Invalid Login"; // just for testing; in a real site, we wouldn't echo something before the doctype, body, etc.
		}else{
			$msg = "Please enter a Username and Password";
		}
	}
}
?>


 <!-- 

Note: All this styling is in place for a standalone lesson in creating a Secure Login. It must be replaced by whatever template you are using for your application.

  -->
<!DOCTYPE html>
<html>
<head>
	<title>Login</title>
	<!-- These must be in place to use Bootstrap ! -->
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	<style type="text/css">
		.formstyle{ /* optional: in case you don't like the really wide form */
			max-width:450px;
		}

	</style>
</head>
<body>
	<div class="container">

		<h1>Please Login</h1>

		<form name="myform" class="formstyle" method="post" action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>">

		<!-- you can copy/paste one of these form-groups, then change the form element and label within -->
		  <div class="form-group">
		    <label for="username">Username:</label>
		    <input type="text" class="form-control" name="username">
		  </div>
		 <!-- / form-group -->

		  <div class="form-group">
		    <label for="password">Password:</label>
		    <input type="password" class="form-control" name="password">
		  </div>

		  <input type="submit" class="btn btn-default" name="mysubmit">
		</form>
		<?php 
			if($msg){
				echo "<div class=\"alert alert-info\">$msg</div>";
			}
		 ?>
	</div><!-- / .container -->
</body>
</html>