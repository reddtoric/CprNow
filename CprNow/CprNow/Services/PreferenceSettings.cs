using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace CprNow.Services
{
    public class PreferenceSettings
    {
        public EventHandler OnCpmChanged;
        public EventHandler OnStartEndHistoryChanged;
        public EventHandler OnVolumeChanged;

        private const string startEndHistoryKey = "0";
        private const string autoSetVolumeKey = "1";
        private const string cpmKey = "2";
        private const string disclaimerKey = "3";

        private const string startDateTimeFormat = "MMMM d  hh:mm:ss tt";
        private const string endDateTimeFormat = "hh:mm:ss tt";

        private string currentLatestStartTime;

        private PreferenceSettings()
        {
            currentLatestStartTime = "";
        }

        public static PreferenceSettings Instance { get; } = new PreferenceSettings();

        public void EnqueueLatestStartTime(DateTime latestStartTime)
        {
            currentLatestStartTime = latestStartTime.ToString(startDateTimeFormat);


            /*
            Queue<string> updatedStartHistory = GetStartEndHistory();

            updatedStartHistory.Enqueue(latestStartTime.ToString(dateTimeFormat));

            while (updatedStartHistory.Count > 10)
            {
                updatedStartHistory.Dequeue();
            }

            Preferences.Set(startHistoryKey, Serialize<string[]>(updatedStartHistory.ToArray()));

            OnStartHistoryChanged?.Invoke(null, null);
            */
        }

        public void EnqueueLatestStartEndTime(DateTime latestEndTime)
        {
            if (currentLatestStartTime != "")
            {
                Queue<string> startEndHistory = GetStartEndHistory();

                startEndHistory.Enqueue(currentLatestStartTime + " - " + latestEndTime.ToString(endDateTimeFormat));

                while (startEndHistory.Count > 10)
                {
                    startEndHistory.Dequeue();
                }

                Preferences.Set(startEndHistoryKey, Serialize(startEndHistory.ToArray()));

                currentLatestStartTime = "";
            }

            OnStartEndHistoryChanged?.Invoke(null, null);
        }

        public Queue<string> GetStartEndHistory()
        {
            string startEndHistoryAsString = Preferences.Get(startEndHistoryKey, string.Empty);

            if (string.IsNullOrEmpty(startEndHistoryAsString))
            {
                return new Queue<string>();
            }

            return new Queue<string>(Deserialize<string[]>(startEndHistoryAsString));
        }

        public int GetAutoSetVolume()
        {
            return Preferences.Get(autoSetVolumeKey, 80);
        }

        public void SetAutoSetVolume(int level)
        {
            int _level = level;

            if (level < 0)
            {
                _level = 0;
            }
            else if (level > 100)
            {
                _level = 100;
            }

            Preferences.Set(autoSetVolumeKey, _level);

            OnVolumeChanged?.Invoke(null, null);
        }

        public int GetCpm()
        {
            return Preferences.Get(cpmKey, 100);
        }

        public void SetCpm(int cpm)
        {
            int _cpm = cpm;

            if (cpm < 100)
            {
                _cpm = 100;
            }
            else if (cpm > 120)
            {
                _cpm = 120;
            }

            Preferences.Set(cpmKey, _cpm);

            OnCpmChanged?.Invoke(null, null);
        }

        public bool GetDisclaimerAgreement()
        {
            return Preferences.Get(disclaimerKey, false);
        }

        public void SetDisclaimerAgreement(bool agreed)
        {
            Preferences.Set(disclaimerKey, agreed);
        }

        private static T Deserialize<T>(string serializedObject) => JsonConvert.DeserializeObject<T>(serializedObject);

        private static string Serialize<T>(T objectToSerialize) => JsonConvert.SerializeObject(objectToSerialize);
    }
}