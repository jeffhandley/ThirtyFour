using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThirtyFour
{
    public static class NumericRanges
    {
        private class Range
        {
            public Range(int min, int max)
            {
                Min = min;
                Max = max;
            }

            public int Min { get; set; }
            public int Max { get; set; }

            public override string ToString()
            {
                if (Min == Max)
                {
                    return Min.ToString();
                }

                return String.Format("{0}-{1}", Min, Max);
            }
        }

        private static IEnumerable<Range> ToRanges(this int[] numbers)
        {
            if (!numbers.Any())
            {
                return new Range[0];
            }

            var range = new Range(numbers.First(), numbers.First());
            var ranges = new List<Range>(new[] { range });

            foreach (var number in numbers.Skip(1))
            {
                if (number == range.Max + 1)
                {
                    range.Max = number;
                }
                else
                {
                    range = new Range(number, number);
                    ranges.Add(range);
                }
            }

            return ranges;
        }

        public static string ToRangesString(this int[] numbers)
        {
            return String.Join(",", numbers.ToRanges());
        }
    }
}
