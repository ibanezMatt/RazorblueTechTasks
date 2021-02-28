using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorbuleTechTask3.Models;

namespace RazorbuleTechTask3.Helpers
{
    public static class LevenshteinDistance
    {
        /// <summary>
        /// Will compute the minimum number of changes required to transform the given string to our validOption
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validOption"></param>
        /// <returns>an object of key, being the validOption and the cost of transforming the value to the validOption</returns>
        public static LevenshteinCost Compute(string value, string validOption)
        {
            int valueLength = value.Length;
            int validOptLength = validOption.Length;
            int[,] d = new int[valueLength + 1, validOptLength + 1];

            // Initialize arrays.
            for (int i = 0; i <= valueLength; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= validOptLength; d[0, j] = j++)
            {
            }

            for (int i = 1; i <= valueLength; i++)
            {
                for (int j = 1; j <= validOptLength; j++)
                {
                    // calculate the cost
                    int cost = (validOption[j - 1] == value[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost
                    );
                }
            }

            // Return cost object.
            return new LevenshteinCost
            {
                Key = validOption,
                Cost = d[valueLength, validOptLength]
            };
        }
    }
}
