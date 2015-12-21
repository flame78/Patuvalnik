namespace Patuvalnik
{
    using Models;
    using System.Collections.Generic;
    using ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using SQLite;
    using Windows.Storage;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Patuvalnik.Models;
    using DataProvider;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public SQLiteDataProvider Sql { get; private set; }

        
        public MainPage()
        {
            Sql = new SQLiteDataProvider();
            Sql.InitSql();
            this.InitializeComponent();
        }
        
        private void FeedButtonClick(object sender, RoutedEventArgs e)
        {
            this.FeedDropDown.IsOpen = true;
        }

        private void UseCurrentLocation(object sender, RoutedEventArgs e)
        {
            this.FeedDropDown.IsOpen = false;
        }

        private void RateDriver(object sender, RoutedEventArgs e)
        {
            this.FeedDropDown.IsOpen = false;
        }

        private void ChangeCitiesButtonClick(object sender, RoutedEventArgs e)
        {
            this.ChangeCitiesDropDown.IsOpen = true;
        }

        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            this.OptionsDropDown.IsOpen = true;
        }

        private void HideChangeCiries(object sender, RoutedEventArgs e)
        {
            this.ChangeCitiesDropDown.IsOpen = false;
        }

        private async void LogOutClick(object sender, RoutedEventArgs e)
        {
            var data = await Sql.GetData();
            var ks = data.Where(k => k.Key == "Log").FirstOrDefault();
            if (ks != null)
            {
                await Sql.RemoveKeyStringAsync(ks);
            }

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(LoginPage));
        }
    }
}
