using System;

namespace GradeBook
{
    static class BookRender
    {
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

        public static Book RenderAddGrades(string bookName)
        {
            const string quit = "Q";
            
            var book = new Book(bookName);
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
        
        public static void RenderStatistics(Book book)
        {
            try
            {
                Console.WriteLine($"Grade Book: {book.Name}");
                Console.WriteLine($"The average grade is {book.ComputeAverage():N2}");
                Console.WriteLine($"The highest grade is {book.HighestGrade():N2}");
                Console.WriteLine($"The lowest grade is {book.LowestGrade():N2}");
                Console.WriteLine($"The letter grade is {book.Letter()}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }            
        }
    }
}