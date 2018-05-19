using System;
using System.Linq;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Plugins.Color.iOS;
using UIKit;

namespace WaiterHelper.iOS.Common
{
    public static class UIViewControllerExtensions
    {
        public static UIViewController GetFirstDescendandOf<T>(this UIViewController parent)
            where T : UIViewController
        {
            return GetFirstDescendandOf(parent, typeof(T));
        }

        public static UIViewController GetFirstDescendandOf(this UIViewController parent, Type descendadType)
        {
            while (parent.ChildViewControllers.Any())
            {
                foreach (var childViewController in parent.ChildViewControllers)
                {
                    if (childViewController.GetType() == descendadType)
                        return childViewController;
                    var result = GetFirstDescendandOf(childViewController, descendadType);
                    if (result != null)
                        return result;
                }
                return null;
            }
            return null;
        }

        public static UIViewController LayoutChildViewControllerInside(this UIViewController parentViewController, UIView viewHolder, UIViewController childViewController)
        {
            parentViewController.AddChildViewController(childViewController);
            childViewController.LoadViewIfNeeded();

            viewHolder.Add(childViewController.View);
            viewHolder.AddConstraints(childViewController.View.AtTopOf(viewHolder),
                                      childViewController.View.AtLeftOf(viewHolder),
                                      childViewController.View.AtRightOf(viewHolder),
                                      childViewController.View.WithSameHeight(viewHolder),
                                      childViewController.View.WithSameWidth(viewHolder));

            childViewController.DidMoveToParentViewController(parentViewController);
            childViewController.View.TranslatesAutoresizingMaskIntoConstraints = false;

            return childViewController;
        }

        public static void LayoutViewInside(this UIView viewHolder, UIView childView)
        {
            viewHolder.Add(childView);
            viewHolder.AddConstraints(childView.AtTopOf(viewHolder),
                                      childView.AtLeftOf(viewHolder),
                                      childView.AtRightOf(viewHolder),
                                      childView.WithSameHeight(viewHolder),
                                      childView.WithSameWidth(viewHolder));
            childView.TranslatesAutoresizingMaskIntoConstraints = false;
        }

        public static void UnloadViewController(this UIViewController childViewController)
        {
            childViewController?.WillMoveToParentViewController(null);
            childViewController?.View.RemoveFromSuperview();
            childViewController?.RemoveFromParentViewController();
            childViewController?.Dispose();
            childViewController = null;
        }

        public static UIViewController GetTopViewController(this UIWindow window)
        {
            var topController = window.RootViewController;

            while (topController.PresentedViewController != null)
            {
                topController = topController.PresentedViewController;
            }

            return topController;
        }

        public static void ShowNavigationBarTitle(this UIViewController viewController, string title)
        {
            if (viewController.NavigationController != null && viewController.NavigationItem != null)
            {
                viewController.NavigationItem.Title = title;
                viewController.NavigationController.NavigationBar.Hidden = false;

                viewController.NavigationController.NavigationBar.BarTintColor = AppTheme.ColorAccent.ToNativeColor();
                viewController.NavigationController.NavigationBar.Translucent = false;
                viewController.NavigationController.NavigationBar.Opaque = true;
                viewController.NavigationController.NavigationBar.TintColor = UIColor.White;
                viewController.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes
                {
                    ForegroundColor = UIColor.White
                };
            }
        }

        public static UIViewController GetTopViewController<T>(UIViewController viewController)
            where T : UIViewController
        {
            if (viewController is UINavigationController navController)
                return GetTopViewController<T>(navController.VisibleViewController);

            if (viewController is UITabBarController tab)
            {
                if (tab.SelectedViewController != null)
                    return GetTopViewController<T>(tab.SelectedViewController);
            }
            if (viewController.PresentedViewController != null)
            {
                return GetTopViewController<T>(viewController.PresentedViewController);
            }

            return viewController;
        }
    }
}