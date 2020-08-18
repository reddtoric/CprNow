using System;
using CprNow.Services;

[assembly: Xamarin.Forms.Dependency(typeof(StopTimerService))]

namespace CprNow.Services
{
    public class StopTimerService : IStopTimerService
    {
        private EventHandler OnDestroyOrPause;

        public void RegisterOnDestroyOrPause(EventHandler onDestroyOrPause)
        {
            OnDestroyOrPause += onDestroyOrPause;
        }

        public void StopTimer()
        {
            OnDestroyOrPause?.Invoke(null, null);
        }
    }
}