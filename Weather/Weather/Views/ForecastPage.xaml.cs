using System;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models;
using Weather.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            //await DisplayAlert?

            MainThread.BeginInvokeOnMainThread(async () => { await LoadForecast(); });
        }
        private async Task LoadForecast()
        {
            //Here you load the forecast

            await Task.Run( () =>
            {
                Task<Forecast> t1 = service.GetForecastAsync(Title);
                Device.BeginInvokeOnMainThread( () =>
                {
                    //groupedList.ItemsSource = t1.Result.Items;
                    groupedforecast.Items = t1.Result.Items.GroupBy(x => x.DateTime.Date);
                    groupedList.ItemsSource = groupedforecast.Items;

                    ImageIcon.Source = t1.Result.Items[0].Icon;
                    currentTemp.Text = $"{t1.Result.Items[0].Temperature:F0}°C";
                    currentWind.Text = $"{t1.Result.Items[0].WindSpeed:F0} m/s";
                    currentDesc.Text = $"{t1.Result.Items[0].Description}";
                    currentTitle.Text = $"Current weather data for {Title}";
                    currentDateTime.Text = $"{t1.Result.Items[0].DateTime.ToString("yyyy - MMMM - d")} \n{DateTime.Now.ToString("HH:mm")}";
                    backgroundPic.Source = $"{Title}.png";
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

