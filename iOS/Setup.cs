using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;
using NikoHealth.iOS.Bindings;
using UIKit;
using WaiterHelper.Helpers;
using WaiterHelper.iOS.Common;
using WaiterHelper.iOS.Controls;
using WaiterHelper.Services;

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
            Mvx.LazyConstructAndRegisterSingleton<IApiConnection, HttpApiConnection>();
            Mvx.LazyConstructAndRegisterSingleton<IRecognizerService, RecognizerService>();
            Mvx.LazyConstructAndRegisterSingleton<IMenuService, MenuService>();
            Mvx.LazyConstructAndRegisterSingleton<ILog, LogService>();
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
            registry.RegisterFactory(new MvxCustomBindingFactory<MvxMultipleSelectionCollectionViewSource>(MultipleSelectionBinding.Name, (source) => new MultipleSelectionBinding(source)));
            registry.RegisterCustomBindingFactory<TouchDrawingImageView>(TouchDrawingImageViewBinding.Name, (arg) => new TouchDrawingImageViewBinding(arg));
        }

        protected override MvvmCross.iOS.Views.Presenters.IMvxIosViewPresenter CreatePresenter()
        {
            return new ViewPresenter(ApplicationDelegate, Window) as MvvmCross.iOS.Views.Presenters.IMvxIosViewPresenter;
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.RegisterType<IMvxBindingContext, MvxBindingContext>();
        }
    }
}