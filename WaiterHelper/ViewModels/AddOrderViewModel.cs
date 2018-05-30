using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using WaiterHelper.Models;
using WaiterHelper.ViewModels.Search;
using WaiterHelper.Services;
using MvvmCross.Core.Navigation;
namespace WaiterHelper.ViewModels
{
    public class AddOrderViewModel : ViewModelBase
    {
        private readonly IMenuService menuService;
        private readonly IMvxNavigationService mvxNavigationService;
        public MvxObservableCollection<SearchEquipmentItemViewModel> Meals { get; set; }

        public AddOrderViewModel(IMenuService menuService, IMvxNavigationService mvxNavigationService)
        {
            this.menuService = menuService;
            this.mvxNavigationService = mvxNavigationService;

            Meals = new MvxObservableCollection<SearchEquipmentItemViewModel>();
        }

        public override Task Initialize()
        {
            return LoadDataAsync(async () =>
            {
                Meals = new MvxObservableCollection<SearchEquipmentItemViewModel>(GetItemViewModels(menuService.GetAllMeals()));
            });
        }

        private IEnumerable<SearchEquipmentItemViewModel> GetItemViewModels(IEnumerable<Meal> meals)
        => meals.Select(meal => new SearchEquipmentItemViewModel(meal, mvxNavigationService));
    }
}
