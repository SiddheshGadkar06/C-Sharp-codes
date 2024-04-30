using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReorderLevel_Dictionary
{
    internal class Program
    {
        public static Dictionary<string, int> ProductDetails = new Dictionary<string, int>();

        public void AddProductDetails(string itemName, int quantity)
        {
            ProductDetails.Add(itemName, quantity);
        }

        public List<string> CheckReorderLevel(int reorderLevel)
        {
            var level = ProductDetails.Where(p => p.Value < reorderLevel).Select(p => p.Key).ToList();
            return level;
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Enter the number of products");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter the item Name");
                string itemName = Console.ReadLine();
                Console.WriteLine("Enter the stock quantity");
                int quantity = Convert.ToInt32(Console.ReadLine());
                p.AddProductDetails(itemName, quantity);
            }
            Console.WriteLine("Enter the reorder Level");
            int lvl = Convert.ToInt32(Console.ReadLine());

            var list = p.CheckReorderLevel(lvl);
            if (list==null)
            {
                Console.WriteLine("No need for reorder");
            }
            else
            {
                Console.WriteLine("List of Products - reorder level below "+lvl);
                foreach (var l in list)
                {
                    Console.WriteLine(l);
                }
            }
            Console.ReadKey();
        }
    }
}

