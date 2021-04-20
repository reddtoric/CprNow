using Android.App;
using CprNow.Services;

[assembly: Xamarin.Forms.Dependency(typeof(QuitAppService))]

namespace CprNow.Services
{
    public class QuitAppService : IQuitAppService
    {
        public void Quit()
        {
            Activity activity = (Activity)Android.App.Application.Context;
            activity.FinishAndRemoveTask();
            Java.Lang.JavaSystem.Exit(0);
        }
    }
}