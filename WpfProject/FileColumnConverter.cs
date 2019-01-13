using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace WpfProject
{
    public class FileColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            char file = (char)value;
            List<char> columns = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            return columns.IndexOf(file);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
