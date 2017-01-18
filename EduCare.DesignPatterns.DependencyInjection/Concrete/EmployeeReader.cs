using Dapper;
using EduCare.DesignPatterns.DependencyInjection.Helper;
using EduCare.DesignPatterns.DependencyInjection.Models;
using System.Collections.Generic;
using System.Linq;

namespace EduCare.DesignPatterns.DependencyInjection.Concrete
{
    public class EmployeeReader : DbConnector<Employee>
    {
        public override List<Employee> GetItems()
        {
            var list = Connection.Query<Employee>("SELECT TOP 15 EmployeeId, FirstName, LastName, HireDate FROM Employees").ToList();
            return list;
        }
    }
}
