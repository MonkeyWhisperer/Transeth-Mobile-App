using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Transeth.Droid
{
    [Activity(Label = "Transeth", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    [IntentFilter(new[] { "android.intent.action.SEND" }, Categories = new[] { Intent.CategoryDefault }, DataMimeTypes = new[] { "text/plain" })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            LoadApplication(new App());

            if (Intent.ActionSend.Equals(Intent.Action) && Intent.Type != null && "text/plain".Equals(Intent.Type))
            {
                handleSendUrl();
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void handleSendUrl()
        {
            var view = new LinearLayout(this) { Orientation = Orientation.Vertical };

            var url = Intent.GetStringExtra(Intent.ExtraText);
           
            new AlertDialog.Builder(this)
                .SetTitle("Thanks for sharing")                
                .SetMessage(url)
                .SetView(view)
                .SetPositiveButton("DONE", (dialog, whichButton) =>
                {             
                    FinishAndRemoveTask();
                    FinishAffinity();
                })
                //.SetNegativeButton("CANCEL", (dialog, whichButton) =>
                //{
                //    FinishAndRemoveTask();
                //    FinishAffinity();
                //})
                .Show();
        }
    }
}