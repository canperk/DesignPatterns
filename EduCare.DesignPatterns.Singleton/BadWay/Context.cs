using EduCare.DesignPatterns.Singleton.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduCare.DesignPatterns.Singleton.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace EduCare.DesignPatterns.Singleton.BadWay
{
    public class Context : IContext
    {

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            var list = new List<Category>();
            var connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Categories";
                var command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category = new Category();
                        category.Id = Convert.ToInt32(reader["CategoryId"]);
                        category.Name = reader["CategoryName"].ToString();
                        list.Add(category);
                    }
                }
            }
            return list;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var list = new List<Employee>();
            var connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Employees";
                var command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new Employee();
                        employee.Id = Convert.ToInt32(reader["EmployeeID"]);
                        employee.FirstName = reader["FirstName"].ToString();
                        employee.LastName = reader["LastName"].ToString();
                        employee.HireDate = Convert.ToDateTime(reader["HireDate"]);
                        list.Add(employee);
                    }
                }
            }
            return list;
        }
    }
}
