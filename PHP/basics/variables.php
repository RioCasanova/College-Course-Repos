<?php include "includes/header.php" ?>
<h1>PHP Variables</h1>
<?php
$firstName = "Dirk";
$lastName = "Diggler";

echo "<p>The name is $firstName $lastName</p>";
?>
<h3>Another HTML block to demo a new PHP block</h3>
<?php
echo "<p>The name is $firstName $lastName</p>";
?>

<?php
$theName = "Sal";
$theName .= " Struthers";
echo " The name is $theName";
?>

<?php
$num1 = 3;
$num2 = 5;
$num3 = ($num1 + $num2) / $num1;
$num3 = number_format($num3, 2);
echo "<p>The result is $num3</p>";

$x = 5;
$x++;
echo "<p>The result is $x</p>";

echo (5 > 3) && (4 < 8);
?>





<?php include "includes/footer.php" ?>