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
    [Register ("TablesCollectionViewController")]
    partial class TablesCollectionViewController
    {
        [Outlet]
        UIKit.UICollectionView TablesCollectionView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TablesCollectionView != null) {
                TablesCollectionView.Dispose ();
                TablesCollectionView = null;
            }
        }
    }
}