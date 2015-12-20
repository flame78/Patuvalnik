namespace Patuvalnik
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
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
    }
}
