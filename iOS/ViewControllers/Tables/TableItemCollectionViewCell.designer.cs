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
	[Register ("TableItemCollectionViewCell")]
	partial class TableItemCollectionViewCell
	{
		[Outlet]
		UIKit.UIButton AddOrderButton { get; set; }

		[Outlet]
		UIKit.UILabel NumberLabel { get; set; }

		[Outlet]
		UIKit.UIButton ReserveButton { get; set; }

		[Outlet]
		UIKit.UILabel SmokingLabel { get; set; }

		[Outlet]
		UIKit.UILabel StatusLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddOrderButton != null) {
				AddOrderButton.Dispose ();
				AddOrderButton = null;
			}

			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}

			if (SmokingLabel != null) {
				SmokingLabel.Dispose ();
				SmokingLabel = null;
			}

			if (ReserveButton != null) {
				ReserveButton.Dispose ();
				ReserveButton = null;
			}

			if (NumberLabel != null) {
				NumberLabel.Dispose ();
				NumberLabel = null;
			}
		}
	}
}
