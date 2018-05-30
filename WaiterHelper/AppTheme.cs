using System;
using MvvmCross.Platform.UI;
using System.Globalization;

namespace WaiterHelper
{
    public static class AppTheme
    {
        public static readonly MvxColor ColorPrimary = "#2a3f54".FromHex();
        public static readonly MvxColor ColorPrimaryDark = "#223343".FromHex();
        public static readonly MvxColor ColorAccent = "#48b2ff".FromHex();
        public static readonly MvxColor LightGray = "#f0f3f7".FromHex();
        public static readonly MvxColor White = "#ffffff".FromHex();
        public static readonly MvxColor Gray = "#AAe2e2e2".FromHex();
        public static readonly MvxColor PressedGray = "#EEEEEE".FromHex();

        public static readonly MvxColor ext_dark = "#000000".FromHex();
        public static readonly MvxColor TextDarkBlue = "#2a3f54".FromHex();
        public static readonly MvxColor TextBlue = "#06aed5".FromHex();
        public static readonly MvxColor TextGray = "#606060".FromHex();
        public static readonly MvxColor TextBlueGray = "#aab3bc".FromHex();
        public static readonly MvxColor TextGrayDark = "#333333".FromHex();

        public static readonly MvxColor tab_bg = ColorPrimary;
        public static readonly MvxColor tab_bg_selected = ColorPrimary;
        public static readonly MvxColor tab_bg_pressed = ColorPrimaryDark;

        public static readonly MvxColor StatusGreen = "#6dc85e".FromHex();
        public static readonly MvxColor StatusBlue = ColorAccent;
        public static readonly MvxColor StatusBlueDark = ColorPrimary;
        public static readonly MvxColor StatusOrange = "#ff720b".FromHex();
        public static readonly MvxColor StatusGray = "#abb7c5".FromHex();
        public static readonly MvxColor StatusRed = "#ff4848".FromHex();

        public static readonly string PhoneFormat = "{0:(###) ###-####}";

        public const string DefaultDateFormat = "dd/MM/yyyy";

        private static MvxColor Parse3DigitColor(string value)
        {
            var red = Int32.Parse(value.Substring(0, 1), NumberStyles.HexNumber);
            var green = Int32.Parse(value.Substring(1, 1), NumberStyles.HexNumber);
            var blue = Int32.Parse(value.Substring(2, 1), NumberStyles.HexNumber);
            return new MvxColor(UpByte(red), UpByte(green), UpByte(blue));
        }

        private static int UpByte(int input)
        {
            var fourBit = input & 0xF;
            var output = fourBit << 4;
            output |= fourBit;
            return output;
        }

        public static MvxColor Parse6DigitColor(string value)
        {
            var rgb = Int32.Parse(value, NumberStyles.HexNumber);
            return new MvxColor(rgb, 255);
        }

        public static MvxColor Parse8DigitColor(string value)
        {
            // assume RGBA
            var rgb = Int32.Parse(value.Substring(0, 6), NumberStyles.HexNumber);
            var a = Int32.Parse(value.Substring(6, 2), NumberStyles.HexNumber);
            return new MvxColor(rgb, a);
        }

        public static MvxColor FromHex(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return new MvxColor(0);

            value = value.TrimStart('#');
            if (value.Length == 0)
                return new MvxColor(0);

            switch (value.Length)
            {
                case 3:
                    return Parse3DigitColor(value);

                case 6:
                    return Parse6DigitColor(value);

                case 8:
                    return Parse8DigitColor(value);

                default:
                    return new MvxColor(0);
            }
        }

        public static class New
        {
            public static MvxColor CharcoalGrey = "#434c4f".FromHex();
            public static MvxColor BorderColor = "#cfc9c9".FromHex();
        }
    }
}
