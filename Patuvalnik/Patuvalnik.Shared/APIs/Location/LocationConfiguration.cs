using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace Patuvalnik.APIs.Location
{
    public partial class MainPage : Page
    {
        public const string FEATURE_NAME = "Geolocation";

        List<Scenario> scenarios = new List<Scenario>
        {
            new Scenario() { Title = "Track position", ClassType = typeof(Patuvalnik.APIs.Location.Scenario1) },
            new Scenario() { Title = "Get position", ClassType = typeof(Patuvalnik.APIs.Location.Scenario2) },
        };
    }

    public class Scenario
    {
        public string Title { get; set; }

        public Type ClassType { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}