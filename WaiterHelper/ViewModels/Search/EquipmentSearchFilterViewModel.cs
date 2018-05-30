using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using WaiterHelper.Models;
using MvvmCross.Core.Navigation;

namespace WaiterHelper.ViewModels.Search
{

    public class EquipmentSearchFilterViewModel : ViewModelBase, IMvxViewModel<EquipmentSearchFilterViewModel.NavigationParameter, EquipmentSearchFilter>
    {
        public class NavigationParameter
        {
            public EquipmentSearchFilter Filter { get; set; }
        }

        private readonly IMvxNavigationService mvxNavigationService;
        public MvxAsyncCommand ApplyCommand { get; set; }
        public MvxAsyncCommand ResetCommand { get; set; }

        public MvxCommand ShowSearchPopUp { get; set; }

        public EquipmentSearchFilter EquipmentSearchFilter { get; set; }
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public EquipmentSearchFilterViewModel(IMvxNavigationService mvxNavigationService)
        {
            this.mvxNavigationService = mvxNavigationService;
            ApplyCommand = new MvxAsyncCommand(() => CloseFilters(true));
            CloseCommand = new MvxAsyncCommand(() => CloseFilters(false));
            ResetCommand = new MvxAsyncCommand(ClearFilterAsync);

            ShowSearchPopUp = new MvxCommand(NavigateToSearchPopUp);
        }

        public void NavigateToSearchPopUp()
        {
            mvxNavigationService.Navigate<SearchViewModel>();
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
            if (!CloseCompletionSource.Task.IsCompleted)
                CloseCompletionSource.TrySetResult(null);
        }

        private Task CloseFilters(bool filtersApply)
        {
            if (filtersApply)
                return Close(EquipmentSearchFilter);
            return Close(null);
        }

        public Task<bool> Close(EquipmentSearchFilter result)
        {
            CloseCompletionSource.TrySetResult(result);
            return Task.FromResult(Close(this));
        }

        private Task ClearFilterAsync()
        {
            this.EquipmentSearchFilter.Category = string.Empty;
            this.EquipmentSearchFilter.Name = string.Empty;
            this.EquipmentSearchFilter.MinPrice = string.Empty;
            this.EquipmentSearchFilter.MaxPrice = string.Empty;

            return Task.FromResult(true);
        }

        public void Prepare(NavigationParameter parameter)
        {
            EquipmentSearchFilter = parameter.Filter;
        }
    }
}
