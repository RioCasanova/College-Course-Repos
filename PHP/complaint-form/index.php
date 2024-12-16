<?php
require("./includes/validation.php");
require "/home/rcasanova2/public_html/PHPMailer-master/PHPMailer-master/src/Exception.php";
require "/home/rcasanova2/public_html/PHPMailer-master/PHPMailer-master/src/PHPMailer.php";
require "/home/rcasanova2/public_html/PHPMailer-master/PHPMailer-master/src/SMTP.php";

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

$name = isset($_POST['name']) ? trim($_POST['name']) : "";
$email = isset($_POST['email']) ? trim($_POST['email']) : "";
$reason_for_complaint = isset($_POST['reason_for_complaint']);
$text_area = isset($_POST['text_area']) ? trim($_POST['text_area']) : "";
$form_good = isset($_POST['submitOne']) ? TRUE : FALSE;



// Messages variables

$message_name = "";
$message_email = "";
$message_radio = "";
$message_phone = "";
$message_comments = "";

$message_pass = "";


if (isset($_POST['submitOne'])) {

    // NAME VALIDATION


    $name = filter_var($name, FILTER_SANITIZE_STRING);

    if (is_blank($name)) {
        $message_name = "<p>Please enter your name.</p>";
        $form_good = FALSE;
    } elseif (!is_letters($name)) {
        $message_name = "<p>Your name can contain only letters and spaces.</p>";
        $form_good = FALSE;
    } elseif (!$name) {
        $message_name = "<p>Please enter a valid name.</p>";
        $form_good = FALSE;
    } elseif (strpos($name, " ") == false) {
        $message_name = "<p>Please enter your first and last name.</p>";
        $form_good = FALSE;
    }

    // EMAIL VALIDATION

    if (is_blank($email)) {
        $message_email = "<p>Please enter your email.</p>";
        $form_good = FALSE;
    } elseif (!filter_var($email, FILTER_SANITIZE_EMAIL) || !filter_var($email, FILTER_VALIDATE_EMAIL)) {
        $message_email = "<p>Please enter a valid email address.</p>";
        $form_good = FALSE;
    }

    // RADIO VALIDATION

    if (is_blank($reason_for_complaint)) {
        $message_radio = "<p>Please select a reason for complaint.</p>";
        $form_good = FALSE;
    } elseif (!filter_var($reason_for_complaint, FILTER_SANITIZE_NUMBER_INT)) {
        $message_phone = "<p>Please enter a valid phone number, using numbers only.</p>";
        $form_good = FALSE;
    }



    // COMMENTS VALIDATION
    $text_area = filter_var($text_area, FILTER_SANITIZE_STRING);

    if (is_blank($text_area)) {
        $message_comments = "<p>Please enter your comments.</p>";
        $form_good = FALSE;
    } elseif (strlen($text_area) < 5) {
        $message_comments = "<p>Comments should be more than 5 characters please.</p>";
        $form_good = FALSE;
    } elseif (strlen($text_area) > 150) {
        $message_comments = "<p>Comments only in less than 150 characters please.</p>";
        $form_good = FALSE;
    }

    // continue cleaning up comments

    $text_area = filter_var($text_area, FILTER_SANITIZE_SPECIAL_CHARS);

    $text_area = filter_var($text_area, FILTER_SANITIZE_STRING);


} // \ if submit

if ($form_good == TRUE) {
    $message_pass = "<p>SUCCESS. You have passed validation.</p>";
    $body = "<h2>This came from your form</h2>";
    $body .= "<p>Name: $name</p>";
    $body .= "<p>Email: $email</p>";
    $body .= "<p>Reason: $reason_for_complaint</p>";
    $body .= "<p>Message: $text_area</p>";

    $to = "riocasanova@gmail.com";
    $subject = "Web form submission";

    $mail = new PHPMailer(true);

    try {
        //Recipients
        $mail->setFrom('rcasanova2@dmitstudent.ca', 'DMIT Student');
        $mail->addAddress($to, 'My Gmail'); //Add a recipient		    
        $mail->addReplyTo('rcasanova2@dmitstudent.ca', 'My Nait account');
        // $mail->addBCC('bcc@example.com');

        //Attachments
        // $mail->addAttachment('/var/tmp/file.tar.gz');         //Add attachments
        // $mail->addAttachment('/tmp/image.jpg', 'new.jpg');    //Optional name

        //Content
        $mail->isHTML(true); //Set email format to HTML
        $mail->Subject = $subject;
        $mail->Body = $body;
        // $mail->AltBody = 'This is the body in plain text for non-HTML mail clients';

        $mail->send();

        // echo 'Message has been sent';
        header("Location:thank-you.php");

    } catch (Exception $e) {
        echo "Message could not be sent. Mailer Error: {$mail->ErrorInfo}";
    }
    // header("Location:thank-you.php");
}

