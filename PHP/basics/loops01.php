<?php include "includes/header.php" ?>

<h1>PHP Loops</h1>

<?php
echo "<h2>The While Statement</h2>";

$i = 1; // initialization

while ($i <= 5) {
    echo "The number is " . $i . "<br>";
    $i++; // incrementation
}
echo "<hr>";
?>


<?php include "includes/footer.php" ?>