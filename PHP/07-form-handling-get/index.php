<?php
/*
    Initialize our form variables. If user has already submitted something we'll use that; if not, we'll give them a placeholder
*/

// If it is not set give it a default value -- this is a ternary statement
$username = isset($_GET['username']) ? $_GET['username'] : 'YOUR NAME';

$job = isset($_GET['job']) ? $_GET['job'] : 'JOB TITLE';
$phone = isset($_GET['phone']) ? $_GET['phone'] : '(123)-456-7890';
$location = isset($_GET['location']) ? $_GET['location'] : 'CITY, PROVINCE';
$email = isset($_GET['email']) ? $_GET['email'] : 'jappleseed@gmail.com';
$website = isset($_GET['website']) ? $_GET['website'] : 'http://www.yourwebsite.com';








print_r($_GET);
?>



<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Business Card Generator</title>
    <link rel="stylesheet" href="css/styles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Heebo&display=swap" rel="stylesheet">
</head>

<body>
    <main>
        <section class="form">
            <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="get">
                <fieldset>
                    <h2>Fill in your info</h2>
                    <p>To generate your very own business card, fill out the information below. When you are finished,
                        press 'Ready' to see the final result.</p>
                </fieldset>
                <fieldset>
                    <div class="form-control">
                        <!--  Here we see how to "prepopulate" a form field that is to keep the previous value-->

                        <input type="text" name="username" id="username" value="<?php echo $username; ?>">
                        <label for="username">Your Name</label>

                    </div>
                    <div class="form-control">
                        <select name="job" id="job">
                            <option value="WEB DEVELOPER" <?php if (isset($job) && $job == "WEB DEVELOPER") {
                                echo "selected";
                            } ?>>Web Developer</option>
                            <option value="UI/UX DESIGNER">UI/UX Designer</option>
                            <option value="PART-TIME JEDI">Part-Time Jedi</option>
                        </select>
                        <label for="job">Job Title</label>
                    </div>
                    <div class="form-control">
                        <input type="tel" name="phone" id="phone" value="<?php echo $phone; ?>">
                        <label for="phone">Phone Number</label>
                    </div>
                    <div class="form-control">

                        <input type="text" name="location" id="location" value="<?php echo $location; ?>">
                        <label for="location">Location</label>
                    </div>
                    <div class="form-control">

                        <input type="email" name="email" id="email" value="<?php echo $email; ?>">
                        <label for="email">Email Address</label>
                    </div>
                    <div class="form-control">
                        <input type="url" name="website" id="website" value="<?php echo $website; ?>">
                        <label for="website">URL</label>
                    </div>

                </fieldset>
                <input type="submit" name="submit" value="Ready!">
            </form>
        </section>
        <section class="card">
            <div class="front-side">
                <div class="color-grid">
                    <div class="black"></div>
                    <div class="red1"></div>
                    <div class="red2"></div>
                    <div class="green"></div>
                </div>
                <div class="info-grid">
                    <div class="name">
                        <h2>
                            <?php echo $username; ?>
                        </h2>
                        <h5>
                            <?php echo $job; ?>
                        </h5>
                    </div>
                    <div class="addr">
                        <img src="img/location.svg" alt="location pin icon">
                        <p>
                            <?php echo $location; ?>
                        </p>
                    </div>
                    <div class="phoneNo">
                        <img src="img/phone.svg" alt="phone icon">
                        <p>
                            <?php echo $phone; ?>
                        </p>
                    </div>
                    <div class="emailId">
                        <img src="img/computer.svg" alt="computer icon">
                        <p class="email">
                            <?php echo $email; ?>

                        </p>
                        <p class="web">
                            <?php echo $website; ?>
                        </p>
                    </div>
                </div>
            </div>
            <!-- Backside of the card -->
            <div class="back-side">
                <div class="color-grid">
                    <div class="black"></div>
                    <div class="red1"></div>
                    <div class="red2"></div>
                    <div class="green"></div>
                </div>
                <div class="name-tag">
                    <h2>
                        <?php echo $username; ?>
                    </h2>
                    <p>
                        <?php echo $job; ?>
                    </p>
                </div>
            </div>
        </section>
    </main>
</body>

</html>