<?php



$firstname = isset($_POST['firstname']) ? $_POST['firstname'] : 'first name';

$lastname = isset($_POST['lastname']) ? $_POST['lastname'] : 'last name';

$colour = isset($_POST['colour']) ? $_POST['colour'] : 'colour';
$clothing = isset($_POST['clothing']) ? $_POST['clothing'] : 'clothing';


// configuration of the radio buttons
if (isset($_POST['male'])) {
    $gender = 'male';
} else if (isset($_POST['female'])) {
    $gender = 'female';
} else {
    $gender = 'gender';
}



?>




<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" href="css/styles.css" />
    <script src="js/main.js" type="module" defer></script>
    <title>Template01</title>
</head>

<body>
    <header>
        <h1 class="visually-hidden">Template01</h1>
        <nav class="navbar navbar-dark bg-dark" aria-label="First navbar example">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">MadLibs</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarsExample01" aria-controls="navbarsExample01" aria-expanded="false"
                    aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarsExample01">
                    <ul class="navbar-nav me-auto mb-2">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="#">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Link</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link disabled" aria-disabled="true">Disabled</a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown"
                                aria-expanded="false">Dropdown</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="#">Action</a></li>
                                <li><a class="dropdown-item" href="#">Another action</a></li>
                                <li>
                                    <a class="dropdown-item" href="#">Something else here</a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <form role="search">
                        <input class="form-control" type="search" placeholder="Search" aria-label="Search" />
                    </form>
                </div>
            </div>
        </nav>
    </header>
    <main>
        <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
            <fieldset>
                <div class="form-control">
                    <div class="my-3">
                        <label for="firstname" class="form-label">First Name</label>
                        <input type="text" name="firstname" class="form-control form-control-lg" id="firstname"
                            value="<?php echo $firstname; ?>" placeholder="first name">
                    </div>
                    <div class="my-3">
                        <label for="lastname" class="form-label">Last Name</label>
                        <input type="text" name="lastname" class="form-control form-control-lg" id="lastname"
                            value="<?php echo $lastname; ?>" placeholder="last name">
                    </div>
                    <div class="my-3">
                        <select class="form-select form-select-lg my-3" name="colour" id="colour"
                            aria-label="Default select example">
                            <option selected>Favourite Colour</option>
                            <option value="Red" <?php if (isset($colour) && $colour == "Red") {
                                echo 'selected';
                            } ?>>Red</option>
                            <option value="Blue" <?php if (isset($colour) && $colour == "Blue") {
                                echo 'selected';
                            } ?>>Blue</option>
                            <option value="Green" <?php if (isset($colour) && $colour == "Green") {
                                echo 'selected';
                            } ?>>Green</option>
                        </select>
                    </div>
                    <div class="">
                        <select class="form-select form-select-lg my-3" name="clothing" id="clothing"
                            aria-label="Default select example">
                            <option>Piece of clothing</option>
                            <option value="Shirt" <?php if (isset($clothing) && $clothing == "Shirt") {
                                echo 'selected';
                            } ?>>Shirt</option>
                            <option value="Underwear" <?php if (isset($clothing) && $clothing == "Underwear") {
                                echo 'selected';
                            } ?>>Underwear</option>
                            <option value="Sweater" <?php if (isset($clothing) && $clothing == "Sweater") {
                                echo 'selected';
                            } ?>>Sweater</option>
                        </select>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="male" id="male" <?php if (isset($gender) && $gender == 'male') {
                            echo 'checked';
                        } ?>>
                        <label class="form-check-label" for="male">
                            Male
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="female" id="female" <?php if (isset($gender) && $gender == "female") {
                            echo 'checked';
                        } ?>>
                        <label class="form-check-label" for="female">
                            Female
                        </label>
                    </div>
                </div>
            </fieldset>
            <input type="submit" name="mySubmit" value="Submit">
        </form>
    </main>
    <footer>
        <?php

        if (isset($_POST['mySubmit'])) {
            echo "<h1>$firstname</h1>";
            echo "<h1>$lastname</h1>";
            echo "<h1>$colour</h1>";
            echo "<h1>$clothing</h1>";
            echo "<h1>$gender</h1>";
        }

        // echo "<p>You will end your day by seeing $firstname at 7pm. Make sure to bring the money you've been provided. The movie ticket is \$12. $friend's favourite candy is $candy, so grab some of those too.</p>\n\n";
        

        ?>
    </footer>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
</body>

</html>