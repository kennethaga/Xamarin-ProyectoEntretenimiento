using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppEntretenimiento.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HollywoodPage : ContentPage
    {
        private List<Position> _posiciones = new List<Position>() {
            new Position(34.137641, -118.321196),
            new Position(9.933459, -84.077056)
        };

        public HollywoodPage()
        {
            InitializeComponent();

            PickerLugares.Items.Add("Hollywood");
            PickerLugares.Items.Add("Costa Rica");


            PickerLugares.SelectedIndex = 0;

            PickerLugares.SelectedIndexChanged += (s, e) =>
            {

                var posicion = _posiciones[PickerLugares.SelectedIndex];
                var mapSpan = MapSpan.FromCenterAndRadius(posicion, Distance.FromMiles(1));

                Mapa.MoveToRegion(mapSpan);
            };

            ButtonUbicacion.Command = new Command(async () =>
            {
                var location = await Xamarin.Essentials.Geolocation.GetLocationAsync();

                var mapSpan = MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(0.5));

                Mapa.MoveToRegion(mapSpan);
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var posicion = new Position(34.137641, -118.321196);

            Mapa.Pins.Add(new Pin { Label = "Hollywood", Position = posicion });

            var mapSpan = MapSpan.FromCenterAndRadius(posicion, Distance.FromMiles(0.5));

            Mapa.MoveToRegion(mapSpan);
        }
    }

}