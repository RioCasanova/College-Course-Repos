<?php
// Getting values from the post
$name = isset($_POST['name']);
$email = isset($_POST['email']);
$phone = isset($_POST['phone']);
$comments = isset($_POST['comments']);

// Variable Declarations
$form_good = TRUE;

// Creating Functions
function has_length_exactly($value, $length)
{
    $str_length = strlen($value);
    return $str_length == $length;
}
function is_valid_textarea($value)
{
    if ($value == '') {
        return FALSE;
    } elseif (strlen($value) > 150) {
        return FALSE;
    } elseif (strlen($value) < 5) {
        return FALSE;
    } else {
        return TRUE;
    }
}

// Using functions


$phone = str_replace('-', '', $phone);
$phone = str_replace('+', '', $phone);
$phone = str_replace(' ', '', $phone);
$phone = str_replace('(', '', $phone);
$phone = str_replace(')', '', $phone);

if ($form_good == TRUE) {
    if (!is_numeric($phone)) {
        $message_phone = "<p>Please enter a valid phone number, using numbers only.</p>";
        $form_good = FALSE;
    } elseif (has_length_exactly($phone, 10)) {
        $message_phone = "<p>Please enter a 10 digit phone number.</p>";
        $form_good = FALSE;
    }
}
if ($form_good == TRUE) {
    $message_pass = "<p> This message </p>";
}
?>







<!doctype html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>PHP Form Validation</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
</head>

<body>
    <h1 class="visually-hidden">PHP Form Validation</h1>
    <div class="container">
        <div class="row g-6">
            <div class="col-md-12">
                <form action="validation.php" method="post">
                    <div class="mb-3 col-6">
                        <label for="name" class="form-label">Name</label>
                        <input type="text" class="form-control" id="name" placeholder="">
                    </div>
                    <div class="mb-3">
                        <label for="email" class="form-label">Email</label>
                        <input type="email" class="form-control" id="email" placeholder="email">
                    </div>
                    <div class="mb-3">
                        <label for="phone" class="form-label">Phone</label>
                        <input type="phone" class="form-control" id="phone" placeholder="phone number">
                    </div>
                    <div class="mb-3">
                        <label for="comments" class="form-label">Comments</label>
                        <textarea class="form-control" name="comments" id="comments"
                            rows="3"><?php echo $comments ?></textarea>
                    </div>
                    <input type="submit" class="form-control col-3" name="mySubmit" id="mySubmit" value="Submit">
                </form>
            </div>


            <!-- Good place for our SUCCESS message -->
            <?php if ($form_good == TRUE): ?>
                <div class="alert alert-success my-4">
                    <?php echo $message_pass ?>
                </div>
            <?php endif; ?>
        </div>
    </div>
</body>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
    crossorigin="anonymous"></script>

</html>