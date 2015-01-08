using System;
using System.Drawing;

using Foundation;
using UIKit;
using WebServiceDemo.Service;

namespace WebServiceDemo.iOS
{
    public partial class RootViewController : UIViewController
    {
        public RootViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            MyService service = new MyService();
            MyButton.TouchUpInside +=async (sender, e) =>
            {
                var result = await service.GetData(999);

                UIAlertView c = new UIAlertView();
                c.ExclusiveTouch = true;
                new UIAlertView(string.Empty, result, null, "OK").Show();



            };
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}