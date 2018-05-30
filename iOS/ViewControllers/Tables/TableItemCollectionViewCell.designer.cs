// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WaiterHelper.iOS.ViewControllers.Tables
{
    [Register ("TableItemCollectionViewCell")]
    partial class TableItemCollectionViewCell
    {
        [Outlet]
        UIKit.UIButton AddOrderButton { get; set; }

        [Outlet]
        UIKit.UIView HolderView { get; set; }

        [Outlet]
        UIKit.UILabel MaxCountLabel { get; set; }

        [Outlet]
        UIKit.UILabel NumberLabel { get; set; }

        [Outlet]
        UIKit.UIButton ReserveButton { get; set; }

        [Outlet]
        UIKit.UILabel SmokingLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddOrderButton != null) {
                AddOrderButton.Dispose ();
                AddOrderButton = null;
            }

            if (HolderView != null) {
                HolderView.Dispose ();
                HolderView = null;
            }

            if (MaxCountLabel != null) {
                MaxCountLabel.Dispose ();
                MaxCountLabel = null;
            }

            if (NumberLabel != null) {
                NumberLabel.Dispose ();
                NumberLabel = null;
            }

            if (ReserveButton != null) {
                ReserveButton.Dispose ();
                ReserveButton = null;
            }

            if (SmokingLabel != null) {
                SmokingLabel.Dispose ();
                SmokingLabel = null;
            }
        }
    }
}