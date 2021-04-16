using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.ValueConverter
{
    public class DateTimeToDateConverter : IValueConverter
    {
        string[] m_Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;

            if (dateTime != null)
            {
                return dateTime.DayOfWeek + ": " + m_Months[dateTime.Month - 1] + " " + dateTime.Day + ", " + dateTime.Year;
            }

            return "";
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
