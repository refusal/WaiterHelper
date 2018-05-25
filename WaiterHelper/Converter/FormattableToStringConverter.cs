using System;
using MvvmCross.Platform.Converters;

namespace WaiterHelper.Converters
{
    public class FormattableToStringConverter : MvxValueConverter<IFormattable, string>
    {
        public static string Name = nameof(FormattableToStringConverter);

        protected override string Convert(IFormattable value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IFormatProvider formatProvider = culture.DateTimeFormat;
            //TODO 
            if (value is DateTimeOffset && (DateTimeOffset)value == default(DateTimeOffset))
                return "-";

            return value?.ToString(parameter as string, formatProvider);
        }
    }

    public class StringValueToTemperatureFormatConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var temperature = Double.TryParse(value, out double doubleValue) ? (int)doubleValue : 0;
            return $"{temperature}˚";
        }
    }
}