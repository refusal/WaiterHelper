using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace WaiterHelper
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            Mvx.LazyConstructAndRegisterSingleton<IMvxAppStart, AppStart>();
        }
    }
}
