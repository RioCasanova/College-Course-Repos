<?php include "includes/header.php"; ?>
<h1>PHP Arrays</h1>
<h2>Numeric Arrays</h2>

<?php
$arrFruit = array();
array_push($arrFruit, "apple", "raspberry", "orange");

echo "<pre>"; // allows HTML to retain whitespace so our array output is prettier
print_r($arrFruit);
echo "</pre>";

// to access a single item in our array we need to know the index number 

echo "<p>The second item is "
    . $arrFruit[1] . ".</p>";
?>
<h2>Associative Arrays</h2>

<?php
$salaries["Clarance"] = 5000;
$salaries["Bobby-Sue"] = 4000;
$salaries["Biffy"] = 2500;
$salaries["Skippy"] = 2;

echo "Bobby-Sues salary is " . $salaries["Bobby-Sue"];

echo "<pre>";
print_r($salaries);
echo "</pre>";
?>
<h2>Some Interesting Array Examples</h2>

<?php
echo "<pre>";
print_r($_SERVER);
echo "</pre>";

?>


<?php include "includes/footer.php"; ?>