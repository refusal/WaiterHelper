using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Core.ViewModels;

namespace WaiterHelper.iOS.Presentation
{
    public class MvxMasterCustomPresentationAttribute : MvxChildPresentationAttribute
    {
        public Type Host { get; set; }

        public MvxMasterCustomPresentationAttribute() { }

        public MvxMasterCustomPresentationAttribute(Type HostType)
        {
            this.Host = HostType;
        }
    }
}
