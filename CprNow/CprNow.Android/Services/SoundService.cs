using Android.Media;
using Android.Views;
using CprNow.Droid;
using CprNow.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SoundService))]

namespace CprNow.Services
{
    public class SoundService : ISoundService
    {
        private readonly AudioManager audioManager;
        private MediaPlayer mediaPlayer;

        public SoundService()
        {
            audioManager = (AudioManager)MainActivity.Instance.GetSystemService(Android.Content.Context.AudioService);
        }

        public int GetVolume()
        {
            return audioManager.GetStreamVolume(Stream.Music);
        }

        public void PlayBeep()
        {
            mediaPlayer.Start();
        }

        public void PlayClick()
        {
            var activity = MainActivity.Instance;

            var view = activity.FindViewById<View>(Android.Resource.Id.Content);

            view.PlaySoundEffect(SoundEffects.Click);
        }

        public void SetVolume(int volumePercentage, bool playSound)
        {
            int vol = audioManager.GetStreamMaxVolume(Stream.Music) * volumePercentage / 100;

            audioManager.SetStreamVolume(Stream.Music,
                vol,
                VolumeNotificationFlags.PlaySound);

            if (playSound)
            {
                PlayBeep();
            }
        }

        public void StartSoundService()
        {
            mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.beep_short);
        }

        public void StopSoundService()
        {
            mediaPlayer.Release();
        }
    }
}