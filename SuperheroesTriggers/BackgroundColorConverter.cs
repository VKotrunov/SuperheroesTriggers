using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SuperheroesTriggers
{
    class BackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Brushes.PaleGreen;
            else
                return Brushes.IndianRed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
