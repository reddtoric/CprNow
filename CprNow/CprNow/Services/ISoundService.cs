namespace CprNow.Services
{
    public interface ISoundService
    {
        int GetVolume();

        void PlayBeep();

        void PlayClick();

        void SetVolume(int volumePercentage, bool playSound);

        void StartSoundService();

        void StopSoundService();
    }
}