?>




<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Red+Hat+Display:wght@300&display=swap" rel="stylesheet">
    <title>Grade Calculator</title>
</head>
<style>
    .red-hat-display {
        font-family: 'Red Hat Display', sans-serif;
    }
</style>

<body class="">
    <div class="container ">
        <main class="">
            <div class="py-5 fw-lighter red-hat-display">
                <h1>Complaint form</h1>
                <p class="lead">Here in the Star Wars fan community, we take your complaints seriously. That's why we've
                    created this form, which will swiftly process your complaint (and even more swiftly forward it to
                    our
                    junk mail folder).</p>
                <hr>
            </div>
            <div class="row g-6">
                <div class="col-md-12 ">
                    <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
                        <div class="row g-3 p-3 bg-info-subtle rounded">
                            <div class="col-12">
                                <label for="name" class="form-label">Name:</label>
                                <input type="text" class="form-control" id="name" name="name"
                                    value="<?php echo $name; ?>" placeholder="Your Name">
                                <div id="name-help" class="form-text text-warning"> <!-- our message div -->
                                    <?php echo $message_name; ?>
                                </div>
                            </div>
                            <div class="col-12">
                                <label for="email" class="form-label">Email:</label>
                                <input type="text" class="form-control" id="email" name="email"
                                    value="<?php echo $email; ?>" placeholder="Your Email">
                                <div id="name-help" class="form-text text-warning"> <!-- our message div -->
                                    <?php echo $message_email; ?>
                                </div>
                            </div>
                            <p class="mb-0 mt-4 fw-bold">Reason for Complaint:</p>
                            <div id="name-help" class="form-text text-warning"> <!-- our message div -->
                                <?php echo $message_radio; ?>
                            </div>
                            <div class="form-check">

                                <input class="form-check-input" type="radio" name="reason_for_complaint"
                                    id="reason_for_complaint" checked>
                                <label class="form-check-label" for="reason_for_complaint">
                                    I'm upset that Mara Jade isn't canon.
                                </label>
                            </div>
                            <div class="form-check">
                                <input class="form-check-input" type="radio" name="reason_for_complaint"
                                    id="reason_for_complaint2">
                                <label class="form-check-label" for="reason_for_complaint">
                                    Kathleen Kennedy ruined my life.
                                </label>
                            </div>
                            <div class="form-check">
                                <input class="form-check-input" type="radio" name="reason_for_complaint"
                                    id="reason_for_complaint">
                                <label class="form-check-label" for="reason_for_complaint">
                                    There's a minor error on Yarael Poofs Wookiepedia page.
                                </label>
                            </div>
                            <div class="form-check">
                                <input class="form-check-input" type="radio" name="reason_for_complaint"
                                    id="reason_for_complaint">
                                <label class="form-check-label" for="reason_for_complaint">
                                    I saw a photo of George Lucas in something other than a plaid button-up and it made
                                    me deeply uncomfortable.
                                </label>
                            </div>
                            <div class="form-check">
                                <input class="form-check-input" type="radio" name="reason_for_complaint"
                                    id="reason_for_complaint">
                                <label class="form-check-label" for="reason_for_complaint">
                                    My uncle made me clean the droids instead of letting me go to Tosche Station to pick
                                    up some power converters.
                                </label>
                            </div>
                            <div class="mb-3">
                                <label for="text_area" class="form-label">What is your
                                    message?</label>
                                <textarea name="text_area" class="form-control" id="text_area" cols="30"
                                    rows="10"><?php echo $text_area ?></textarea>
                                <div id="text-help" class="form-text text-warning"> <!-- our message div -->
                                    <?php echo $message_comments; ?>
                                </div>
                            </div>
                            <input class="w-25 btn btn-warning btn-md" type="submit" name="submitOne"
                                value="Lodge Complaint"></input>
                        </div>
                    </form>
                </div>
            </div>
        </main>
    </div>
</body>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
    crossorigin="anonymous"></script>
</body>

</html>