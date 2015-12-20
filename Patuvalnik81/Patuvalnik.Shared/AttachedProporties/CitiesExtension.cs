using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace Patuvalnik.AttachedProporties
{
  public class CitiesExtension

    {
        public static int GetCityFrom(DependencyObject obj)
        {
            return (int)obj.GetValue(GetCityFromProperty);
        }

        public static void SetCityFrom(DependencyObject obj, int value)
        {
            obj.SetValue(GetCityFromProperty, value);
        }

        // Using a DependencyProperty as the backing store for Bottom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GetCityFromProperty =
            DependencyProperty.RegisterAttached("CityFrom",
            typeof(double),
            typeof(object),
            new PropertyMetadata(1.0, OnCityFromChange));

      private static void OnCityFromChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
      }

      public static int GetCityTo(DependencyObject obj)
        {
            return (int)obj.GetValue(GetCityToProperty);
        }

        public static void SetCityTo(DependencyObject obj, int value)
        {
            obj.SetValue(GetCityToProperty, value);
        }

        // Using a DependencyProperty as the backing store for Bottom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GetCityToProperty =
            DependencyProperty.RegisterAttached("CityTo",
            typeof(double),
            typeof(object),
            new PropertyMetadata(1.0, OnCityToChange));

        private static void OnCityToChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
         
        }
        
    }
}
