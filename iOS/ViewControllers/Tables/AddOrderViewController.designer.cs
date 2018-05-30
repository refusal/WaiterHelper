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
    [Register ("AddOrderViewController")]
    partial class AddOrderViewController
    {
        [Outlet]
        UIKit.UIButton AddMealButton { get; set; }


        [Outlet]
        UIKit.UIButton CancelButton { get; set; }


        [Outlet]
        UIKit.UIButton CloseButton { get; set; }


        [Outlet]
        UIKit.UIButton ConfirmButton { get; set; }


        [Outlet]
        UIKit.UITextField CountOfClientsEditText { get; set; }


        [Outlet]
        UIKit.UITableView MealsTableView { get; set; }


        [Outlet]
        UIKit.UITextView NotesTextView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddMealButton != null) {
                AddMealButton.Dispose ();
                AddMealButton = null;
            }

            if (CancelButton != null) {
                CancelButton.Dispose ();
                CancelButton = null;
            }

            if (CloseButton != null) {
                CloseButton.Dispose ();
                CloseButton = null;
            }

            if (ConfirmButton != null) {
                ConfirmButton.Dispose ();
                ConfirmButton = null;
            }

            if (CountOfClientsEditText != null) {
                CountOfClientsEditText.Dispose ();
                CountOfClientsEditText = null;
            }

            if (MealsTableView != null) {
                MealsTableView.Dispose ();
                MealsTableView = null;
            }

            if (NotesTextView != null) {
                NotesTextView.Dispose ();
                NotesTextView = null;
            }
        }
    }
}