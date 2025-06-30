using System;
using System.Globalization;
using System.Windows.Data;

namespace PersianDatePicker_Core_Wpf.Converters
{
    public class DateTimeToPersianStringConverter : IValueConverter
    {
        private readonly PersianCalendar _persianCalendar = new PersianCalendar();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                int year = _persianCalendar.GetYear(date);
                int month = _persianCalendar.GetMonth(date);
                int day = _persianCalendar.GetDayOfMonth(date);
                return $"{year:0000}/{month:00}/{day:00}";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Optional: برای تبدیل معکوس شمسی به میلادی
            return null;
        }
    }
}
