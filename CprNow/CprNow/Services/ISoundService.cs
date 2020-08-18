namespace CprNow.Services
{
    public interface ISoundService
    {
        void PlayBeep();

        void PlayClick();

        int GetVolume();

        void SetVolume(int volumePercentage, bool playSound);
    }
}