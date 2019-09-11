using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ringba_test
{
    class TextProvider
    {
        public static string GetText()
        {
            //In a real world environment this would be read from a config file
            var request = System.Net.WebRequest.Create("https://ringba-test-html.s3-us-west-1.amazonaws.com/TestQuestions/output.txt");
            //In a real world environment this would be read from a config file
            var savePath = "C:\\Users\\franciscov\\Documents\\output.txt";

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

            return File.ReadAllText(savePath);
        }   
    }
}
