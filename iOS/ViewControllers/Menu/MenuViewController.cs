using System;
using UIKit;
using MvvmCross.iOS.Views;
using WaiterHelper.ViewModels;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Plugins.Color.iOS;

namespace WaiterHelper.iOS.ViewControllers
{
    [MvxFromStoryboard("Menu")]
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MenuViewController : ViewControllerBase<MenuViewModel>
    {
        public MenuViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

