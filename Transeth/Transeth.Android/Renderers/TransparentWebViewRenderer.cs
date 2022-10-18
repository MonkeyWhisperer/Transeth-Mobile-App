using System;
using System.Threading.Tasks;
using Android.Content;
using Transeth.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(WebView), typeof(TransparentWebViewRenderer))]
namespace Transeth.Droid
{
    [Obsolete]
    public class TransparentWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            // Setting the background as transparent
            this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            this.Control.Settings.SetSupportMultipleWindows(true);

        }
    }
}