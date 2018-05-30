using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using WaiterHelper.ViewModels.Search;

namespace WaiterHelper.iOS.ViewControllers.Menu
{
    public partial class OrderMealTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("OrderMealTableViewCell");
        public static readonly UINib Nib;

        static OrderMealTableViewCell()
        {
            Nib = UINib.FromName("OrderMealTableViewCell", NSBundle.MainBundle);
        }

        protected OrderMealTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<OrderMealTableViewCell, SearchEquipmentItemViewModel>();
                //bindingSet.Bind(NameLabel).To(vm => vm.Meal.Name);
                //bindingSet.Bind(PriceLabel).To(vm => vm.Meal.Price);
                //bindingSet.Bind(WeightLabel).To(vm => vm.Meal.Weight);
                //bindingSet.Bind(QtyTextField).To(vm => vm.Count).OneWayToSource();
                bindingSet.Apply();
            });
        }
    }
}
