using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMetricAlgorithms
{
    class Program
    {
        // Examples of Hamming, Levenshtein & Damerau-Levenshtein
        // Number of operations would take to convert from String1 -> String2 or...
        // ...Number of different characters between the two Strings
        static void Main(string[] args)
        {
            Console.WriteLine("Compare 'Rem' and her sister 'Ram' names: " + StringMetric.Hamming("Rem", "Ram")); // 1
            Console.WriteLine("Compare 'Luigi' and 'Waluigi' names: " + StringMetric.Levenshtein("Luigi", "Waluigi")); // 3
            Console.WriteLine("Compare 'Fox McCloud' and 'James McCloud names: " + StringMetric.DamerauLevenshtein("Fox McCloud", "James McCloud")); // 5
            Console.WriteLine("Compare 'Pikachu' and 'Pichu' names: " + StringMetric.Levenshtein("Pikachu", "Pichu")); // 2 
        }
    }
}
