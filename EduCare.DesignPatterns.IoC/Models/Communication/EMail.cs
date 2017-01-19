using System;

namespace EduCare.DesignPatterns.IoC.Models
{
    public sealed class EMail : ICommunication
    {
        public string SendMessage(string title, string content)
        {
            return $"Email just sent. Title : {title}. Sent date : {DateTime.Now}";
        }
    }
}
