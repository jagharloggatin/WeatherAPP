using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Weather.Models;
using Weather.Services;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ForecastPage : ContentPage
    {
        OpenWeatherService service;
        GroupedForecast groupedforecast;

        public ForecastPage()
        {
            InitializeComponent();
            
            service = new OpenWeatherService();
            groupedforecast = new GroupedForecast();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Code here will run right before the screen appears
            //You want to set the Title or set the City
            //This is making the first load of data

            MainThread.BeginInvokeOnMainThread(async () => {await LoadForecast();});
        }
        private async Task LoadForecast()
        {
            //Heare you load the forecast

            await Task.Run(() =>
            {
                Task<Forecast> t1 = service.GetForecastAsync(Title);
                Device.BeginInvokeOnMainThread(() =>
                {
                    t1.Result.Items.ForEach(x => x.Icon = $"http://openweathermap.org/img/wn/{x.Icon}@2x.png");

                    groupedList.ItemsSource = t1.Result.Items;
                    ImageIcon.Source = t1.Result.Items[0].Icon;
                    currentTemp.Text = $"{t1.Result.Items[0].Temperature:F0}°C";
                    currentWind.Text = $"{t1.Result.Items[0].WindSpeed:F0} m/s";
                    currentDesc.Text = $"{t1.Result.Items[0].Description}";
                    currentTitle.Text = $"Current weather data for {Title}";
                    backgroundPic.Source = $"https://i.pinimg.com/originals/20/ae/f2/20aef23d39a8dcb74bf663ed89ab08d6.gif";
                    currentDateTime.Text = $"{t1.Result.Items[0].DateTime.ToString("yyyy - MMMM - d")} \n{DateTime.Now.ToString("HH:mm")}";
                });
            });
        }

        private async void RefreshButton(object sender, EventArgs e)
        {
            refreshLoad.IsRunning = true;
            await Task.Delay(4000);
            await LoadForecast();
            refreshLoad.IsRunning = false;
        }
    }
}

