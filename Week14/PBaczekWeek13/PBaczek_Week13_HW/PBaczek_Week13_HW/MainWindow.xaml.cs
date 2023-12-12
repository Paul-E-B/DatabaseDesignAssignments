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
using System.Windows.Media.Animation;

namespace PBaczek_Week13_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        APITest test = new APITest("http://ec2-3-141-26-114.us-east-2.compute.amazonaws.com/index.php");

        public MainWindow()
        {

            InitializeComponent();
            UserInput.Text = "Enter fruit name here...";

        }

        string command;


        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            await test.Fruit_RunAddTestAsync(UserInput.Text);
            
            ClearUserInput();

        }




        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            await test.Fruit_RunRemoveTestAsync(UserInput.Text);

            ClearUserInput();

        }

        public static string? serverTime;
        public static string? isGetSuccessful;

        private async void Print_Click(object sender, RoutedEventArgs e)
        {
            FruitList.Items.Clear();

            string[] online_fruitData = await test.Fruit_RunGetTestAsync();
            //FruitList.Items.Add(online_fruitData);

            FruitList.Items.Add(isGetSuccessful);
            FruitList.Items.Add(serverTime);
            FruitList.Items.Add("");

            foreach (string fruit in online_fruitData)
            {
                FruitList.Items.Add(fruit);
            }
            
        }


        void ClearUserInput()
        {
            UserInput.Text = string.Empty;
        }



    }
}