using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMetricAlgorithms
{
    static class StringMetric
    {
        // Hamming Distance
        public static int Hamming(string _fromWord, string _toWord)
        {
            if(_fromWord.Length != _toWord.Length)
            {
                Console.WriteLine("The Lengths are NOT the same!");
                return -1;
            }

            int numOfDifferences = _fromWord.ToCharArray().Zip(_toWord.ToCharArray(), (c1, c2) => new { c1, c2 }).Count(m => m.c1 != m.c2 );
            return numOfDifferences;
        }

        // Levenshtein Distance
        public static int Levenshtein(string _fromWord, string _toWord, bool _showMatrix = false)
        {
            // Construct the Operation Matrix
            int row = _fromWord.Length;
            int column = _toWord.Length;
            int[,] opMatrix = new int[row + 1, column + 1];


            // Can't compare against a NULL string
            if (row == 0 || column == 0)
                return 0;

            // Initialize the 1st row and column
            for (int i = 0; i <= row; opMatrix[i, 0] = i++) { }
            for (int i = 0; i <= column; opMatrix[0, i] = i++) { } 

            // Iterate through the matrix
            for(int i = 1; i <= row; i++)
            {
                for(int j = 1; j <= column; j++)
                {
                    // Are the current letters the same? 
                    int cost = (_fromWord[i - 1] == _toWord[j - 1]) ? 0 : 1; 

                    // Key - Number of Operations, where operations can be Insertion, Deletion or Replace
                    // Note: The operations are NOT actually performed. 
                    // |_A_|_B_|  =  | Delete  | Insert |
                    // |_C_|_X_|     | Replace | Result |
                    // 
                    int deletion = opMatrix[i - 1, j] + 1;
                    int insertion = opMatrix[i, j - 1] + 1;
                    int substitution = opMatrix[i - 1, j - 1] + cost;
                    opMatrix[i, j] = Math.Min(Math.Min(deletion, insertion) , substitution);
                }
            }

            // Display Matrix, if toggled
            if (_showMatrix)
            {

                for (int i = 0; i <= row; i++)
                {
                    for (int j = 0; j <= column; j++)
                    {
                        Console.Write("|" + opMatrix[i, j].ToString());
                    }
                    Console.WriteLine("");
                }
            }

            // The total number of operations to convert fromWord -> ToWord is located...
            return opMatrix[row, column]; // ...at the bottom right corner of the Operation Matrix
        }

        public static int DamerauLevenshtein(string _fromWord, string _toWord, bool _showMatrix = false)
        {
            // Construct the Operation Matrix
            int row = _fromWord.Length; 
            int column = _toWord.Length; 
            int[,] opMatrix = new int[row + 1, column + 1];

            // Can't compare against a NULL string
            if (row == 0 || column == 0)
                return 0;

            // Initialize the 1st row and column
            for (int i = 0; i < row; opMatrix[i, 0] = i++) { }
            for (int j = 0; j < column; opMatrix[0, j] = j++) { };

            // Iterate through the matrix
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < column; j++)
                {
                    int cost = (_fromWord[i - 1] == _toWord[j - 1]) ? 0 : 1;
                    int insertion = opMatrix[i, j - 1] + 1;
                    int deletion = opMatrix[i - 1, j] + 1;
                    int substitution = opMatrix[i - 1, j - 1] + cost;

                    int distance = Math.Min(insertion, Math.Min(deletion, substitution));

                    // Transposition
                    if (i > 1 && j > 1 && _fromWord[i - 1] == _toWord[j - 2] && _fromWord[i - 2] == _toWord[j - 1])
                    {
                        distance = Math.Min(distance, opMatrix[i - 2, j - 2] + cost);
                    }

                    opMatrix[i, j] = distance;
                }
            }

            // Display Matrix, if toggled
            if (_showMatrix)
            {

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        Console.Write("|" + opMatrix[i, j].ToString());
                    }
                    Console.WriteLine("");
                }
            }

            return opMatrix[row - 1, column - 1];
        }
    }
}
