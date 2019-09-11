using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ringba_test
{
    class Operators
    {
        public static void CountPrefixes(string text)
        {
            SpaceCounters();
            var mostCommPref = "";
            var mostCommPrefCount = 0;
            var mostCommPrefDisplay = "";

            //Starting numbers for i and j are the dec ASCII values for A and a respectively
            for (int i = 65; i < 91; i++)
            {
                for (int j = 97; j < 123; j++)
                {
                    var prefixDisplay = ((char) i).ToString() + ((char) j).ToString();
                    var prefix = prefixDisplay + "[a-z]";
                    var prefixCount = Regex.Matches(text, prefix).Count;

                    if (prefixCount == mostCommPrefCount)
                    {
                        mostCommPref += mostCommPref == "" ? prefix : " " + prefix;
                    }
                    else if (prefixCount > mostCommPrefCount)
                    {
                        mostCommPref = prefix;
                        mostCommPrefDisplay = prefixDisplay;
                        mostCommPrefCount = prefixCount;
                    }
                }
            }
            Console.WriteLine("Most common prefix(es): {0}. Appearances: {1}", mostCommPrefDisplay, mostCommPrefCount);
        }

        public static void CountCaps(string text)
        {
            SpaceCounters();
            var capsCount = Regex.Matches(text, "[A-Z]").Count;
            Console.WriteLine("Number of capitalized letters: {0}", capsCount);
        }

        public static void CountChars(string text)
        {
            SpaceCounters();
            for (int i = 65; i < 91; i++)
            {
                string filter = ((char)i) + "|" + ((char) (i + 32));
                var charCount = Regex.Matches(text, filter).Count;
                Console.WriteLine("Number of appearances of letter {0}: {1}", ((char)i).ToString(), charCount);
            }
        }

        public static void CountWords(string text)
        {
            //A more "correct" strategy would be to add the words to a dictionary and evaluate repetitions
            //But to save memory I chose this approach instead
            SpaceCounters();
            var wordCollection = Regex.Matches(text, @"[\b[A-Z][^A-Z]*]*");

            var mostCommWord = "";
            var mostCommWordCount = 0;

            for (int i = 0; i < wordCollection.Count; i++)
            {
                //This addition to the filter is to keep it from counting the (for example) "Abe" in "Abel"
                string filter = wordCollection[i].Value + @"\B";
                var currentWord = Regex.Matches(text,filter);

                if ((currentWord.Count == mostCommWordCount) && (currentWord[0].ToString() != mostCommWord))
                {
                    mostCommWord += mostCommWord == "" ? wordCollection[i].Value : ", " + wordCollection[i].Value;
                }
                else if (currentWord.Count > mostCommWordCount)
                {
                    mostCommWord = wordCollection[i].Value;
                    mostCommWordCount = currentWord.Count;
                }
            }

            Console.WriteLine("Most common word(s): {0}. Appearances: {1}", mostCommWord, mostCommWordCount);
        }

        private static void SpaceCounters()
        {
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.WriteLine("Gathering statistics. Please wait...");
            Console.WriteLine();
        }
    }
}
