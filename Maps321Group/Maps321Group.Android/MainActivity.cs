using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;

namespace Maps321Group.Droid
{
    [Activity(Label = "Maps321Group", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLoactionID = 0;
        readonly string[] locationPermission =
        {
           Manifest.Permission.AccessCoarseLocation,
           Manifest.Permission.AccessFineLocation
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        protected override void OnStart()
        {
            base.OnStart();
            if ((int) Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessCoarseLocation)!= Permission.Granted)
                {
                    RequestPermissions(locationPermission, RequestLoactionID);
                }
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == RequestLoactionID)
            {
                if ((grantResults.Length )== 1 && (grantResults[0] == (int)Permission.Granted))
                {
                    Console.WriteLine("@@@Succsess");
                }
                else
                {
                    Console.WriteLine("@@@Permission denied");
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
    }
}