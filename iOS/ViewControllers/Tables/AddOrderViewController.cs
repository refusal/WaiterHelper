using System;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;
using WaiterHelper.iOS.Presentation;
using WaiterHelper.ViewModels;
using WaiterHelper.iOS.Common;
using WaiterHelper.iOS.ViewControllers.Menu;

namespace WaiterHelper.iOS.ViewControllers.Tables
{
    [MvxModalAutoSizePresentation(ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
    [MvxFromStoryboard("Tables")]
    public partial class AddOrderViewController : MvxViewController<AddOrderViewModel>
    {
        private MvxActionBasedSimpleTableViewSource cartTableViewSource;

        public AddOrderViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            cartTableViewSource = new MvxActionBasedSimpleTableViewSource(MealsTableView, CartItemTableViewCell.Key, CartItemTableViewCell.Key, createFunc: null, reloadDataOverride: true);
            var bindingSet = this.CreateBindingSet<AddOrderViewController, AddOrderViewModel>();
            bindingSet.Bind(CancelButton).To(vm => vm.CloseCommand);
            bindingSet.Bind(CloseButton).To(vm => vm.CloseCommand);
            bindingSet.Bind(cartTableViewSource).For(source => source.ItemsSource).To(vm => vm.Meals);
            bindingSet.Apply();
        }
    }
}