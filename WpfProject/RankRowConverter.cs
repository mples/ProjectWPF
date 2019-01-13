using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfProject
{
    public class RankRowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rank = (int)value;
            return 8 - rank;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
