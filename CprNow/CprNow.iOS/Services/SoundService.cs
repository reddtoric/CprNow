using System;
using AVFoundation;
using CprNow.Services;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(CprNow.iOS.Services.SoundService))]

namespace CprNow.iOS.Services
{
    public class SoundService : ISoundService
    {
        private readonly AVAudioPlayer beep;

        public SoundService()
        {
            beep = AVAudioPlayer.FromUrl(NSUrl.FromFilename("beep.wav"));
        }

        public void PlayBeep()
        {
            beep.Play();
        }

        public void PlayClick()
        {
            UIDevice.CurrentDevice.PlayInputClick();
        }

        public int GetVolume()
        {
            throw new Exception("not implemented yet");
        }

        public void SetVolume(int volumePercentage, bool playSound)
        {
            throw new Exception("not implemented yet");
        }
    }
}