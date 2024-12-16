<?php include "includes/header.php"; ?>


<h1>Insult Generator</h1>

<form method="post">
    <input type="submit" name="insultme" value="Insult Me!" class="btn btn-danger">
</form>

<?php 
// let's grab the submit button being pressed!!!
// Important! Has the user clicked the button. Without this, stuff happens on page load without having the user interact with your form.

if(isset($_POST['insultme'])){// this "insultme" refers to a form element by it's name attribute. This is mission critical !!!!!
    //echo "Button has been pressed!!!";

    // initialize and populate 2 arrays
   $words1 = array('bloody','witless','lousy','lumpy','crusty');
   $words2 = array('gremlin', 'fungus', 'goblin', 'juggler', 'cow');
   
   // grab a single item at random from each array

   $word1 = $words1[rand(0, count($words1) -1)];
   $word2 = $words2[rand(0, count($words2) -1)];

   echo "<h3 class=\"alert alert-info\">" . $word1 . " " . $word2 . "</h3>";


}


?>

<?php include "includes/footer.php"; ?>
        

