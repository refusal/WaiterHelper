using System;
using UIKit;
using MvvmCross.iOS.Views;
using WaiterHelper.ViewModels;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Plugins.Color.iOS;
using MvvmCross.Binding.BindingContext;

namespace WaiterHelper.iOS.ViewControllers
{
    [MvxFromStoryboard("Menu")]
    [MvxTabPresentation(WrapInNavigationController = true)]
    public partial class MenuViewController : ViewControllerBase<MenuViewModel>
    {
        public MenuViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var bindingSet = this.CreateBindingSet<MenuViewController, MenuViewModel>();
            bindingSet.Bind(TestButton).To(vm => vm.ShowAdditionalSearch);
            bindingSet.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

