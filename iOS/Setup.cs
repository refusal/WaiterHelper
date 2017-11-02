using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;
using UIKit;

namespace WaiterHelper.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(IMvxApplicationDelegate appDelegate, UIWindow window) : base(appDelegate, window)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.RegisterType<IMvxBindingContext, MvxBindingContext>();
        }
    }
}