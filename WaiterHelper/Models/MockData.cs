using System;
using System.Collections.Generic;
using System.Dynamic;
using Foundation;

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
            meals.Add(CreateMeal(1, "Caprese Salad with Pesto Sauce", 15, 200, MealType.Salad));
            meals.Add(CreateMeal(1, "Panzenella", 20, 150, MealType.Salad));
            meals.Add(CreateMeal(1, "Bruschetta", 10, 100, MealType.Snack, IsVegetarian: false, IsSpicy: true));
            meals.Add(CreateMeal(1, "Focaccia Bread", 5, 140, MealType.Snack, IsVegetarian: true));
            meals.Add(CreateMeal(1, "Pasta Carbonara", 30, 300, MealType.Pasta));
            return meals;
        }

        private static Meal CreateMeal(int id, string name, int price, int weight, MealType mealType,
                         string description = "", bool IsVegetarian = false, bool IsSpicy = false)
        {
            var meal = new Meal()
            {
                Id = id,
                Name = name,
                Price = price,
                Weight = weight,
                MealType = (int)mealType,
                IsSpicy = IsSpicy,
                IsVegetarian = IsVegetarian,
                Description = description,
                ImagePath = "res:" + NSBundle.MainBundle.PathForResource("pasta-carbonara", "jpg")
            };

            return meal;
        }
        #endregion
    }
}
