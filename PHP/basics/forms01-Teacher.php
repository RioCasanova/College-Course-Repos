<?php include "includes/header.php"; ?>


<h1>Forms Primer</h1>

<form method="post" action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>">
  <div class="mb-3">
    <label for="name" class="form-label">Name</label>
    <input type="text" class="form-control" id="name" name="name">

  </div>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" name="email">

  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1" name="password">
  </div>
  <div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1" name="newsletter" value="news">
    <label class="form-check-label" for="exampleCheck1">Receive Newsletter</label>
  </div>
  <div class="mb-3">
    <select class="form-select" name="country">
      <option selected value="CA">Canada</option>
      <option value="UK">U.K.</option>
      <option value="US">U.S.</option>
      <option value="NZ">N.Z.</option>
    </select>
  </div>


  <button type="submit" class="btn btn-primary" name="mysubmit">Submit</button>
</form>

<?php


// on your own, create an if statement that user has clicked the button...like the last thing we did

if (isset($_POST['mysubmit'])) { // did you add a name attribute to your submit button???
  echo "<pre>";
  print_r($_POST);
  echo "</pre>";
}
?>



<?php include "includes/footer.php"; ?>