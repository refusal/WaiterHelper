using System;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;
using WaiterHelper.iOS.Presentation;
using WaiterHelper.ViewModels;
using WaiterHelper.iOS.Common;
using WaiterHelper.iOS.ViewControllers.Menu;
using MvvmCross.Binding.iOS.Views;

namespace WaiterHelper.iOS.ViewControllers.Tables
{
    [MvxModalAutoSizePresentation(ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
    [MvxFromStoryboard("Tables")]
    public partial class AddOrderViewController : MvxViewController<AddOrderViewModel>
    {
        private MvxSimpleTableViewSource cartTableViewSource;

        public AddOrderViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            cartTableViewSource = new MvxSimpleTableViewSource(MealsTableView, CartItemTableViewCell.Key, CartItemTableViewCell.Key);
            var bindingSet = this.CreateBindingSet<AddOrderViewController, AddOrderViewModel>();
            bindingSet.Bind(CancelButton).To(vm => vm.CloseCommand);
            bindingSet.Bind(CloseButton).To(vm => vm.CloseCommand);
            bindingSet.Bind(cartTableViewSource).For(source => source.ItemsSource).To(vm => vm.Meals);
            bindingSet.Apply();

            MealsTableView.Source = cartTableViewSource;
            MealsTableView.EstimatedRowHeight = 100f;
            MealsTableView.RowHeight = UITableView.AutomaticDimension;
        }
    }
}