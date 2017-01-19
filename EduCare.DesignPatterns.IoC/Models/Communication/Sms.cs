namespace EduCare.DesignPatterns.IoC.Models
{
    public class Sms : ICommunication
    {
        public string SendMessage(string title, string content)
        {
            return $"We have sent SMS. Title : {title}";
        }
    }
}
