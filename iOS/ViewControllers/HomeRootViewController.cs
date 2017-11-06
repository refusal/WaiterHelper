using System;
using System.Linq;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Plugins.Color.iOS;
using UIKit;
using WaiterHelper.ViewModels;

namespace WaiterHelper.iOS.ViewControllers
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class HomeRootViewController : MvxTabBarViewController<HomeRootViewModel>
    {
        private int createdSoFarCount;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            DefinesPresentationContext = true;
            if (this.ViewModel == null)
                return;

            var viewControllers = new[]
            {
                CreateTabFor("Tables","TablesTab",this.ViewModel.TablesCollectionViewModel),
                CreateTabFor("Menu" ,"MenuTab", this.ViewModel.MenuViewModel),
                CreateTabFor("Settings" ,"MenuTab", this.ViewModel.SettingsViewModel),
            };

            ViewControllers = viewControllers;

            CustomizableViewControllers = new UIViewController[] { };
            SelectedViewController = ViewControllers[0];

            this.TabBar.TintColor = AppTheme.ColorAccent.ToNativeColor();
            this.TabBar.BarTintColor = UIColor.White;
            this.TabBar.Layer.BorderWidth = 0.5f;
            this.TabBar.Layer.BorderColor = UIColor.Gray.CGColor;
        }

        private UIViewController CreateTabFor(string title, string iconName, IMvxViewModel viewModel)
        {
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;

            if (ShouldWrapInNavigationViewController(screen.GetType()))
            {
                var navigationViewController = new MvxNavigationController(screen);
                screen.NavigationController.NavigationBar.Hidden = true;
                screen = navigationViewController;
            }

            screen.Title = title?.ToUpper();

            var image = UIImage.FromBundle(iconName);
            screen.TabBarItem = new UITabBarItem(title, image, createdSoFarCount);

            createdSoFarCount++;
            return screen;
        }

        private bool ShouldWrapInNavigationViewController(Type viewControllerType)
        {
            var attribute = viewControllerType
                .GetCustomAttributes(typeof(MvxBasePresentationAttribute), true)
                .FirstOrDefault() as MvxTabPresentationAttribute;
            return attribute?.WrapInNavigationController ?? false;
        }

        public override bool ShowChildView(UIViewController viewController)
        {
            var navigationController = SelectedViewController as UINavigationController;

            // if the current selected ViewController is not a NavigationController, then a child cannot be shown
            if (navigationController == null)
            {
                return false;
            }

            navigationController.PushViewController(viewController, true);

            return true;
        }

        public override bool CanShowChildView()
        {
            return SelectedViewController is UINavigationController;
        }

        public override void ShowTabView(UIViewController viewController, MvxTabPresentationAttribute attribute)
        {
            base.ShowTabView(viewController, attribute);
        }
    }
}