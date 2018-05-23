using System;
using System.Collections;
using System.Collections.Generic;
using WaiterHelper.Models;
using WaiterHelper.Helpers;
using System.Linq;
namespace WaiterHelper.Services
{
    public class MenuService : CacheProviderBase, IMenuService
    {
        public MenuService(ILog log) : base(log)
        {
            this.SaveRange(MockData.Tables, true);
            this.SaveRange(MockData.GetMeals(), true);
        }

        public IList<Meal> GetAllMeals()
        {
            return SharedRealm.All<Meal>().ToList();
        }

        public IList<Table> GetAllTables()
        {
            return SharedRealm.All<Table>().ToList();
        }
    }
}
