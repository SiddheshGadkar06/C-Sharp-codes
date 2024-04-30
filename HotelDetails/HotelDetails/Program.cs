using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDetails
{
        public class Program
        {
            public static Dictionary<String, float> hotelDetails = new Dictionary<string, float>()
        {
            {"The Hay Adams", 3},
            {"Montage Kapalua Bay", 3.5f},
            {"Jungle Resort", 4.5f},
            {"Mandarin Oriental", 5},
            {"The Greenwich Hotel", 5}
        };


        public static Dictionary<String, float> SearchHotel(String hotelName)
        {
            var l = hotelDetails.Where(h => hotelName == h.Key).ToDictionary(h => h.Key, h => h.Value);
            return l;
        }

        public static Dictionary<String, float> UpdateHotelRating(string hotelName, float rating)
        {
            var result = new Dictionary<String, float>();
            if (hotelDetails.ContainsKey(hotelName))
            {
                hotelDetails[hotelName] = rating;
                result.Add(hotelName, rating);
            }
            return result;
        }


        public static Dictionary<String, float> SortByHotelName()
        {
            var l = hotelDetails.OrderBy(h => h.Key).Select(h => h).ToDictionary(h => h.Key, h => h.Value);
            return l;
        }

        public static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("1. Search by hotel name");
                Console.WriteLine("2. Update hotel rating");
                Console.WriteLine("3. Sort hotels by name");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the hotel name");
                        string hotelName = Console.ReadLine();
                        var result = SearchHotel(hotelName);
                        if (result == null)
                            Console.WriteLine("Hotel Not Found");
                        else
                            foreach (var item in result)
                                Console.WriteLine($"{item.Key} {item.Value}");
                        break;
                    case 2:
                        Console.WriteLine("Enter the hotel name");
                        hotelName = Console.ReadLine();
                        Console.WriteLine("Enter the rating");
                        float rating = float.Parse(Console.ReadLine());
                        result = UpdateHotelRating(hotelName, rating);
                        if (result == null)
                            Console.WriteLine("Hotel Not Found");
                        else
                            foreach (var item in result)
                                Console.WriteLine($"{item.Key} {item.Value}");
                        break;
                    case 3:
                        result = SortByHotelName();
                        foreach (var item in result)
                            Console.WriteLine($"{item.Key} {item.Value}");
                        break;
                    case 4:
                        Console.WriteLine("Thank you");
                        break;
                }
            } while (choice != 4);
        }


    }
}
