using CoreGraphics;
using UIKit;

namespace WaiterHelper.iOS.Presentation
{
    public class TransitioningDelegateAtLocation : UIViewControllerTransitioningDelegate
    {
        private CGRect startFrame;
        private CGRect presentationFrame;

        private ModalPresentationController presentationController;

        private AnimatedTransitioningAtLocation animationTransitioning;
        public AnimatedTransitioningAtLocation AnimationTransitioning
        {
            get
            {
                if (animationTransitioning == null)
                {
                    animationTransitioning = new AnimatedTransitioningAtLocation(this.startFrame);
                }
                return animationTransitioning;
            }
        }

        public TransitioningDelegateAtLocation(CGRect startFrame, CGRect presentationFrame)
        {
            this.startFrame = startFrame;
            this.presentationFrame = presentationFrame;
        }

        public override UIPresentationController GetPresentationControllerForPresentedViewController(UIViewController presentedViewController, UIViewController presentingViewController, UIViewController sourceViewController)
        {
            if (this.presentationController == null)
            {
                this.presentationController = new ModalPresentationController(presentedViewController, presentationFrame);
            }
            return this.presentationController;
        }

        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForDismissedController(UIViewController dismissed)
        {
            var transitioning = this.AnimationTransitioning;
            transitioning.IsPresentation = false;
            return transitioning;
        }

        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForPresentedController(UIViewController presented, UIViewController presenting, UIViewController source)
        {
            var transitioning = this.AnimationTransitioning;
            transitioning.IsPresentation = true;
            return transitioning;
        }
    }
}
