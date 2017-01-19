namespace EduCare.DesignPatterns.IoC.Models
{
    public interface ICommunication
    {
        string SendMessage(string title, string content);
    }
}
