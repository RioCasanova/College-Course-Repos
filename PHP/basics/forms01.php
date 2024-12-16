<?php include "includes/header.php" ?>

<form method="post" class="p-5 container" action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>">
    <div class="mb-3 col-6">
        <label for="name" class="form-label">Name</label>
        <input type="text" class="form-control" id="name" name="name">

    </div>
    <div class="mb-3 col-6">
        <label for="email" class="form-label">Email</label>
        <input type="email" class="form-control" id="Email@gmail.com" name="email">
    </div>
    <div class="mb-3 col-6">
        <label for="inputPassword2" class="form-label">Password</label>
        <input type="password" class="form-control" id="inputPassword2" placeholder="Password" name="password">
    </div>
    <div class="mb-3 form-check">
        <input type="checkbox" class="form-check-input" id="exampleCheck1" name="newsletter" value="news">
        <label class="form-check-label" for="exampleCheck1">Receive Newsletter</label>
    </div>
    <div class="mb-3 col-6">
        <select class="form-select" name="country">
            <option selected value="CA">Canada</option>
            <option value="UK">U.K.</option>
            <option value="US">U.S.</option>
            <option value="NZ">N.Z.</option>
        </select>
    </div>
    <div class="col-auto">
        <button name="button" type="submit" class="btn btn-primary mb-3">Submit</button>
    </div>
</form>


<?php
// on your own create an if statement that user has clicked the button
echo "<pre>";
print_r($_POST);
echo "</pre>";
?>
<?php include "includes/footer.php" ?>