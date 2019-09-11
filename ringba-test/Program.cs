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

                Operators.PrintCharUse(Operators.CountChars(text));

                var capsStatistics = Operators.CountCaps(text);
                Console.WriteLine("Number of capitalized letters: {0}", capsStatistics.MostCommCount);

                var wordStatistics = Operators.CountWords(text);
                Console.WriteLine("Most common word(s): {0}. Appearances: {1}", wordStatistics.MostComm, wordStatistics.MostCommCount);

                var prefixStatistics = Operators.CountPrefixes(text);
                Console.WriteLine("Most common prefix(es): {0}. Appearances: {1}", prefixStatistics.MostComm, prefixStatistics.MostCommCount);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error performing request");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
