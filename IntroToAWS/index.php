<?php

    //creates a reference to the func.php file
    require "func.php";

    //create a helper function from func.php
    $helper = new Helper();

    if(isset($_REQUEST['add-fruit']))
    {
        $fruit = $_REQUEST['add-fruit'];
        $helper->AddFruit($fruit);
    }

    if(isset($_REQUEST['remove-fruit']))
    {
        $fruit = $_REQUEST['remove-fruit'];
        $helper->RemoveFruit($fruit);
    }


    if(isset($_REQUEST['print-fruit']))
    {
        $helper->PrintFruit($fruit);
    }
?>