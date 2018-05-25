using System;
using System.Collections.Generic;
using PropertyChanged;

namespace WaiterHelper.Models
{
    [AddINotifyPropertyChangedInterface]
    public class EquipmentSearchFilter
    {
        public string Warehouse { get; set; }
        public string SerialOrLotNumber { get; set; }
        public string Name { get; set; }
        public string IdPartNumber { get; set; }

        public string Hcpcs { get; set; }

        public string Manufacturer { get; set; }
        public List<string> AvailableManufacturers { get; set; }

        public string Group { get; set; }
        public List<string> AvailableGroups { get; set; }

        public string Category { get; set; }
        public List<string> AvailableCategories { get; set; }

        public bool IsEmpty =>
              string.IsNullOrWhiteSpace(IdPartNumber) &&
              string.IsNullOrWhiteSpace(Name) &&
              string.IsNullOrWhiteSpace(SerialOrLotNumber) &&
              string.IsNullOrWhiteSpace(Manufacturer) &&
              string.IsNullOrWhiteSpace(Group) &&
              string.IsNullOrWhiteSpace(Category) &&
              string.IsNullOrWhiteSpace(Hcpcs);

    }
}
