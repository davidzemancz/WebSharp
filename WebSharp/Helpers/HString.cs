using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSharp.Helpers
{
    internal static class HString
    {
        public static bool Equals(string s, params char[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                if (s.Length <= i || s[i] != chars[i]) return false;
            }
            return true;
        }
    }
}
