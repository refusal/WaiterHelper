using System;
using MvvmCross.Core.ViewModels;

namespace WaiterHelper.ViewModels.Tables
{
    public class TablesCollectionViewModel : MvxViewModel
    {
        public MvxObservableCollection<TableItemViewModel> Tables { get; private set; }

        public TablesCollectionViewModel()
        {
            Tables = new MvxObservableCollection<TableItemViewModel>() { new TableItemViewModel(),
                                                                         new TableItemViewModel(),
                                                                         new TableItemViewModel()};
        }
    }
}
