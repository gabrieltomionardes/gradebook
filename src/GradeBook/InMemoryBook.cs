using System;
using System.Collections.Generic;

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

        public Statistics ComputeStatistics()
        {
            return new Statistics(_grades);
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