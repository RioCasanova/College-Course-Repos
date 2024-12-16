<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PHP Custom Functions</title>
</head>

<body>
    <h1>PHP Custom Functions</h1>
    <?php
    /*
    reusable sippets of code that can be called multiple times
    DRY = "Don't Repeat Yourself"

    Syntax:
    function myFunctionName () {
        // code here
    }
    */
    function hello_world()
    {
        return "Hello World!";
    }

    echo "<h3>" . hello_world() . "</h3>";


    // Passing Arguments
    // When we define a function, we can make them more dynamic by passing arguments (parameters). These are local variables. This is important since a custom function cannot access script variables from outside themselves.
    
    function is_bigger($a, $b)
    {
        return $a >= $b;
    }

    $bigger = is_bigger(10, 15);
    if ($bigger) {
        echo "<p>This number is bigger or equal to the second</p>";
    } else {
        echo "<p>This number is not bigger or equal to the second</p>";
    }

    echo "<hr>";
    // We can assign a default value to an argument. This way, that argument becomes optional when we call it.
    
    function times($a, $b = 2)
    {
        return $a * $b;
    }
    echo times(2);


    ?>
</body>

</html>