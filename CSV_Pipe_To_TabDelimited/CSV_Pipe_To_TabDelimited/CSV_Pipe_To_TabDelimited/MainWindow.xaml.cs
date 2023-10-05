using System.Collections.Generic;
using System.Linq;
using System.Windows;



namespace CSV_Pipe_To_TabDelimited
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //This holds the pairings of valid extension and that file type's associated delimiter
        Dictionary<string, char> extensions_And_Delimiter_To_Parse = new Dictionary<string, char>();

        //An array of the valid file extension
        string[] validFileExtensions;


        //This is the directory this program reads from
        string inputDirectory;


        //This is the directory this program writes to
        string outputDirectory;


        //A list of all files in the input directory
        List<string> allFiles_InDirectory = new List<string>();


        //A list of all files with a valid extension in the input directory
        List<string> validFiles_InDirectory = new List<string>();


        

        /// <summary>
        /// Called when the program loads.
        /// It initializes all important info to for the program
        /// </summary>
        
        public MainWindow()
        {
            InitializeDesired_ExtensionDelimiterPairing();

            InitializeDirectories("..\\..\\..\\resources", "..\\..\\..\\resources\\output");

            InitializeComponent();
        }


        /// <summary>
        /// This is what happens when the user clicks The Button with the word "Activate"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Get a list of all paths to all files in the directory
            allFiles_InDirectory = GetFilePaths.All_FilesInDirectory(inputDirectory);

            //Filter the extensions of all files so that only valid file types
            validFiles_InDirectory = Filter.FilterFilesByExtension(allFiles_InDirectory, validFileExtensions);

            //Import the data and parse it
            ProcessData.Process_Files(validFiles_InDirectory, extensions_And_Delimiter_To_Parse, outputDirectory);

            //Inform the user that their files have been processed in The Textbox
            TheText.Text = "Files Processed";
        }



        /// <summary>
        /// This initialized the extensions and delimiters that are going
        /// to be parsed. It's currently hard-coded, but it's not hard to
        /// modify for a user to pass in a string and char.
        /// </summary>
        private void InitializeDesired_ExtensionDelimiterPairing()
        {
            //Adds the parse parameters for csv files
            extensions_And_Delimiter_To_Parse.Add(".csv", ',');


            //Adds the parse parameters for pipe files
            extensions_And_Delimiter_To_Parse.Add(".txt", '|');

            //Gets a string array of the correct file extensions to parse
            validFileExtensions = extensions_And_Delimiter_To_Parse.Keys.ToArray();
        }



        /// <summary>
        /// A method to set the input and output directories
        /// </summary>
        /// <param name="inDirectory">The input directory
        /// <param name="outDirectory">The output directory
        private void InitializeDirectories(string inDirectory, string outDirectory)
        {
            inputDirectory = inDirectory;

            outputDirectory = outDirectory;
        }

    }
}
