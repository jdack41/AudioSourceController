using AudioSourceController.Domains.Track;
using UnityEngine;
using Zenject;

namespace AudioSourceController.Domains.UI
{
    public class Panel : MonoBehaviour, IPanel
    {
        private TrackDisplay trackDisplay;

        public TrackDisplay Track { get { return this.trackDisplay; } }

        [Inject]
        public void Construct([InjectOptional]TrackDisplay trackDisplay)
        {
            this.trackDisplay = trackDisplay;
        }
        public class Factory : PlaceholderFactory<TrackDisplay, Panel>
        {
        }

    }
}