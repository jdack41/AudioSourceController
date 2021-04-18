namespace AudioSourceController.Logic.Audio.Effecter
{
    public interface IEffecter
    {
        void ApplyTapeStop();
        void ResetPitch();
        void ApplyStutter();
        void ResetLoopCounter();
        void SetStutterStartTime();
        void TogglePlayStopAudio();
    }
}