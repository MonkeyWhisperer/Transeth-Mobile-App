using System;
using Transeth;
using Transeth.iOS;
using Foundation;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WebView), typeof(MyWebViewRenderer))]
namespace Transeth.iOS
{
    public class MyWebViewRenderer : WkWebViewRenderer, IWKNavigationDelegate
    {



        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {           
            base.OnElementChanged(e);

            this.BackgroundColor = UIKit.UIColor.Clear;
            this.Opaque = false;

            //NavigationDelegate = this;
        }

        //[Export("webView:decidePolicyForNavigationAction:decisionHandler:")]
        //public void DecidePolicy(WKWebView webView, WKNavigationAction navigationAction, Action<WKNavigationActionPolicy> decisionHandler)
        //{
        //    if (navigationAction.TargetFrame == null)
        //    {
        //        webView.LoadRequest(navigationAction.Request);
        //    }
        //    decisionHandler.Invoke(WKNavigationActionPolicy.Allow);
        //}
    }
}