using System;
using MvvmCross.Core.ViewModels;

namespace WaiterHelper.Helpers
{
    public static class MvxViewModelLoaderExtension
    {
        public static T LoadViewModel<T>(this IMvxViewModelLoader loader)
        {
            return (T)loader.LoadViewModel(new MvxViewModelRequest(typeof(T)), null);
        }
    }
}
