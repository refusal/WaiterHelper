using System;
using UIKit;
using CoreGraphics;

namespace WaiterHelper.iOS.Presentation
{
    public class TransitioningDelegateAtCenter : UIViewControllerTransitioningDelegate
    {
        private ModalPresentationController presentationController;

        public override UIPresentationController GetPresentationControllerForPresentedViewController(UIViewController presentedViewController, UIViewController presentingViewController, UIViewController sourceViewController)
        {
            if (this.presentationController == null)
            {
                presentationController = new ModalPresentationController(presentedViewController, new CoreGraphics.CGRect(new CGPoint(UIScreen.MainScreen.Bounds.Width / 2 - presentedViewController.PreferredContentSize.Width / 2,
                                                                                                                                      UIScreen.MainScreen.Bounds.Height / 2 - presentedViewController.PreferredContentSize.Height / 2),
                                                                                                                          presentedViewController.PreferredContentSize));
                presentationController.BackgroundColor = UIColor.FromRGB(173, 181, 189);
            }
            return this.presentationController;
        }
    }
}
