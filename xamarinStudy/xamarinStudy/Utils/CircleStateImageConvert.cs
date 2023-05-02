using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace NMAP.Utils
{
    internal class CircleStateImageConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string source;
            switch (value)
            {
                case "REL":
                    source = "Circle_Green_24.png";
                    break;
                case "":
                default:
                    source = "Circle_Gray_24.png";
                    break;
            }
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
