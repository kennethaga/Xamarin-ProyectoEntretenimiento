using AppEntretenimiento.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEntretenimiento.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntretenimientoPage : ContentPage
    {
        //public ObservableCollection<string> Items { get; set; }
        public string TextoBusqueda { get; set; }
        public mEntretenimiento[] Items { get; set; } = new mEntretenimiento[0];

        public List<mEntretenimiento> Resultados { get; set; } = new List<mEntretenimiento>();

        public Command RefreshCommand { get; set; }

        public SQLiteDb Database { get; }

        public EntretenimientoPage()
        {
            Database = DependencyService.Get<SQLiteDb>();
            BindingContext = this;

            RefreshCommand = new Command(() => RefrescarDatos());
            InitializeComponent();

            SearchBarItems.TextChanged += (sender, args) =>
            {

                // LIKE '%Pant%'
                var resultado = Items.Where(entretenimiento => entretenimiento.Tipo.Contains(TextoBusqueda))
                                     .ToList();

                Resultados = resultado;
                ListViewDatos.ItemsSource = Resultados;
            };
        }

        private async void RefrescarDatos()
        {
            var http = new HttpClient();

            IsBusy = true;


            var json = await http.GetStringAsync("https://testapi.io/api/kennethaga/Entretenimiento");

            Items = JsonConvert.DeserializeObject<mEntretenimiento[]>(json);

            await Database.DeleteAllAsync<mEntretenimiento>();

            Resultados = Items.ToList();
            ListViewDatos.ItemsSource = Resultados;

            IsBusy = false;
        }

        protected override async void OnAppearing()
        {
            RefrescarDatos();
        }
    }
}
