using System;
using System.Collections.Generic;
using WaiterHelper.Models;

namespace WaiterHelper.Services
{

    public interface IMenuService
    {
        IList<Meal> GetAllMeals();
        IList<Table> GetAllTables();
    }
}
