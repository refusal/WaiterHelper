// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WaiterHelper.iOS.ViewControllers.Menu
{
    [Register("EquipmentSearchViewController")]
    partial class EquipmentSearchViewController
    {
        [Outlet]
        UIKit.UIActivityIndicatorView ActivityLoader { get; set; }

        [Outlet]
        UIKit.UIButton BarcodeButton { get; set; }

        [Outlet]
        UIKit.UIView BarcodeViewHolder { get; set; }

        [Outlet]
        UIKit.UIButton CancelButton { get; set; }

        [Outlet]
        UIKit.UIButton CartButton { get; set; }

        [Outlet]
        UIKit.UIView CartEmptyView { get; set; }

        [Outlet]
        UIKit.UITableView CartTableView { get; set; }

        [Outlet]
        UIKit.UIView CartView { get; set; }

        [Outlet]
        UIKit.UIView EmptyView { get; set; }

        [Outlet]
        UIKit.UIButton FilterButton { get; set; }

        [Outlet]
        UIKit.UIView LoadView { get; set; }

        [Outlet]
        UIKit.UILabel LotNumberCartHeaderLabel { get; set; }

        [Outlet]
        UIKit.UILabel QtyCartHeaderLabel { get; set; }

        [Outlet]
        UIKit.UIButton SaveButton { get; set; }

        [Outlet]
        UIKit.UICollectionView SearchCollectionView { get; set; }

        [Outlet]
        UIKit.UILabel SelectedItemsCountLabel { get; set; }

        [Outlet]
        UIKit.UILabel SelectedLabel { get; set; }

        [Outlet]
        UIKit.UILabel SerialNumberCartHeaderLabel { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (ActivityLoader != null)
            {
                ActivityLoader.Dispose();
                ActivityLoader = null;
            }

            if (BarcodeButton != null)
            {
                BarcodeButton.Dispose();
                BarcodeButton = null;
            }

            if (BarcodeViewHolder != null)
            {
                BarcodeViewHolder.Dispose();
                BarcodeViewHolder = null;
            }

            if (CancelButton != null)
            {
                CancelButton.Dispose();
                CancelButton = null;
            }

            if (CartButton != null)
            {
                CartButton.Dispose();
                CartButton = null;
            }

            if (CartEmptyView != null)
            {
                CartEmptyView.Dispose();
                CartEmptyView = null;
            }

            if (CartTableView != null)
            {
                CartTableView.Dispose();
                CartTableView = null;
            }

            if (CartView != null)
            {
                CartView.Dispose();
                CartView = null;
            }

            if (FilterButton != null)
            {
                FilterButton.Dispose();
                FilterButton = null;
            }

            if (LoadView != null)
            {
                LoadView.Dispose();
                LoadView = null;
            }

            if (LotNumberCartHeaderLabel != null)
            {
                LotNumberCartHeaderLabel.Dispose();
                LotNumberCartHeaderLabel = null;
            }

            if (QtyCartHeaderLabel != null)
            {
                QtyCartHeaderLabel.Dispose();
                QtyCartHeaderLabel = null;
            }

            if (SaveButton != null)
            {
                SaveButton.Dispose();
                SaveButton = null;
            }

            if (SearchCollectionView != null)
            {
                SearchCollectionView.Dispose();
                SearchCollectionView = null;
            }

            if (SelectedItemsCountLabel != null)
            {
                SelectedItemsCountLabel.Dispose();
                SelectedItemsCountLabel = null;
            }

            if (SelectedLabel != null)
            {
                SelectedLabel.Dispose();
                SelectedLabel = null;
            }

            if (SerialNumberCartHeaderLabel != null)
            {
                SerialNumberCartHeaderLabel.Dispose();
                SerialNumberCartHeaderLabel = null;
            }

            if (EmptyView != null)
            {
                EmptyView.Dispose();
                EmptyView = null;
            }
        }
    }
}
