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
    [Register("EquipmentSearchCartViewController")]
    partial class EquipmentSearchCartViewController
    {
        [Outlet]
        UIKit.UIButton CancelButton { get; set; }

        [Outlet]
        UIKit.UITableView CartTableView { get; set; }

        [Outlet]
        UIKit.UIView EmptyView { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (CancelButton != null)
            {
                CancelButton.Dispose();
                CancelButton = null;
            }

            if (CartTableView != null)
            {
                CartTableView.Dispose();
                CartTableView = null;
            }

            if (EmptyView != null)
            {
                EmptyView.Dispose();
                EmptyView = null;
            }
        }
    }
}
