using System;

namespace EduCare.DesignPatterns.Strategy.Models
{
    public class ActionLog
    {
        public ActionLog(string text)
        {
            Text = text;
        }
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Text { get; set; }
    }
}
