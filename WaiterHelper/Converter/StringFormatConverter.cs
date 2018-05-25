using System;
using MvvmCross.Platform.Converters;

namespace WaiterHelper.Converters
{
    public class StringFormatConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter is string format)
                return string.Format(format, value);

            return value;
        }
    }
}