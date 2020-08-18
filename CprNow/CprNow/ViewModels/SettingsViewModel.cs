using System;
using System.Collections.Generic;
using System.Linq;
using CprNow.Services;
using Xamarin.Forms;

namespace CprNow.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly PreferenceSettings preferenceSettings;
        private readonly ISoundService soundService;

        public SettingsViewModel()
        {
            preferenceSettings = PreferenceSettings.Instance;
            soundService = DependencyService.Get<ISoundService>();

            Title = "Settings";

            preferenceSettings.OnCpmChanged += (object sender, EventArgs e) => OnPropertyChanged("Cpm");
            preferenceSettings.OnVolumeChanged += (object sender, EventArgs e) => OnPropertyChanged("AutoSetVolume");
            preferenceSettings.OnStartEndHistoryChanged += (object sender, EventArgs e) => OnPropertyChanged("StartEndHistory");
        }

        public int AutoSetVolume
        {
            get => preferenceSettings.GetAutoSetVolume();
            set
            {
                int val = (int)Math.Round(value / 5.0) * 5;

                if (val == AutoSetVolume)
                {
                    soundService.SetVolume(AutoSetVolume, false);
                }
                else
                {
                    soundService.SetVolume(AutoSetVolume, true);
                }

                preferenceSettings.SetAutoSetVolume(val);
            }
        }

        public int Cpm
        {
            get => preferenceSettings.GetCpm();
            set
            {
                int val = (int)Math.Round(value / 5.0) * 5;
                preferenceSettings.SetCpm(val);

                OnPropertyChanged("CpmLabel");
            }
        }

        public string CpmLabel
        {
            get => Cpm.ToString() + " cpm";
        }

        public List<string> StartEndHistory
        {
            get
            {
                var tmp = preferenceSettings.GetStartEndHistory().Reverse();

                int n = tmp.Count();
                if (n < 10)
                {
                    var blanks = new List<string>();

                    for (int i = 0; i < 10 - n; i++)
                    {
                        blanks.Add("-");
                    }

                    return tmp.Concat(blanks).ToList();
                }

                return tmp.ToList();
            }
        }
    }
}