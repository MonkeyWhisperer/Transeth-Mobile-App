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

        protected override async void OnAppearing()
        {
            await CheckAndRequestCameraPermission();

            //var photo = await MediaPicker.CapturePhotoAsync();

            base.OnAppearing();
        }

        public async Task<PermissionStatus> CheckAndRequestCameraPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                await DisplayAlert("Permissions Denied", "Grant Eyez-App permission manually from Settings -> Privacy -> Camera", "OK");

                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.Camera>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.Camera>();

            return status;
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
