using AudioSourceController.Domains.Track;
using UnityEngine;
using Zenject;

namespace AudioSourceController.Domains.Audio
{
    public class SoundSource : ISoundSource
    {
        private int selector = 0;
        private AudioSource[] mixes;
        private TrackDisplay[] track = new TrackDisplay[2];
        public float SampleTime
        {
            get
            {
                return this.mixes[this.selector].time;
            }
            set
            {
                this.mixes[this.selector].time = value;
            }
        }
        public float Pitch
        {
            get
            {
                return this.mixes[this.selector].pitch;
            }
            set
            {
                this.mixes[this.selector].pitch = value;
            }
        }
        public TrackDisplay Track
        {
            get
            {
                return this.track[this.selector];
            }
            set
            {
                this.track[this.selector] = value;
            }
        }

        public SoundSource([Inject(Id = "aMix")] AudioSource aMix, [Inject(Id = "bMix")] AudioSource bMix)
        {
            this.mixes = new AudioSource[] { aMix, bMix };
        }

        public void SetSource(AudioClip clip, TrackDisplay track)
        {
            this.mixes[this.selector].Stop();
            this.mixes[this.selector].clip = clip;
            this.mixes[this.selector].time = 0;
            this.track[this.selector] = track;
        }

        public TrackDisplay GetTrackDisplay(int selector)
        {
            return this.track[selector];
        }
    }
}