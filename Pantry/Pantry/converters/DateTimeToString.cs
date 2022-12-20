using Pantry.Utilities;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Pantry.converters
{
    /*public class DateTimeToString //: IValueConverter
    {
        public String ConvertDateTimeToString(DateTime date)
        {

             return (date).ToString("yyyy-MM-dd");
            

        }

        public DateTime ConvertStringToDateTime(String value)
        {
            DateTime date;

              if (String.IsNullOrEmpty(value))
              {
                  date = new DateTime(0001, 01, 01);
              }
              else
              {
                  date = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
              }

              return date;
        
    }*/

    public class DateTimeToString : IValueConverter
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