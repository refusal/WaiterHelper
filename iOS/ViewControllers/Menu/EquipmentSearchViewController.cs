using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Binding.iOS;
using WaiterHelper.ViewModels;
using WaiterHelper.iOS.Common;
using WaiterHelper.ViewModels.Search;
using WaiterHelper.Converters;
using NikoHealth.iOS.Bindings;

namespace WaiterHelper.iOS.ViewControllers.Menu
{
    [MvxFromStoryboard("SearchEquipment")]
    [MvxModalPresentation(Animated = true, ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen, ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
    public partial class EquipmentSearchViewController : ViewControllerBase<EquipmentSearchViewModel>
    {
        private UILabel badgeLabel;
        private MvxActionBasedSimpleTableViewSource cartTableViewSource;
        private MvxMultipleSelectionCollectionViewSource collectionViewSource;
        private BoolToConditionalValuesConverter<string> cancelButtonTitleConverter
            = new BoolToConditionalValuesConverter<string>("Cancel", "Close");

        private UIViewController barcodeViewController;

        public EquipmentSearchViewController() { }
        public EquipmentSearchViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            cartTableViewSource = new MvxActionBasedSimpleTableViewSource(CartTableView, CartItemTableViewCell.Key, CartItemTableViewCell.Key, createFunc: null, reloadDataOverride: true);
            collectionViewSource = new MvxMultipleSelectionCollectionViewSource(SearchCollectionView, new NSString(nameof(SearchEquipmentPadCollectionViewCell)));

            var bindingSet = this.CreateBindingSet<EquipmentSearchViewController, EquipmentSearchViewModel>();

            //Main Colelction
            bindingSet.Bind(collectionViewSource).To(vm => vm.AvailableEquipments);
            bindingSet.Bind(collectionViewSource).For(MultipleSelectionBinding.Name)
                      .To(vm => vm.SelectedItems).Mode(MvvmCross.Binding.MvxBindingMode.OneWay);
            bindingSet.Bind(collectionViewSource).For(item => item.ItemSelectedCommand).To(vm => vm.ItemSelectedCommand);
            bindingSet.Bind(collectionViewSource).For(item => item.ItemDeselectedCommand).To(vm => vm.ItemDeselectedCommand);
            bindingSet.Bind(SelectedItemsCountLabel).To(vm => vm.SelectedItemsDescription);
            bindingSet.Bind(EmptyView).For(v => v.Hidden)
                     .To(vm => vm.AvailableEquipments)
                     .WithConversion<EmptyToBoolConverter>();

            //Cart
            bindingSet.Bind(cartTableViewSource).For(source => source.ItemsSource).To(vm => vm.SelectedItems);
            bindingSet.Bind(CartButton).For(button => button.Selected).To(vm => vm.CartOpened);
            bindingSet.Bind(CartButton).To(vm => vm.ChangeCartVisibilityCommand);
            bindingSet.Bind(CartView).For(view => view.Hidden).To(vm => vm.CartOpened)
                      .WithConversion<BoolInversionConverter>();

            bindingSet.Bind(CartEmptyView).For(view => view.Hidden).To(vm => vm.SelectedItems)
                    .WithConversion<EmptyToBoolConverter>();


            badgeLabel = CreateShopCartBadgeLabel();
            CartButton.Add(badgeLabel);
            //Badge
            bindingSet.Bind(badgeLabel).To(vm => vm.ShoppingCartCount);
            bindingSet.Bind(badgeLabel).For(label => label.Hidden).To(vm => vm.ShoppingCartCount).WithConversion<EmptyToBoolConverter>(EmptyToBoolConverter.InvertParameter);

            //Filter
            bindingSet.Bind(FilterButton).To(vm => vm.SearchCommand);
            bindingSet.Bind(FilterButton).For(button => button.Selected)
                      .To(vm => vm.FilterApplied);

            //Save Cancel
            bindingSet.Bind(CancelButton).To(vm => vm.CloseCommand);
            bindingSet.Bind(CancelButton)
                      .For(button => button.BindTitle())
                      .To(vm => vm.CanCancel)
                      .WithConversion(cancelButtonTitleConverter);

            bindingSet.Bind(SaveButton).To(vm => vm.CompleteShoppingCommand);

            //Progress
            bindingSet.Bind(LoadView).For(v => v.Hidden)
                     .To(vm => vm.IsBusy)
                     .WithConversion<BoolInversionConverter>();

            bindingSet.Apply();

            SearchCollectionView.Source = collectionViewSource;
            SearchCollectionView.AllowsSelection = true;
            SearchCollectionView.AllowsMultipleSelection = true;

            CartTableView.Source = cartTableViewSource;
            CartTableView.EstimatedRowHeight = 100f;
            CartTableView.RowHeight = UITableView.AutomaticDimension;
            CartTableView.BackgroundView = CartEmptyView;
        }

        private UILabel CreateShopCartBadgeLabel()
        {
            var label = new UILabel(new CGRect(x: 8, y: 0, width: 15, height: 15))
            {
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.FromRGB(20, 177, 215),
                BackgroundColor = UIColor.White,
                Text = "0"
            };

            label.Font = label.Font.WithSize(12);
            label.Layer.MasksToBounds = true;
            label.Layer.BorderColor = UIColor.Clear.CGColor;
            label.Layer.BorderWidth = 1;
            label.Layer.CornerRadius = label.Bounds.Size.Height / 2;

            return label;
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

        public override void ViewDidDisappear(bool animated)
        {
            if (!ViewModel.CloseCompletionSource?.Task.IsCompleted ?? false)
                ViewModel.CloseCompletionSource.TrySetResult(null);
            base.ViewDidDisappear(animated);
        }
    }
}