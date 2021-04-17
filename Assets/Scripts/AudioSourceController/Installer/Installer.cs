using Zenject;
using UnityEngine;
using AudioSourceController.Domains.Audio;
using AudioSourceController.Logic.Inputter;
using AudioSourceController.Logic.Audio.Effecter;
using AudioSourceController.Controller.Audio.Effecter;
using AudioSourceController.Repository.Audio.Loader;
using AudioSourceController.Repository.TrackDisplays;
using AudioSourceController.Domains.Track;
using AudioSourceController.Domains.UI;

namespace AudioSourceController.Installer
{
    public class Installer : MonoInstaller
    {
        [SerializeField]
        private GameObject uiObject;
        [SerializeField]
        private AudioSource aMix;
        [SerializeField]
        private AudioSource bMix;
        [SerializeField]
        private GameObject panel;
        public override void InstallBindings()
        {
            Container.BindInstance(uiObject).WithId("uiComponent").AsSingle();
            Container.BindInstance(aMix).WithId("aMix").AsCached();
            Container.BindInstance(bMix).WithId("bMix").AsCached();
            Container.Bind<ISoundSource>().To<SoundSource>().AsSingle();
            Container.Bind<IInputter>().To<KeyBoardInputter>().AsSingle();
            Container.Bind<IEffecter>().To<Effecter>().AsSingle();
            Container.Bind<IEffectController>().To<EffectController>().AsSingle();
            Container.Bind<ITrackDisplaysRepository>().To<TrackDisplaysRepository>().AsSingle();
            Container.Bind<IAudioLoader>().To<Mp3AudioLoader>().AsSingle();
            Container.BindFactory<TrackDisplay, Panel, Panel.Factory>().FromComponentInNewPrefab(panel);
        }
    }
}