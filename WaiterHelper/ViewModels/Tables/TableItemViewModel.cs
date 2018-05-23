using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Navigation;
using WaiterHelper.Models;

namespace WaiterHelper.ViewModels.Tables
{
    public class TableItemViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService mvxNavigationService;
        public IMvxCommand ReserveCommand { get; internal set; }

        public TableItemViewModel(Table table, IMvxNavigationService mvxNavigationService)
        {
            this.mvxNavigationService = mvxNavigationService;
            ReserveCommand = new MvxAsyncCommand(async () => await mvxNavigationService.Navigate<ReserveViewModel>());
        }

    }
}
