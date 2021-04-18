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
        private GameObject[] mixJackets;

        public TrackDisplay Track { get { return this.trackDisplay; } }

        [Inject]
        public void Construct([InjectOptional] TrackDisplay trackDisplay, IAudioLoader loader, ISoundSource soundSource, [Inject(Id = "aJacket")] GameObject aJacket, [Inject(Id = "bJacket")] GameObject bJacket)
        {
            this.trackDisplay = trackDisplay;
            this.loader = loader;
            this.soundSource = soundSource;
            this.mixJackets = new GameObject[2] {aJacket, bJacket};
        }
        public class Factory : PlaceholderFactory<TrackDisplay, Panel>
        {
        }

        public async void LoadClip()
        {
            await loadClip();
        }

        // TODO: 別クラスに移管
        private async UniTask loadClip()
        {
            AudioClip clip = await this.loader.LoadClip(trackDisplay.FileName);
            soundSource.SetSource(clip, trackDisplay);
            mixJackets[soundSource.Selector].GetComponent<Renderer>().material.mainTexture = trackDisplay.Jacket;
        }
    }
}