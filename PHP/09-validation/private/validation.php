<?php 

// here is where we will have many reusable functions
// trim(): removes spaces before and after a text string
// === means is the same as AND is the same data type as
function is_blank($value){
    return !isset($value) || trim($value) === '';
}

function is_letters($value){
    return preg_match("/^[a-zA-Z\s]*$/", $value);
}

function has_length_exactly($value, $length){
    $str_length = strlen($value);
    return $str_length == $length;// make sure this is == (comparison), not = (assignment)
}


?>