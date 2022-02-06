using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSharp.Helpers
{
    internal static class HChar
    {
        public static bool IsParentheses(char c) => c == '(' || c == ')';

        public static bool IsBrackets(char c) => c == '[' || c == ']';

        public static bool IsBraces(char c) => c == '{' || c == '}';

        public static bool IsOperator(char c) => c == '+' || c == '-' || c == '*' || c == '/';

        public static bool Equals(char c, string s)
        {
            return c == s[0];
        }
    }
}
