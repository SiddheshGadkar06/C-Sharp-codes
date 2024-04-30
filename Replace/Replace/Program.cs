using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Replace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
            string input = Console.ReadLine();
            //string rep = input.Replace('a', '*');

            string[] arr = input.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                int index = arr[i].IndexOf('a');
                if (index != -1)
                {
                    arr[i] = arr[i].Remove(index, 1).Insert(index, "*");
                }
            }

            string rep = String.Join(" ", arr);

            var b= arr.Where(s => s.Contains('b'));
            foreach(var s in b)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(rep);
            
            Console.ReadKey();
        }
    }
}
