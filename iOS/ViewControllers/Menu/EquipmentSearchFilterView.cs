using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using CoreGraphics;
using MvvmCross.Binding.iOS.Views;
using WaiterHelper.ViewModels.Search;
using WaiterHelper.iOS.Presentation;
using WaiterHelper.iOS.Common;

namespace WaiterHelper.iOS.ViewControllers.Menu
{
    [MvxModalPresentationAttributeCustomTransition(Animated = true, StartWidthPresenter = 38, SpaceFromTop = 64, StartXPosition = 100,
                                                   PresentationWidth = 38, SpaceFromBottom = 0, PresentationXPosition = 62)]
    [MvxFromStoryboard("SearchEquipment")]
    public partial class EquipmentSearchFilterView : MvxViewController<EquipmentSearchFilterViewModel>
    {
        private UIPopoverController categoryPopoverController;
        private MvxPickerViewModel categoryPickerViewModel;
        public EquipmentSearchFilterView(IntPtr intPtr) : base(intPtr) { }

        public EquipmentSearchFilterView() : base("EquipmentSearchFilterView", null) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var bindingSet = this.CreateBindingSet<EquipmentSearchFilterView, EquipmentSearchFilterViewModel>();
            InitializeAndBindPopovers(bindingSet);

            bindingSet.Bind(NameTextField).To(vm => vm.EquipmentSearchFilter.Name);
            bindingSet.Bind(CategoryLabel).To(vm => vm.EquipmentSearchFilter.Category);
            bindingSet.Bind(MinPriceTextField).To(vm => vm.EquipmentSearchFilter.MinPrice);
            bindingSet.Bind(MaxPriceTextField).To(vm => vm.EquipmentSearchFilter.MaxPrice);
            bindingSet.Bind(VeganSwitch).To(vm => vm.EquipmentSearchFilter.IsVegetarian);
            bindingSet.Bind(NoSpicySwitch).To(vm => vm.EquipmentSearchFilter.IsNoSpicy);
            bindingSet.Bind(PopUpButton).To(vm => vm.ShowSearchPopUp);

            bindingSet.Bind(ApplyButton).To(vm => vm.ApplyCommand);
            bindingSet.Bind(CloseButton).To(vm => vm.CloseCommand);
            bindingSet.Bind(ResetButton).To(vm => vm.ResetCommand);
            bindingSet.Apply();

            NameTextField.ClearButtonMode = UITextFieldViewMode.Always;

            ApplyButton.AddDefaultBorder(1, 4);
            ResetButton.AddDefaultBorder(1, 4);
            ApplyButton.AddShadow();
            ResetButton.AddShadow();

            View.Layer.BorderColor = UIColor.LightGray.CGColor;
            View.Layer.BorderWidth = 0.5f;

            CategoryViewHolder.AddDefaultBorder(1f, 4f, UIColor.FromRGB(213, 217, 224).CGColor);
        }

        private void InitializeAndBindPopovers(MvxFluentBindingDescriptionSet<EquipmentSearchFilterView, EquipmentSearchFilterViewModel> bindingSet)
        {
            (categoryPopoverController, categoryPickerViewModel) = CreatePopover(CategoryArrowView);

            bindingSet.Bind(categoryPickerViewModel).For(pickerVM => pickerVM.ItemsSource).To(vm => vm.EquipmentSearchFilter.AvailableCategories);
            bindingSet.Bind(categoryPickerViewModel).For(pickerVM => pickerVM.SelectedItem).To(vm => vm.EquipmentSearchFilter.Category);
            CategoryViewHolder.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                categoryPopoverController.PresentFromRect(CategoryViewHolder.Frame, CategoryViewHolder, UIPopoverArrowDirection.Up, true);
                CategoryArrowView.Transform = CGAffineTransform.MakeRotation((nfloat)Math.PI * 2);
            }));
        }


        private (UIPopoverController, MvxPickerViewModel) CreatePopover(UIImageView arrowImageView)
        {
            var viewController = new UIViewController();
            var popoverController = new UIPopoverController(viewController)
            {
                PopoverContentSize = new CGSize(200, 200)
            };
            var groupPickerView = new UIPickerView();
            var groupPickerModel = new MvxPickerViewModel(groupPickerView);
            viewController.View = groupPickerView;
            groupPickerView.Model = groupPickerModel;
            popoverController.DidDismiss += (s, e) =>
            {
                arrowImageView.Transform = CGAffineTransform.MakeRotation((nfloat)Math.PI);
            };
            arrowImageView.Transform = CGAffineTransform.MakeRotation((nfloat)Math.PI);

            return (popoverController, groupPickerModel);
        }
    }
}