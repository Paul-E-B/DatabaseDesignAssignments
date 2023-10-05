using System;
using System.Collections.Generic;
using System.Linq;


namespace CSV_Pipe_To_TabDelimited
{
    /// <summary>
    /// A class for processing data
    /// </summary>
    internal class ProcessData
    {
        //Create an instance of this script's name for errorlog purposes
        static string scriptName = typeof(ProcessData).Name;

        //A list to hold data from the current file
        static List<string> dataInCurrentFile = new List<string>();

        //A list of all the parsed data from the file
        static List<string> parsedData = new List<string>();

        //The extension of the current file
        static string? extension;

        //The delimiter used to segment data in the current file
        static char delimiter;


        /// <summary>
        /// This method imports data from a list of all valid file extensions, parses the data, then outputs the parsed data to a txt file
        /// </summary>
        /// <param name="validFilePaths"></param>This is a list of all valid file paths in the desired directory
        /// <param name="extensions_And_Delimiters_To_Parse"></param>This is the dictionary of valid extension and delimiter pairings
        /// <param name="outputDirectory"></param>This is the directory that all of the data should be written to
        public static void Process_Files(List<string> validFilePaths, Dictionary<string, char> extensions_And_Delimiters_To_Parse, string outputDirectory)
        {
            //Cycle through each valid file in the directory
            foreach (string filePath in validFilePaths)
            {
                try
                {
                    //Check if the current file ends is of a valid extension, then stores the matching extension
                    extension = extensions_And_Delimiters_To_Parse.Keys.First(ext => filePath.EndsWith(ext));



                    if (extension != null)
                    {
                        //Import data from the current file path
                        dataInCurrentFile = Importer.Import(filePath);

                        //Delimiter used to segment the incoming data file
                        delimiter = extensions_And_Delimiters_To_Parse[extension];

                        //Clear the list of parsed data so it may be used again
                        parsedData.Clear();

                        //Parse the file and get a list of data from within it
                        parsedData = ParseDelimitedFile.Parse(dataInCurrentFile, delimiter);

                        //Export the parsed data to the desired output directory
                        Exporter.Export(parsedData, outputDirectory);

                    }
                }
                catch (Exception e)
                {
                    ErrorLog.LogError(e.ToString(), scriptName);
                }



            }

        }





    }
}
