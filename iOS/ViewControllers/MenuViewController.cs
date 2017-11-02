using System;
using UIKit;
using MvvmCross.iOS.Views;
using WaiterHelper.ViewModels;

namespace WaiterHelper.iOS.ViewControllers
{
    public partial class MenuViewController : MvxViewController<MenuViewModel>
    {
        public MenuViewController() : base("MenuViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

