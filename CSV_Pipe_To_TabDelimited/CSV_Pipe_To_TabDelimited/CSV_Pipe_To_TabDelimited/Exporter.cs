using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CSV_Pipe_To_TabDelimited
{
    internal class Exporter
    {
        static string scriptName = typeof(Exporter).Name;

        static string? fileName;

        static List<string> errors = new List<string>();


        public static void Export(List<string> parsedData, string directory)
        {

            fileName = null;
            fileName = parsedData[0].Substring(0, parsedData[0].Length - 4) + "_out.txt";

            try
            {
                using (FileStream fileStream = new FileStream(Path.Combine(directory,fileName), FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        for(int c = 1; c < parsedData.Count; c++)
                        {
                            writer.WriteLine(parsedData[c]);
                            writer.WriteLine();
                        }
                        writer.Close();
                    }
                    fileStream.Close();
                }
            }
            catch(Exception e)
            {
                ErrorLog.LogError(e.ToString(), scriptName);
            }

        }


        public static void ExportErrorLog(string directory)
        {
            try
            {
                using (FileStream fileStream = new FileStream(Path.Combine(directory, "ErrorLog.txt"), FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        errors.Clear();
                        errors = ErrorLog.ReturnErrorLog();

                        foreach(string error in errors)
                        {
                            writer.WriteLine(error);
                            writer.WriteLine();
                        }
                        writer.Close();
                    }
                    fileStream.Close();
                }
            }
            catch (Exception e)
            {
                ErrorLog.LogError(e.ToString(), scriptName);
            }
        }

    }
}
