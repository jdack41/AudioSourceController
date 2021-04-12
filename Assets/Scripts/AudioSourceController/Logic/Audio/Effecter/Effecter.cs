using AudioSourceController.Domains.Audio;
using System;
using UnityEngine;

namespace AudioSourceController.Logic.Audio.Effecter
{
    public class Effecter : IEffecter
    {
        private readonly ISoundSource soundSource;

        private int loopCounter;

        public Effecter(ISoundSource soundSource)
        {
            this.soundSource = soundSource;
        }

        public void ApplyTapeStop()
        {
            if (soundSource.Pitch > 0)
            {
                soundSource.Pitch -= 0.005f;
            }
        }

        public void ResetPitch()
        {
            soundSource.Pitch = 1;
        }

        public void ApplyStutter(ref float sampleTime)
        {
            double timeSpan = TimeSpan.FromSeconds(15d / 168d).TotalSeconds;
            if (soundSource.SampleTime - sampleTime >= timeSpan)
            {
                if (this.loopCounter > 2)
                {
                    soundSource.SampleTime = sampleTime + (4 * (float)TimeSpan.FromSeconds(15d / 168d).TotalSeconds);
                    sampleTime = soundSource.SampleTime;
                    this.loopCounter = 0;
                }
                else
                {
                    soundSource.SampleTime = sampleTime;
                    this.loopCounter++;
                }
            }
        }

        public void ResetStutter()
        {
            this.loopCounter = 0;
        }

    }
}