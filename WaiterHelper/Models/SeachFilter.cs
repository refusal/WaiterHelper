using System;
using System.Collections.Generic;
using PropertyChanged;

namespace WaiterHelper.Models
{
    [AddINotifyPropertyChangedInterface]
    public class EquipmentSearchFilter
    {
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public bool IsNoSpicy { get; set; }
        public bool IsVegetarian { get; set; }

        public List<string> AvailableCategories { get; set; }

        public bool IsEmpty =>
        string.IsNullOrWhiteSpace(MinPrice) &&
              string.IsNullOrWhiteSpace(Name) &&
              string.IsNullOrWhiteSpace(MaxPrice) &&
              string.IsNullOrWhiteSpace(Category);
    }
}
