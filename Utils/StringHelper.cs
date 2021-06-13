using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFormValidator.Utils
{
    class StringHelper
    {
        public static string GetStringBetweenTwoCharacters(string text, char startChar, char endChar)
        {
            int startIndex = text.IndexOf(startChar);
            int endIndex = text.IndexOf(endChar);
            return text.Substring(startIndex + 1, endIndex - startIndex - 1);
        }
    }
}
