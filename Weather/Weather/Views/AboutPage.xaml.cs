using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Weather.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            aboutBack.Source = $"https://pbs.twimg.com/media/EbJGUk1XsAAtzDp?format=jpg&name=large";
            //weatherSymbol.Source = $"https://www.pngfind.com/pngs/m/273-2733257_icon-weather-portal-comments-weather-icons-png-white.png";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            IntroScreen();
        }

        public async void IntroScreen() 
        {
            first.IsVisible = true;
            first.Opacity = 0;
            second.IsVisible = true;
            second.Opacity = 0;
            third.IsVisible = true;
            third.Opacity = 0;
            fourth.IsVisible = true;
            fourth.Opacity = 0;
            await Task.WhenAll(second.FadeTo(1, 2000));
            await Task.WhenAll(third.FadeTo(1, 2000));
            await Task.WhenAll(fourth.FadeTo(1, 2000));
            await Task.WhenAll(first.FadeTo(1, 2000));
        }
    }
}
