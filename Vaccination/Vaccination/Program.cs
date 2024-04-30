//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Vaccination
//{
//    internal class Program
//    {
//        public static Dictionary<string, string> vaccinationDetails = new Dictionary<string, string>();

//        public void AddVaccinationDetails(Dictionary<string, string> dic)
//        {
//            foreach (var item in dic)
//            {
//                vaccinationDetails.Add(item.Key, item.Value);
//            }
//        }

//        public List<string> GetEmployeeId(string status)
//        {
//            List<string> empId = new List<string>();
//            foreach (var item in vaccinationDetails.Keys)
//            {
//                if (vaccinationDetails[item].Equals(status))
//                {
//                    empId.Add(item);
//                }
//            }
//            return empId;
//        }

//        public string UpdateVaccinationStatus(string id, string status)
//        {
//            foreach (var item in vaccinationDetails.Keys)
//            {
//                if (item.Equals(id))
//                {
//                    vaccinationDetails[item] = status;
//                }
//            }
//            return id + "_" + status;
//        }
//        static void Main(string[] args)
//        {
//            int op = 0;
//            Program p = new Program();

//            while (op != 4)
//            {   

//                Console.WriteLine("1. Add the vaccination details");
//                Console.WriteLine("2. Get Employee id by status");
//                Console.WriteLine("3. Update vaccination details");
//                Console.WriteLine("4. Exit");
//                Console.WriteLine("Enter your Choice");
//                op = Convert.ToInt32(Console.ReadLine());
//                switch (op)
//                {
//                    case 1:
//                        Console.WriteLine("Enter the employee id");
//                        string id = Console.ReadLine();
//                        Console.WriteLine("Enter the status");
//                        string status = Console.ReadLine();
//                        Dictionary<string, string> dic = new Dictionary<string, string>();
//                        dic.Add(id, status);
//                        p.AddVaccinationDetails(dic);
//                        break;
//                    case 2:
//                        Console.WriteLine("Enter the status");
//                        string stat = Console.ReadLine();
//                        var l = p.GetEmployeeId(stat);

//                            foreach(var item in l)
//                            {
//                                Console.WriteLine(item);
//                            }



//                        break;
//                    case 3:
//                        Console.WriteLine("Enter the employee id");
//                        string ids = Console.ReadLine();
//                        Console.WriteLine("Enter the status");
//                        string stats = Console.ReadLine();
//                        Console.WriteLine(p.UpdateVaccinationStatus(ids, stats));
//                        break;
//                    default:
//                        break;
//                }
//            }
//            if (op == 4)
//            {
//                Console.WriteLine("Thank you");
//            }
//            Console.ReadKey();
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static Dictionary<string, string> vaccinationDetails = new Dictionary<string, string>();

    public static void AddVaccinationDetails(string id, string status)
    {
        vaccinationDetails[id] = status;
    }

    public static List<string> GetEmployeeId(string status)
    {
        List<string> employees = new List<string>();
        foreach (var detail in vaccinationDetails)
        {
            if (detail.Value == status)
            {
                employees.Add(detail.Key);
            }
        }
        return employees;
    }

    public static string UpdateVaccinationStatus(string id, string status)
    {
        vaccinationDetails[id] = status;
        return id + "_" + status;
    }

    public static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("1. Add the vaccination details");
            Console.WriteLine("2. Get employee id by status");
            Console.WriteLine("3. Update vaccination details");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the employee id");
                    string id = Console.ReadLine();
                    Console.WriteLine("Enter the status");
                    string status = Console.ReadLine();
                    AddVaccinationDetails(id, status);
                    break;
                case 2:
                    Console.WriteLine("Enter the status");
                    string statusToCheck = Console.ReadLine();
                    List<string> employees = GetEmployeeId(statusToCheck);
                    foreach (string employee in employees)
                    {
                        Console.WriteLine(employee);
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the employee id");
                    string idToUpdate = Console.ReadLine();
                    Console.WriteLine("Enter the status");
                    string newStatus = Console.ReadLine();
                    string result = UpdateVaccinationStatus(idToUpdate, newStatus);
                    Console.WriteLine(result);
                    break;
                case 4:
                    Console.WriteLine("Thank You");
                    break;
            }
        } while (choice != 4);


    }
}
