using LibAdventOfCode2017.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAdventOfCode2017.Helpers
{
    public static class HelperDay9 
    {
        static string RemoveCancelled(this string input)
        {
            int start = 0;
            while ((start = input.IndexOf('!')) > -1)
            {
                input = input.Remove(start, 2);
            }
            return input;
        }

        static string RemoveGarbage(this string input)
        {
            int start = 0;
            while ((start = input.IndexOf('<')) > -1)
            {
                int end = input.IndexOf('>') + 1;
                input = input.Remove(start, end - start);
            }
            return input;
        }

        public static string CleanUp(this string input)
        {
            return input.RemoveCancelled().RemoveGarbage();
        }

        public static bool QuickCheckIfBalanced(this string input)
        {
            if (input.Count(x => x == '{') != input.Count(x => x == '}'))
            {
                throw new Exception("Unbalanced String");
            }
            return true;
        }

        public static bool ParseInput(this string input)
        {
            if (input.QuickCheckIfBalanced()) {; }
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>() { { '{', '}' } };
            List<char> ValidDelimiters = new List<char> { '{', '}', ',', ' ' };
            List<char> Spaces = new List<char> { '\r', '\n', '\t', ' ' };
            Stack<char> brackets = new Stack<char>();

            try
            {
                char previousChar = ' ';
                // Iterate through each character in the input string
                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];
                    if (Spaces.Contains(c))
                        continue;

                    // check if the character is one of the 'opening' brackets
                    if (bracketPairs.Keys.Contains(c))
                    {
                        // if yes, push to stack
                        if (ValidDelimiters.Contains(previousChar))
                        {
                            brackets.Push(c);
                        }
                        else
                        {
                            throw new Exception("Malformed Input");
                        }
                        previousChar = c;
                    }
                    else
                        // check if the character is one of the 'closing' brackets
                        if (bracketPairs.Values.Contains(c))
                    {
                        if (ValidDelimiters.Contains(previousChar))
                        {
                            // check if the closing bracket matches the 'latest' 'opening' bracket
                            if (c == bracketPairs[brackets.First()])
                            {
                                brackets.Pop();
                            }
                            else
                            { // if not, its an unbalanced string
                                return false;
                                throw new Exception("Unbalanced String");
                            }
                        }
                        else
                        {
                            throw new Exception("Malformed Input");
                        }
                        previousChar = c;
                    }
                    else
                    // continue looking
                    { previousChar = c; continue; }
                }
            }
            catch
            {
                // an exception will be caught in case a closing bracket is found, 
                // before any opening bracket.
                // that implies, the string is not balanced. Return false
                return false;
            }

            // Ensure all brackets are closed
            if (brackets.Count() == 0)
                return true;
            else
                throw new Exception("Unbalanced String");
        }
    }
}