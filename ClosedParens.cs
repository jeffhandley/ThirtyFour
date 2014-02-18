using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThirtyFour
{
    public static class ClosedParens
    {
        public static bool HasMismatchedParens(this string statement)
        {
            return MatchParens(statement).HasMismatch;
        }

        public static int GetParenPairCount(this string statement)
        {
            return MatchParens(statement).ClosedPairCount;
        }

        public static int GetUnopenedParenCount(this string statement)
        {
            return MatchParens(statement).UnopenedCloseParens;
        }

        private struct ParenMatching
        {
            public int ClosedPairCount;
            public int UnclosedOpenParens;
            public int UnopenedCloseParens;
            public bool HasMismatch
            {
                get
                {
                    return (UnclosedOpenParens > 0 || UnopenedCloseParens > 0);
                }
            }
        }

        private static ParenMatching MatchParens(string statement)
        {
            Stack opened = new Stack();
            ParenMatching matching = new ParenMatching();

            foreach (var c in statement)
            {
                if (c == '(')
                {
                    opened.Push(null);
                }
                else if (c == ')')
                {
                    if (opened.Count == 0)
                    {
                        ++matching.UnopenedCloseParens;
                    }
                    else
                    {
                        opened.Pop();
                        ++matching.ClosedPairCount;
                    }
                }
            }

            matching.UnclosedOpenParens += opened.Count;
            return matching;
        }
    }
}
