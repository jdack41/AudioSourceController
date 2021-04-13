using AudioSourceController.Domains.Track;
using UnityEngine;

namespace AudioSourceController.Domains.Audio
{
    public interface ISoundSource
    {
        public TrackDisplay Track { get; set; }
        public float SampleTime { get; set; }
        public float Pitch { get; set; }
    }
}