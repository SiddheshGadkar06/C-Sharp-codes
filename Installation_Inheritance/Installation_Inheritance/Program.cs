using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Installation_Inheritance
{
    public class Installation
    {
        public string ExpectedDate { get; set; }
        public string InstalledDate { get; set; }
        public double Rating { get; set; }
        public string Feedback { get; set; }
    }

    public class InstallationDetails : Installation
    {
        public void GetCustomerFeedback()
        {
            DateTime expectedDate = DateTime.Parse(ExpectedDate);
            DateTime installedDate = DateTime.Parse(InstalledDate);

            if (installedDate < expectedDate)
                Feedback = "VeryGood";
            else if (installedDate == expectedDate)
                Feedback = "Good";
            else if (installedDate <= expectedDate.AddDays(3))
                Feedback = "Average";
            else
                Feedback = "Poor";
        }

        public double CalculateRating()
        {
            if (Rating < 1 || Rating > 10)
                return 0;

            switch (Feedback)
            {
                case "VeryGood":
                    Rating += Rating * 0.5;
                    break;
                case "Good":
                    Rating += Rating * 0.2;
                    break;
                case "Average":
                    Rating -= Rating * 0.2;
                    break;
                case "Poor":
                    Rating -= Rating * 0.5;
                    break;
            }

            return Rating;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
    
            InstallationDetails installationDetails = new InstallationDetails();

            Console.WriteLine("Enter the expected date");
            installationDetails.ExpectedDate = Console.ReadLine();

            Console.WriteLine("Enter the installed date");
            installationDetails.InstalledDate = Console.ReadLine();

            Console.WriteLine("Enter the rating");
            installationDetails.Rating = double.Parse(Console.ReadLine());

            installationDetails.GetCustomerFeedback();
            double updatedRating = installationDetails.CalculateRating();

            if (updatedRating == 0)
                Console.WriteLine("Invalid rating");
            else
                Console.WriteLine($"Now your rating is {updatedRating}");

            Console.ReadKey();
        }
    }
}
