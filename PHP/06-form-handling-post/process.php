<!-- Even though this particular demo has exactly 10 inputs, all of which are required, the solution for other possibilities (an odd number, a number of things that we aren't sure of, etc.) is included down below. Students will need this code in their upcoming lab-->

<?php 
if($_SERVER['REQUEST_METHOD'] == 'POST') {
        $nums = array();

        for($i = 1; $i <= 10; $i++){
            $nums[] = $_POST["num{$i}"];

        }
      


        sort($nums); // Sorts the numbers in ascending order.

        //print_r($nums);

        // MEAN

        $count = count($nums); // count eh items in the array
        $sum = array_sum($nums); // calcs the sum of all the elements in the array
        $mean = $sum/$count;

        /*
                The median calculation depends on whether the number of elements in the array is odd or even.

                If the array has an odd number of elements, then the median is simply the middle number. To calculate the index of the middle number, we first subtract 1 from the count to get the maximum index, and then divide by 2 and round down using floor().

                On the other hand, if the array has an even number of elements, then the median is the average of the the two middle elements. To calculate the indices of the two middle elements, we use the same calculation as before, but we store the result in $middle and subtract 1 from it to get the index of the first middle element. We then add 1 to $middle to get the index of the second middle number. 

        */

            $middle = floor(($count - 1)/ 2); // floor rounds to the lowest integer
            // Let's check to see if the number of elements is odd or even.

            if($count % 2 == 0){ // even
                $median = ($nums[$middle] + $nums[$middle + 1]) / 2;
            } else{ // odd

                $median = $nums[$middle];
            }

        // MODE
        
        $mode = array_count_values($nums); // returns only the unique values from the array in an associative array. keys are the unique values and the values are number of time they occur.

        $mode = array_keys($mode, max($mode)); // get the  array item that occurs the mostest

        $mode = implode(',', $mode); // convert array to string
         





        /////////// OUTPUT TO USER

        echo "\n<div class='alert alert-info' role='alert'>";
        echo "\n\t<p>Your numbers: " . implode (',', $nums) . "</p>";
        echo "\n\t <p>Mean {$mean} </p>";
        echo "\n\t<p>Median {$median} </p>";
        echo "\n\t<p>Mode {$mode} </p>";
        echo "\n</div>";
}






?>