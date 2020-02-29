using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Science");
            
            book.AddGrade(2.3);
            book.AddGrade(9.3);
            book.AddGrade(7.4);

            var average = book.ComputeAverage();
            var highestGrade = book.HighestGrade();
            var lowestGrade = book.LowestGrade();
            
            Console.WriteLine($"The average grade is {average:N2}");
            Console.WriteLine($"The highest grade is {highestGrade:N2}");
            Console.WriteLine($"The lowest grade is {lowestGrade:N2}");
        }
    }
}
