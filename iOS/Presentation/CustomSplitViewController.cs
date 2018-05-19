using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;
using System.Threading;
using System.Threading.Tasks;
using System;
using WaiterHelper.iOS.Common;

namespace WaiterHelper.iOS.Presentation
{
    public partial class CustomSplitViewController : MvxViewController
    {
        private CancellationTokenSource cancellationTokenSource;
        private bool didLayoutSubviews = false;
        private readonly TimeSpan delayTimeDetailSwitchTime = TimeSpan.FromMilliseconds(200);

        protected UIViewController DetailViewController { get; set; }
        protected UIViewController MasterViewController { get; set; }
        public CustomSplitViewController() : base("CustomSplitViewController", null)
        {
        }

        public string EmptyText
        {
            get
            {
                return EmptyTextLabel.Text;
            }
            set
            {
                EmptyTextLabel.Text = value;
            }
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (didLayoutSubviews)
                return;

            var masterWidthRatio = 0.30f;
            MasterWidthConstraint.Constant = View.Frame.Width * masterWidthRatio;
            didLayoutSubviews = true;
        }

        public virtual async void ShowDetailViewController(UIViewController vc, MvxViewModelRequest viewModelRequest)
        {
            LoadViewIfNeeded();

            cancellationTokenSource?.Cancel(true);
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await Task.Delay(delayTimeDetailSwitchTime, cancellationTokenSource.Token);
            }
            catch (Exception)
            {
                return;
            }

            if (DetailViewController != null)
                DetailViewController?.UnloadViewController();

            DetailViewController = this.LayoutChildViewControllerInside(DetailView, vc);
        }

        public virtual void ShowMasterViewController(UIViewController vc)
        {
            LoadViewIfNeeded();
            MasterViewController = this.LayoutChildViewControllerInside(MasterView, vc);
        }
    }
}