using System;
using System.Collections.Generic;
using MvvmCross.Platform.Converters;
using WaiterHelper.Models;

namespace WaiterHelper.Converter
{
    public class IntToCategoryConverter : MvxValueConverter<int, string>
    {
        public static readonly Dictionary<MealType, string> Relations = new Dictionary<MealType, string>()
        {
            {MealType.AlcoholDrink, "Alcohol Drink"},
            {MealType.Drink, "Drink"},
            {MealType.Meat, "Meat"},
            {MealType.Pasta, "Pasta"},
            {MealType.Snack, "Snack"},
            {MealType.Soup, "Soup"},
            {MealType.Salad, "Salad"}
        };

        protected override string Convert(int value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Relations.TryGetValue((MealType)value, out string relation);
            return relation;
        }
    }
}