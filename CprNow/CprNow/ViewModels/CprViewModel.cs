using System;
using System.Threading.Tasks;
using CprNow.Services;
using Xamarin.Forms;

namespace CprNow.ViewModels
{
    public class CprViewModel : BaseViewModel
    {
        private const int delayInbetween = 100;
        private const double handsDown = 0.8;
        private const double handsNormal = 1.0;
        private const string primaryColor = "#cc0000";
        private const string stopButtonColor = "#1a1a1a";

        private readonly PreferenceSettings preferenceSettings;
        private readonly ISoundService soundService;
        private readonly IStopTimerService stopTimerService;

        private int cpmInMs;
        private double handsScale;
        private string pressVisible;
        private string latestStartTime;

        private bool isTimerOn;
        private bool loop;
        private string toggleButtonLabel;
        private string toggleButtonColor;

        public CprViewModel()
        {
            preferenceSettings = PreferenceSettings.Instance;
            soundService = DependencyService.Get<ISoundService>();
            stopTimerService = DependencyService.Get<IStopTimerService>();

            ToggleTimerCommand = new Command(async () => await ToggleTimer());

            preferenceSettings.OnCpmChanged += (object sender, EventArgs e) => OnPropertyChanged("Cpm");

            SetInitialValues();

            stopTimerService.RegisterOnDestroyOrPause((object sender, EventArgs e) => StopTimer());
        }

        private void SetInitialValues()
        {
            HandsScale = handsNormal;
            PressVisible = "False";
            LatestStartTime = "--:--:-- XX";

            StopTimer();
        }

        public int Cpm
        {
            get => preferenceSettings.GetCpm();
        }

        public double HandsScale
        {
            get => handsScale;
            set => SetProperty(ref handsScale, value);
        }

        public string PressVisible
        {
            get => pressVisible;
            set => SetProperty(ref pressVisible, value);
        }

        public string LatestStartTime
        {
            get => latestStartTime;
            set => SetProperty(ref latestStartTime, value);
        }

        public string ToggleButtonColor
        {
            get => toggleButtonColor;
            set => SetProperty(ref toggleButtonColor, value);
        }

        public string ToggleButtonLabel
        {
            get => toggleButtonLabel;
            set => SetProperty(ref toggleButtonLabel, value);
        }

        public Command ToggleTimerCommand { get; set; }

        public void StopTimer()
        {
            // if timer WAS already on, enqueue time
            if (isTimerOn)
            {
                preferenceSettings.EnqueueLatestStartEndTime(DateTime.Now);
            }


            isTimerOn = false;
            loop = false;
            ToggleButtonLabel = "Start";
            ToggleButtonColor = primaryColor;
        }

        private async Task CpmTimer()
        {
            HandsScale = handsDown;
            PressVisible = "True";

            soundService.PlayBeep();

            await Task.Delay(delayInbetween);

            HandsScale = handsNormal;
            PressVisible = "False";

            await Task.Delay(cpmInMs);

            return;
        }

        private async Task ToggleTimer()
        {
            // if timer WAS already on, enqueue time
            if (isTimerOn)
            {
                preferenceSettings.EnqueueLatestStartEndTime(DateTime.Now);
            }

            isTimerOn = !isTimerOn;
            loop = isTimerOn;
            ToggleButtonLabel = isTimerOn ? "Stop" : "Start";
            ToggleButtonColor = isTimerOn ? stopButtonColor : primaryColor;

            soundService.PlayClick();

            // if timer IS now turned on
            if (isTimerOn)
            {
                var now = DateTime.Now;
                LatestStartTime = now.ToString("hh:mm:ss tt");
                preferenceSettings.EnqueueLatestStartTime(now);

                // Ensure audio is heard every time
                soundService.SetVolume(preferenceSettings.GetAutoSetVolume(), false);

                cpmInMs = (60000 / preferenceSettings.GetCpm()) - delayInbetween;

                while (loop)
                {
                    await CpmTimer();
                }
            }
        }
    }
}