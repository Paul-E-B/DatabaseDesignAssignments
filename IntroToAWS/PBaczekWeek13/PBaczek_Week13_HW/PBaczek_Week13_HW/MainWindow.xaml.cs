using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Linq;
using System;
using System.Reflection.PortableExecutable;
using System.Xml;
using System.Security.Policy;

namespace PBaczek_Week13_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserInput.Text = "Enter fruit name here...";

        }

        string command;

        private void Add_Click(object sender, RoutedEventArgs e)
        {
                command = $"http://ec2-3-141-26-114.us-east-2.compute.amazonaws.com/index.php?add-fruit={UserInput.Text}";
                Execute_SqlCommand_Via_Url(command);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            command = $"http://ec2-3-141-26-114.us-east-2.compute.amazonaws.com/index.php?remove-fruit={UserInput.Text}";
            Execute_SqlCommand_Via_Url(command);

        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            FruitList.Items.Clear();

            string urlText = Call_url("http://ec2-3-141-26-114.us-east-2.compute.amazonaws.com/index.php?print-fruit=true");

            string[] splitText = urlText.Split('>');

            foreach (string line in splitText)
            {
                FruitList.Items.Add(line.Replace("<br", ""));
            }
        }


        public string Call_url(string url)
        {
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string urlText = reader.ReadToEnd(); // it takes the response from your url. now you can use as your need  

            reader.Close();

            return urlText;
        }


        void Execute_SqlCommand_Via_Url(string url)
        {
            if (UserInput.Text != "Enter fruit name here..." && UserInput.Text != "")
            {
                UserInput.Text = string.Empty;
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
            }
        }


    }
}