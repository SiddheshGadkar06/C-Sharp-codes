using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pld
{
    internal class Palindrome
    {
        public bool Pal(string input)
        {
            string reverse = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reverse += input[i];
            }

            if (input == reverse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
