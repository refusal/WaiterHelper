// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WaiterHelper.iOS.ViewControllers
{
    [Register ("SearchPopUpControl")]
    partial class SearchPopUpControl
    {
        [Outlet]
        WaiterHelper.iOS.Controls.TouchDrawingImageView DrawingImage { get; set; }


        [Outlet]
        UIKit.UILabel ResultTextLabel { get; set; }


        [Outlet]
        UIKit.UIButton SearchButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DrawingImage != null) {
                DrawingImage.Dispose ();
                DrawingImage = null;
            }

            if (ResultTextLabel != null) {
                ResultTextLabel.Dispose ();
                ResultTextLabel = null;
            }

            if (SearchButton != null) {
                SearchButton.Dispose ();
                SearchButton = null;
            }
        }
    }
}