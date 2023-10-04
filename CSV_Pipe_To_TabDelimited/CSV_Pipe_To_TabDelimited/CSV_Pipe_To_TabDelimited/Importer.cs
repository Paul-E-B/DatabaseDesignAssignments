using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Pipe_To_TabDelimited
{
    internal class Importer
    {
        static string scriptName = typeof(Importer).Name;

        static string? currentLineInFile;

        static List<string> allDataFromFile = new List<string>();


        public static List<string> Import(string path)
        {
            allDataFromFile.Clear();
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    //add the name of the file to the top of the data list
                    allDataFromFile.Add(Path.GetFileName(path));

                    while ((currentLineInFile = streamReader.ReadLine()) != null)
                    {
                        allDataFromFile.Add(currentLineInFile);
                    }
                    streamReader.Close();
                }
            }
            catch(Exception e)
            {
                ErrorLog.LogError(e.ToString(), scriptName);
            }


            return allDataFromFile;
        }

    }


    
}
