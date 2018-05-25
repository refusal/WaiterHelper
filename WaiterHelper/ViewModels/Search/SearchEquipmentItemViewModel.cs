using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace WaiterHelper.ViewModels.Search
{
    public class SearchEquipmentItemViewModel : ViewModelBase
    {
        private readonly IMvxNavigationService navigationService;

        public SearchEquipmentItemViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;

            //ShowDetailsCommand = new MvxAsyncCommand(ShowDetailsAsync);
        }

        //private Task ShowDetailsAsync() => navigationService.Navigate<EquipmentDetailViewModel, EquipmentDetailViewModel.NavigationParameter>
        //(new EquipmentDetailViewModel.NavigationParameter() { Equipment = Equipment, EquipmentType = equipmentType, Components = Equipment.Components });
    }
}
