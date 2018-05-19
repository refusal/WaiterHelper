using MvvmCross.iOS.Views.Presenters.Attributes;
using System;

namespace WaiterHelper.iOS.Presentation
{
    public class MvxDetailCustomPresentationAttribute : MvxChildPresentationAttribute
    {
        public Type Host { get; set; }

        public MvxDetailCustomPresentationAttribute() { }

        public MvxDetailCustomPresentationAttribute(Type HostType)
        {
            this.Host = HostType;
        }
    }
}
