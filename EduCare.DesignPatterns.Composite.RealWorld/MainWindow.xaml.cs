using EduCare.DesignPatterns.Composite.RealWorld.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System;
using Dapper;

namespace EduCare.DesignPatterns.Composite.RealWorld
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var str = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            Connection = new SqlConnection(str);
            Connection.Open();
            LoadFirstItem();
        }

        private void LoadFirstItem()
        {
            var emp = Connection.Query<Employee>("SELECT TOP 1 Id, FullName FROM Employees WHERE DirectReports IS NULL").Single();
            trv.Items.Add(emp);
        }

        public SqlConnection Connection { get; set; }

        private void trv_Expanded(object sender, RoutedEventArgs e)
        {
            var emp = (e.OriginalSource as TreeViewItem).DataContext as Employee;
            if (emp == null)
                return;
            if (emp.Employees.Any())
                return;

            var employees = Connection.Query<Employee>($"SELECT Id, FullName FROM Employees WHERE DirectReports = {emp.Id}").ToList();
            employees.ForEach(i => {
                emp.AddSubEmployee(i);
            });
        }
    }
}
