using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Navigation;
using WaiterHelper.Services;
using System.Threading.Tasks;
using System.Linq;

namespace WaiterHelper.ViewModels.Tables
{
    public class TablesCollectionViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService mvxNavigationService;
        private readonly IMenuService menuService;
        public MvxObservableCollection<TableItemViewModel> Tables { get; private set; }

        public TablesCollectionViewModel(IMvxNavigationService mvxNavigationService, IMenuService menuService)
        {
            this.mvxNavigationService = mvxNavigationService;
            this.menuService = menuService;
        }

        public override Task Initialize()
        {
            Tables = new MvxObservableCollection<TableItemViewModel>(menuService.GetAllTables()?.Select((table) => new TableItemViewModel(table, mvxNavigationService)));
            return Task.FromResult(true);
        }
    }
}
