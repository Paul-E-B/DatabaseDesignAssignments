<?php
    
    //create a class to add functions
    class Helper
    {
        
        

        //$ creates an argument that allows a variable to be passed in
        public function AddFruit($fruit)
        {
            //creates a connect to the database
            //where are we connecting - localhost because this database is on the server
            //which user is connecting - root
            //with what password - 123456
            //specify which database - web_design_database
            $link = mysqli_connect("localhost","root","123456","web_design_database");

            //the use of the .variable. is similar to +variable+ in c# string syntax.
            //this is an SQL query written in SQL for the fruit table
            $query = "INSERT INTO fruit(name) VALUES ('".$fruit."')";

            //this is taking the link created from the "conn.php" file
            $result = mysqli_query($link,$query); 
            
            //close the link
            $link->close();

        }

        public function RemoveFruit($fruit)
        {
            $link = mysqli_connect("localhost","root","123456","web_design_database");

            $query = "Delete From fruit where name='".$fruit."'";

            $result = mysqli_query($link,$query); 
            
            $link->close();
        }

        
        public function GetFruit()
        {
            $fruitArr = Array();

            $link = mysqli_connect("localhost","root","123456","web_design_database");

            //select all from fruit
            $query = "Select * From fruit";

            if($result = mysqli_query($link,$query))
            {
                //if there are rows in the table
                if($result->num_rows>0)
                {
                    //while row has some value
                    while($row = $result->fetch_array(MYSQLI_ASSOC))
                    {
                        array_push($fruitArr, $row['name']);
                    }
                }
            }

            $link->close();

            return $fruitArr;
        }
    }

?>