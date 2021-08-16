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
            InitializeComponent();
            //MainStack.Padding = new Thickness(0, 48, 0, 0);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); 
        }
    }
}
