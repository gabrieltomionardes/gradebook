using System;
using System.IO;
using System.Linq;

namespace GradeBook
{
    public class DiskBook : IBook
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name can not be null or empty");
                }

                _name = value;
            }
        }
        
        public DiskBook(string name)
        {
            Name = name;
        }
        
        public void AddGrade(double grade)
        {
            if (ValidGrade(grade))
            {
                using var writer = File.AppendText($"{Name}.txt");
                writer.WriteLine(grade);
                if (GradeBookAdded != null)
                {
                    GradeBookAdded.Invoke(grade, new EventArgs());
                }    
            }
            else
            {
                throw new ArgumentException($"The {nameof(grade)} {grade} is invalid");
            }
        }

        public Statistics ComputeStatistics()
        {
            var grades = File.ReadLines($"{Name}.txt").Select(double.Parse).ToList();
            return new Statistics(grades);
        }

        public event GradeBookAddedDelegate GradeBookAdded;
        
        private bool ValidGrade(double grade) => grade >= 0 && grade <= 100;
    }
}