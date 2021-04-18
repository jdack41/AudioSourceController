using AudioSourceController.Domains.Track;
using UnityEngine;

namespace AudioSourceController.Domains.Audio
{
    public interface ISoundSource
    {
        TrackDisplay Track { get; set; }
        float SampleTime { get; set; }
        float Pitch { get; set; }
        int Selector { get; }
        bool IsPlaying { get; }
        void SetSource(AudioClip clip, TrackDisplay track);
        TrackDisplay GetTrackDisplay(int selector);
        void SetSelector(int selector);
        void PlaySoundSource();
        void StopSoundSource();
    }
}