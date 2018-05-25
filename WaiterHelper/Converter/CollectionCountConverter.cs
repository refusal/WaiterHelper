using System;
using MvvmCross.Platform.Converters;

namespace WaiterHelper.Converters
{
    public class CollectionCountConverter : MvxValueConverter<int?, string>
    {
        protected override string Convert(int? value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case null:
                case 0:
                    return string.Empty;
                default:
                    return $"{value} Item{(value == 1 ? "" : "s")}";
            }
        }
    }
}