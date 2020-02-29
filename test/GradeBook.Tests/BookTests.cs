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
            Assert.Equal("Name can not be null or empty", exception.Message);
        }
        
        [Fact]
        public void TestNullGradeBookName()
        {
            void Act() => new Book(null);
            var exception = Assert.Throws<ArgumentException>((Action) Act);
            Assert.Equal("Name can not be null or empty", exception.Message);
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
    }
}
