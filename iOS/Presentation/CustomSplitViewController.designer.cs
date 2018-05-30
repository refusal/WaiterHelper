// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WaiterHelper.iOS.Presentation
{
    [Register ("CustomSplitViewController")]
    partial class CustomSplitViewController
    {
        [Outlet]
        UIKit.UILabel EmptyTextLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView DetailView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MasterView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint MasterWidthConstraint { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DetailView != null) {
                DetailView.Dispose ();
                DetailView = null;
            }

            if (EmptyTextLabel != null) {
                EmptyTextLabel.Dispose ();
                EmptyTextLabel = null;
            }

            if (MasterView != null) {
                MasterView.Dispose ();
                MasterView = null;
            }

            if (MasterWidthConstraint != null) {
                MasterWidthConstraint.Dispose ();
                MasterWidthConstraint = null;
            }
        }
    }
}