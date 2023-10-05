using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Pipe_To_TabDelimited
{
    internal class ParseDelimitedFile
    {
        static string scriptName = typeof(ParseDelimitedFile).Name;

        static string? currentLineInParsedData;

        static List<string> parsedData = new List<string>();

        static string? currentLineInData;

        static string? currentData;

        static int? increment;

        /// <summary>
        /// This method reads through data from an imported file
        /// </summary>
        /// <param name="incomingData"></param>Data of delimited for that needs to be parsed
        /// <param name="delimiter"></param>The delimiter used to seperate portions of data
        /// <returns>Parsed data of the correct format for export</returns>
        public static List<string> Parse(List<string> incomingData, char delimiter)
        {
            //continue to keep the file name as the first line in the data
            parsedData.Add(incomingData[0]);

            //start at 1 because the first line in the data is the name of the file
            for(int i = 1; i < incomingData.Count; i++)
            {
                currentLineInData = incomingData[i];

                currentLineInParsedData += "Line#" + i + " :";

                if (currentLineInData.Contains(delimiter))
                {
                    //increment tracks which line of data is current being read
                    increment = 1;

                    //read through each character in the data
                    for(int c = 0; c < currentLineInData.Length; c++)
                    {
                        try
                        {
                            //if the current character is a delimiter, increment and log that section of data
                            if (currentLineInData[c] == delimiter)
                            {
                                currentLineInParsedData += "Field#" + increment + "=" + currentData + "==> ";
                                currentData = "";
                                increment++;
                                c++;

                            }
                            currentData += currentLineInData[c];
                        }
                        catch(Exception e)
                        {
                            ErrorLog.LogError(e.ToString(), scriptName);
                        }
                    }

                    //Because files don't end with a delimiter, this is called one last time to hold data from the final value
                    currentLineInParsedData += "Field#" + increment + "=" + currentData;


                    parsedData.Add(currentLineInParsedData);

                    currentLineInParsedData = null;
                }
                else
                {
                    ErrorLog.LogError("Delimiter Missing From a Line ", scriptName);
                }


            }





            return parsedData;
        }

    }
}
