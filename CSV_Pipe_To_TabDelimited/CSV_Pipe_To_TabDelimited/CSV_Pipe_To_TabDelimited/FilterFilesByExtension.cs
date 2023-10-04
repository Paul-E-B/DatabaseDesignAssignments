using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Pipe_To_TabDelimited
{
    internal class FilterFilesByExtension
    {

        static List<string> allValid_FilesInDirectory = new List<string>();

        static string scriptName = typeof(FilterFilesByExtension).Name;

        public static List<string> Filter(List<string> filesInDirectory, string[] extensionsToFind)
        {

            foreach (string fileExtension in filesInDirectory)
            {

                try
                {

                    if (extensionsToFind.Any(ext => fileExtension.EndsWith(ext)))
                    {
                        allValid_FilesInDirectory.Add(fileExtension);
                    }
                    else
                    {
                        ErrorLog.LogError("Invalid Extension", scriptName);
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
