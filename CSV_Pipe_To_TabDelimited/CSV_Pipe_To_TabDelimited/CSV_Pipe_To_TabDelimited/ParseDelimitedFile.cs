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

        static string? lineOfParsedData;

        static List<string> parsedData = new List<string>();

        static string? currentLineInData;

        static string? currentData;

        static int? increment;

        static char[]? endOfLineTrim = { '=', '=', '>', ' ' };

        public static List<string> Parse(List<string> incomingData, char delimiter)
        {
            //continue to keep the file name as the first line in the data
            parsedData.Add(incomingData[0]);

            //start at 1 because the first line in the data is the name of the file
            for(int i = 1; i < incomingData.Count; i++)
            {
                currentLineInData = incomingData[i];

                lineOfParsedData += "Line#" + i + " :";

                if (currentLineInData.Contains(delimiter))
                {
                    increment = 1;

                    for(int c = 0; c < currentLineInData.Length; c++)
                    {
                        try
                        {
                            if (currentLineInData[c] == delimiter)
                            {
                                lineOfParsedData += "Field#" + increment + "=" + currentData + "==> ";
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

                    lineOfParsedData += "Field#" + increment + "=" + currentData;


                    parsedData.Add(lineOfParsedData);

                    lineOfParsedData = null;
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
