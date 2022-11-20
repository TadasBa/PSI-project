using Pantry.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Pantry.converters
{
    internal class DateTimeToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("yyyy-MM-dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Exception e = new NotImplementedException();
            ExceptionLogger.LogExceptionToFile(e, "Convert back method is not implemented");
            throw e;

        }
    }
}