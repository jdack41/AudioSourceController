using AudioSourceController.Domains.Audio;
using AudioSourceController.Domains.Track;
using AudioSourceController.Repository.Audio.Loader;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace AudioSourceController.Domains.UI
{
    public class Panel : MonoBehaviour, IPanel
    {
        private TrackDisplay trackDisplay;

        private IAudioLoader loader;

        private ISoundSource soundSource;

        public TrackDisplay Track { get { return this.trackDisplay; } }

        [Inject]
        public void Construct([InjectOptional]TrackDisplay trackDisplay, IAudioLoader loader, ISoundSource soundSource)
        {
            this.trackDisplay = trackDisplay;
            this.loader = loader;
            this.soundSource = soundSource;
        }
        public class Factory : PlaceholderFactory<TrackDisplay, Panel>
        {
        }

        public async void LoadClip()
        {
            Debug.Log("clicked");
            AudioClip clip = await this.loader.LoadClip(trackDisplay.FileName);
            soundSource.SetSource(clip, trackDisplay);
        }
    }
}