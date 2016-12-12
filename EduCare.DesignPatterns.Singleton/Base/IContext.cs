using EduCare.DesignPatterns.Singleton.Models;
using System.Collections.Generic;

namespace EduCare.DesignPatterns.Singleton.Base
{
    public interface IContext
    {
        void AddCategory(Category category);
        void AddEmployee(Employee employee);
        IEnumerable<Category> GetCategories();
        IEnumerable<Employee> GetEmployees();
    }
}
