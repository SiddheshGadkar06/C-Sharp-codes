using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieScreening_Dictionary
{
    public class Movie
    {
        public string MovieName { get; set; }
        public string ScreenedDate { get; set; }
        public string RemovedDate { get; set; }
        public double Price { get; set; }
    }
    internal class Program
    {
        public static Dictionary<int, Movie> screeningDetails = new Dictionary<int, Movie>();

        public Dictionary<string, double> MovieScreenedMoreNumberOfDays()
        {
            //Gives only one output, so wrong answer
            //var l = screeningDetails.Values.Aggregate
            //        ((s, next) => ((DateTime.Parse(s.RemovedDate) - DateTime.Parse(s.ScreenedDate)).TotalDays >
            //        (DateTime.Parse(next.RemovedDate) - DateTime.Parse(next.ScreenedDate)).TotalDays ? s : next));
            //Dictionary<string, double> Movie = new Dictionary<string, double>();
            //Movie.Add(l.MovieName, l.Price);
            //return Movie;

            //gives Correct answer
            var lim = screeningDetails.Values.Max(x => (DateTime.Parse(x.RemovedDate) - DateTime.Parse(x.ScreenedDate)).TotalDays);
            var min = screeningDetails.Values.Where((x) =>
            {
                var change = (DateTime.Parse(x.RemovedDate) - DateTime.Parse(x.ScreenedDate)).TotalDays;
                return change == lim;
            }).ToDictionary(c => c.MovieName, c => c.Price);
            return min;

        }

    

        public Dictionary<string, double> MovieWithScreenedDays()
        {
            return screeningDetails.Values
                .ToDictionary(s => s.MovieName, s => (DateTime.Parse(s.RemovedDate) - DateTime.Parse(s.ScreenedDate)).TotalDays);
        }
        public static void Main(string[] args)
        {
            screeningDetails.Add(1, new Movie { MovieName = "Avatar", ScreenedDate = "01/01/2024", RemovedDate = "04/11/2024", Price = 150 });
            screeningDetails.Add(2, new Movie { MovieName = "Eternals", ScreenedDate = "02/01/2024", RemovedDate = "03/07/2024", Price = 120 });
            screeningDetails.Add(3, new Movie { MovieName = "Iron Man", ScreenedDate = "01/01/2024", RemovedDate = "04/11/2024", Price = 100 });
            screeningDetails.Add(4, new Movie { MovieName = "LightYear", ScreenedDate = "01/01/2024", RemovedDate = "01/21/2024", Price = 90 });
            screeningDetails.Add(5, new Movie { MovieName = "Black Panther", ScreenedDate = "01/01/2024", RemovedDate = "01/25/2024", Price = 110 });

            var program = new Program();

            while (true)
            {
                Console.WriteLine("1. Movie screening more number of days");
                Console.WriteLine("2. Movie with their screening days");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    var result = program.MovieScreenedMoreNumberOfDays();
                    foreach (var item in result)
                    {
                        Console.WriteLine($"{item.Key} {item.Value}");
                    }
                }
                else if (choice == 2)
                {
                    var result = program.MovieWithScreenedDays();
                    foreach (var item in result)
                    {
                        Console.WriteLine($"{item.Key} {item.Value}");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Thank You");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                }
            }
        }

    
    }
}
