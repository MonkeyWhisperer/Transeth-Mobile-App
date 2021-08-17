using System;
using Airbnb.Lottie;
using UIKit;

namespace ShareApp.iOS
{
    public partial class SplashViewController : UIViewController
    {
        public SplashViewController() : base() { }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var viewAnimation = LOTAnimationView.AnimationNamed("3738-blockchain-2");
            //var viewAnimation = LOTAnimationView.AnimationNamed("43108-business-team");

            viewAnimation.Frame = new CoreGraphics.CGRect(x: 0, y: 200, width: 400, height: 400);

            //viewAnimation.Frame = cGRect;

            viewAnimation.Center = this.View.Center;
            viewAnimation.ContentMode = UIViewContentMode.ScaleAspectFit;

            View.AddSubview(viewAnimation);

            View.BackgroundColor = UIColor.Black;

            

            //center the animation 
            //viewAnimation.Center = View.Center;            

            viewAnimation.PlayWithCompletion((finished) =>
            {
                UIApplication.SharedApplication.Delegate.FinishedLaunching
                (UIApplication.SharedApplication, new Foundation.NSDictionary());
            });

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}

