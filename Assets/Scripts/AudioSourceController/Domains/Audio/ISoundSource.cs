using UnityEngine;

namespace AudioSourceController.Domains.Audio
{
    public interface ISoundSource
    {
        public string ClipName { get; set; }

        public string Bpm { get; set; }

        public Texture2D Jacket { get; set; }
        public float SampleTime { get; set; }
        public float Pitch { get; set; }
    }
}