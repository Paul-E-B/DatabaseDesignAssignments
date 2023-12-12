//this code was created by Paul Baczek on 9/18/2023 for Database Design For Applications, assignment 2
//I found 4 lines of code from user DaisyTian-1203 at the start of the project when I was still re-learning
//windows forms
//https://learn.microsoft.com/en-us/answers/questions/87507/wpf-how-can-i-call-an-openfolderdialog-and-load-th
//The other reference used for this project was the official microsoft visual studio ide guide

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TextFileReader
{
    public partial class Form1 : Form
    {
        //instantiate scripts to use their functions
        Utility utility = new Utility();
        TxtReader TxtReader = new TxtReader();

        //stores fill and contents of a txt file
        Dictionary<string, string> txtInfoDict = new Dictionary<string, string>();
        
        //store all txt files within a directory in a list
        List<string> txtFilesInSelectedPath = new List<string>();

        //used to store the user's directory selection
        string selectedPath;

        //used to store all txt files within the selected directory
        string[] allFilesInDirectory;

        //stores the file info of selected text files
        FileInfo FileProps;

        //used to store various paths in temp use cases 
        string path;

        //content in a single txt file before its char count is taken.
        string contentOfSelectedTxtFile;

        //Holds the char count of a of txt file 
        Dictionary<char, int> characterCount = new Dictionary<char, int>();

        //this string stores the alphabet in order. Used to out dictionary results in order.
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        
        //line 1 found
        //Creates a folder browser dialogue, which is used to display a user's directory and store their selection 
        FolderBrowserDialog openFileDialogue = new FolderBrowserDialog();


        public Form1()
        {
            InitializeComponent();
        }

        //activates when the "Path..." button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //line 2 found
            //Displays the file dialogue to the user and stores their selection
            var result = openFileDialogue.ShowDialog();


            selectedPath = null;

            //line 3 found (modified from DaisyTian's code)
            //Checks to see if the user selects ok
            if (result.ToString() != "Cancel")
            {
                //clear the checked list box options
                checkedListBox1.Items.Clear();

                //clear the text boxes
                richTextBox1.Clear();
                richTextBox2.Clear();


                //line 4 found
                //Saves the user's directory selection to a variable
                selectedPath = openFileDialogue.SelectedPath;
                

                //displays the path next to the selection button
                textBox1.Text = selectedPath;


                //sets the file array to null
                allFilesInDirectory = null;


                //Get an array of all the files within a directory
                allFilesInDirectory = Directory.GetFiles(selectedPath);


                //check each file in the directory and adds it to list if it is a .txt
                txtFilesInSelectedPath = allFilesInDirectory.Where(f => f.Contains(".txt")).ToList();


                //Clear the txt info dict
                txtInfoDict.Clear();

                //cycle through the text files in the selected path
                foreach (string f in txtFilesInSelectedPath) 
                {
                    //populate with files info for current txt file
                    FileProps = new FileInfo(f);

                    //populate with txt file names and paths in selected directory 
                    txtInfoDict.Add(FileProps.Name, f);

                    //outputs the name of the text file to the checked list box
                    checkedListBox1.Items.Add(FileProps.Name); 
                
                }
            }
        
        }


        //activate when check list item is checked or unchecked 
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear richtextbox1
            richTextBox1.Clear();

            //cycle through the list of text files checked in the checked list box
            for (int c = 0; c < checkedListBox1.CheckedItems.Count; c++)
            {
                //This stores the file name the user selected from the check list as a string path
                path = checkedListBox1.CheckedItems[c].ToString();
                

                //read the text file at the defined path and output it into a rich text box
                richTextBox1.Text += "Name: " + path + "   Content: " + TxtReader.TxtRead(txtInfoDict[path]) + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            //clear the results text box
            richTextBox2.Clear();
           
            //cycle through all checkedListBox files
            for (int s = 0; s < checkedListBox1.CheckedItems.Count; s++) 
            {
                //clear the character count dict
                characterCount.Clear();
                
                //stores the file path 
                path = checkedListBox1.CheckedItems[s].ToString();

                //content in file, converted to lowercase for processing
                contentOfSelectedTxtFile = TxtReader.TxtRead(txtInfoDict[path]).ToLower(); 

                
                //note to self - se if adding a utility foreach(var v in variable) with try-catch is viable
                
                //cycles through each char in the curent content file
                foreach(char c in contentOfSelectedTxtFile)
                {

                    //check if character is a letter 
                    if (char.IsLetter(c))
                    {

                        //track character count with a dictionary
                        try
                        {
                            characterCount.Add(c, 1);
                        }
                        catch
                        {
                            characterCount[c] += 1;
                        }
                    }
                }


                //output the current txt file name
                richTextBox2.Text += "Name: " + path + "\n";

                //cycle through the alphabet in order
                for(int i = 0; i < alphabet.Length; i++)
                {
                    //try to out the char count value
                    try
                    {
                        //output the current char and count to result textbox
                        richTextBox2.Text += alphabet[i] + "   " + characterCount[alphabet[i]]+"\n";
                    }
                    catch
                    {
                        //if there is no count of a character, this adds it to the count dict as 0
                        characterCount.Add(alphabet[i], 0);

                        //out the current char and count to result textbox
                        richTextBox2.Text += alphabet[i] + "   " + characterCount[alphabet[i]] + "\n";
                    }
                }

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }
    }
}
