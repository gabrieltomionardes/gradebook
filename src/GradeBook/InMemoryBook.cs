using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class InMemoryBook : IBook
    {
        public event GradeBookAddedDelegate GradeBookAdded;
        
        private readonly ICollection<double> _grades;

        private string _name;
        
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"The name can not be null or empty");
                }

                _name = value;
            }
        }

        public InMemoryBook(string name)
        {
            Name = name;
            _grades = new List<double>();
        }

        public double ComputeAverage() =>
            _grades.Count > 0 ?
            _grades.Aggregate(0.0, (accumulated, next) => accumulated + next) / _grades.Count :
            throw new Exception("Grades is empty");
        
        public double HighestGrade() => _grades.Count > 0 ?_grades.Max() : throw new Exception("Grades is empty");
        
        public double LowestGrade() => _grades.Count > 0 ? _grades.Min() : throw new Exception("Grades is empty");
       
        public char Letter()
        {
            switch (ComputeAverage())
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
        
        public void AddGrade(double grade)
        {
            if (ValidGrade(grade))
            {
                _grades.Add(grade);

                GradeBookAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"The {nameof(grade)} {grade} is invalid");
            }
        }
        
        private bool ValidGrade(double grade) => grade >= 0 && grade <= 100;
    }
}