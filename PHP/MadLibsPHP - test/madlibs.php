<?php

$firstname = isset($_POST['firstname']) ? $_POST['firstname'] : 'first name';
$lastname = isset($_POST['lastname']) ? $_POST['lastname'] : 'last name';
$colour = isset($_POST['colour']) ? $_POST['colour'] : 'colour';
$clothing = isset($_POST['clothing']) ? $_POST['clothing'] : 'naked';

if (isset($_POST['male'])) {
    $gender = 'male';
} else if (isset($_POST['female'])) {
    $gender = 'female';
} else {
    $gender = 'gender';
}



?>

<!doctype html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Lab01-Rio Casanova</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
</head>

<body>
    <header>
        <h1 class="visually-hidden">Hello, world!</h1>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark" aria-label="Eighth navbar example">
            <div class="container">
                <a class="navbar-brand" href="#">Lab 01</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarsExample07" aria-controls="navbarsExample07" aria-expanded="false"
                    aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarsExample07">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
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
                                <li><a class="dropdown-item" href="#">Something else here</a></li>
                            </ul>
                        </li>
                    </ul>
                    <form role="search">
                        <input class="form-control" type="search" placeholder="Search" aria-label="Search">
                    </form>
                </div>
            </div>
        </nav>
    </header>
    <main>
        <form action="madlibs.php" method="post">
            <div class="form-control px-5 px-5">
                <div class="mb-3">
                    <label for="firstname" class="form-label">First Name</label>
                    <input type="text" name="firstname" class="form-control" id="firstname" placeholder="firstname">
                </div>
                <div class="mb-3">
                    <label for="lastname" class="form-label">Last Name</label>
                    <input type="text" name="lastname" class="form-control" id="lastname" placeholder="lastname">
                </div>
                <div class="mb-3">
                    <select class="form-select" name="colour" aria-label="Default select example">
                        <option selected>Select a Colour</option>
                        <option value="Red">Red</option>
                        <option value="Blue">Blue</option>
                        <option value="Green">Green</option>
                    </select>
                </div>
                <div class="mb-3">
                    <select class="form-select" name="clothing" aria-label="Default select example">
                        <option selected>Select article of clothing</option>
                        <option value="Sweater">One</option>
                        <option value="Kilt">Kilt</option>
                        <option value="Headband">Headband</option>
                    </select>
                </div>
                <div class="form-check">
                    <input class="form-check-input" name="male" type="checkbox" value="" id="male">
                    <label class="form-check-label" for="male">
                        Male
                    </label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" name="female" type="checkbox" value="" id="female">
                    <label class="form-check-label" for="female">
                        Female
                    </label>
                </div>
                <div class="mt-3"><input type="submit" name="mySubmit" value="submit"></div>
            </div>

        </form>
        <?php
        if (isset($_POST['mySubmit'])) {
            echo "{$firstname} ran into Mr.{$lastname} and turned a bright shade of {$colour} because {$firstname} was wearing nothing but a {$clothing}, but it wasn't the first time Mr.{$lastname} had seen a {$gender} in a {$clothing}.";
        }

        ?>
    </main>
    <footer></footer>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
</body>

</html>