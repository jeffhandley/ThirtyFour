using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ThirtyFour
{
    public static class RepeatedString
    {
        public static string LongestRepeatedString(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            var repeats = new List<Tuple<string, int>>();

            for (var x = 0; x < input.Length; ++x)
            {
                for (var l = 1; x + l <= input.Length; ++l)
                {
                    var pattern = input.Substring(x, l);
                    repeats.Add(Tuple.Create(pattern, Regex.Matches(input, pattern).Count));
                }
            }

            var longest = repeats
                .Where(r => r.Item2 > 1)
                .OrderByDescending(r => r.Item1.Length)
                .ThenByDescending(r => r.Item2)
                .FirstOrDefault();

            return longest != null ? longest.Item1 : null;
        }
    }
}
