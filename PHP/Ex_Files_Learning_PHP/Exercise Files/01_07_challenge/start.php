<?php
$name = "Teresa"; // Heading 1
$city = "NYC";
$movie = "Star Wars"; //Italics
$friend = "George"; //Bold
$candy = "Sour Patch Kids";


echo '<h1>' . $name . '</h1>';
echo '<p>Drove to</p>';
print_r($city);
echo '<p>To watch</p>';
echo "<i>{$movie}</i>";
echo "<p>with</p>" . "<b>{$friend}</b>";
echo "<p>and ate {$candy}</p>";
?>

// SOLUTION <-- so weird how this shows up... <?php
$name = "Teresa"; // Heading 1
$city = "NYC";
$movie = "Star Wars"; //Italics
$friend = "George"; //Bold
$candy = "Sour Patch Kids";
?> <h1>
    <?php echo $name; ?>
    </h1>
    <?php
    // echo "<h1>Hello, $name</h1>\n\n";
    echo "<p>So glad you can join us in $city today! You will be <b>$friend</b>'s guide as you do a range of activities.</p>\n\n";

    echo "<p>You will end your day by seeing <i>$movie</i> at 7pm. Make sure to bring the money you've been provided. The movie ticket is \$12. $friend's favourite candy is $candy, so grab some of those too.</p>\n\n";