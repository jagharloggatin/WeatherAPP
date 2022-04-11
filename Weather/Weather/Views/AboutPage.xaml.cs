using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
            letter1.IsVisible = true;
            letter1.Opacity = 0;
            letter2.IsVisible = true;
            letter2.Opacity = 0;
            letter3.IsVisible = true;
            letter3.Opacity = 0;
            letter4.IsVisible = true;
            letter4.Opacity = 0;
            letter5.IsVisible = true;
            letter5.Opacity = 0;
            letter6.IsVisible = true;
            letter6.Opacity = 0;
            letter7.IsVisible = true;
            letter7.Opacity = 0;
            letter8.IsVisible = true;
            letter8.Opacity = 0;
            letter9.IsVisible = true;
            letter9.Opacity = 0;
            letter10.IsVisible = true;
            letter10.Opacity = 0;
            letter11.IsVisible = true;
            letter11.Opacity = 0;
            letter12.IsVisible = true;
            letter12.Opacity = 0;
            letter13.IsVisible = true;
            letter13.Opacity = 0;
            letter14.IsVisible = true;
            letter14.Opacity = 0;
            letter15.IsVisible = true;
            letter15.Opacity = 0;
            letter16.IsVisible = true;
            letter16.Opacity = 0;
            letter17.IsVisible = true;
            letter17.Opacity = 0;
            letter18.IsVisible = true;
            letter18.Opacity = 0;
            letter19.IsVisible = true;
            letter19.Opacity = 0;
            printName.IsVisible = true;
            printName.Opacity = 0;

            await Task.WhenAll(letter1.FadeTo(1, 1000));
            await Task.WhenAll(letter2.FadeTo(1, 200));
            await Task.WhenAll(letter3.FadeTo(1, 200));
            await Task.WhenAll(letter4.FadeTo(1, 200));
            await Task.WhenAll(letter5.FadeTo(1, 200));
            await Task.WhenAll(letter6.FadeTo(1, 200));
            await Task.WhenAll(letter7.FadeTo(1, 200));
            await Task.WhenAll(letter8.FadeTo(1, 200));
            await Task.WhenAll(letter9.FadeTo(1, 200));
            await Task.WhenAll(letter10.FadeTo(1, 200));
            await Task.WhenAll(letter11.FadeTo(1, 200));
            await Task.WhenAll(letter12.FadeTo(1, 200));
            await Task.WhenAll(letter13.FadeTo(1, 200));
            await Task.WhenAll(letter14.FadeTo(1, 200));
            await Task.WhenAll(letter15.FadeTo(1, 200));
            await Task.WhenAll(letter16.FadeTo(1, 200));
            await Task.WhenAll(letter17.FadeTo(1, 200));
            await Task.WhenAll(letter18.FadeTo(1, 200));
            await Task.WhenAll(letter19.FadeTo(1, 200));
            await Task.WhenAll(printName.FadeTo(1, 3000));
        }
    }
}
