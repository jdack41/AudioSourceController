using UnityEngine;

namespace AudioSourceController.Audio.Effecter
{
    public class Effecter : IEffecter
    {
        private readonly IAudio audio;

        public Effecter(IAudio audio)
        {
            this.audio = audio;
        }

        public void ApplyTapeStop()
        {
            if (audio.Pitch > 0) {
                audio.Pitch -= 0.005f;
            }
        }

        public void ResetPitch() 
        {
            audio.Pitch = 1;
        }

    }
}