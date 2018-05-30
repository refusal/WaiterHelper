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
        public IMvxCommand AddOrderCommand { get; internal set; }
        public IMvxCommand CloseOrderCommand { get; internal set; }

        public Table Table { get; set; }

        public TableItemViewModel(Table table, IMvxNavigationService mvxNavigationService)
        {
            this.mvxNavigationService = mvxNavigationService;

            Table = table;
            ReserveCommand = new MvxAsyncCommand(async () => await mvxNavigationService.Navigate<ReserveViewModel>());
            AddOrderCommand = new MvxAsyncCommand(async () => await mvxNavigationService.Navigate<AddOrderViewModel>());

        }

    }
}
