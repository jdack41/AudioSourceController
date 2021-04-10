using UnityEngine;

namespace AudioSourceController.Domains.Audio
{
    public class SoundSource : ISoundSource
    {
        private readonly AudioSource audioSource;

        private string clipName;

        private string bpm;

        private Texture2D jacket;

        public string ClipName { get; set; }

        public string Bpm { get; set; }

        public Texture2D Jacket { get; set; }

        public float SampleTime { get { return this.audioSource.time; } set { this.audioSource.time = value; } }
        public float Pitch { get { return this.audioSource.pitch; } set { this.audioSource.pitch = value; } }

        public SoundSource(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }


    }
}