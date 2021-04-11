namespace AudioSourceController.Logic.Audio.Effecter
{
    public interface IEffecter
    {
        void ApplyTapeStop();
        void ResetPitch();
        void ApplyStutter(ref float sampleTime);
        void ResetStutter();
    }
}