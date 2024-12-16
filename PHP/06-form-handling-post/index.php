<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Mean, Median, &amp; Mode Calculator</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous">
  </head>
  <body>

   <main class="container mt-5">
        <section class="row justify-content-center">
            <div class="col-md-10 col-lg-9 col-xxl-8">
            <h1>Mean, Median, &amp; Mode Calculator</h1>
                <div class="row">
                    <div class="col-md-6">

                    <!-- here we include a file that does the processing. -->
                    <?php  include('process.php');?>

                    <aside class="card">
                        <div class="card-header bg-info">
                            <h2 class="card-title">What are Mean, Median, and Mode</h2>

                        </div>
                        <div class="card-body">
                            <p class="mb-4 text-body-secondary">The mean, media, and mode are different ways figuring out the 'centre', or a 'typical' data point, in a given set of numbers.</p>

                            <dl>
                                <dt>Mean</dt>
                                <dd>The "average" number; found by adding all data points and dividing by the number of data points.</dd>
                                                    
                                <dt>Median</dt>
                                <dd>The middle number; found by ordering all data points and picking out the one in the middle.</dd>
                            
                                <dt>Mode</dt>
                                <dd>The most frequent number = that is, the number that occurs the highest number of times.</dd>
                            
                            </dl>
                            <p class="mt-4 text-body-secondary">
                                Enter ten numbers into the form on the right, then hit Calculate to see your Mean, Median, and Mode.
                            </p>
                        </div>
                    </aside>
                    </div>
                    <div class="col-md-6">
                        <form action="" method="post">
                            <?php 
                                // here, we dynamically create some form elements

                                for($i = 1; $i <= 10; $i++){
                                    echo "\n<div class='mb-3'>";
                                    echo "\n<label for='num{$i}' class='form-label'>Enter Number {$i}: </label>";
                                    echo  "\n<input type='number' class='form-control' name='num{$i}' required>";
                                    echo "\n</div>";

                                }
                            ?>
                            <input type="submit" class="btn btn-primary my-4">

                        </form>
                                

                    </div>
                </div>
            </div>
        </section>
    </main>
    



  </body>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-HwwvtgBNo3bZJJLYd8oVXjrBZt8cqVSpeBNS5n7C8IVInixGAoxmnlMuBnhbgrkm" crossorigin="anonymous"></script>
</html>