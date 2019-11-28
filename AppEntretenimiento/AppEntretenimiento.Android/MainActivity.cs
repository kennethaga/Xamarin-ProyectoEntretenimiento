
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace AppEntretenimiento.Droid
{
    [Activity(Label = "AppEntretenimiento", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Xamarin.Forms.DependencyService.Register<SQLiteAndroid>();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class SQLiteAndroid : SQLiteDb
    {
        public SQLiteAndroid()
            : base(
                 System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/Entretenimiento.db3"
                  )
        {
        }
    }
}