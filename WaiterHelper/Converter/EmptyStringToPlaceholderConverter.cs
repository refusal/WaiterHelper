using System;
using MvvmCross.Platform.Converters;

namespace WaiterHelper.Converters
{
    public class EmptyStringToPlaceholderConverter : MvxValueConverter<string, string>
    {
        public const string DefaultEmptyString = " - ";

        protected override string Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace(value?.ToString()) ? (parameter as string) ?? DefaultEmptyString : value;
        }
    }
}