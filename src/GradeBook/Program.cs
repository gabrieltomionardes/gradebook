
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // var bookName = BookRender.RenderBookName();
            // var book = BookRender.RenderAddGrades(bookName);
            // BookRender.RenderStatistics(book);
            // BookRender.RenderLog();
            InMemoryBook book = null; // new DiskBook("teste");
            book.AddGrade(20.3);
            book.AddGrade(80.1);
            book.AddGrade(23.1);
        }
    }
}
