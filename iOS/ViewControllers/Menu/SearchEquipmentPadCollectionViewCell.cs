using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Plugins.Color.iOS;
using UIKit;
using WaiterHelper.ViewModels;
using WaiterHelper.ViewModels.Search;
using WaiterHelper.Converters;
using WaiterHelper.Converter;

namespace WaiterHelper.iOS.ViewControllers.Menu
{
    public partial class SearchEquipmentPadCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString(nameof(SearchEquipmentPadCollectionViewCell));
        private readonly MvxImageViewLoader imageLoader;
        private const string PlaceholderName = "dish_placeholder";

        private string resourcePath = "res:" + NSBundle.MainBundle.PathForResource(PlaceholderName, "png");

        public static readonly UINib Nib;

        public SearchEquipmentPadCollectionViewCell(IntPtr handle) : base(handle)
        {
            //imageLoader = new MvxImageViewLoader(() => this.DeviceImageView)
            //{
            //    DefaultImagePath = resourcePath,
            //    ErrorImagePath = resourcePath
            //};

            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<SearchEquipmentPadCollectionViewCell, SearchEquipmentItemViewModel>();
                bindingSet.Bind(TitleLabel).To(vm => vm.Meal.Name);
                bindingSet.Bind(PriceLabel).To(vm => vm.Meal.Price);
                bindingSet.Bind(WeightLabel).To(vm => vm.Meal.Weight);
                bindingSet.Bind(imageLoader).To(vm => vm.Meal.ImagePath);
                bindingSet.Bind(CategoryLabel).To(vm => vm.Meal.MealType).WithConversion<IntToCategoryConverter>();
                bindingSet.Bind(SpicyTagView).For(v => v.Hidden).To(vm => vm.Meal.IsSpicy).WithConversion<BoolInversionConverter>();
                bindingSet.Bind(VeganTagView).For(v => v.Hidden).To(vm => vm.Meal.IsVegetarian).WithConversion<BoolInversionConverter>();
                bindingSet.Apply();
            });
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            MainView.Layer.CornerRadius = 4f;
            MainView.Layer.BorderColor = UIColor.LightGray.CGColor;
            MainView.Layer.BorderWidth = 1.5f;

            SpicyTagView.Layer.CornerRadius = 2f;
            VeganTagView.Layer.CornerRadius = 2f;
        }

        public override bool Selected
        {
            get => base.Selected;
            set
            {
                base.Selected = value;
                SetSelected(value);
            }
        }

        private void SetSelected(bool selected)
        {
            MainView.Layer.BorderColor = selected ? AppTheme.ColorAccent.ToNativeColor().CGColor : UIColor.LightGray.CGColor;
            MainView.Layer.BorderWidth = selected ? 3f : 1.5f;
        }
    }
}
