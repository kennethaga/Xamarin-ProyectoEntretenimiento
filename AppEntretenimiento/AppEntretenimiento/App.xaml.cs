using AppEntretenimiento.Views;
using Xamarin.Forms;

namespace AppEntretenimiento
{
    public partial class App : Application
    {
        public SQLiteDb Database { get; set; }

        public MainPage PantallaPrincipal { get; set; } = new MainPage()
        {
            Title = "Entretenimiento de Peliculas y Series"
        };

        public App()
        {
            InitializeComponent();

            //Database = DependencyService.Get<SQLiteDb>();
            MainPage = new NavigationPage(PantallaPrincipal);
        }

        protected async override void OnStart()
        {
            // Handle when your app starts
            //await Database.IncludeAsync<mEntretenimiento>();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps

        }

        protected override void OnResume()
        {
            // Handle when your app resumes

        }
    }
}
