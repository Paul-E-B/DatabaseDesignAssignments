using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace CSV_Pipe_To_TabDelimited
{
    internal class GetFilePaths
    {

        static string scriptName = typeof(GetFilePaths).Name;

        static List<string> all_FilesInDirectory = new List<string>();

        /// <summary>
        /// This method creates a list of extensions to all files in a desired directory
        /// </summary>
        /// <param name="directory"></param>The extension to the desired directory
        /// <returns>A list of all file extensions in the desired directory</returns>
        public static List<string> All_FilesInDirectory(string directory)
        {
            try
            {
                all_FilesInDirectory = Directory.GetFiles(directory).ToList();
            }
            catch (Exception e)
            {
                ErrorLog.LogError(e.ToString(), scriptName);
            }
            return all_FilesInDirectory;
        }


    }
}
