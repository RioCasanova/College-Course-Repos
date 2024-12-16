<!doctype html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Date Checker</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
</head>

<body>

    <div class="container mt-5">
        <h1>Date Checker</h1>
        <p class="lead text-muted mb-5">What to know how many days its been since something has happened? What about a
            countdown until a date in the future? Enter a date below to check how many days are between now and then.
        </p>

        <form action="<?php echo $_SERVER['PHP_SELF'] ?>" method="get">
            <div class="mb-3">
                <label for="date" class="form-label">Enter a date:</label>
                <input type="date" name="date" class="form-control"
                    value="<?php echo isset($_GET['date']) ? $_GET['date'] : ''; ?>" required>
            </div>
            <button style="submit" class="btn btn-primary">Submit</button>
        </form>
        <?php
        // Because we are using get method, we need to make sure that the user is not tampering with the URL (like phil does with Moodle).
        
        function validateDate($date)
        {
            $dateFormat = 'Y-m-d';
            $parsedDate = date_parse_from_format($dateFormat, $date);
            return $parsedDate['error_count'] === 0 && checkdate($parsedDate['month'], $parsedDate['day'], $parsedDate['year']);
        }

        // calculate hte difference in days between two dates
        function calculateDaysDifference($date)
        {
            $currentDate = date('Y-m-d');
            $difference = strtotime($currentDate) - strtotime($date);
            return round($difference / (60 * 60 * 24));
        }

        if ($_SERVER['REQUEST_METHOD'] === 'GET') {
            if (isset($_GET['date'])) {
                $inputDate = $_GET['date'];


                if (validateDate($inputDate)) {
                    $daysDifference = calculateDaysDifference($inputDate);
                    if ($daysDifference < 0) {
                        echo "<div class='alert alert-success mt-3'> The date is in the future. There are " . abs($daysDifference) . " days left. </div>";
                    } elseif ($daysDifference > 0) {
                        echo "<div class='alert alert-warning mt-3'> The date is in the past. It was " . abs($daysDifference) . " days ago. </div>";
                    } else {
                        echo "<div class='alert alert-info mt-3'> The date is today!</div>";
                    }
                } else {
                    echo "<div class='alert alert-danger mt-5'> Invalid Date Format </div>";
                }
            }
        }

        ?>
    </div>
</body>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
    crossorigin="anonymous"></script>

</html>