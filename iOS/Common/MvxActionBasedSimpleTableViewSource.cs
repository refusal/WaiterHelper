using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace WaiterHelper.iOS.Common
{
    public class MvxActionBasedSimpleTableViewSource : MvxSimpleTableViewSource
    {
        public override System.Collections.IEnumerable ItemsSource
        {
            get
            {
                return base.ItemsSource;
            }
            set
            {
                base.ItemsSource = value;
            }
        }

        public Func<UITableView, NSIndexPath, object, UITableViewCell> GetOrCreateCellForFunc { get; set; }

        public MvxActionBasedSimpleTableViewSource(UITableView tableView, string nibName, string cellIdentifier = null,
                                                   NSBundle bundle = null, Func<UITableView, NSIndexPath, object, UITableViewCell> createFunc = null, bool reloadDataOverride = false)
                    : base(tableView, nibName, cellIdentifier, bundle)
        {

            GetOrCreateCellForFunc = createFunc;
            ReloadOnAllItemsSourceSets = reloadDataOverride;
        }

        public string DefaultCellIndentifier => CellIdentifier;

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            if (GetOrCreateCellForFunc != null)
                return GetOrCreateCellForFunc.Invoke(tableView, indexPath, item);

            var tableViewCell = tableView.DequeueReusableCell(CellIdentifier, indexPath);
            if (tableViewCell is MvxIndexedTableViewCell indexedCell)
            {
                indexedCell.Index = indexPath.Row;
                indexedCell.Owner = tableView;
            }

            return tableViewCell;
        }
    }
}
