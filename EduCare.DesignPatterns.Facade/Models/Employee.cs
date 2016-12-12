using System;

namespace EduCare.DesignPatterns.Facade.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IpAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EMail { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
