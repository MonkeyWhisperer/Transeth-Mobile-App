using Transeth.Helper;
using Transeth.Models;
using Transeth.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Transeth
{    
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public string RootURL = "https://www.transeth.org/";

        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            transethWebView.Source = RootURL;
            transethWebView.Navigating += Webview_Navigating;
            MainStack.Padding = new Thickness(0, 48, 0, 0);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); 
        }
  
        private async void Webview_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (!e.Url.Contains(RootURL))
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    transethWebView.Opacity = 0;
                    transethWebView.Source = RootURL;
                    await Task.Delay(500);
                    transethWebView.Opacity = 1;
                }
                else
                {
                    BackBtn.IsVisible = true;
                    lottie_cv.IsVisible = true;
                    lottie_cv.Frame = 0;
                    await Task.Delay(2640);
                    lottie_cv.IsVisible = false;
                }                
            }                   
        }

        async void ReturnToHomepage(object sender, EventArgs args)
        {
            transethWebView.Opacity = 0;
            lottie_back_cv.Frame = 0;
            lottie_back_cv.IsVisible = true;
            BackBtn.IsVisible = false;
            lottie_cv.IsVisible = true;
            transethWebView.Source = RootURL;

            await Task.Delay(4000);
            lottie_back_cv.IsVisible = false;
            transethWebView.Opacity = 1;
        }
    }
}
