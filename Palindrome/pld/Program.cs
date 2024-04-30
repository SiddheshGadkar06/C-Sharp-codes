using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string or number");
            string input = Console.ReadLine();
            
            Palindrome palindrome = new Palindrome();
            if (palindrome.Pal(input))
            {
                Console.WriteLine(input + " is a Palindrome.");
            }
            else
            {
                Console.WriteLine(input + " is not a Palindrome.");
            }
            Console.ReadKey();
        }
    }
}
