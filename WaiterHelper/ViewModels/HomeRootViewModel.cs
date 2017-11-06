using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Navigation;
using WaiterHelper.Helpers;
using System.Threading.Tasks;

namespace WaiterHelper.ViewModels
{
    public class HomeRootViewModel : ViewModelBase
    {
        private readonly IMvxViewModelLoader loader;
        private readonly IMvxNavigationService navigationService;

        public MvxAsyncCommand SyncCommand { get; set; }
        public MvxAsyncCommand SettingsCommand { get; set; }
        public MvxCommand ShowAllTabsCommand { get; set; }

        public MvxCommand ShowLeftCommand { get; set; }

        public MenuViewModel MenuViewModel { get; set; }
        public TablesCollectionViewModel TablesCollectionViewModel { get; set; }

        public HomeRootViewModel(IMvxViewModelLoader loader, IMvxNavigationService navigationService)
        {
            this.loader = loader;
            this.navigationService = navigationService;

            MenuViewModel = loader.LoadViewModel<MenuViewModel>();
            TablesCollectionViewModel = loader.LoadViewModel<TablesCollectionViewModel>();

        }

        public override async Task Initialize()
        {
            await base.Initialize();

            await MenuViewModel.Initialize();
            await TablesCollectionViewModel.Initialize();
        }
    }
}
