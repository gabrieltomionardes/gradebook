namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        
        double HighestGrade();
        
        double LowestGrade();
        
        char Letter();
        
        double ComputeAverage();
        
        string Name { get; }
        
        event GradeBookAddedDelegate GradeBookAdded;
    }
}