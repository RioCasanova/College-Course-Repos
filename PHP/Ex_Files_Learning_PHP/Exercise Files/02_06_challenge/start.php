<?php
$min = 1;
$max = 50;
$guess = -1; //Change this value to test!
$num = 16; // Change this value to test!

// If you really want to go nuts, try this:
// $num = rand($min, $max);



$result = match (true) {
    $guess < $min => 'Guess is out of range -- must be more than 1',
    $guess > $max => 'Guess is out of range -- must be less than 50',
    $guess > $num => 'incorrect -- too high',
    $guess < $num => 'incorrect -- too low',
    $guess == $num => 'Good guess! -- that is correct',
    default => 'Unknown'
};

echo $result;