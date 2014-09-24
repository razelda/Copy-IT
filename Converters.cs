using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Copy_IT
{
    public class ExpandedConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((string)value == (string)parameter);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return parameter;
        }
    }

    public class ExpandedConerter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((string)value == (string)parameter);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return parameter;
        }
    }

    public class ExpandedMultiConverter : IMultiValueConverter
    {
        string id { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            id = values[1] as string;
            return ((string)values[0] == (string)values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            object[] splitValues = new object[2];

            splitValues[0] = id;
            splitValues[1] = Binding.DoNothing;

            return splitValues;
        }
    }
}
