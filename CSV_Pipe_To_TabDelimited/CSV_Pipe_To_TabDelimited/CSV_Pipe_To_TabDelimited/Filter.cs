using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Pipe_To_TabDelimited
{
    /// <summary>
    /// A class that holds methods related to filtering file directories
    /// </summary>
    internal class Filter
    {
        //the list that will be passed at the end of the program
        static List<string> allValid_FilesInDirectory = new List<string>();

        //get the script's name for errorlog purposes
        static string scriptName = typeof(Filter).Name;


        /// <summary>
        /// A method to create a list of files in a given directory that are of a valid file extension type 
        /// </summary>
        /// <param name="filesInDirectory"></param>This is a full list of all files in the desired directory
        /// <param name="validExtensions"></param>This is an array of the valid extensions
        /// <returns>A list of all files with the valid file extension in a desired directory</returns>
        public static List<string> FilterFilesByExtension(List<string> filesInDirectory, string[] validExtensions)
        {

            foreach (string currentFilePath in filesInDirectory)
            {

                try
                {
                    //If the current file path ends with any extension within the valid extension array,
                    //they are added to the list of files that will be returned
                    if (validExtensions.Any(ext => currentFilePath.EndsWith(ext)))
                    {
                        allValid_FilesInDirectory.Add(currentFilePath);
                    }
 
                }
                catch (Exception e)
                {
                    ErrorLog.LogError(e.ToString(), scriptName);
                }

            }
            return allValid_FilesInDirectory;
        }

    }
}
