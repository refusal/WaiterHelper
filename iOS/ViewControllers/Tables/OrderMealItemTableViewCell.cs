using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using WaiterHelper.ViewModels.Search;

namespace WaiterHelper.iOS.ViewControllers.Tables
{
    public partial class OrderMealItemTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("OrderMealItemTableViewCell");
        public static readonly UINib Nib;

        static OrderMealItemTableViewCell()
        {
            Nib = UINib.FromName("OrderMealItemTableViewCell", NSBundle.MainBundle);
        }

        protected OrderMealItemTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<OrderMealItemTableViewCell, SearchEquipmentItemViewModel>();
                bindingSet.Bind(NameLabel).To(vm => vm.Meal.Name);
                bindingSet.Bind(PriceLabel).To(vm => vm.Meal.Price);
                bindingSet.Bind(WeightLabel).To(vm => vm.Meal.Weight);
                //bindingSet.Bind(QtyLabel).To(vm => vm.Count).OneWayToSource();
                bindingSet.Apply();
            });
        }
    }
}

