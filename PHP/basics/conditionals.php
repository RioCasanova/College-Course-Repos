<?php include "includes/header.php" ?>
<h1>Conditionals</h1>
<h3>if/else</h3>
<?php
if (5 < 3) {
    echo "A True statement";
} else {
    echo "Not a True statement";
}

echo "<p> </p>";
$userName = "Dirk";
$passWord = "Boogie";

if (($userName == "Dirk") && ($passWord == "Boogie")) {
    echo "welcome";
} else {
    echo "NOT Welcome";
}

$x = 2;
switch ($x) {
    case 1:
        echo "One";
        break;
    case 2:
        echo "Two";
        break;
    case 3:
        echo "Three";
        break;
    default:
        echo "We do not know that value";
        break;
}
?>
<?php include "includes/footer.php" ?>