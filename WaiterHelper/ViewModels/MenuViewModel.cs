using System;
using MvvmCross.Core.ViewModels;
using CoreImage;
using MvvmCross.Core.Navigation;
using System.Threading.Tasks;

namespace WaiterHelper.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService mvxNavigationService;

        public IMvxCommand ShowAdditionalSearch { get; set; }

        public MenuViewModel(IMvxNavigationService mvxNavigationService)
        {
            this.mvxNavigationService = mvxNavigationService;
            ShowAdditionalSearch = new MvxAsyncCommand(ShowSearchPopUp);
        }

        private async Task ShowSearchPopUp()
        {
            await mvxNavigationService.Navigate<SearchViewModel>();
        }
    }
}
