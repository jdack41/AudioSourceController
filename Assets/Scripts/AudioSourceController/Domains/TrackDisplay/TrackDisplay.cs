using UnityEngine;

namespace AudioSourceController.Domains.Track
{
    public class TrackDisplay
    {
        private string clipName;

        private string bpm;

        private Texture2D jacket;

        public string ClipName { get { return this.clipName; } }

        public string Bpm { get { return this.bpm; } }

        public Texture2D Jacket { get { return this.jacket; } }

        public TrackDisplay(string clipName, string bpm, Texture2D jacket)
        {
            this.clipName = clipName;
            this.bpm = bpm;
            this.jacket = jacket;
        }
    }
}