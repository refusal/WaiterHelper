using System.Collections.Generic;
using Realms;

namespace WaiterHelper.Models
{
    public enum MealType
    {
        Drink,
        AlcoholDrink,
        Salad,
        Soup,
        National,
        Snack,
        Pasta,
        Meat
    }

    public class Meal : RealmObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<MealType> MealTypes { get; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsSpicy { get; set; }
    }

    public class Table : RealmObject
    {
        public int Number { get; set; }
        public int MaxCount { get; set; }
        public int CurrentCount { get; set; }
        public bool IsSmoking { get; set; }
        public bool IsReserved { get; set; }
    }
}
