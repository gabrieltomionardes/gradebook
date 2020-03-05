using System;
using System.IO;

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
                    throw new ArgumentException($"The name can not be null or empty");
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
            var writer = File.AppendText($"{Name}.txt");
            try
            {
                writer.WriteLine(grade);
            }
            finally
            {
                writer.Close();    
            }
        }

        public double HighestGrade()
        {
            throw new System.NotImplementedException();
        }

        public double LowestGrade()
        {
            throw new System.NotImplementedException();
        }

        public char Letter()
        {
            throw new System.NotImplementedException();
        }

        public double ComputeAverage()
        {
            throw new System.NotImplementedException();
        }

        public event GradeBookAddedDelegate GradeBookAdded;
    }
}