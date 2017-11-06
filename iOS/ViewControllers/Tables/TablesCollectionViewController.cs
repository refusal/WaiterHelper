using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using WaiterHelper.ViewModels;

namespace WaiterHelper.iOS.ViewControllers
{
    [MvxFromStoryboard("Tables")]
    [MvxTabPresentation(WrapInNavigationController = true)]
    public partial class TablesCollectionViewController : ViewControllerBase<TablesCollectionViewModel>
    {
        public TablesCollectionViewController(IntPtr handle) : base(handle) { }

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

