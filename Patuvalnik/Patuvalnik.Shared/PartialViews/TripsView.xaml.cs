 // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Patuvalnik.PartialViews
{
    using Contracts;
    using Models;
    using REST;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TripsView : Page
    {
        private IDataProvider dataProvider;

        public TripsView()
        {
            this.dataProvider = new VrumDataProvider();
            this.InitializeComponent();
        }

        private void ShowDetails(object sender, SelectionChangedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            ListBox lb = sender as ListBox;
            Trip selectedTrip = lb.SelectedItem as Trip;
            rootFrame.Navigate(typeof(TripDetailsPage), selectedTrip.Id);
        }
    }
}