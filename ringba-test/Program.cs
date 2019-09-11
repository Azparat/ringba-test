using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ringba_test
{
    class Program
    {
        static void Main(string[] args)
        {
            //In a real world environment this would be read from a config file
            var request = System.Net.WebRequest.Create("https://ringba-test-html.s3-us-west-1.amazonaws.com/TestQuestions/output.txt");
            //In a real world environment this would be read from a config file
            var savePath = "C:\\Users\\franciscov\\Documents\\output.txt";


            Console.WriteLine("Welcome!");
            //Creating a Spacer() overload for this case seemed unnecesary
            Console.WriteLine("--------------");

            try
            {
                using (Stream stream = request.GetResponse().GetResponseStream())
                {
                    Console.WriteLine("");
                    Console.WriteLine("Obtaining file. Please wait...");

                    var fStream = new FileStream(savePath, FileMode.Create);
                    byte[] byteArray = new byte[256];
                    int count = stream.Read(byteArray, 0, byteArray.Length);

                    while (count > 0)
                    {
                        fStream.Write(byteArray, 0, count);
                        count = stream.Read(byteArray, 0, byteArray.Length);
                    }

                    fStream.Close();
                }

                var text = File.ReadAllText(savePath);

                Operators.CharCounter(text);
                Operators.CapsCounter(text);
                //Operators.WordCounter(text);
                Operators.PrefixCounter(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error obtaining the file");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
