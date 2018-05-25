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
    [Register("CartItemTableViewCell")]
    partial class CartItemTableViewCell
    {
        [Outlet]
        UIKit.UIButton DeleteButton { get; set; }


        [Outlet]
        UIKit.UILabel HcpcsLabel { get; set; }


        [Outlet]
        UIKit.UIButton HcpcsMoreButton { get; set; }


        [Outlet]
        UIKit.UILabel IdPartLabel { get; set; }


        [Outlet]
        UIKit.UILabel LotNumberLabel { get; set; }


        [Outlet]
        UIKit.UILabel ManufacturerLabel { get; set; }


        [Outlet]
        UIKit.UILabel NameLabel { get; set; }


        [Outlet]
        UIKit.UILabel QtyLabel { get; set; }


        [Outlet]
        UIKit.UILabel SerialNumberLabel { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (HcpcsLabel != null)
            {
                HcpcsLabel.Dispose();
                HcpcsLabel = null;
            }

            if (HcpcsMoreButton != null)
            {
                HcpcsMoreButton.Dispose();
                HcpcsMoreButton = null;
            }

            if (IdPartLabel != null)
            {
                IdPartLabel.Dispose();
                IdPartLabel = null;
            }

            if (LotNumberLabel != null)
            {
                LotNumberLabel.Dispose();
                LotNumberLabel = null;
            }

            if (ManufacturerLabel != null)
            {
                ManufacturerLabel.Dispose();
                ManufacturerLabel = null;
            }

            if (NameLabel != null)
            {
                NameLabel.Dispose();
                NameLabel = null;
            }

            if (QtyLabel != null)
            {
                QtyLabel.Dispose();
                QtyLabel = null;
            }

            if (SerialNumberLabel != null)
            {
                SerialNumberLabel.Dispose();
                SerialNumberLabel = null;
            }
        }
    }
}