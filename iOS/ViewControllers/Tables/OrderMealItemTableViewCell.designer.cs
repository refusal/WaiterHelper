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
	[Register ("OrderMealItemTableViewCell")]
	partial class OrderMealItemTableViewCell
	{
		[Outlet]
		UIKit.UIButton DeleteButton { get; set; }

		[Outlet]
		UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		UIKit.UILabel PriceLabel { get; set; }

		[Outlet]
		UIKit.UILabel QtyLabel { get; set; }

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

			if (WeightLabel != null) {
				WeightLabel.Dispose ();
				WeightLabel = null;
			}

			if (DeleteButton != null) {
				DeleteButton.Dispose ();
				DeleteButton = null;
			}

			if (QtyLabel != null) {
				QtyLabel.Dispose ();
				QtyLabel = null;
			}
		}
	}
}
