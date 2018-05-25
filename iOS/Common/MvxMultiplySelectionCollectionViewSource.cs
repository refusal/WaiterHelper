using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using MvvmCross.Core.ViewModels;
using WaiterHelper.ViewModels.Search;

namespace WaiterHelper.iOS.Common
{
    public class MvxMultipleSelectionCollectionViewSource : MvxCollectionViewSourceAnimated
    {
        private bool inEditMode;

        public event Action<IEnumerable<object>> SelectedItemsUpdated;

        public IEnumerable<object> SelectedItems
        {
            get => GetSelectedItems();
            set => SetSelectedItems(value);
        }

        public MvxCommand<SearchEquipmentItemViewModel> ItemSelectedCommand { get; set; }
        public MvxCommand<SearchEquipmentItemViewModel> ItemDeselectedCommand { get; set; }

        public MvxMultipleSelectionCollectionViewSource(UICollectionView collectionView,
                                                NSString defaultCellIndentifier) : base(collectionView, defaultCellIndentifier) { }


        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            if (inEditMode)
                return;
            UpdateSelectedItems();
            ItemSelectedCommand?.Execute(ItemsSource.ElementAt(indexPath.Row));
        }

        public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            if (inEditMode)
                return;
            UpdateSelectedItems();
            ItemDeselectedCommand?.Execute(ItemsSource.ElementAt(indexPath.Row));
        }

        private void UpdateSelectedItems() => SelectedItemsUpdated?.Invoke(SelectedItems);

        private IEnumerable<object> GetSelectedItems()
        {
            foreach (var selectedIndexPath in CollectionView.GetIndexPathsForSelectedItems())
            {
                yield return ItemsSource.ElementAt(selectedIndexPath.Row);
            }
        }

        private void SetSelectedItems(IEnumerable<object> newSelectedItems)
        {
            DeselectRange(CollectionView.GetIndexPathsForSelectedItems());
            if (this.ItemsSource == null)
                return;
            if (newSelectedItems == null)
            {
                if (CollectionView.GetIndexPathsForSelectedItems().Any())
                    DeselectRange(CollectionView.GetIndexPathsForSelectedItems());

                return;
            }
            foreach (var item in ItemsSource)
            {
                var selectedItemFromItemSource = newSelectedItems.FirstOrDefault(newSelectedItem => item == newSelectedItem);
                if (selectedItemFromItemSource != null)
                {
                    var indexOfItem = ItemsSource.GetPosition(selectedItemFromItemSource);
                    this.CollectionView.SelectItem(NSIndexPath.FromRowSection(indexOfItem, 0), true, UICollectionViewScrollPosition.None);
                }
                else
                    this.CollectionView.DeselectItem(NSIndexPath.FromRowSection(ItemsSource.GetPosition(item), 0), true);
            }

        }

        private void DeselectRange(NSIndexPath[] indexPaths)
        {
            inEditMode = true;
            foreach (var indexPath in indexPaths)
                CollectionView.DeselectItem(indexPath, true);
            inEditMode = false;
        }
    }
}
