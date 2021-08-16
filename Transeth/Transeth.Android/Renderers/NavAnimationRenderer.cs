using System;
using System.Threading.Tasks;
using Android.Content;
using Transeth.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(NavAnimationRenderer))]
namespace Transeth.Droid
{

    public class NavAnimationRenderer : NavigationPageRenderer
    {
        public NavAnimationRenderer(Context context) : base(context)
        {

        }
        protected override Task<bool> OnPushAsync(Page view, bool animated)
        {
            return base.OnPushAsync(view, false);
        }

        protected override Task<bool> OnPopViewAsync(Page page, bool animated)
        {
            return base.OnPopViewAsync(page, false);
        }

        protected override Task<bool> OnPopToRootAsync(Page page, bool animated)
        {
            return base.OnPopToRootAsync(page, false);
        }
    }
}
