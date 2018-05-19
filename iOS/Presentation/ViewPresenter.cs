using System.Linq;
using CoreGraphics;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;
using UIKit;
using MvvmCross.Core.Views;
using WaiterHelper.iOS.Presentation;
using WaiterHelper.iOS.Common;

namespace WaiterHelper.iOS
{
    public class ViewPresenter : MvxIosViewPresenter
    {
        protected CGRect screenSize;

        public ViewPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
            screenSize = UIScreen.MainScreen.Bounds;
        }

        protected override void ShowModalViewController(UIViewController viewController, MvvmCross.iOS.Views.Presenters.Attributes.MvxModalPresentationAttribute attribute, MvxViewModelRequest request)
        {
            switch (attribute)
            {
                case MvxModalAutoSizePresentationAttribute customModalAttribute:
                    {
                        // setup modal based on attribute
                        if (attribute.WrapInNavigationController)
                        {
                            viewController = CreateNavigationController(viewController);
                        }

                        var transitionDelegate = new TransitioningDelegateAtCenter();

                        viewController.ModalPresentationStyle = UIModalPresentationStyle.Custom;
                        viewController.ModalTransitionStyle = customModalAttribute.ModalTransitionStyle;
                        viewController.TransitioningDelegate = transitionDelegate;

                        // Check if there is a modal already presented first. Otherwise use the window root
                        var modalHost = ModalViewControllers.LastOrDefault() ?? _window.RootViewController;

                        modalHost.PresentViewController(
                            viewController,
                            attribute.Animated,
                            null);

                        ModalViewControllers.Add(viewController);
                        break;
                    }
                default:
                    base.ShowModalViewController(viewController, attribute, request);
                    break;
            }
        }

        public override void RegisterAttributeTypes()
        {
            base.RegisterAttributeTypes();

            AttributeTypesToActionsDictionary.Add(typeof(MvxModalAutoSizePresentationAttribute), new MvxPresentationAttributeAction
            {
                ShowAction = (vc, attribute, request) =>
                {
                    var viewController = (UIViewController)this.CreateViewControllerFor(request);
                    ShowModalViewController(viewController, (MvxModalAutoSizePresentationAttribute)attribute, request);
                },
                CloseAction = (viewModel, attribute) => CloseModalViewController(viewModel, (MvxModalPresentationAttribute)attribute)
            });

            AttributeTypesToActionsDictionary.Add(typeof(MvxRootChildPresentationAttribute), new MvxPresentationAttributeAction
            {
                ShowAction = (vc, attribute, request) =>
                {
                    var viewController = (UIViewController)this.CreateViewControllerFor(request);
                    ShowRootChildViewController(viewController, (MvxRootChildPresentationAttribute)attribute, request);
                },
                CloseAction = (viewModel, attribute) => CloseChildViewController(viewModel, (MvxChildPresentationAttribute)attribute)
            });

            AttributeTypesToActionsDictionary.Add(typeof(MvxDetailCustomPresentationAttribute), new MvxPresentationAttributeAction
            {
                ShowAction = (vc, attribute, request) =>
                {
                    var viewController = (UIViewController)this.CreateViewControllerFor(request);
                    ShowDetailCustomSplitViewController(viewController, (MvxDetailCustomPresentationAttribute)attribute, request);
                },
                CloseAction = (viewModel, attribute) => CloseChildViewController(viewModel, (MvxChildPresentationAttribute)attribute)
            });

            AttributeTypesToActionsDictionary.Add(typeof(MvxMasterCustomPresentationAttribute), new MvxPresentationAttributeAction
            {
                ShowAction = (vc, attribute, request) =>
                {
                    var viewController = (UIViewController)this.CreateViewControllerFor(request);
                    ShowMasterCustomSplitViewController(viewController, (MvxMasterCustomPresentationAttribute)attribute, request);
                },
                CloseAction = (viewModel, attribute) => CloseChildViewController(viewModel, (MvxChildPresentationAttribute)attribute)
            });
        }

        private void ShowRootChildViewController(UIViewController viewController, MvxRootChildPresentationAttribute attribute, object request)
        {
            var rootNavigationViewController = (_window.RootViewController as MvxNavigationController);
            if (rootNavigationViewController != null)
                PushViewControllerIntoStack(rootNavigationViewController, viewController, attribute.Animated);
        }

