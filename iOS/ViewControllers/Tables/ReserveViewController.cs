using System;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;
using WaiterHelper.iOS.Presentation;
using WaiterHelper.ViewModels;
using WaiterHelper.iOS.Common;

namespace WaiterHelper.iOS.ViewControllers.Tables
{
    [MvxModalAutoSizePresentation(ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
    [MvxFromStoryboard("Tables")]
    public partial class ReserveViewController : MvxViewController<ReserveViewModel>
    {
        public ReserveViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var bindingSet = this.CreateBindingSet<ReserveViewController, ReserveViewModel>();
            bindingSet.Bind(CancelButton).To(vm => vm.CloseCommand);
            bindingSet.Bind(CloseButton).To(vm => vm.CloseCommand);
            bindingSet.Apply();
        }
    }
}