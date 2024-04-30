//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FirstProject
//{
//    internal class Program
//    {

//        public static Dictionary<string, int> MountainDetails = new Dictionary<string, int>();

//        public static void AddMountainDetails(string[] mountains)
//        {
//            foreach (var mountain in mountains)
//            {
//                var details = mountain.Split(':');

//            }
//        }
//        static void Main(string[] args)
//        {   /*
//            Console.WriteLine("Enter the code");
//            string input = Console.ReadLine();
//            string depC = input.Substring(7,5);

//            Console.WriteLine(depC);
//            Console.WriteLine(input.Length);
//            */

//            /*
//            DateTime aDay = DateTime.Now;
//            TimeSpan aMonth = new System.TimeSpan(30, 0, 0, 0);
//            DateTime aDayAfterAMonth = aDay.Add(aMonth);
//            DateTime aDayBeforeAMonth = aDay.Subtract(aMonth);
//            Console.WriteLine("{0:dddd}", aDayAfterAMonth);
//            Console.WriteLine("{0:dddd}", aDayBeforeAMonth);
//            */

//            //string sentence = "the quick brown fox jumps over the lazy dog";

//            //// Split the string into individual words.
//            //string[] words = sentence.Split(' ');

//            //// Prepend each word to the beginning of the
//            //// new sentence to reverse the word order.
//            //string reversed = words.Aggregate((first, next) =>
//            //                                      next + " " + first);

//            //IEnumerable<string>  r= (from i in words select i);


//            //Console.WriteLine(r);

//            //// This code produces the following output:
//            ////
//            //// dog lazy the over jumps fox brown quick the




//            Console.ReadKey();
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static Dictionary<string, int> ProductDetails { get; set; } = new Dictionary<string, int>();

    public void AddProductDetails(string itemName, int quantity)
    {
        ProductDetails.Add(itemName, quantity);
    }

    public List<string> CheckReorderLevel(int reorderLevel)
    {
        var level = ProductDetails.Where(p => p.Value < reorderLevel).Select(p => p.Key).ToList();
        if (level != null)
        {
            return level;
        }
        else
        {
            Console.WriteLine("No need for reorder");
            return new List<string>();
        }
    }
    public static void Main(string[] args)
    {
        Console.Write("Enter date of birth in yyyy/mm/dd/ format");
        DateTime Dob = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine(DateTime.Today);
        Console.WriteLine(DateTime.Now);
        Console.WriteLine(DateTime.Today.Minute);
        Console.WriteLine(DateTime.Now.Minute);
        Console.WriteLine(DateTime.Today.Month);
        Console.WriteLine(DateTime.Now.Month);
        Console.ReadKey();
    }
}

