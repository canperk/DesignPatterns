using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace EduCare.DesignPatterns.ChainOfResponsibility.Converters
{
    public class NumberToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var number = (int)value;
            return (number > 0) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
