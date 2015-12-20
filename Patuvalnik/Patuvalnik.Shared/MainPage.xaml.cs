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

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string dbName = "Trips.db";

        public List<Trip> trips { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            bool dbExists = await CheckDbAsync(dbName);
            if (!dbExists)
            {
                await CreateDatabaseAsync();
                await AddTripsAsync();
            }

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            var query = conn.Table<Trip>();
            trips = await query.ToListAsync();
        }

        #region SQLite utils
        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.CreateTableAsync<Trip>();
        }

        private async Task AddTripsAsync()
        {
            var list = new List<Trip>()
            {
                new Trip()
                {
                }
            };

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.InsertAllAsync(list);
        }

        private async Task DeleteTripsAsync(Trip trip)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            if (trip != null)
            {
                await conn.DeleteAsync(trip);
            }
        }

        private async Task DropTableAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.DropTableAsync<Trip>();
        }

        #endregion SQLite utils

        private void FeedButtonClick(object sender, RoutedEventArgs e)
        {
            this.FeedDropDown.IsOpen = true;
        }

        private void UseCurrentLocation(object sender, RoutedEventArgs e)
        {
            this.FeedDropDown.IsOpen = false;
            var mpvm = this.DataContext as MainPageViewModel;
            mpvm.FromCity = mpvm.Cities[0];
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
    }
}
