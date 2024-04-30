using System;
using System.Collections.Generic;
using System.Linq;

public class HotelBill
{
    public string BillNo { get; set; }
    public double BillAmount { get; set; }
    public string Status { get; set; }
}

public class Program
{
    public static List<HotelBill> billList = new List<HotelBill>
    {
        new HotelBill { BillNo = "H01", BillAmount = 450, Status = "UnPaid" },
        new HotelBill { BillNo = "H02", BillAmount = 50, Status = "Paid" },
        new HotelBill { BillNo = "H03", BillAmount = 500, Status = "Paid" },
        new HotelBill { BillNo = "H04", BillAmount = 2000, Status = "UnPaid" }
    };


    public static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("1. Get bill details");
            Console.WriteLine("2. Update Bill Status");
            Console.WriteLine("3. Sort Bill By Status");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter bill number");
                    string billNo = Console.ReadLine();
                    List<HotelBill> billDetails = GetBillDetails(billNo);
                    if (billDetails.Count == 0)
                    {
                        Console.WriteLine("Invalid bill number");
                    }
                    else
                    {
                        foreach (var bill in billDetails)
                        {
                            Console.WriteLine($"BillNo: {bill.BillNo}, BillAmount: {bill.BillAmount}, Status: {bill.Status}");
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter bill number");
                    billNo = Console.ReadLine();
                    Console.WriteLine("Enter bill status");
                    string status = Console.ReadLine();
                    List<HotelBill> updatedBill = UpdateBillStatus(billNo, status);
                    if (updatedBill.Count == 0)
                    {
                        Console.WriteLine("Invalid bill number");
                    }
                    else
                    {
                        foreach (var bill in updatedBill)
                        {
                            Console.WriteLine($"BillNo: {bill.BillNo}, BillAmount: {bill.BillAmount}, Status: {bill.Status}");
                        }
                    }
                    break;
                case 3:
                    List<HotelBill> sortedBills = SortBillByStatus();
                    foreach (var bill in sortedBills)
                    {
                        Console.WriteLine($"BillNo: {bill.BillNo}, BillAmount: {bill.BillAmount}, Status: {bill.Status}");
                    }
                    break;
                case 4:
                    Console.WriteLine("Thank You");
                    break;
            }
        } while (choice != 4);
    }

    public static List<HotelBill> GetBillDetails(string billNo)
    {   
        //List<HotelBill> l = (from bill in billList where bill.BillNo == billNo select bill).ToList();
        var res = billList.Where(b => b.BillNo == billNo).Select(b => b).ToList();
        return res;
    }

    public static List<HotelBill> UpdateBillStatus(string billNo, string status)
    {
        //var billToUpdate = (from bill in billList where bill.BillNo == billNo select bill).FirstOrDefault();
        var billToUpdate = billList.Where(b => b.BillNo == billNo).Select(b => b).FirstOrDefault();
        if (billToUpdate != null)
        {
            billToUpdate.Status = status;
            return new List<HotelBill> { billToUpdate };
        }
        return new List<HotelBill>();
    }

    public static List<HotelBill> SortBillByStatus()
    {
        //return (from bill in billList orderby bill.Status descending select bill).ToList();
        var l = billList.OrderByDescending(b=>b.Status).Select(b=>b).ToList();
        return l;
    }
}
