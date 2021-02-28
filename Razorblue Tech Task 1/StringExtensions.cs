using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RazorblueTechTask1
{
    public static class StringExtensions
    {
        /// <summary>
        /// Function to compare two strings and determine whether they are anagrams
        /// </summary>
        /// <returns>
        /// true if both values are an anagram of each other; otherwise, false
        /// </returns>
        public static bool IsAnagramOf(this string value, string valueToCompare)
        {
            // if either value is null, return false
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(valueToCompare))
            {
                return false;
            }

            // create character maps for each value
            var firstCharMap = CreateCharacterMap(value);
            var secondCharMap = CreateCharacterMap(valueToCompare);

            // if the total count of each map doesn't match we don't have an anagram
            if (firstCharMap.Count != secondCharMap.Count)
            {
                return false;
            }

            return firstCharMap.All(f => secondCharMap.ContainsKey(f.Key) ? f.Value == secondCharMap[f.Key] : false);
        }

        private static Dictionary<char, int> CreateCharacterMap(string value)
        {
            // remove special characters
            string cleansedValue = CleanseValue(value);

            // return a Dictionary as a character map
            return cleansedValue.Distinct()
                                .ToDictionary(v => v, v => cleansedValue.Count(c => c == v));
        }

        private static string CleanseValue(string value)
        {
            // use a regex to take the original value and remove special characters
            // and return the transformed value as a lowercase string
            return Regex.Replace(value, @"[_]+|[^\w]+|[\d-]+", "").ToLower();
        }
    }
}
