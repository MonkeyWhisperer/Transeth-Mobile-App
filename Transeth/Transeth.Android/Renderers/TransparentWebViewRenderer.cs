using System;
using System.Threading.Tasks;
using Android.Annotation;
using Android.App;
using Android.Content;
using Android.Webkit;
using Transeth.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(Xamarin.Forms.WebView), typeof(TransparentWebViewRenderer))]
namespace Transeth.Droid
{
    [Obsolete]
    public class TransparentWebViewRenderer : WebViewRenderer
    {
        Activity mContext;
        public TransparentWebViewRenderer(Context context) : base(context)
        {
            this.mContext = context as Activity;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            this.Control.Settings.SetSupportMultipleWindows(false);

            Control.Settings.JavaScriptEnabled = true;
            Control.ClearCache(true);
            Control.Settings.MediaPlaybackRequiresUserGesture = false;
            Control.Settings.SetGeolocationEnabled(true);
            Control.SetWebChromeClient(new MyWebClient(mContext));
        }
        public class MyWebClient : WebChromeClient
        {
            Activity mContext;
            public MyWebClient(Activity context)
            {
                this.mContext = context;
            }
            [TargetApi(Value = 21)]
            public override void OnPermissionRequest(PermissionRequest request)
            {
                mContext.RunOnUiThread(() =>
                {
                    request.Grant(request.GetResources());
                });
            }
            public override void OnGeolocationPermissionsShowPrompt(string origin, GeolocationPermissions.ICallback callback)
            {
                callback.Invoke(origin, true, true);
            }
        }
    }
}