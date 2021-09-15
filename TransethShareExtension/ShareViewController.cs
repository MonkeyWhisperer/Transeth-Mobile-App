using System;
using System.IO;
using CoreFoundation;
using Foundation;
using MobileCoreServices;
using Social;
using UIKit;

namespace TransethShareExtension
{
    public partial class ShareViewController : SLComposeServiceViewController
    {
        protected ShareViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override bool IsContentValid()
        {
            return true;
        }

        public override void DidSelectPost()
        {
            var description = "";
            var url = "";

            foreach (var extensionItem in ExtensionContext.InputItems)
            {
                if (extensionItem.Attachments != null)
                {
                    foreach (var attachment in extensionItem.Attachments)
                    {
                        if (attachment.HasItemConformingTo(UTType.URL))
                        {
                            attachment.LoadItem(UTType.URL, null, (data, error) =>
                            {
                                var nsUrl = data as NSUrl;
                                url = nsUrl.AbsoluteString;
                            });                           
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(extensionItem.AttributedContentText.Value))
                {
                    description = extensionItem.AttributedContentText.Value;
                }
            }

            DispatchQueue.MainQueue.DispatchAfter(new DispatchTime(DispatchTime.Now, 3000000), () =>
            {                
                var alert = UIAlertController.Create("Thanks for sharing\n\n" + description + "\n", url, UIAlertControllerStyle.Alert);
                PresentViewController(alert, true, () =>
                {
                    DispatchQueue.MainQueue.DispatchAfter(new DispatchTime(DispatchTime.Now, 3000000000), () =>
                    {
                        ExtensionContext.CompleteRequest(new NSExtensionItem[0], null);
                    });
                });
            });
        }

        public override SLComposeSheetConfigurationItem[] GetConfigurationItems()
        {
            return new SLComposeSheetConfigurationItem[0];
        }
    }
}
