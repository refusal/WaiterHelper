using MvvmCross.Core.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Chance.MvvmCross.Plugins.UserInteraction;
using MvvmCross.Platform;

namespace WaiterHelper.ViewModels
{
    public class ViewModelBase : MvxViewModel
    {
        public virtual bool IsBusy { get; set; }
        public virtual string Title { get; set; }
        public virtual IMvxCommand CloseCommand { get; set; }

        public ViewModelBase()
        {
            CloseCommand = new MvxCommand(() => Close(this));
        }

        public async Task LoadDataAsync(Func<Task> loading)
        {
            try
            {
                IsBusy = true;
                await loading();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}