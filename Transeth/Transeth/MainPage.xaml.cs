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

namespace Transeth
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    { 
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            transethWebView.Navigating += Webview_Navigating;
            //MainStack.Padding = new Thickness(0, 48, 0, 0);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); 
        }

        public string OriginalURL = "https://www.transeth.org/";
        private async void Webview_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url != OriginalURL)
            {
                BackBtn.IsVisible = true;
                lottie_cv.IsVisible = true;                
                lottie_cv.Frame = 0;
                await Task.Delay(2640);
                lottie_cv.IsVisible = false;
            }            
        }

        async void ReturnToHomepage(object sender, EventArgs args)
        {
            transethWebView.Opacity = 0;
            lottie_back_cv.Frame = 0;
            lottie_back_cv.IsVisible = true;
            BackBtn.IsVisible = false;
            lottie_cv.IsVisible = true;
            transethWebView.Source = "https://www.transeth.org/";

            await Task.Delay(4000);
            lottie_back_cv.IsVisible = false;
            transethWebView.Opacity = 1;

        }

    }
}
