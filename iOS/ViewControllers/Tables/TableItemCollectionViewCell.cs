using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using Foundation;
using MvvmCross.Binding.BindingContext;
using WaiterHelper.ViewModels.Tables;
using System.Diagnostics;
using WaiterHelper.Converters;
using WaiterHelper.iOS.Common;

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

        public static BoolToConditionalValuesConverter<string> converter = new BoolToConditionalValuesConverter<string>("smoking", "no smoking");

        protected TableItemCollectionViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<TableItemCollectionViewCell, TableItemViewModel>();
                bindingSet.Bind(ReserveButton).To(vm => vm.ReserveCommand);
                bindingSet.Bind(AddOrderButton).To(vm => vm.AddOrderCommand);
                bindingSet.Bind(NumberLabel).To(vm => vm.Table.Number);
                bindingSet.Bind(MaxCountLabel).To(vm => vm.Table.MaxCount);
                bindingSet.Bind(SmokingLabel).To(vm => vm.Table.IsSmoking).WithConversion(converter);
                bindingSet.Apply();
            });
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            HolderView.AddDefaultBorder();
        }
    }
}