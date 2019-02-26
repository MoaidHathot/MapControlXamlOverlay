using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MapControlXamlOverlay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Random _random = new Random();

        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OnClick_Add(object sender, RoutedEventArgs e)
        {
            var count = int.Parse(ItemCount.Text);

            var brush = new SolidColorBrush(Colors.Red);

            for (var index = 0; index < count; ++index)
            {
                var item = new Border
                {
                    Background = brush,
                    Width = 30,
                    Height = 30
                };

                var longitude = _random.Next(-180, 180);
                var latitude = _random.Next(-90, 90);

                MapControl.SetLocation(item, new Geopoint(new BasicGeoposition { Latitude = latitude, Longitude = longitude }));

                Map.Children.Add(item);
            }
        }

        private void OnClick_Remove(object sender, RoutedEventArgs e)
        {
            Map.Children.Clear();
        }
    }
}
