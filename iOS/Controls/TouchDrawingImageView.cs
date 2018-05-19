using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using System.Linq;
using CoreImage;

namespace WaiterHelper.iOS.Controls
{
    [Register(nameof(TouchDrawingImageView))]
    public class TouchDrawingImageView : UIImageView
    {
        private CGPoint previousTouchLocation;

        public byte[] ImageAsJpeg { get; set; }

        public TouchDrawingImageView() => InitView();
        public TouchDrawingImageView(IntPtr handle) : base(handle) => InitView();
        public TouchDrawingImageView(NSCoder coder) : base(coder) => InitView();

        [DesignatedInitializer]
        public TouchDrawingImageView(CGRect frame) : base(frame) => InitView();

        private void InitView()
        {
            this.ContentMode = UIViewContentMode.ScaleAspectFit;
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            if (!DrawingEnabled)
                return;
            UITouch firstTouch = ((UITouch)touches.FirstOrDefault());
            var coalescedTouches = evt.GetCoalescedTouches(firstTouch);

            if (coalescedTouches == null)
                return;

            UIGraphics.BeginImageContext(this.Frame.Size);
            var cgContext = UIGraphics.GetCurrentContext();
            this.Image?.DrawAsPatternInRect(new CGRect(0, 0, this.Frame.Width, this.Frame.Height));
            cgContext.SetLineCap(CGLineCap.Round);

            foreach (var touch in coalescedTouches)
            {
                nfloat lineWidth = touch.Force != 0 ? (touch.Force / touch.MaximumPossibleForce) * 10 : 5;
                UIColor lineColor = UIColor.Black;
                cgContext.SetLineWidth(lineWidth);
                cgContext.SetStrokeColor(lineColor.CGColor);
                cgContext.MoveTo(previousTouchLocation.X, previousTouchLocation.Y);
                cgContext.AddLineToPoint(touch.LocationInView(this).X, touch.LocationInView(this).Y);
                cgContext.StrokePath();
                previousTouchLocation = touch.LocationInView(this);
            }

            this.Image = UIGraphics.GetImageFromCurrentImageContext(); ;
            UIGraphics.EndImageContext();
        }

        internal void SetImage(byte[] value)
        {
            value = value ?? new byte[0];
            var data = NSData.FromArray(value);

            this.ImageAsJpeg = this.Image?.AsJPEG().ToArray();
            this.Image = data.Length != 0 ? new UIImage(data) : new UIImage();
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            if (!DrawingEnabled)
                return;
            previousTouchLocation = ((UITouch)touches.FirstOrDefault()).LocationInView(this);
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            if (!DrawingEnabled)
                return;
            previousTouchLocation = default(CGPoint);
            ImageAsJpeg = this.Image?.AsJPEG().ToArray();
            ImageUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void ClearImage()
        {
            this.Image = null;
        }

        public event EventHandler ImageUpdated;

        public bool DrawingEnabled { get; set; } = true;
    }

}
