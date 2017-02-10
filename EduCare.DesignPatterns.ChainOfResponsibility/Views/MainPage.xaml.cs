using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace EduCare.DesignPatterns.ChainOfResponsibility.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            frmContent.ContentTransitions = new TransitionCollection();
            frmContent.ContentTransitions.Add(new AddDeleteThemeTransition());
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(typeof(AllItems));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            splMenu.IsPaneOpen = !splMenu.IsPaneOpen;
        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            Navigate<AllItems>();
        }

        private void btnRequestList_Click(object sender, RoutedEventArgs e)
        {
            Navigate<EmployeeRequests>();
        }
        private void Navigate<T>()
        {
            var type = typeof(T);
            if (frmContent.Content.ToString() != type.FullName)
                frmContent.Navigate(type);
        }
    }
}
