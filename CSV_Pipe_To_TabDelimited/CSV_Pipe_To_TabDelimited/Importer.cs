using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Pipe_To_TabDelimited
{
    internal class Importer
    {

        public static string? fileExtension;

        public static char delimiter;

        static string? currentLineInFile;

        static int lineCounter;

        static string? fileName;

        /// <summary>
        /// Import all data from desired file. This is currently geared toward txt
        /// files.
        /// </summary>
        /// <param name="path"></param>This is the relative path of a file
        /// <returns>A list of all data from the file</returns>
        public static void StreamData(List<string> inputPaths, string outputPath)
        {
            ClearOutputDirectory(outputPath);

            foreach (string currentFilePath in inputPaths)
            {
                //checks if the file extension is valid
                FilterFileByExtension(currentFilePath);

                if(fileExtension != null)
                { 
                    fileName = Path.GetFileName(currentFilePath);

                    delimiter = MainWindow.extensions_And_Delimiter_To_Parse[fileExtension];


                    using (StreamReader reader = new StreamReader(currentFilePath))
                    {
                        using (FileStream fileStream = new FileStream(Path.Combine(outputPath,fileName), FileMode.OpenOrCreate))
                        {
                            using(StreamWriter writer = new StreamWriter(fileStream))
                            { 
                                lineCounter = 1;

                                //Read the script until null
                                while ((currentLineInFile = reader.ReadLine()) != null)
                                {
                                    
                                    //parse the line of data
                                    ParseDelimitedFile.ParseDelimterLine(currentLineInFile, delimiter);

                                    //Export that line of data
                                    Exporter.ExportStream(lineCounter, ParseDelimitedFile.parsedData, writer);

                                    lineCounter++;
                                }
                                writer.Close();
                            }
                            fileStream.Close();
                        }
                        reader.Close();
                    }
                }

            }   

        } 



        static void FilterFileByExtension(string path)
        {
            if (MainWindow.validFileExtensions.Any(ext => path.EndsWith(fileExtension = ext)))
            {

            }
            else
            {
                fileExtension = null;
                ErrorLog.LogError("Invalid extension", path);
            }   
        }




        static void ClearOutputDirectory(string outputPath)
        {
            var dir = Directory.GetFiles(outputPath);
            foreach(string file in dir)
            {
                File.Delete(file);
            }
        }


    }

}


    

