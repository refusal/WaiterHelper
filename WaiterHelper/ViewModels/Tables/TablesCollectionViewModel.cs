using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Navigation;

namespace WaiterHelper.ViewModels.Tables
{
    public class TablesCollectionViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService mvxNavigationService;
        public MvxObservableCollection<TableItemViewModel> Tables { get; private set; }

        public TablesCollectionViewModel(IMvxNavigationService mvxNavigationService)
        {
            this.mvxNavigationService = mvxNavigationService;
            Tables = new MvxObservableCollection<TableItemViewModel>() { new TableItemViewModel(mvxNavigationService),
                new TableItemViewModel(mvxNavigationService),
                new TableItemViewModel(mvxNavigationService)};
        }
    }
}
