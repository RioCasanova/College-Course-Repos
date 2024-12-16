<!doctype html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Palindrome Checker</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
</head>

<body>
    <section class="container py-5">
        <div class="row py-lg-5">
            <div class="col-lg-6 col-md-8 mx-auto">
                <h1 class="text-center fw-light">Palindrome Checker</h1>
                <p class="text-center lead text-muted">Use the form below to see whether your word is a palindrome</p>
                <hr class="my-5">
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 col-md-8 mx-auto">
                <form action="<?php echo $_SERVER['PHP_SELF'] ?>" method="post">
                    <div class="mb-3">
                        <label for="pal" class="form-label">Your word or phrase</label>
                        <input type="text" name="pal" id="pal" class="form-control" required>
                    </div>
                    <input type="submit" class="btn btn-primary" name="form-submit" value="Is this a Palindrome?">
                </form>


                <div class="col-lg-6 col-md-8 mt-5">
                    <?php
                    // Defining our custom function
                    function palindrome_check($string)
                    {
                        $string = strtolower($string); // makes it lower-case
                        $string = str_replace(' ', '', $string); // removes spaces
                    
                        $pal_check = ($string == strrev($string));
                        return $pal_check;
                    }

                    if (isset($_POST['form-submit'])) {
                        if (isset($_POST['pal'])) {
                            $pal = $_POST['pal'];
                            $result = palindrome_check($pal) ? "This is a palindrome" : "This is not a palindrome";
                            echo "<p class='text-success'> $result </p>";
                        }

                    }


                    ?>
                </div>
            </div>
        </div>
    </section>


</body>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
    crossorigin="anonymous"></script>

</html>