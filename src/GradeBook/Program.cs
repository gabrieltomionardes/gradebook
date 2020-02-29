using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            
            book.AddGrade(2.3);
            book.AddGrade(9.3);
            book.AddGrade(7.4);

            var average = book.ComputeAverage();            
            
            Console.WriteLine($"The average grade is {average:N2}");
        }
    }
}
