using System;
using CoreGraphics;
using UIKit;
namespace WaiterHelper.iOS.Common
{
    public static class UIViewExtensions
    {
        public static void AddCircleMask(this UIView view)
        {
            view.Layer.CornerRadius = view.Frame.Width / 2;
            view.Layer.MasksToBounds = true;
        }

        public static void AddDefaultBorder(this UIView view, double borderWidth = 1f, double cornerRadius = 2f, CGColor borderColor = null)
        {
            borderColor = borderColor ?? UIColor.FromRGB(173, 181, 189).CGColor;
            view.Layer.BorderWidth = new nfloat(borderWidth);
            view.Layer.CornerRadius = new nfloat(cornerRadius);
            view.Layer.BorderColor = borderColor;
        }

        public static void AddShadow(this UIView view, float height = 0.0f, float width = 0.5f)
        {
            var shadowPath = UIBezierPath.FromRect(view.Bounds);
            SetShadow(view, shadowPath, height, width);
        }

        public static void AddShadowWithOffset(this UIView view, int viewOffset = 30, float height = 0.0f, float width = 0.5f)
        {
            var shadowPath = UIBezierPath.FromRect(SetCorrectViewBounds(view, viewOffset));
            SetShadow(view, shadowPath, height, width);
        }

        private static void SetShadow(UIView view, UIBezierPath shadowPath, float height, float width)
        {
            view.Layer.MasksToBounds = false;

            view.Layer.ShadowColor = UIColor.LightGray.CGColor;
            view.Layer.ShadowOpacity = 0.8f;
            view.Layer.ShadowRadius = 3.0f;
            view.Layer.ShadowOffset = new CGSize(2, 2);
        }

        private static CGRect SetCorrectViewBounds(UIView view, int viewOffset)
        {
            var width = UIScreen.MainScreen.Bounds.Width - viewOffset;
            view.Bounds = new CoreGraphics.CGRect(view.Bounds.X, view.Bounds.Y, width, view.Bounds.Height);
            return view.Bounds;
        }

        public static void SizeHeaderToFit(this UITableView tableViewWithHeader)
        {
            var headerView = tableViewWithHeader.TableHeaderView;

            headerView.SetNeedsLayout();
            headerView.LayoutIfNeeded();

            var height = headerView.SystemLayoutSizeFittingSize(UIView.UILayoutFittingCompressedSize).Height;
            var frame = headerView.Frame;
            var frameSize = headerView.Frame.Size;
            frameSize.Height = height;

            headerView.Frame = new CoreGraphics.CGRect(frame.Location, frameSize);
            tableViewWithHeader.TableHeaderView = headerView;
        }
    }
}