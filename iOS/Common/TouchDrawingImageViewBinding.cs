using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using WaiterHelper.iOS.Controls;

namespace WaiterHelper.iOS.Common
{
    public class TouchDrawingImageViewBinding : MvxTargetBinding<TouchDrawingImageView, byte[]>
    {
        public const string Name = nameof(TouchDrawingImageViewBinding);

        public TouchDrawingImageViewBinding(TouchDrawingImageView target) : base(target)
        {
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        protected override void SetValue(byte[] value)
        {
            Target?.SetImage(value);
        }

        public override void SubscribeToEvents()
        {
            Target.ImageUpdated += UpdateBinding;
        }

        private void UpdateBinding(object sender, EventArgs e)
        {
            FireValueChanged(Target.ImageAsJpeg);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                Target.ImageUpdated -= UpdateBinding;
            }
            base.Dispose(isDisposing);
        }
    }
}
