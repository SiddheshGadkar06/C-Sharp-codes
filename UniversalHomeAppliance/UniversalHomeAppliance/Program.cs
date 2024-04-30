using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalHomeAppliance   //DO NOT change the namespace name
{
    public class Appliance    //DO NOT change the class name
    {
        //Implement code here
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
    }
    public class Program    //DO NOT change the class name
    {
        public static Dictionary<int, Appliance> applianceDetails = new Dictionary<int, Appliance>();

        //Implement the methods as per the description
        public Dictionary<string, string> GetApplianceDetails(string applianceID)
        {
            var res = applianceDetails.Values.Where(a => a.Id == applianceID).ToDictionary(a=>a.Id, (a) =>
            {
                return a.Name + "_" + a.Brand;
            });
            return res;
        }
        public Dictionary<string, string> FindApplianceWithPriceRange(double minRange, double maxRange)
        {
            var res = applianceDetails.Values.Where(a => a.Price >= minRange && a.Price <= maxRange).ToDictionary(a=>a.Name,a=>a.Brand);
            return res;
        }

        public Dictionary<int, Appliance> FindHighCostAppliance()
        {
            var highest = applianceDetails.Values.Max(a => a.Price);
            return applianceDetails.Where(a => a.Value.Price == highest).ToDictionary(a => a.Key, a => a.Value);
        }
        public static void Main(string[] args) //DO NOT change the method signature
        {
            applianceDetails.Add(1, new Appliance { Id = "AP01", Name = "Refrigerator", Brand = "LG", Price = 10000 });
            applianceDetails.Add(2, new Appliance { Id = "AP02", Name = "Dishwasher", Brand = "Samsung", Price = 25000 });
            applianceDetails.Add(3, new Appliance { Id = "AP03", Name = "Oven", Brand = "Bosch", Price = 5000 });
            applianceDetails.Add(4, new Appliance { Id = "AP04", Name = "Microwave", Brand = "Whirlpool", Price = 7500 });
            applianceDetails.Add(5, new Appliance { Id = "AP05", Name = "Toaster", Brand = "LG", Price = 1500 });

            //Implement code here

        }
    }
}