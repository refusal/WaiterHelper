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
    [Register ("SearchEquipmentPadCollectionViewCell")]
    partial class SearchEquipmentPadCollectionViewCell
    {
        [Outlet]
        UIKit.UILabel CategoryLabel { get; set; }


        [Outlet]
        UIKit.UIImageView DeviceImageView { get; set; }


        [Outlet]
        UIKit.UIButton ItemInfoButton { get; set; }


        [Outlet]
        UIKit.UIView MainView { get; set; }


        [Outlet]
        UIKit.UILabel PriceLabel { get; set; }


        [Outlet]
        UIKit.UIView SpicyTagView { get; set; }


        [Outlet]
        UIKit.UILabel TitleLabel { get; set; }


        [Outlet]
        UIKit.UIView VeganTagView { get; set; }


        [Outlet]
        UIKit.UILabel WeightLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CategoryLabel != null) {
                CategoryLabel.Dispose ();
                CategoryLabel = null;
            }

            if (DeviceImageView != null) {
                DeviceImageView.Dispose ();
                DeviceImageView = null;
            }

            if (ItemInfoButton != null) {
                ItemInfoButton.Dispose ();
                ItemInfoButton = null;
            }

            if (MainView != null) {
                MainView.Dispose ();
                MainView = null;
            }

            if (PriceLabel != null) {
                PriceLabel.Dispose ();
                PriceLabel = null;
            }

            if (SpicyTagView != null) {
                SpicyTagView.Dispose ();
                SpicyTagView = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }

            if (VeganTagView != null) {
                VeganTagView.Dispose ();
                VeganTagView = null;
            }

            if (WeightLabel != null) {
                WeightLabel.Dispose ();
                WeightLabel = null;
            }
        }
    }
}