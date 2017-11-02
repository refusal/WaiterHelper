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
	[Register ("MenuViewController")]
	partial class MenuViewController
	{
		[Outlet]
		UIKit.UICollectionView MenuCollectionView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MenuCollectionView != null) {
				MenuCollectionView.Dispose ();
				MenuCollectionView = null;
			}
		}
	}
}
