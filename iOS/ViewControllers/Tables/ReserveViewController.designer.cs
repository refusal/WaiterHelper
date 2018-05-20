// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WaiterHelper.iOS.ViewControllers.Tables
{
	[Register ("ReserveViewController")]
	partial class ReserveViewController
	{
		[Outlet]
		UIKit.UIButton CancelButton { get; set; }

		[Outlet]
		UIKit.UIButton CloseButton { get; set; }

		[Outlet]
		UIKit.UIButton ConfirmButton { get; set; }

		[Outlet]
		UIKit.UIDatePicker DatePicker { get; set; }

		[Outlet]
		UIKit.UITextField NameEditText { get; set; }

		[Outlet]
		UIKit.UITextView NotesTextView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CloseButton != null) {
				CloseButton.Dispose ();
				CloseButton = null;
			}

			if (DatePicker != null) {
				DatePicker.Dispose ();
				DatePicker = null;
			}

			if (NameEditText != null) {
				NameEditText.Dispose ();
				NameEditText = null;
			}

			if (NotesTextView != null) {
				NotesTextView.Dispose ();
				NotesTextView = null;
			}

			if (ConfirmButton != null) {
				ConfirmButton.Dispose ();
				ConfirmButton = null;
			}

			if (CancelButton != null) {
				CancelButton.Dispose ();
				CancelButton = null;
			}
		}
	}
}
