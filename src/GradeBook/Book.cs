using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private readonly ICollection<double> _grades = new List<double>();

        public double ComputeAverage() =>
            _grades.Aggregate((a, b) => a + b) / _grades.Count;

        public void AddGrade(double grade)
        {
            if (ValidGrade(grade))
            {
                _grades.Add(grade);
            }
            else
            {
                throw new Exception($"The grade {grade} is invalid");
            }
        }

        private bool ValidGrade(double grade) => grade >= 0 || grade <= 100;
    }
}