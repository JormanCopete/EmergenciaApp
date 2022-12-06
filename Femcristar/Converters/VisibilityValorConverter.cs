using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppEmergencia.Converters
{
    public class VisibilityValorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var entrada = (double)value;
            bool resultado;

            if (entrada == 0)
                resultado = false;
            else
                resultado = true;

            return resultado;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
