// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WaiterHelper.iOS.ViewControllers.Menu
{
    [Register ("CartItemTableViewCell")]
    partial class CartItemTableViewCell
    {
        [Outlet]
        UIKit.UILabel NameLabel { get; set; }

        [Outlet]
        UIKit.UILabel PriceLabel { get; set; }

        [Outlet]
        UIKit.UITextField QtyTextField { get; set; }

        [Outlet]
        UIKit.UILabel WeightLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NameLabel != null) {
                NameLabel.Dispose ();
                NameLabel = null;
            }

            if (PriceLabel != null) {
                PriceLabel.Dispose ();
                PriceLabel = null;
            }

            if (QtyTextField != null) {
                QtyTextField.Dispose ();
                QtyTextField = null;
            }

            if (WeightLabel != null) {
                WeightLabel.Dispose ();
                WeightLabel = null;
            }
        }
    }
}