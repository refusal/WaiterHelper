// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
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
