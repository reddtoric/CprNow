using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using CprNow.Services;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms;

namespace CprNow.Droid
{
    [Activity(Label = "CPR Now", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private int originalUserVolume;
        private ISoundService soundService;
        private IStopTimerService stopTimerService;

        public static MainActivity Instance { get; private set; }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // FFImageLoading.SVG.Forms
            CachedImageRenderer.Init(true);

            // Auto set volume is set each time timer starts rather than here

            soundService = DependencyService.Get<ISoundService>();
            originalUserVolume = soundService.GetVolume();

            stopTimerService = DependencyService.Get<IStopTimerService>();

            this.Window.SetFlags(Android.Views.WindowManagerFlags.KeepScreenOn, Android.Views.WindowManagerFlags.KeepScreenOn);

            LoadApplication(new App());
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            SetVolumeToOriginalUserVol();
            stopTimerService.StopTimer();
        }

        protected override void OnPause()
        {
            base.OnPause();

            SetVolumeToOriginalUserVol();
            stopTimerService.StopTimer();
        }

        private void SetVolumeToOriginalUserVol()
        {
            soundService.SetVolume(originalUserVolume, false);
        }
    }
}