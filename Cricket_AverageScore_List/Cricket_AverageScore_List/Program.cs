using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_AverageScore_List
{
    internal class Program
    {
        public static List<int> playerList = new List<int>();

        public void AddScoreDetails(int runScored)
        {
            playerList.Add(runScored);
        }

        public double GetAverageRunsSecured()
        {
            double total = 0;
            if (playerList != null)
            {
                foreach (var i in playerList)
                {
                    total = total + i;
                }
                var l = Math.Round((total / playerList.Count),2);
                return l;
                //return total / playerList.Count;
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            int op = 0;
            Program p = new Program();

            while (op != 3)
            {

                Console.WriteLine("1. Add runs Scored");
                Console.WriteLine("2. Average Score of the player");                
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your Choice");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Enter the runs scored");
                        int run = Convert.ToInt32(Console.ReadLine());
                        p.AddScoreDetails(run);
                        break;
                    case 2:
                        Console.WriteLine("Average runs secured: "+ p.GetAverageRunsSecured());
                        break;
                    default:
                        break;
                }
            }
            if (op == 3)
            {
                Console.WriteLine("Thank you");
            }
            Console.ReadKey();
        }
    }
}
