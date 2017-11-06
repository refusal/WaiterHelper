using System;

using UIKit;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.iOS.Views;
using WaiterHelper.ViewModels;

namespace WaiterHelper.iOS.ViewControllers.Settings
{
    [MvxFromStoryboard("Settings")]
    [MvxTabPresentation(WrapInNavigationController = true)]
    public partial class SettingsViewController : MvxViewController<SettingsViewModel>
    {
        public SettingsViewController(IntPtr handle) : base(handle)
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

