<?php

function is_blank($value)
{
    return !isset($value) || trim($value) === '';
}

function is_letters($value)
{
    return preg_match("/^[a-zA-Z\s]*$/", $value);
}

function has_length_exactly($value, $length)
{
    $str_length = strlen($value);
    return $str_length == $length;
}


?>