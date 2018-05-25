using System;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace WaiterHelper.iOS.Common
{
    public abstract class MvxIndexedTableViewCell : MvxTableViewCell
    {
        public MvxIndexedTableViewCell(IntPtr intPtr) : base(intPtr) { }
        public UITableView Owner { get; set; }
        public virtual int Index { set; get; }
    }
}
