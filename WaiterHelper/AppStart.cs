using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using WaiterHelper.ViewModels;

namespace WaiterHelper
{
    public class AppStart : IMvxAppStart
    {
        private readonly IMvxNavigationService navigationService;

        public AppStart(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public async void Start(object hint = null)
        {
            await navigationService.Navigate<HomeRootViewModel>();
        }
    }
}