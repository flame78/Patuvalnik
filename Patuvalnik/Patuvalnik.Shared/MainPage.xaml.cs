﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class MainPage : Page
    {
        private Geolocator geolocator;

        public MainPage()
        {
            this.InitializeComponent();
            
            this.geolocator = new Geolocator();
            this.geolocator.PositionChanged += OnGeolocationPositionchanged;
        }

        private void OnGeolocationPositionchanged(Geolocator sender, PositionChangedEventArgs args)
        {            
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var lat = args.Position.Coordinate.Latitude;
                var lon = args.Position.Coordinate.Longitude;
            });
        }
    }
}
