using System;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace WaiterHelper.iOS.Presentation
{
    public class MvxModalPresentationAttributeCustomTransition : MvxModalPresentationAttribute
    {
        public double SpaceFromBottom { get; set; } = 0;
        public double SpaceFromTop { get; set; } = 0;

        public double StartWidthPresenter { get; set; } = 0;
        public double StartXPosition { get; set; } = 0;

        public double PresentationWidth { get; set; } = 100;
        public double PresentationXPosition { get; set; } = 0;
    }
}
