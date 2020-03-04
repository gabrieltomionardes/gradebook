
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookName = BookRender.RenderBookName();
            var book = BookRender.RenderAddGrades(bookName);
            BookRender.RenderStatistics(book);
            BookRender.RenderLog();
        }
    }
}
