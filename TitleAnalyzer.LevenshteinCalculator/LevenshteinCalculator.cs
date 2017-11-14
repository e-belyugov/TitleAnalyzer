using System;
using TitleAnalyzer.Domain.Abstract;

namespace TitleAnalyzer.LevenshteinCalculator
{
    /// <summary>
    /// Levenshtein similarity calculator
    /// </summary>
     public class LevenshteinCalculator : ISimilarityCalculator
    {
        public double Calculate(string string1, string string2)
        {
            int count1 = string1.Length;
            int count2 = string2.Length;
            int[,] matrix = new int[count1, count2];

            for (int i = 0; i < count1; i++) matrix[i, 0] = i + 1;
            for (int i = 0; i < count2; i++) matrix[0, i] = i + 1;

            for (int i = 1; i < count2; i++)
            {
                for (int j = 1; j < count1; j++)
                {
                    if (string1[j] == string2[i])
                    {
                        matrix[j, i] = matrix[j - 1, i - 1];
                    }
                    else
                    {
                        matrix[j, i] = Math.Min(matrix[j - 1, i] + 1, Math.Min(matrix[j, i - 1] + 1, matrix[j - 1, i - 1] + 1));
                    }
                }
            }

            return matrix[count1 - 1, count2 - 1];
        }
    }
}
