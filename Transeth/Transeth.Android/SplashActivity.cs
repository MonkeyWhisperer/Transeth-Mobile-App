using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using AndroidX.AppCompat.App;

namespace Transeth.Droid
{
    [Activity(Label = "Transeth", Icon = "@mipmap/ic_launcher", Theme = "@style/MyTheme.Splash", Immersive = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}