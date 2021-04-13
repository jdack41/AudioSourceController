using UnityEngine;

namespace AudioSourceController.Domains.Track
{
    public class TrackDisplay
    {
        private string clipName;

        private string bpm;

        private Texture2D jacket;

        public string ClipName { get; set; }

        public string Bpm { get; set; }

        public Texture2D Jacket { get; set; }

        public TrackDisplay(string clipName, string bpm, Texture2D jacket)
        {
            this.clipName = clipName;
            this.bpm = bpm;
            this.jacket = jacket;
        }
    }
}