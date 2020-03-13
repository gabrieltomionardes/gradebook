namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        
        Statistics ComputeStatistics();
               
        string Name { get; }
        
        event GradeBookAddedDelegate GradeBookAdded;
    }
}