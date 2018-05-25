using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Plugins.Color.iOS;
using UIKit;
using WaiterHelper.ViewModels;

namespace WaiterHelper.iOS.ViewControllers.Menu
{
    public partial class SearchEquipmentPadCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString(nameof(SearchEquipmentPadCollectionViewCell));

        public static readonly UINib Nib;

        public SearchEquipmentPadCollectionViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<SearchEquipmentPadCollectionViewCell, MenuItemViewModel>();
                bindingSet.Apply();
            });
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            MainView.Layer.CornerRadius = 4f;
            MainView.Layer.BorderColor = UIColor.LightGray.CGColor;
            MainView.Layer.BorderWidth = 1.5f;
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
