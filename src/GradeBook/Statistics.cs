using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Statistics
    {
        public double Average { get; }
        public double HighestGrade { get; }
        public double LowestGrade { get; }

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var average when average >= 90:
                        return 'A';
                    case var average when average >= 80:
                        return 'B';
                    case var average when average >= 70:
                        return 'C';
                    case var average when average >= 60:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }


        public Statistics(ICollection<double> grades)
        {
            if (grades.Count > 0)
            {
                double total = 0, high = double.MinValue, low = double.MaxValue;
                
                foreach (var grade in grades)
                {
                    total += grade;
                    high = Math.Max(high, grade);
                    low = Math.Min(low, grade);
                }

                Average = total / grades.Count;
                HighestGrade = high;
                LowestGrade = low;
            }
            else
            {
                throw new Exception("Grades is empty");    
            }
        }
    }
}