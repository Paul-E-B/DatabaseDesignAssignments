using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileReader
{
    public class TxtReader
    {
        StreamReader reader;
        string textContent;
        

        //this code is based on the code found on the microsoft official c# guide

        public string TxtRead(string pathDirectory)
        {
            textContent = null;
            reader = new StreamReader(pathDirectory);
            try
            {

                do
                {
                    textContent += reader.ReadLine();
                }
                while (reader.Peek() != -1);
            }
            catch
            {
                reader.Close();
            }
            return textContent;
        }




    }
}
