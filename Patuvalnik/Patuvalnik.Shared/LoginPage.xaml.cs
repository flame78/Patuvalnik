using Patuvalnik.DataProvider;
using Patuvalnik.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Patuvalnik
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public SQLiteDataProvider Sql { get; private set; }

        public LoginPage()
        {
            Sql = new SQLiteDataProvider();
            Sql.InitSql();
            CheckIsLoged();
            this.InitializeComponent();
        }

        private async void CheckIsLoged()
        {
            var data = await Sql.GetData();
            if (data!= null && data.Where(k => k.Key=="Log").FirstOrDefault() != null)
            {
                NavigateToMainPage();
            }
        }

        private async void LogInWithFbButtonClick(object sender, RoutedEventArgs e)
        {
            Sql.AddKeyStringAsync(new KeyString { Key="Log", Str="Access Token" });
            NavigateToMainPage();
        }

        private void NavigateToMainPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
