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
            asbEmployees.ItemsSource = EmployeeData.Employees;
            asbEmployees.DisplayMemberPath = "Name";
            asbEmployees.TextMemberPath = "Name";
        }

        private void asbEmployees_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (SelectedItem != null && SelectedItem.Name == sender.Text)
                return;
            asbEmployees.ItemsSource = EmployeeData.Employees.Where(i => i.Name.StartsWith(sender.Text));
        }

        private void asbEmployees_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            SelectedItem = args.SelectedItem as Employee;
            txtCurrentUser.Text = SelectedItem.Name;
            lstSubEmployees.ItemsSource = SelectedItem.SubEmployees;
        }

        private void btnSaveExpense_Click(object sender, RoutedEventArgs e)
        {
            var expense = new Expense
            {
                Description = txtDescription.Text,
                Amount = int.Parse(txtAmount.Text),
            };
            //Add Manager's Expense List
        }

        private void lstSubEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSubEmployees.SelectedItem == null)
            {
                lstExpenses.ItemsSource = null;
                return;
            }
            lstExpenses.ItemsSource = (lstSubEmployees.SelectedItem as Employee).ExpenseList;
        }
    }
}
