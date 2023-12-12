using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileReader
{
    internal class Utility
    {
        //convert string array to list of strings
        public List<string> StringArrayToList(string[] array)
        {
            //create temp list that wil hold data from array
            List<string> tempList = new List<string>();

            //loop through array
            for (int c = 0; c < array.Count(); c++)
            {
                //add array info to the list
                tempList.Add(array[c]);
            }
            //return list
            return tempList;
        }
    }
}
