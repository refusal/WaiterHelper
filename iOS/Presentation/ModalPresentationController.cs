using CoreGraphics;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using UIKit;

namespace WaiterHelper.iOS.Presentation
{
    public class ModalPresentationController : UIPresentationController
    {
        private UIView dismissView;

        public UIColor BackgroundColor
        {
            set
            {
                this.dismissView.BackgroundColor = value;
                this.dismissView.Alpha = 0.4f;
            }
        }

        private IMvxViewDispatcher viewDispatcher = Mvx.Resolve<IMvxViewDispatcher>();

        private CGRect presentationFrame;
        public ModalPresentationController(UIViewController presentingViewController, CGRect presentationFrame)
            : base(presentingViewController, null)
        {
            this.presentationFrame = presentationFrame;
            SetUpDimmingView();
        }

        public override CoreGraphics.CGRect FrameOfPresentedViewInContainerView
        {
            get
            {
                return presentationFrame;
            }
        }

        public override void PresentationTransitionWillBegin()
        {
            this.dismissView.Frame = this.ContainerView.Bounds;
            this.ContainerView.InsertSubview(this.dismissView, 0);
        }

        private void SetUpDimmingView()
        {
            this.dismissView = new UIView();
            var dimmingViewTapGestureRecogniser = new UITapGestureRecognizer(this.DimmingViewTapped);
            this.dismissView.AddGestureRecognizer(dimmingViewTapGestureRecogniser);
        }

        private void DimmingViewTapped(UIGestureRecognizer gesture)
        {
            if (gesture.State == UIGestureRecognizerState.Recognized)
            {
                var mvxViewController = this.PresentedViewController as MvxViewController;
                if (mvxViewController != null && mvxViewController.ViewModel != null)
                {
                    viewDispatcher.ChangePresentation(new MvxClosePresentationHint(mvxViewController.ViewModel));
                }
                else
                {
                    PresentedViewController.DismissViewController(true, null);
                }
            }
        }
    }
}
