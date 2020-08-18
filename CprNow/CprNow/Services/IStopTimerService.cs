using System;

namespace CprNow.Services
{
    public interface IStopTimerService
    {
        void RegisterOnDestroyOrPause(EventHandler onDestroyOrPause);

        void StopTimer();
    }
}