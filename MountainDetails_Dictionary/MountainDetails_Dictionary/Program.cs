using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountainDetails_Dictionary
{
    internal class Program
    {
        public static Dictionary<string, int> MountainDetails = new Dictionary<string, int>();

        public void AddMountainDetails(string[] mountain)
        {
            MountainDetails = mountain.Select(m => m.Split(':'))
                        .ToDictionary(details => details[0], details => Convert.ToInt32(details[1]));

        }

        public int FindMountainHeight(string mountainName)
        {
            if (MountainDetails.ContainsKey(mountainName))
            {
                return MountainDetails[mountainName];
            }
            else
            {
                Console.WriteLine("No mountains are available");
                return -1;
            }
        }

        public List<string> FindTheHighestMountains()
        {
            var highest = MountainDetails.Values.Max();
            return MountainDetails.Where(m => m.Value == highest).Select(m => m.Key).ToList();
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            while (true)
            {
                Console.WriteLine("1. Add Mountain Details");
                Console.WriteLine("2. View Mountain Height");
                Console.WriteLine("3. View Mountains With Highest Height");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter the choice");
                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the number of entries");
                        int ent = Convert.ToInt32(Console.ReadLine());
                        var mountain = new string[ent];
                        for (int i = 0; i < ent; i++)
                        {
                            mountain[i] = Console.ReadLine();
                        }
                        p.AddMountainDetails(mountain);
                        break;

                    case 2:
                        Console.WriteLine("Enter the mountain name needs to be searched");
                        string name = Console.ReadLine();
                        var h = p.FindMountainHeight(name);
                        if (h != -1)
                        {
                            Console.WriteLine("Height is :" + h);
                        }
                        break;
                    case 3:
                        var hm = p.FindTheHighestMountains();
                        Console.WriteLine("Mountain Names with highest height are:");
                        foreach (var i in hm)
                        {
                            Console.WriteLine(i);
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
