using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Pipe_To_TabDelimited
{
    internal class ProcessData
    {

        static string scriptName = typeof(ProcessData).Name;

        static List<string> dataInCurrentFile = new List<string>();

        static List<string> parsedData = new List<string>();

        static string? extension;

        static char delimiter;

        public static void Process_Files(List<string> validFilePaths, Dictionary<string, char> extensions_And_Delimiters_To_Parse, string outputDirectory)
        {
            foreach (string filePath in validFilePaths)
            {
                try
                {
                    extension = extensions_And_Delimiters_To_Parse.Keys.First(ext => filePath.EndsWith(ext));
                }
                catch(Exception e)
                {
                    ErrorLog.LogError("Invalid Extension ", scriptName);
                }



                if (extension != null)
                {
                    dataInCurrentFile = Importer.Import(filePath);

                    delimiter = extensions_And_Delimiters_To_Parse[extension];

                    parsedData.Clear();

                    parsedData = ParseDelimitedFile.Parse(dataInCurrentFile, delimiter);

                    Exporter.Export(parsedData, outputDirectory);


                }



            }

        }





    }
}
