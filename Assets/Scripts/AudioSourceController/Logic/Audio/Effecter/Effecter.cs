using AudioSourceController.Domains.Audio;
using System;
using UnityEngine;

namespace AudioSourceController.Logic.Audio.Effecter
{
    public class Effecter : IEffecter
    {
        private readonly ISoundSource soundSource;
        private int loopCounter;
        private float triggeredSampleTime = 0;

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

        public void ApplyStutter()
        {
            double timeSpan = Math.Floor(TimeSpan.FromSeconds(15d / 120d).TotalSeconds * 100) / 100;
            if (soundSource.SampleTime - triggeredSampleTime >= timeSpan)
            {
                if (this.loopCounter > 2)
                {
                    soundSource.SampleTime = triggeredSampleTime + (4 * (float)TimeSpan.FromSeconds(15d / 120d).TotalSeconds);
                    triggeredSampleTime = soundSource.SampleTime;
                    this.loopCounter = 0;
                }
                else
                {
                    soundSource.SampleTime = triggeredSampleTime;
                    this.loopCounter++;
                }
            }
        }

        public void SetStutterStartTime()
        {
            this.triggeredSampleTime = soundSource.SampleTime;
        }

        public void ResetLoopCounter()
        {
            this.loopCounter = 0;
        }

    }
}