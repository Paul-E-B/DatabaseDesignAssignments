using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Windows.Documents;

namespace PBaczek_Week13_HW
{
    internal class APITest
    {
        private string url;
        private static readonly HttpClient client = new HttpClient();

        public APITest(string url)
        {
            this.url = url;
        }

        public async Task Fruit_RunAddTestAsync(string fruit)
        {
            var values = new Dictionary<string, string> { { "add-fruit", fruit } };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public async Task Fruit_RunRemoveTestAsync(string fruit)
        {
            var values = new Dictionary<string, string> { { "remove-fruit", fruit } };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        public async Task<string[]> Fruit_RunGetTestAsync()
        {
            var response = await client.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();

            return Fruit_FormatData(responseString);
        }



        string[] Fruit_FormatData(string data)
        {
            data = data.Replace("\"", "");

            string[] splitData = data.Split(',');

            MainWindow.isGetSuccessful = (splitData[0].Replace("{",""));
            MainWindow.serverTime = splitData[1];

            string fruitData = (data.Split(':'))[3];
            fruitData = fruitData.Replace("[","");
            fruitData = fruitData.Replace("]}", "");

            return fruitData.Split(',');
        }



    }
}
