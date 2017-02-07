using EduCare.DesignPatterns.ChainOfResponsibility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCare.DesignPatterns.ChainOfResponsibility.Helper
{
    public class EmployeeData
    {
        static EmployeeData()
        {

            var e1 = new Employee { Id = 1, Name = "Can PERK", Manager = null };
            var e2 = new Employee { Id = 2, Name = "Nancy Urgent", Manager = e1 };
            var e3 = new Employee { Id = 3, Name = "Candice Albert", Manager = e1 };
            var e4 = new Employee { Id = 4, Name = "Isaac Harrington", Manager = e2 };
            var e5 = new Employee { Id = 5, Name = "Fahad Kebir", Manager = e2 };
            var e6 = new Employee { Id = 6, Name = "Kurt Ossain", Manager = e2 };
            var e7 = new Employee { Id = 7, Name = "Alfred Carriger", Manager = e2 };
            var e8 = new Employee { Id = 8, Name = "Lucas O'Neil", Manager = e3 };
            var e9 = new Employee { Id = 9, Name = "Lisa Roosvelt", Manager = e3 };
            var e10 = new Employee { Id = 10, Name = "Taisia Kostorova", Manager = e1 };
            var e11 = new Employee { Id = 11, Name = "Zeynep Aksu", Manager = e9 };
            var e12 = new Employee { Id = 12, Name = "Frank Palace", Manager = e9 };
            var e13 = new Employee { Id = 13, Name = "Olga Tarasova", Manager = e7 };
            var e14 = new Employee { Id = 14, Name = "Laura Peacock", Manager = e7 };
            var e15 = new Employee { Id = 15, Name = "Sergey Kimenov", Manager = e5 };
            var e16 = new Employee { Id = 16, Name = "Jane Rose", Manager = e14 };
            var e17 = new Employee { Id = 17, Name = "Satsuki Nakamura", Manager = e9 };
            var e18 = new Employee { Id = 18, Name = "Jin Seng Ahn", Manager = e3 };

            e3.ExpenseList.Add(new Expense() { Description = "Holiday", Amount = 600, RequestDate = new DateTime(2017, 1, 6) });
            e3.ExpenseList.Add(new Expense() { Description = "Transportation", Amount = 100, RequestDate = new DateTime(2017, 1, 6) });
            e3.ExpenseList.Add(new Expense() { Description = "Lunch With Customers", Amount = 300, RequestDate = new DateTime(2017, 1, 6) });
            e13.ExpenseList.Add(new Expense() { Description = "Consultant Document Fee", Amount = 100, RequestDate = new DateTime(2017, 1, 6) });
            e3.ExpenseList.Add(new Expense() { Description = "Gas", Amount = 100, RequestDate = new DateTime(2017, 1, 6) });
            e3.ExpenseList.Add(new Expense() { Description = "Special Reasons", Amount = 700, RequestDate = new DateTime(2017, 1, 6) });
            e3.ExpenseList.Add(new Expense() { Description = "School Payment For Children", Amount = 100, RequestDate = new DateTime(2017, 1, 6) });
            e3.ExpenseList.Add(new Expense() { Description = "Keyboard - Mouse Set", Amount = 50, RequestDate = new DateTime(2017, 1, 6) });
            e7.ExpenseList.Add(new Expense() { Description = "Personal Stuffs", Amount = 300, RequestDate = new DateTime(2017, 1, 6) });
            e7.ExpenseList.Add(new Expense() { Description = "Health", Amount = 250, RequestDate = new DateTime(2017, 1, 6) });
            e7.ExpenseList.Add(new Expense() { Description = "Pre-Payment", Amount = 400, RequestDate = new DateTime(2017, 1, 6) });
            e11.ExpenseList.Add(new Expense() { Description = "Health", Amount = 100, RequestDate = new DateTime(2017, 1, 6) });
            Employees = new List<Employee> { e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15, e16, e17, e18 };
            Employees.ForEach(i => i.PhotoPath = $"/Assets/Photos/Thumb/p{i.Id}.jpg");
        }
        public static List<Employee> Employees { get; private set; }
    }
}
