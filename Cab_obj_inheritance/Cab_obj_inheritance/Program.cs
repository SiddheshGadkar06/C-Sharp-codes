using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cab_obj_inheritance
{   
    public class Cab
    {
        public string BookingID { get; set; }
        public string CabType { get; set; }
        public double Distance { get; set; }
        public double Fare { get; set; }

    }

    public class CabDetails : Cab
    {
        public bool ValidateBookingID()
        {
            //string pattern = @"^AC@\d{3}$";
            //Regex regex = new Regex(pattern);

            //if (regex.IsMatch(BookingID))
            //{
            //    return true;
            //}
            //return false;

            return Regex.IsMatch(BookingID,@"^AC@\d{3}$");
        }

        public Cab CalculateFareAmount()
        {
            double pricePerKm = 0;
            switch (CabType)
            {
                case "Hatchback":
                    pricePerKm = 10;
                    break;
                case "Sedan":
                    pricePerKm = 20;
                    break;
                case "SUV":
                    pricePerKm = 30;
                    break;
            }
            Fare = Distance * pricePerKm;
            return this;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CabDetails cabDetails = new CabDetails();

            Console.WriteLine("Enter the booking id");
            cabDetails.BookingID = Console.ReadLine();

            if (!cabDetails.ValidateBookingID())
            {
                Console.WriteLine("Invalid booking id");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter the cab type");
            cabDetails.CabType = Console.ReadLine();

            Console.WriteLine("Enter the distance in km");
            cabDetails.Distance = double.Parse(Console.ReadLine());

            Cab cab = cabDetails.CalculateFareAmount();

            Console.WriteLine($"Booking Id : {cab.BookingID}");
            Console.WriteLine($"Cab Type : {cab.CabType}");
            Console.WriteLine($"Distance : {cab.Distance}");
            Console.WriteLine($"Fare : {cab.Fare}");
            Console.ReadKey();
        }
    }
}
