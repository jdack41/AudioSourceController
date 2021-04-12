using AudioSourceController.Domains.Track;
using UnityEngine;

namespace AudioSourceController.Domains.Audio
{
    public class SoundSource : ISoundSource
    {
        private readonly AudioSource audioSource;
        private TrackDisplays track;
        public float SampleTime { get { return this.audioSource.time; } set { this.audioSource.time = value; } }
        public float Pitch { get { return this.audioSource.pitch; } set { this.audioSource.pitch = value; } }
        public TrackDisplays Track { get { return this.track; } set { this.track = value; } }

        public SoundSource(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }


    }
}