using UnityEngine;

namespace AudioSourceController.Domains.Track
{
    public class TrackDisplays
    {
        private string clipName;

        private string bpm;

        private Texture2D jacket;

        public string ClipName { get; set; }

        public string Bpm { get; set; }

        public Texture2D Jacket { get; set; }
    }
}