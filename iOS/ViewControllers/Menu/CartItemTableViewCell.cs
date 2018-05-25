using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using WaiterHelper.ViewModels.Search;

namespace WaiterHelper.iOS.ViewControllers.Menu
{
    public partial class CartItemTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("CartItemTableViewCell");
        public static readonly UINib Nib;

        static CartItemTableViewCell()
        {
            Nib = UINib.FromName("CartItemTableViewCell", NSBundle.MainBundle);
        }

        protected CartItemTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<CartItemTableViewCell, SearchEquipmentItemViewModel>();
                bindingSet.Apply();
            });
        }
    }
}
