using EduCare.DesignPatterns.ChainOfResponsibility.Helper;
using EduCare.DesignPatterns.ChainOfResponsibility.Models;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace EduCare.DesignPatterns.ChainOfResponsibility.Views
{
    public sealed partial class EmployeeRequests : Page
    {
        public Employee SelectedItem { get; private set; }
        public EmployeeRequests()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            asbLogin.ItemsSource = EmployeeData.Employees;
        }

        private void asbLogin_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            SelectedItem = args.SelectedItem as Employee;
            lstExpenses.ItemsSource = SelectedItem.ApproveList;
        }

        private void asbLogin_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (SelectedItem != null && SelectedItem.Name == sender.Text)
                              return;
            asbLogin.ItemsSource = EmployeeData.Employees.Where(i => i.Name.StartsWith(sender.Text));
        }
    }
}
