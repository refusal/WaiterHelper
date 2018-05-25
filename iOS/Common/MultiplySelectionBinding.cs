using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.ExtensionMethods;
using WaiterHelper.iOS.Common;

namespace NikoHealth.iOS.Bindings
{
    public class MultipleSelectionBinding : MvxTargetBinding
    {
        private bool isUpdatingSelection = false;

        private MvxMultipleSelectionCollectionViewSource multipleSelectionCollectionSource;

        public static readonly string Name = nameof(MultipleSelectionBinding);

        public MultipleSelectionBinding(MvxMultipleSelectionCollectionViewSource multipleSelectionSource) : base(multipleSelectionSource)
        {
            this.multipleSelectionCollectionSource = multipleSelectionSource;
            multipleSelectionSource.SelectedItemsUpdated += OnSelectedItemsUpdated;
        }

        private void OnSelectedItemsUpdated(IEnumerable<object> newItems)
        {
            //if (isUpdatingSelection)
            //    return;
            //FireValueChanged(newItems?.ToList());
        }

        public override Type TargetType => typeof(object);

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public override void SetValue(object value)
        {
            var items = value as IEnumerable<object>;
            isUpdatingSelection = true;

            if (multipleSelectionCollectionSource != null)
                this.multipleSelectionCollectionSource.SelectedItems = items;

            isUpdatingSelection = false;
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (multipleSelectionCollectionSource != null)
                    multipleSelectionCollectionSource.SelectedItemsUpdated -= OnSelectedItemsUpdated;
                multipleSelectionCollectionSource = null;
            }
            base.Dispose(isDisposing);
        }
    }
}
