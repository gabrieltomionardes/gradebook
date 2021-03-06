using System;
using System.Collections.Generic;

namespace GradeBook
{
    static class BookRender
    {
        private static readonly List<string> Log = new List<string>();
        public static string RenderBookName()
        {
            string bookName;
            
            do
            {
                Console.Write("Enter the book name: ");
                bookName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(bookName));

            return bookName;
        }

        public static IBook RenderAddGrades(string bookName)
        {
            const string quit = "Q";
            
            var book = new InMemoryBook(bookName);
            book.GradeBookAdded += OnGradeBookAdded;
            var input = "";
            while (!quit.Equals(input))
            {
                Console.Write("Enter the grade (or 'Q' to quit): ");
                input = Console.ReadLine();

                if (quit.Equals(input)) continue;

                try
                {
                    book.AddGrade(double.Parse(input));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }
            
            return book;
        }
        
        public static void RenderStatistics(IBook book)
        {
            try
            {
                var statistics = book.ComputeStatistics();
                Console.WriteLine($"Grade Book: {book.Name}");
                Console.WriteLine($"The average grade is {statistics.Average:N2}");
                Console.WriteLine($"The highest grade is {statistics.HighestGrade:N2}");
                Console.WriteLine($"The lowest grade is {statistics.LowestGrade:N2}");
                Console.WriteLine($"The letter grade is {statistics.Letter}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }            
        }

        public static void RenderLog()
        {
            Console.WriteLine("LOG");
            Log.ForEach(Console.WriteLine);
        }
        
        static void OnGradeBookAdded(object sender, EventArgs args)
        {
            Log.Add("Grade book was added");
        }
    }
}