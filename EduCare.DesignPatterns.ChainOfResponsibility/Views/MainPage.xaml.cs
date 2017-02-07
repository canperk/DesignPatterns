using EduCare.DesignPatterns.ChainOfResponsibility.Helper;
using EduCare.DesignPatterns.ChainOfResponsibility.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace EduCare.DesignPatterns.ChainOfResponsibility.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public Employee SelectedItem { get; set; }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstEmployees.ItemsSource = EmployeeData.Employees;
            txtExpenseCount.Text = GetTotalCount().ToString();
        }
        private void lstEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItem = (sender as ListView).SelectedItem as Employee;
            txtCurrentUser.Text = SelectedItem.Name;
            var lstExpenses = FindChildControl<ListView>(hubList, "lstExpenses") as ListView;
            lstExpenses.ItemsSource = SelectedItem.ExpenseList;
        }

        private int GetTotalCount()
        {
            var count = 0;
            EmployeeData.Employees.ForEach(i => {
                count += i.ExpenseList.Count;
            });
            return count;
        }

        private DependencyObject FindChildControl<T>(DependencyObject control, string ctrlName)
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                var child = VisualTreeHelper.GetChild(control, i);
                var fe = child as FrameworkElement;
                if (fe == null) return null;

                if (child is T && fe.Name == ctrlName)
                    return child;
                else
                {
                    var nextLevel = FindChildControl<T>(child, ctrlName);
                    if (nextLevel != null)
                        return nextLevel;
                }
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var txtDescription = FindChildControl<TextBox>(hubNew, "txtDescription") as TextBox;
            var txtAmount = FindChildControl<TextBox>(hubNew, "txtAmount") as TextBox;
            var expense = new Expense
            {
                Description = txtDescription.Text,
                Amount = int.Parse(txtAmount.Text),
                RequestDate = DateTime.Now
            };
            SelectedItem.ExpenseList.Add(expense);
        }
    }
}
