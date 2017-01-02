using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EduCare.DesignPatterns.Composite.RealWorld.Models
{
    public class Employee
    {
        public Employee()
        {
            Employees = new ObservableCollection<Employee>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Path { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public void AddSubEmployee(Employee employee)
        {
            Employees.Add(employee);
        }
    }
}