        protected override void ShowRootViewController(UIViewController viewController, MvxRootPresentationAttribute attribute, MvxViewModelRequest request)
        {
            if (viewController is IMvxTabBarViewController tabBarController)
            {
                var masterNavigationController = CreateNavigationController(viewController);
                SetWindowRootViewController(masterNavigationController);

                masterNavigationController.SetNavigationBarHidden(true, false);

                CloseMasterNavigationController();
                CleanupModalViewControllers();
                CloseSplitViewController();

                MasterNavigationController = masterNavigationController;
                TabBarViewController = tabBarController;
                return;
            }
            base.ShowRootViewController(viewController, attribute, request);
        }

        protected override void ShowChildViewController(UIViewController viewController, MvxChildPresentationAttribute attribute, MvxViewModelRequest request)
        {
            if (viewController is IMvxSplitViewController)
                throw new MvxException("A SplitViewController cannot be presented as a child. Consider using Root instead");

            if (ModalViewControllers.Any())
            {
                if (ModalViewControllers.LastOrDefault() is UINavigationController modalNavController)
                {
                    PushViewControllerIntoStack(modalNavController, viewController, attribute.Animated);

                    return;
                }
                else
                {
                    throw new MvxException($"Trying to show View type: {viewController.GetType().Name} as child, but there is currently a plain modal view presented!");
                }
            }


            if (MasterNavigationController == null || MasterNavigationController?.TopViewController == TabBarViewController)
            {
                if (TabBarViewController != null && TabBarViewController.ShowChildView(viewController))
                {
                    return;
                }
            }
            else
            {
                PushViewControllerIntoStack(MasterNavigationController, viewController, attribute.Animated);
                return;
            }

            throw new MvxException($"Trying to show View type: {viewController.GetType().Name} as child, but there is no current stack!");
        }

        protected override bool TryCloseViewControllerInsideStack(UINavigationController navController, IMvxViewModel toClose)
        {
            return base.TryCloseViewControllerInsideStack(navController, toClose);
        }

        public override void Close(IMvxViewModel toClose)
        {
            // check if there is a modal presented
            if (ModalViewControllers.Any() && CloseModalViewController(toClose))
                return;

            // if the current root is a NavigationController, close it in the stack
            if (MasterNavigationController != null && TryCloseViewControllerInsideStack(MasterNavigationController, toClose))
                return;

            // if the current root is a TabBarViewController, delegate close responsibility to it
            if (TabBarViewController != null && TabBarViewController.CloseChildViewModel(toClose))
                return;

            // if the current root is a SplitViewController, delegate close responsibility to it
            if (SplitViewController != null && SplitViewController.CloseChildViewModel(toClose))
                return;

            MvxTrace.Warning($"Could not close ViewModel type {toClose.GetType().Name}");
        }

        private void ShowMasterCustomSplitViewController(UIViewController vc, MvxMasterCustomPresentationAttribute attribute, MvxViewModelRequest request)
        {
            CustomSplitViewController splitViewController = null;
            if (attribute.Host != null)
                splitViewController = UIViewControllerExtensions.GetFirstDescendandOf(this._window.RootViewController, attribute.Host) as CustomSplitViewController;
            else
                splitViewController = this._window.RootViewController.GetFirstDescendandOf<CustomSplitViewController>() as CustomSplitViewController;
            splitViewController?.ShowMasterViewController(vc);
        }

        private void ShowDetailCustomSplitViewController(UIViewController vc, MvxDetailCustomPresentationAttribute attribute, MvxViewModelRequest request)
        {
            CustomSplitViewController splitViewController = null;
            if (attribute.Host != null)
                splitViewController = UIViewControllerExtensions.GetFirstDescendandOf(this._window.RootViewController, attribute.Host) as CustomSplitViewController;
            else
                splitViewController = this._window.RootViewController.GetFirstDescendandOf<CustomSplitViewController>() as CustomSplitViewController;

            splitViewController?.ShowDetailViewController(vc, request);
        }
    }
}
