using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CSV_Pipe_To_TabDelimited
{
    //a class for exporter related methods
    internal class Exporter
    {

        /// <summary>
        ///A method used for exporting a list of strings as a txt file to a desired directory
        /// </summary>
        /// <param name="parsedData"></param>The parsed data from a delimited file
        /// <param name="directory"></param>The desired output directory for the txt file
        public static void ExportStream(int lineCounter, string data, StreamWriter writer)
        {
            
            try
            {
                writer.WriteLine("Line#"+lineCounter+" :" + data);
                writer.WriteLine();
                                        
            }
            catch(Exception exportError)
            {
                ErrorLog.LogError(exportError.ToString(), data);
            }

        }



















        /*


        /// <summary>
        /// A method used to export the error log to a txt file
        /// </summary>
        /// <param name="directory"></param>The desired output directory
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
        */

    }
}
