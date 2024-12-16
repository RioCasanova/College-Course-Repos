<?php 
// First, let's import our functions. 
require("../private/validation.php");

/*
Initialize our variables

If user has submitted something, 'well get the data from the form. if not, the variable will be initialized as blank.

We'll also have error messages (one for each form field).
If there is an error, we have to prompt the user
*/

$name = (isset($_POST['name'])) ? trim($_POST['name']): "";
$email = (isset($_POST['email'])) ? trim($_POST['email']): "";
$phone = (isset($_POST['phone'])) ? trim($_POST['phone']): "";
$comments = isset($_POST['comments']) ? trim($_POST['comments']): "";

// Messages variables

$message_name = "";
$message_email= "";
$message_phone = "";
$message_comments = "";

$message_pass = "";

$form_good = isset($_POST['submit']) ? TRUE: FALSE;


if(isset($_POST['submit'])){

    // NAME VALIDATION

        // filter_var(var, filtername, options)

    $name = filter_var($name, FILTER_SANITIZE_STRING); // check string for unwanted chars

    if(is_blank($name)){
        $message_name = "<p>Please enter your name.</p>";
        $form_good = FALSE;
    }elseif(!is_letters($name)){
        $message_name = "<p>Your name can contain only letters and spaces.</p>";
        $form_good = FALSE; 
    }elseif(!$name){
        $message_name = "<p>Please enter a valid name.</p>";
        $form_good = FALSE; 
    }elseif(strpos($name, " ") == false){
        $message_name = "<p>Please enter your first and last name.</p>";
        $form_good = FALSE; 
    }

    // EMAIL VALIDATION

    // on your own...check if email is empty using is_blank()

    if(is_blank($email)){
        $message_email = "<p>Please enter your email.</p>";
        $form_good = FALSE;
    }
    elseif(!filter_var($email, FILTER_SANITIZE_EMAIL) || !filter_var($email, FILTER_VALIDATE_EMAIL))  {
        $message_email = "<p>Please enter a valid email address.</p>";
        $form_good = FALSE;
    }


    // PHONE VALIDATION

    if(is_blank($phone)){
        $message_phone = "<p>Please enter your phone number.</p>";
        $form_good = FALSE;  
    }elseif(!filter_var($phone,FILTER_SANITIZE_NUMBER_INT)){
        $message_phone = "<p>Please enter a valid phone number, using numbers only.</p>";
        $form_good = FALSE;
    }

    /*

    Phone numbers can come in a variety of different formats
    examples:
    +1 (780) 123 4567
    1 780 123 4567
    780.123.4567
    (780) 123 4567

    etc.
    
    What we can do is to remove certain characters ourselves without frustraing the user.
    */

    $phone = str_replace('-','', $phone);
    $phone = str_replace('+','', $phone);
    $phone = str_replace(' ','', $phone);
    $phone = str_replace('(','', $phone);
    $phone = str_replace(')','', $phone);

    /*
    We may also want to just give the user one error message at a time, so we can do this in a separate process
    */

    if($form_good == TRUE){
        if(!is_numeric($phone)){
            $message_phone = "<p>Please enter a valid phone number, using numbers only.</p>";
            $form_good = FALSE; 
        }elseif(!has_length_exactly($phone, 10)){
            $message_phone = "<p>Please enter a 10 digit phpne number. </p>";
            $form_good = FALSE;
        }
    }

    // COMMENTS VALIDATION

    if(is_blank($comments)){
        $message_comments = "<p>Please enter your comments.</p>";
        $form_good = FALSE;  
    }
    // On your own... write one or two validators for the length of the comments

    if(strlen($comments) < 5){
        $message_comments = "<p>What. You got writers block? Comments should be more than 5 characters please.</p>";
        $form_good = FALSE;  
    }
    if(strlen($comments) > 200){
        $message_comments = "<p>We don't need your life story here. Some good comments only in less than 200 characters please.</p>";
        $form_good = FALSE;  
    }

    // continue cleaning up comments

    $comments = filter_var($comments, FILTER_SANITIZE_SPECIAL_CHARS);

    $comments = filter_var($comments, FILTER_SANITIZE_STRING);


}// \ if submit

if($form_good == TRUE){
    $message_pass = "<p>SUCCESS. You have passed validation.</p>";
}

?>
<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>PHP Form Validation</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">

    <style>
        .required label:before{ /* the .required class is added to the parent of the label we want to have the * char in */
           color: #fff; /* white works for this example, but change to red or black for most others. */
           content: "*";
           position: absolute;
           margin-left: -15px;
           font-weight:bold;
        }


    </style>
    
  </head>
  <body class="bg-dark">
    <div class="container w-50 p-3 justify-content-center align-items-center ">
        <h1 class="text-light text-center">PHP Form Validation</h1>
     
        <form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>" method="post">

        <div class="mb-3 required">
            <label for="name" class="form-label text-light">Name</label>
            <input type="text" name="name" class="form-control" value="<?php echo $name; ?>"> 

            <div id="name-help" class="form-text text-warning"> <!-- our message div -->
               <?php echo $message_name; ?>
            </div>
            

        </div>

        <div class="mb-3 required">
            <label for="email" class="form-label text-light">Email</label>
            <input type="text" name="email" class="form-control" value="<?php echo $email; ?>"> 
            
            <div id="email-help" class="form-text text-warning">
               <?php echo $message_email; ?>
            </div>


        </div>

        <div class="mb-3 required">
            <label for="phone" class="form-label text-light">Phone</label>
            <input type="text" name="phone" class="form-control" value="<?php echo $phone; ?>">
            
            <div id="phone-help" class="form-text text-warning">
               <?php echo $message_phone; ?>
            </div>    
        </div>

        <div class="mb-3 required">
            <label for="comments" class="form-label text-light">Comments</label>

        <textarea name="comments" id="comments" class="form-control"><?php echo $comments; ?></textarea>  
            
            <div id="comments-help" class="form-text text-warning">
               <?php echo $message_comments; ?>
            </div> 

        </div>
        <button type="submit" class="btn btn-primary" name="submit">Submit</button>
        </form>

        <!-- Good place for our SUCCESS message -->
        <?php if($form_good == TRUE): ?>
            <div class="alert alert-warning my-4">
                <?php echo $message_pass; ?>
            </div>
        <?php endif; ?>

    </div>
  </body>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</html>

