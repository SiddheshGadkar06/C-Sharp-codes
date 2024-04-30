//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Perfume_Dict
//{   
//    class Perfume
//    {
//        public string Type { get; set; }
//        public int QuantitySold { get; set; }
//    }
//    internal class Program
//    {
//        public Dictionary<int, Perfume> PerfumeDetails { get; set; } = new Dictionary<int, Perfume>();

//        public void AddPerfumeDetails(string type, int quantity)
//        {
//            PerfumeDetails.Add(PerfumeDetails.Count+1);
//        }
//        static void Main(string[] args)
//        {

//        }
//    }
//}

using System.Collections.Generic;
using System;
using System.Linq;

public class Perfume
{
    public string Type { get; set; }
    public int QuantitySold { get; set; }
}

public class Program
{
    public static Dictionary<int, Perfume> PerfumeDetails = new Dictionary<int, Perfume>();

    public static void Main()
    {
        PerfumeUtility utility = new PerfumeUtility();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Add perfume details");
            Console.WriteLine("2. Find maximum sold perfume");
            Console.WriteLine("3. Sort by quantity sold");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the perfume type");
                    string type = Console.ReadLine();
                    Console.WriteLine("Enter the quantity sold");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    utility.AddPerfumeDetails(type, quantity);
                    break;
                case 2:
                    Console.WriteLine(utility.FindMaximumSoldPerfume());
                    break;
                case 3:
                    var sortedPerfumes = utility.SortByQuantitySold();
                    foreach (var perfume in sortedPerfumes)
                    {
                        Console.WriteLine($"{perfume.Key}\t{perfume.Value}");
                    }
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        Console.WriteLine("Thank you");
    }
}

public class PerfumeUtility
{
    public Dictionary<int, Perfume> PerfumeDetails = Program.PerfumeDetails;

    public void AddPerfumeDetails(string type, int quantity)
    {
        PerfumeDetails.Add(Program.PerfumeDetails.Count + 1, new Perfume { Type = type, QuantitySold = quantity });
        Console.WriteLine("Inserted successfully");
    }

    public string FindMaximumSoldPerfume()
    {
        int maxQuantity = 0;
        string maxSoldPerfume = "";
        foreach (var perfume in PerfumeDetails)
        {
            if (perfume.Value.QuantitySold > maxQuantity)
            {
                maxQuantity = perfume.Value.QuantitySold;
                maxSoldPerfume = perfume.Value.Type;
            }
        }
        return maxSoldPerfume;
    }

    public Dictionary<string, int> SortByQuantitySold()
    {
        var sortedPerfumes = PerfumeDetails.OrderByDescending(x => x.Value.QuantitySold).ToDictionary(x => x.Value.Type, x => x.Value.QuantitySold);
        return sortedPerfumes;
    }
}
