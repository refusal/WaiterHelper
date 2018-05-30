using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using WaiterHelper.Models;

namespace WaiterHelper.ViewModels.Search
{
    public class SearchEquipmentItemViewModel : ViewModelBase
    {
        private readonly IMvxNavigationService navigationService;

        public Meal Meal { get; private set; }
        public int Count { get; set; }

        public SearchEquipmentItemViewModel(Meal meal, IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
            Meal = meal;

            //ShowDetailsCommand = new MvxAsyncCommand(ShowDetailsAsync);
        }

        //private Task ShowDetailsAsync() => navigationService.Navigate<EquipmentDetailViewModel, EquipmentDetailViewModel.NavigationParameter>
        //(new EquipmentDetailViewModel.NavigationParameter() { Equipment = Equipment, EquipmentType = equipmentType, Components = Equipment.Components });
    }
}
