using System;
using Xamarin.Forms;

namespace testlistview
{
    public class CurrencyColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double amount = (double)value;

            return amount >= 0 ? Color.Green : Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

