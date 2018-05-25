
using System;
using MvvmCross.Platform.Converters;

namespace WaiterHelper.Converters
{
    public class BoolToConditionalValuesConverter<T> : MvxValueConverter<bool, T>
    {
        private T trueValue;
        private T falseValue;

        public BoolToConditionalValuesConverter(T trueValue, T falseValue)
        {
            this.trueValue = trueValue;
            this.falseValue = falseValue;
        }

        protected override T Convert(bool value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => value ? trueValue : falseValue;
    }
}