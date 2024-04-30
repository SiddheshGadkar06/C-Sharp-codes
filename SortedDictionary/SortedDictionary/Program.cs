using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedDictionary
{
    public class Program    //DO NOT change the class name
    {
        public static SortedDictionary<int, Book> bookDetails { get; set; } = new SortedDictionary<int, Book>();

        //Implement the methods as per the description
        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            return new SortedDictionary<string, List<Book>>(bookDetails.Values.GroupBy(b => b.Genre).ToDictionary(g => g.Key, g => g.ToList()));
        }

        public Dictionary<string, double> UpdatePenaltyAmount(double amount)
        {
            var lateReturners = bookDetails.Values.Where(b => (DateTime.Parse(b.ReturnDate) - DateTime.Parse(b.IssueDate)).TotalDays > 3);
            foreach (var book in lateReturners)
            {
                book.Penalty = amount;
            }
            return lateReturners.ToDictionary(b => b.MemberID, b => b.Penalty);
            //var lateReturn = bookDetails.Values.Where(b => (DateTime.Parse(b.IssueDate) - DateTime.Parse(b.ReturnDate)).TotalDays > 3).ToDictionary(x => x.MemberID, x => x.Penalty = amount);
            //return lateReturn;
        }

        public List<string> FindBooksNameWithSameDayReturn()
        {
            return bookDetails.Values.Where(b => b.IssueDate == b.ReturnDate).Select(b => b.Name).ToList();
        }


        public static void Main(string[] args) //DO NOT change the method signature
        {
            bookDetails.Add(1, new Book { MemberID = "M01", Name = "The Stranger", Genre = "Adventure", IssueDate = "04/25/2020", ReturnDate = "05/01/2020", Penalty = 0 });
            bookDetails.Add(2, new Book { MemberID = "M02", Name = "War and Peace", Genre = "Historical", IssueDate = "07/15/2008", ReturnDate = "07/15/2008", Penalty = 0 });
            bookDetails.Add(3, new Book { MemberID = "M03", Name = "Odyssey", Genre = "Adventure", IssueDate = "10/25/2003", ReturnDate = "10/25/2003", Penalty = 0 });
            bookDetails.Add(4, new Book { MemberID = "M04", Name = "The Hobbit", Genre = "Fantasy", IssueDate = "11/08/2020", ReturnDate = "11/13/2020", Penalty = 0 });
            bookDetails.Add(5, new Book { MemberID = "M05", Name = "The Alchemist", Genre = "Fantasy", IssueDate = "02/09/2020", ReturnDate = "02/10/2020", Penalty = 0 });

            //Implement code here
            var program = new Program();

            while (true)
            {
                Console.WriteLine("1. Group books by genre");
                Console.WriteLine("2. Update penalty amount");
                Console.WriteLine("3. Find same day return books");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var booksByGenre = program.GroupBooksByGenre();
                        foreach (var genre in booksByGenre)
                        {
                            Console.WriteLine(genre.Key);
                            foreach (var book in genre.Value)
                            {
                                Console.WriteLine(book.Name);
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the penalty amount");
                        double penaltyAmount = Convert.ToDouble(Console.ReadLine());
                        var updatedPenalties = program.UpdatePenaltyAmount(penaltyAmount);
                        foreach (var member in updatedPenalties)
                        {
                            Console.WriteLine("MemberID: " + member.Key);
                            Console.WriteLine("Penalty: " + member.Value);
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        var sameDayReturnBooks = program.FindBooksNameWithSameDayReturn();
                        foreach (var bookName in sameDayReturnBooks)
                        {
                            Console.WriteLine(bookName);
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }
    }

}
