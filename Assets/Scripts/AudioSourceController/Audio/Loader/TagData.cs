using UnityEngine;

namespace AudioSourceController.Audio.Loader
{
    public class TagData
    {
        private string trackName;
        private Texture2D jacketImage;
        public string TrackName { get { return trackName; } }
        public Texture2D JacketImage { get { return jacketImage; } }

        public TagData(string trackName, Texture2D jacketImage)
        {
            this.trackName = trackName;
            this.jacketImage = jacketImage;
        }
    }
}