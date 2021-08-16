using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Newtonsoft.Json;
using Transeth.Helper;
using UIKit;

namespace Transeth.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            var defs = new NSUserDefaults("group.com.Transeth.ios", NSUserDefaultsType.SuiteName);
            var value = defs.ValueForKey(new NSString("FilePathList"));

            Datas.SharedItems = new List<string>();
            Datas.SharedItems = (List<string>)JsonConvert.DeserializeObject(value.ToString(), typeof(List<string>));
            return true;
        }

        public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
        {
            return base.ContinueUserActivity(application, userActivity, completionHandler);
        }
    }
}
