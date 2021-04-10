using AudioSourceController.Domains.Audio;
using UnityEngine;

namespace AudioSourceController.Audio.Effecter
{
    public class Effecter : IEffecter
    {
        private readonly ISoundSource soundSource;

        public Effecter(ISoundSource soundSource)
        {
            this.soundSource = soundSource;
        }

        public void ApplyTapeStop()
        {
            if (soundSource.Pitch > 0) {
                soundSource.Pitch -= 0.005f;
            }
        }

        public void ResetPitch() 
        {
            soundSource.Pitch = 1;
        }

    }
}