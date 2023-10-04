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
