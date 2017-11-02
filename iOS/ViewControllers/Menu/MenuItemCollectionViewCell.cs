using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using WaiterHelper.ViewModels;

namespace NikoHealth.iOS.Views.Complete.Equipment.Search
{
    public partial class MenuItemCollectionViewCell : MvxCollectionViewCell
    {
        private const string EquipmentPlaceholderName = "equipment_generic";
        private string resourcePath = "res:" + NSBundle.MainBundle.PathForResource(EquipmentPlaceholderName, "png");
        private readonly MvxImageViewLoader imageLoader;

        public static readonly NSString Key = new NSString(nameof(MenuItemCollectionViewCell));

        public static readonly UINib Nib;

        public MenuItemCollectionViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<MenuItemCollectionViewCell, MenuItemViewModel>();
                bindingSet.Apply();
            });
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

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

        }
    }
}
