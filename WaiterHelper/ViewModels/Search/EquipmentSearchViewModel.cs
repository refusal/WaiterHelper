using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chance.MvvmCross.Plugins.UserInteraction;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using PropertyChanged;
using WaiterHelper.Models;
using WaiterHelper.Services;

namespace WaiterHelper.ViewModels.Search
{
    public class EquipmentSearchViewModel
        : ViewModelBase//, IMvxViewModel<EquipmentSearchViewModel.NavigationParameter, IEnumerable<SearchEquipmentItemViewModel>>
    {
        //public class NavigationParameter
        //{
        //    public string[] ExcludedIds { get; set; }
        //}

        private readonly IMvxNavigationService navigationService;
        private readonly IMenuService menuService;

        private string[] excludedIds = new string[0];

        private MvxObservableCollection<SearchEquipmentItemViewModel> DefaultEquipments;
        public MvxObservableCollection<SearchEquipmentItemViewModel> AvailableEquipments { get; set; }

        public List<SearchEquipmentItemViewModel> SelectedItems { get; set; }
        public MvxCommand<SearchEquipmentItemViewModel> ItemSelectedCommand { get; set; }
        public MvxCommand<SearchEquipmentItemViewModel> ItemDeselectedCommand { get; set; }

        public EquipmentSearchFilter EquipmentSearchFilter { get; set; } = new EquipmentSearchFilter();
        public string SelectedItemsDescription => $"{SelectedFilteredItems?.Count() ?? 0} items";
        public int ShoppingCartCount => SelectedItems?.Count ?? 0;
        public bool AnyInShoppingCart => ShoppingCartCount > 0;

        public MvxCommand SearchCommand { get; set; }
        public MvxCommand ChangeCartVisibilityCommand { get; set; }
        public MvxCommand ChangeBarcodeVisibilityCommand { get; set; }

        public MvxAsyncCommand CompleteShoppingCommand { get; set; }

        public bool CartOpened { get; set; }
        public bool FilterApplied => !EquipmentSearchFilter.IsEmpty;

        [DependsOn(nameof(CartOpened), nameof(FilterApplied))]
        public bool CanCancel => (CartOpened || FilterApplied);

        private IEnumerable<SearchEquipmentItemViewModel> SelectedFilteredItems
                => AvailableEquipments.Where(item => SelectedItems.Any(selectedItem => selectedItem == item));

        public TaskCompletionSource<object> CloseCompletionSource { get; set; }


        public EquipmentSearchViewModel(IMvxNavigationService navigationService,
                                        IMenuService menuService)
        {
            this.navigationService = navigationService;
            this.menuService = menuService;

            this.CompleteShoppingCommand = new MvxAsyncCommand(CompleteShoppingAsync);
            this.SearchCommand = new MvxCommand(() => ShowSearchFilterAsync());
            this.ChangeCartVisibilityCommand = new MvxCommand(ChangeCartVisibility);
            this.CloseCommand = new MvxAsyncCommand(CloseShoppingAsync);
            this.ItemSelectedCommand = new MvxCommand<SearchEquipmentItemViewModel>(SelectItem);
            this.ItemDeselectedCommand = new MvxCommand<SearchEquipmentItemViewModel>(DeselectItem);

            SelectedItems = new List<SearchEquipmentItemViewModel>();
        }

        private Task CloseShoppingAsync()
        {
            if (CartOpened)
            {
                ChangeCartVisibility();
                return Task.FromResult(true);
            }
            if (FilterApplied)
            {
                EquipmentSearchFilter = new EquipmentSearchFilter();
                return LoadSearchResultAsync();
            }
            return navigationService.Close(this);
        }

        private async void ShowSearchFilterAsync()
        {
            if (IsBusy)
                return;

            //TODO add update filter
            UpdateFilterOptions();


            var newFilter = await navigationService.Navigate<EquipmentSearchFilterViewModel,
                EquipmentSearchFilterViewModel.NavigationParameter,
                EquipmentSearchFilter>(new EquipmentSearchFilterViewModel.NavigationParameter
                {
                    Filter = this.EquipmentSearchFilter
                });

            if (newFilter != null)
            {
                EquipmentSearchFilter = newFilter;
                await LoadSearchResultAsync();
            }
        }


        private Task CompleteShoppingAsync() => navigationService.Close(this);

        private Task LoadAvailableEquipmentAsync()
        {
            return LoadDataAsync(async () =>
            {
                AvailableEquipments = new MvxObservableCollection<SearchEquipmentItemViewModel>(GetItemViewModels(menuService.GetAllMeals()));
                DefaultEquipments = AvailableEquipments;
            });
        }

        private void ChangeCartVisibility()
        {
            CartOpened = !CartOpened;
            RaisePropertyChanged(() => CartOpened);
        }

        private Task LoadSearchResultAsync()
        {
            //TODO add filter logic

            //var result = from item in DefaultEquipments
            //         where ContainsFilterQuery(item.Equipment.Name, EquipmentSearchFilter.Name)
            //         //Lot or Id
            //         && (ContainsFilterQuery(item.Equipment.LotNumber, EquipmentSearchFilter.SerialOrLotNumber)
            //                || ContainsFilterQuery(item.Equipment.SerialNumber, EquipmentSearchFilter.SerialOrLotNumber)
            //                || (item.Equipment.Components?.Any(component => ContainsFilterQuery(component.SerialNumber, EquipmentSearchFilter.SerialOrLotNumber)
            //                                                   || ContainsFilterQuery(component.LotNumber, EquipmentSearchFilter.SerialOrLotNumber))
            //                    ?? false)
            //            )
            //         && (ContainsFilterQuery(item.Equipment.PartNumber, EquipmentSearchFilter.IdPartNumber)
            //             || ContainsFilterQuery(item.Equipment.ProductId, EquipmentSearchFilter.IdPartNumber)
            //             || ContainsFilterQuery(item.Equipment.Id, EquipmentSearchFilter.IdPartNumber))
            //         && ContainsFilterQuery(item.Equipment.Manufacturer, EquipmentSearchFilter.Manufacturer)
            //         && ContainsFilterQuery(item.Equipment.Group, EquipmentSearchFilter.Group)
            //         && ContainsFilterQuery(item.Equipment.Category, EquipmentSearchFilter.Category)
            //&& ((item.Equipment.AdditionalHcpcsCodes?.Any(i => i?.ToLower()?.Contains(EquipmentSearchFilter.Hcpcs?.ToLower() ?? string.Empty) ?? false) ?? false)
            //|| ContainsFilterQuery(item.Equipment.PrimaryHcpcsCode, EquipmentSearchFilter.Hcpcs ?? string.Empty))
            //select item;

            //AvailableEquipments = new MvxObservableCollection<SearchEquipmentItemViewModel>(result);

            RaisePropertyChanged(() => SelectedItems);
            RaisePropertyChanged(() => ShoppingCartCount);
            RaisePropertyChanged(() => SelectedItemsDescription);

            return Task.FromResult(true);
        }

        private IEnumerable<SearchEquipmentItemViewModel> GetItemViewModels(IEnumerable<Meal> meals)
        => meals.Select(meal => new SearchEquipmentItemViewModel(meal, navigationService));

        private void UpdateFilterOptions()
        {

        }

        private bool ContainsFilterQuery(string propertyValue, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return true;

            return propertyValue?.ToLowerInvariant()?.Contains(filter?.ToLowerInvariant()) ?? false;
        }

        public override Task Initialize()
        {
            return LoadDataAsync(LoadAvailableEquipmentAsync);
        }

        //public void Prepare(NavigationParameter parameter)
        //{
        //    //excludedIds = parameter.ExcludedIds;
        //}

        private void SelectItem(SearchEquipmentItemViewModel newItem)
        {
            this.SelectedItems.Add(newItem);

            RaisePropertyChanged(() => SelectedItems);
            RaisePropertyChanged(() => ShoppingCartCount);
            RaisePropertyChanged(() => SelectedItemsDescription);
            RaisePropertyChanged(() => AnyInShoppingCart);
        }

        private void DeselectItem(SearchEquipmentItemViewModel item)
        {
            this.SelectedItems.Remove(item);

            RaisePropertyChanged(() => SelectedItems);
            RaisePropertyChanged(() => ShoppingCartCount);
            RaisePropertyChanged(() => SelectedItemsDescription);
            RaisePropertyChanged(() => AnyInShoppingCart);
        }
    }
}