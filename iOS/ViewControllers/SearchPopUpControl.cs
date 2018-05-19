using System;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;
using WaiterHelper.iOS.Presentation;
using WaiterHelper.ViewModels;
using WaiterHelper.iOS.Common;

namespace WaiterHelper.iOS.ViewControllers
{
    [MvxModalAutoSizePresentation(ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
    [MvxFromStoryboard("Search")]
    public partial class SearchPopUpControl : MvxViewController<SearchViewModel>
    {
        public SearchPopUpControl(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var bindingSet = this.CreateBindingSet<SearchPopUpControl, SearchViewModel>();
            bindingSet.Bind(this.DrawingImage).For(TouchDrawingImageViewBinding.Name).To(vm => vm.SignatureBytes);
            bindingSet.Bind(SearchButton).To(vm => vm.SearchCommand);
            bindingSet.Bind(ResultTextLabel).To(vm => vm.ResultText);
            bindingSet.Apply();
        }
    }
}