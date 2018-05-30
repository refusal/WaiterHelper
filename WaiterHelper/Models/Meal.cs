﻿using System.Collections.Generic;
using Realms;
using System;

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
        public int MealType { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsSpicy { get; set; }
        public string ImagePath { get; set; }
    }

    public class Table : RealmObject
    {
        public int Number { get; set; }
        public int MaxCount { get; set; }
        public int CurrentCount { get; set; }
        public bool IsSmoking { get; set; }
        public bool IsReserved { get; set; }
    }

    public class Order : RealmObject
    {
        public string Id { get; set; }
        public IList<Meal> Meals { get; }
        public DateTimeOffset Date { get; set; }
        public int TableNumber { get; set; }
    }
}
