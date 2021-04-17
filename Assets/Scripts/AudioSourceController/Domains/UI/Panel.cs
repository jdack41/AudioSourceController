using AudioSourceController.Domains.Track;
using UnityEngine;
using Zenject;

namespace AudioSourceController.Domains.UI
{
    public class Panel : MonoBehaviour, IPanel
    {
        private readonly TrackDisplay trackDisplay;

        public Panel(TrackDisplay trackDisplay)
        {
            this.trackDisplay = trackDisplay;
            
        }
        public class Factory : PlaceholderFactory<TrackDisplay,IPanel>
        {
        }
        
    }
}