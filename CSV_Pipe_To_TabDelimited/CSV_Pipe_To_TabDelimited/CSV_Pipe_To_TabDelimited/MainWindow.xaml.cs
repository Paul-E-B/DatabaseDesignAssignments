using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;


namespace CSV_Pipe_To_TabDelimited
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //string result;

        Dictionary<string, char> extensions_And_Delimiter_To_Parse = new Dictionary<string, char>();

        string[] validFileExtensions;

        string directory;

        List<string> allFiles_InDirectory = new List<string>();


        List<string> validFiles_InDirectory = new List<string>();


        



        public MainWindow()
        {
            //adds the parse parameters for csv files
            extensions_And_Delimiter_To_Parse.Add(".csv", ',');


            //adds the parse parameters for pipe files
            extensions_And_Delimiter_To_Parse.Add(".txt", '|');

            //gets a string array of the file extensions to parse
            validFileExtensions = extensions_And_Delimiter_To_Parse.Keys.ToArray();

            directory = "..\\..\\..\\resources";

            InitializeComponent();


        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            allFiles_InDirectory = GetFilePaths.All_FilesInDirectory(directory);

            validFiles_InDirectory = FilterFilesByExtension.Filter(allFiles_InDirectory, validFileExtensions);

            ProcessData.Process_Files(validFiles_InDirectory, extensions_And_Delimiter_To_Parse, directory);

            TheText.Text = "Files Processed";
        }
    }
}
