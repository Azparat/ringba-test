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
            Console.WriteLine("Welcome!");
            //Creating a Spacer() overload for this case seemed unnecessary
            Console.WriteLine("--------------");

            try
            {
                var text = TextProvider.GetText();

                Operators.CountChars(text);
                Operators.CountCaps(text);
                Operators.CountWords(text);
                Operators.CountPrefixes(text);
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
