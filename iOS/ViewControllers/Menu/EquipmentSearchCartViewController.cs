using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using NikoHealth.Core.ViewModels.Equipment.Search;
using NikoHealth.iOS.Common;
using NikoHealth.iOS.Controls;
using UIKit;
using NikoHealth.iOS.Views.EquipmentSearch.Pad;
using NikoHealth.Core.Converters;

namespace WaiterHelper.iOS.ViewControllers.Menu
{
    [MvxModalPresentation(Animated = true, ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen, ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
    [MvxFromStoryboard("SearchEquipment")]
    public partial class EquipmentSearchCartViewController : MvxViewController<EquipmentSearchViewModel>
    {
        private MvxActionBasedSimpleTableViewSource cartTableViewSource;

        public EquipmentSearchCartViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            cartTableViewSource = new MvxActionBasedSimpleTableViewSource(CartTableView, CartItemTableViewCell.Key);
            var bindingSet = this.CreateBindingSet<EquipmentSearchCartViewController, EquipmentSearchViewModel>();
            bindingSet.Bind(cartTableViewSource).For(source => source.ItemsSource).To(vm => vm.SelectedItems);
            bindingSet.Bind(CancelButton).To(vm => vm.CloseCommand);
            bindingSet.Bind(EmptyView).For(view => view.Hidden).To(vm => vm.SelectedItems)
                      .WithConversion<EmptyToBoolConverter>();
            bindingSet.Apply();

            CartTableView.Source = cartTableViewSource;
            CartTableView.EstimatedRowHeight = 100f;
            CartTableView.BackgroundView = EmptyView;
            CartTableView.RowHeight = UITableView.AutomaticDimension;
        }

        private UITableViewCell OnCreateTableViewCell(UITableView tableView, NSIndexPath indexPath, object dataContext)
        {
            var tableViewCell = tableView.DequeueReusableCell(cartTableViewSource.DefaultCellIndentifier, indexPath);
            if (tableViewCell is MvxIndexedTableViewCell indexedCell)
            {
                indexedCell.Index = indexPath.Row;
                indexedCell.Owner = tableView;
            }
            return tableViewCell;
        }
    }
}
