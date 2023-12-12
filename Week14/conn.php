<?php

    //creates a connect to the database
    //where are we connecting - localhost because this database is on the server
    //which user is connecting - root
    //with what password - 123456
    //specify which database - web_design_database
    $link = mysqli_connect("localhost","root","123456","web_design_database");


    //print an error if there's not no error
    if(mysqli_connect_errno())
    {
        printf("Connect failed: %s\n", mysqli_connect_error());
        exit();
    }


?>