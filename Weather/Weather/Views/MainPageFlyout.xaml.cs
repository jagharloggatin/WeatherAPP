using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageFlyout : ContentPage
    {
        public ListView ListView;
        public MainPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MainPageFlyoutViewModel
        {
            public ObservableCollection<MainPageFlyoutMenuItem> MenuItems { get; set; }

            public MainPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainPageFlyoutMenuItem>(new[]
                {
                    new MainPageFlyoutMenuItem { Id = 0, Title = "Author Page", TargetType=typeof(AboutPage)  },
                    //new MainPageFlyoutMenuItem { Id = 1, Title = "Debug Console", TargetType=typeof(ConsolePage) },
                    new MainPageFlyoutMenuItem { Id = 1, Title = "Stockholm", TargetType=typeof(ForecastPage) },
                    new MainPageFlyoutMenuItem { Id = 2, Title = "Lund", TargetType=typeof(ForecastPage) },
                    new MainPageFlyoutMenuItem { Id = 3, Title = "New York", TargetType=typeof(ForecastPage) },
                    new MainPageFlyoutMenuItem { Id = 4, Title = "Düsseldorf", TargetType=typeof(ForecastPage) },
                    new MainPageFlyoutMenuItem { Id = 5, Title = "Frankfurt", TargetType=typeof(ForecastPage) },
                    new MainPageFlyoutMenuItem { Id = 6, Title = "Singapore", TargetType=typeof(ForecastPage) },
                    new MainPageFlyoutMenuItem { Id = 7, Title = "Tokyo", TargetType=typeof(ForecastPage) },
                });
            }
        }
    }
}