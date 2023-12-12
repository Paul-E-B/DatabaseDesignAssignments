<?php

    $gmdate = gmdate("Y-m-d", time());
    $returnValue = array("success" => true, "serverTime"=>stripslashes($gmdate));
        


    //creates a reference to the func.php file
    require "func.php";

    //create a helper function from func.php
    $helper = new Helper();

    if($_SERVER["REQUEST_METHOD"] == "POST")
    {
        if(isset($_POST['add-fruit']))
        {
            $fruit = $_POST['add-fruit'];
            $helper->AddFruit($fruit);
        }

        if(isset($_POST['remove-fruit']))
        {
            $fruit = $_POST['remove-fruit'];
            $helper->RemoveFruit($fruit);
        }

    }
    else if($_SERVER["REQUEST_METHOD"] == "GET")
    {
        $returnValue['fruit'] = $helper->GetFruit();
        $returnValue['success'] = true;
        //echo stripSlashes($fruitObject);
        
    }
    else
    {
        echo 'no valid request method';
    }


echo stripslashes(json_encode($returnValue));

?>