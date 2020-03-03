using System;
using Xunit;

namespace GradeBook.Tests
{    
    public class BookTests
    {
        [Fact]
        public void TestEmptyGradeBookName()
        {
            void Act() => new Book("");
            var exception = Assert.Throws<ArgumentException>((Action) Act);
            Assert.Equal("The name can not be null or empty", exception.Message);
        }

        [Fact]
        public void CanChangeGradeBookName()
        {
            var book = new Book("Gbrl's");

            book.Name = "Gabriel's";
            
            Assert.Equal("Gabriel's", book.Name);
        }
        
        [Fact]
        public void TestNullGradeBookName()
        {
            void Act() => new Book(null);
            var exception = Assert.Throws<ArgumentException>((Action) Act);
            Assert.Equal("The name can not be null or empty", exception.Message);
        }

        [Fact]
        public void TestComputeAverage()
        {
            var book = new Book("Gabriel's");
            book.AddGrade(39.2);
            book.AddGrade(81.4);
            book.AddGrade(67.6);
            book.AddGrade(70);

            var average = book.ComputeAverage();
            
            Assert.Equal(64.55, average, 1);
        }
        
        [Fact]
        public void TestHighestGradeWithValues()
        {
            var book = new Book("Gabriel's");
            book.AddGrade(29.3);
            book.AddGrade(41.8);
            book.AddGrade(79.2);
            book.AddGrade(63.1);
            
            var highestGrade = book.HighestGrade();

            Assert.Equal(79.2, highestGrade);
        }

        [Fact]
        public void TestHighestGradeWithoutValues()
        {
            var book = new Book("Gabriel's");

            void Act() => book.HighestGrade();

            var exception = Assert.Throws<Exception>((Action) Act);
            
            Assert.Equal("Grades is empty", exception.Message);
        }
        
        [Fact]
        public void TestLowestGradeWithValues()
        {
            var book = new Book("Gabriel's");
            book.AddGrade(29.3);
            book.AddGrade(41.8);
            book.AddGrade(79.2);
            book.AddGrade(63.1);

            var lowestGrade = book.LowestGrade();
            
            Assert.Equal(29.3, lowestGrade);
        }
        
        [Fact]
        public void TestLowestGradeWithoutValues()
        {
            var book = new Book("Gabriel's");

            void Act() => book.LowestGrade();

            var exception = Assert.Throws<Exception>((Action) Act);
            
            Assert.Equal("Grades is empty", exception.Message);
        }
        
        [Fact]
        public void TestAddHighInvalidGrade()
        {
            var book = new Book("Gabriel's");

            void Act() => book.AddGrade(101);

            var exception = Assert.Throws<ArgumentException>((Action) Act);
            
            Assert.Equal("The grade 101 is invalid", exception.Message);
        }
        
        [Fact]
        public void TestAddLowInvalidGrade()
        {
            var book = new Book("Gabriel's");

            void Act() => book.AddGrade(-2);

            var exception = Assert.Throws<ArgumentException>((Action) Act);
            
            Assert.Equal("The grade -2 is invalid", exception.Message);
        }

        [Fact]
        public void GetFLetter()
        {
            var book = new Book("Gabriel's");
            book.AddGrade(33.1);
            book.AddGrade(60.3);
            book.AddGrade(21);

            var letter= book.Letter();
            
            Assert.Equal('F', letter);
        }
        
        [Fact]
        public void GetDLetter()
        {
            var book = new Book("Gabriel's");
            book.AddGrade(70.1);
            book.AddGrade(60.3);
            book.AddGrade(65);

            var letter= book.Letter();
            
            Assert.Equal('D', letter);
        }
        
        [Fact]
        public void GetCLetter()
        {
            var book = new Book("Gabriel's");
            book.AddGrade(70.1);
            book.AddGrade(80.3);
            book.AddGrade(71);

            var letter= book.Letter();
            
            Assert.Equal('C', letter);
        }
        
        [Fact]
        public void GetBLetter()
        {
            var book = new Book("Gabriel's");
            book.AddGrade(92.1);
            book.AddGrade(80.3);
            book.AddGrade(87.2);

            var letter= book.Letter();
            
            Assert.Equal('B', letter);
        }
        
        [Fact]
        public void GetALetter()
        {
            var book = new Book("Gabriel's");
            book.AddGrade(92.1);
            book.AddGrade(99.3);
            book.AddGrade(87.2);

            var letter= book.Letter();
            
            Assert.Equal('A', letter);
        }
    }
}
