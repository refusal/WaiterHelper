using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Support.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace WaiterHelper.iOS.ViewControllers
{
    public class ViewControllerBase<T> : MvxViewController<T>
             where T : class, IMvxViewModel
    {
        public ViewControllerBase() { }

        public ViewControllerBase(IntPtr handle) : base(handle) { }

        public ViewControllerBase(string nibName, NSBundle bundle) : base(nibName, bundle) { }

        private NSObject _keyBoardWillShow;
        private NSObject _keyBoardWillHide;
        private UIView ViewToCenterOnKeyboardShown;
        private UIEdgeInsets previousInsent;

        public virtual bool HandlesKeyboardNotifications => true;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (HandlesKeyboardNotifications)
            {
                RegisterForKeyboardNotifications();
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            if (HandlesKeyboardNotifications)
            {
                UnregisterForKeyboardNotifications();
            }
        }

        protected virtual void RegisterForKeyboardNotifications()
        {
            _keyBoardWillHide = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardNotification);
            _keyBoardWillShow = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardNotification);
        }

        protected virtual void UnregisterForKeyboardNotifications()
        {
            if (!IsViewLoaded)
            {
                return;
            }
            NSNotificationCenter.DefaultCenter.RemoveObserver(_keyBoardWillShow);
            _keyBoardWillShow.Dispose();
            _keyBoardWillShow = null;
            NSNotificationCenter.DefaultCenter.RemoveObserver(_keyBoardWillHide);
            _keyBoardWillHide.Dispose();
            _keyBoardWillHide = null;
        }

        /// <summary>
        /// Gets the UIView that represents the "active" user input control (e.g. textfield, or button under a text field)
        /// </summary>
        /// <returns>
        /// A <see cref="UIView"/>
        /// </returns>
        protected virtual UIView KeyboardGetActiveView() => View.FindFirstResponder();


        private void OnKeyboardNotification(NSNotification notification)
        {
            if (!IsViewLoaded)
                return;

            //Check if the keyboard is becoming visible
            var visible = notification.Name == UIKeyboard.WillShowNotification;

            //Start an animation, using values from the keyboard
            UIView.BeginAnimations("AnimateForKeyboard");
            UIView.SetAnimationBeginsFromCurrentState(true);
            UIView.SetAnimationDuration(UIKeyboard.AnimationDurationFromNotification(notification));
            UIView.SetAnimationCurve((UIViewAnimationCurve)UIKeyboard.AnimationCurveFromNotification(notification));

            //Pass the notification, calculating keyboard height, etc.
            //bool landscape = InterfaceOrientation == UIInterfaceOrientation.LandscapeLeft || InterfaceOrientation == UIInterfaceOrientation.LandscapeRight;
            var keyboardFrame = visible
                ? UIKeyboard.FrameEndFromNotification(notification)
                : UIKeyboard.FrameBeginFromNotification(notification);

            OnKeyboardChanged(visible, keyboardFrame.Height);

            //Commit the animation
            UIView.CommitAnimations();
        }

        /// <summary>
        /// Override this method to apply custom logic when the keyboard is shown/hidden
        /// </summary>
        /// <param name='visible'>
        /// If the keyboard is visible
        /// </param>
        /// <param name='keyboardHeight'>
        /// Calculated height of the keyboard (width not generally needed here)
        /// </param>
        protected virtual void OnKeyboardChanged(bool visible, nfloat keyboardHeight)
        {
            var activeView = ViewToCenterOnKeyboardShown = KeyboardGetActiveView();
            if (activeView == null)
                return;

            var scrollView = activeView.FindSuperviewOfType(View, ScrollType) as UIScrollView;
            if (scrollView == null)
                return;

            if (!visible)
                RestoreScrollPosition(scrollView);
            else
                CenterViewInScroll(activeView, scrollView, keyboardHeight);
        }

        public virtual Type ScrollType { get { return typeof(UIScrollView); } }

        public nint VerticalSpacingFromKeyboard { get; set; } = 10;

        protected virtual void CenterViewInScroll(UIView viewToCenter, UIScrollView scrollView, nfloat keyboardHeight)
        {
            var contentInsets = new UIEdgeInsets(0.0f, 0.0f, keyboardHeight, 0.0f);
            previousInsent = scrollView.ContentInset;
            scrollView.ContentInset = contentInsets;
            scrollView.ScrollIndicatorInsets = contentInsets;

            // Position of the active field relative isnside the scroll view
            // If activeField is hidden by keyboard, scroll it so it's visible
            var viewRectAboveKeyboard = new CGRect(View.Frame.Location, new CGSize(View.Frame.Width, View.Frame.Size.Height - keyboardHeight));

            var activeFieldAbsoluteFrame = ViewToCenterOnKeyboardShown.Superview.ConvertRectToView(ViewToCenterOnKeyboardShown.Frame, View);
            // activeFieldAbsoluteFrame is relative to this.View so does not include any scrollView.ContentOffset

            // Check if the activeField will be partially or entirely covered by the keyboard
            if ((viewRectAboveKeyboard.Height + viewRectAboveKeyboard.Y) < (activeFieldAbsoluteFrame.Y + activeFieldAbsoluteFrame.Height))
            {
                // Scroll to the activeField Y position + activeField.Height + current scrollView.ContentOffset.Y - the keyboard Height
                CGPoint scrollPoint = new CGPoint(0.0f, activeFieldAbsoluteFrame.Location.Y + activeFieldAbsoluteFrame.Height + scrollView.ContentOffset.Y - viewRectAboveKeyboard.Height + VerticalSpacingFromKeyboard);
                scrollView.SetContentOffset(scrollPoint, true);
            }
        }

        protected virtual void RestoreScrollPosition(UIScrollView scrollView)
        {
            scrollView.ContentInset = previousInsent;
            scrollView.ScrollIndicatorInsets = UIEdgeInsets.Zero;
            scrollView.ContentOffset = CGPoint.Empty;
        }

        /// <summary>
        /// Call it to force dismiss keyboard when background is tapped
        /// </summary>
        protected virtual void DismissKeyboardOnBackgroundTap()
        {
            // Add gesture recognizer to hide keyboard
            var tap = new UITapGestureRecognizer { CancelsTouchesInView = false };
            tap.AddTarget(() => View.EndEditing(true));
            View.AddGestureRecognizer(tap);
        }

        public void AddDoneToKeyboard(params UITextField[] textFields)
        {
            var toolbar = new UIToolbar();
            var flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
            doneButton.Clicked += DoneClicked;
            toolbar.SetItems(new[] { flexibleSpace, doneButton }, false);

            foreach (var textField in textFields)
                textField.InputAccessoryView = toolbar;
        }

        protected void DoneClicked(object sender, EventArgs e)
        {
            this.View.EndEditing(true);
        }
    }
}