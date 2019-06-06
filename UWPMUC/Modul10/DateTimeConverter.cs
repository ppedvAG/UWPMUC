using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWPMUC.Modul10
{
    class DateTimeConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
          
            return DateTimeOffset.Now;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
          

            return DateTime.Parse(value.ToString());

        }
    }
}
