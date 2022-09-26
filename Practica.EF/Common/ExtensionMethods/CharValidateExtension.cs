using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.ExtensionMethods
{
    public static class CharValidateExtension
    {
        public static bool IsLetters(this string textChain)
        {
            foreach (char ch in textChain)
            {
                if (!Char.IsLetter(ch) && ch != 32)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateBasicString(string enterString)
        {
            if (string.IsNullOrWhiteSpace(enterString) || enterString.All(char.IsDigit) || !CharValidateExtension.IsLetters(enterString))
            {
                return false;
            }
            else return true;
        }
    }

}
