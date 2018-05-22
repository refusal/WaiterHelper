using System;
using System.Collections.Generic;
using System.Dynamic;
namespace WaiterHelper.Models
{
    public static class MockData
    {
        #region Tables
        public static List<Table> Tables = new List<Table>()
        {
            new Table()
            {
                Number = 1,
                MaxCount = 4,
                CurrentCount = 0,
            },
            new Table()
            {
                Number = 2,
                MaxCount = 4,
                CurrentCount = 0,
                IsSmoking = true,
                IsReserved = true
            },
            new Table()
            {
                Number = 3,
                MaxCount = 4,
                CurrentCount = 0,
                IsSmoking = true,
            },
            new Table()
            {
                Number = 4,
                MaxCount = 4,
                CurrentCount = 0,
                IsSmoking = true,
                IsReserved = true
            },
            new Table()
            {
                Number = 5,
                MaxCount = 2,
                CurrentCount = 0,
            },
            new Table()
            {
                Number = 6,
                MaxCount = 2,
                CurrentCount = 0,
                IsReserved = true
            },
        };
        #endregion

        #region Meals

        public static List<Meal> GetMeals()
        {
            var meals = new List<Meal>();
            meals.Add(CreateMeal(1, "name", 10, 100, new[] { MealType.Drink }));
            meals.Add(CreateMeal(1, "name", 10, 100, new[] { MealType.Drink }));
            return meals;
        }

        private static Meal CreateMeal(int id, string name, int price, int weight, MealType[] mealTypes,
                         string description = "", bool IsVegetarian = false, bool IsSpicy = false)
        {
            var meal = new Meal()
            {
                Id = id,
                Name = name,
                Price = price,
                Weight = weight,
                IsSpicy = IsSpicy,
                IsVegetarian = IsVegetarian,
                Description = description
            };

            foreach (var item in mealTypes)
            {
                meal.MealTypes.Add(item);

            }

            return meal;
        }

        public static List<Meal> Meals = new List<Meal>()
        {
            new Meal()
            {

            }
        }
        #endregion
    }
}
