namespace EduCare.DesignPatterns.Composite.Base
{
    public interface IStructure
    {
        IStructure Parent { get; set; }
        string Name { get; set; }
        string GetPath();
    }
}
