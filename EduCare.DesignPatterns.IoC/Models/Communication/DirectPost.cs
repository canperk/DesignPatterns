namespace EduCare.DesignPatterns.IoC.Models
{
    public class DirectPost : ICommunication
    {
        public string SendMessage(string title, string content)
        {
            return $"Message \"{title}\" posted via PostOffice";
        }
    }
}
