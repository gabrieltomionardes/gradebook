using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private readonly ICollection<double> _grades;
        private readonly string _name;
        public Book(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can not be null or empty");
            }
            _name = name;
            _grades = new List<double>();
        }
        public double ComputeAverage() =>
            _grades.Aggregate(0.0, (accumulated, next) => accumulated + next) / _grades.Count;

        public double HighestGrade() => _grades.Count > 0 ?_grades.Max() : throw new Exception("Grades is empty");
        public double LowestGrade() => _grades.Count > 0 ? _grades.Min() : throw new Exception("Grades is empty");
        public void AddGrade(double grade)
        {
            if (ValidGrade(grade))
            {
                _grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"The grade {grade} is invalid");
            }
        }
        private bool ValidGrade(double grade) => grade >= 0 && grade <= 100;
    }
}