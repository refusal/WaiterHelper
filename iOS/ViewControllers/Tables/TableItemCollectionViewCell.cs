using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using Foundation;
using MvvmCross.Binding.BindingContext;
using WaiterHelper.ViewModels.Tables;

namespace WaiterHelper.iOS.ViewControllers.Tables
{
    public partial class TableItemCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("TableItemCollectionViewCell");
        public static readonly UINib Nib;

        static TableItemCollectionViewCell()
        {
            Nib = UINib.FromName("TableItemCollectionViewCell", NSBundle.MainBundle);
        }

        protected TableItemCollectionViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<TableItemCollectionViewCell, TableItemViewModel>();
                bindingSet.Apply();
            });
        }
    }
}