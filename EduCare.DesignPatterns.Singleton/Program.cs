using EduCare.DesignPatterns.Singleton.GoodWay;
using System;

namespace EduCare.DesignPatterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            var categories = context.GetCategories();
            var categories2 = context.GetCategories();
            var categories3 = context.GetCategories();
            var categories4 = context.GetCategories();

            foreach (var category in categories)
            {
                Console.WriteLine("{0} - {1}", category.Id, category.Name);
            }
            Console.WriteLine("_______");
            var employees = context.GetEmployees();
            var employees2 = context.GetEmployees();
            var employees3 = context.GetEmployees();
            var employees4 = context.GetEmployees();

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} - {1} {2}", employee.Id, employee.FirstName, employee.LastName);
            }
            Console.ReadKey();
        }
    }
}
