using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using WaiterHelper.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using WaiterHelper.iOS.ViewControllers.Tables;
using WaiterHelper.ViewModels.Tables;

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
            var tablesCollectionViewSource = new MvxCollectionViewSource(TablesCollectionView, TableItemCollectionViewCell.Key);

            var bindingSet = this.CreateBindingSet<TablesCollectionViewController, TablesCollectionViewModel>();
            bindingSet.Bind(tablesCollectionViewSource).For(source => source.ItemsSource).To(vm => vm.Tables);
            bindingSet.Apply();

            TablesCollectionView.DataSource = tablesCollectionViewSource;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

