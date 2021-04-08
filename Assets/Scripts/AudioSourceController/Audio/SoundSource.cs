using UnityEngine;

namespace AudioSourceController.Audio
{
    public class SoundSource : IAudio
    {
        private readonly AudioSource audioSource;

        public float SampleTime { get { return this.audioSource.time; } set { this.audioSource.time = value;} }
        public float Pitch { get { return this.audioSource.pitch; } set { this.audioSource.pitch = value; } }

        public SoundSource(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }


    }
}