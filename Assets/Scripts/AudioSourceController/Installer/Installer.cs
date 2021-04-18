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
using AudioSourceController.Controller.App;
using UnityEngine.Audio;
using AudioSourceController.Logic.Audio.Mixer;

namespace AudioSourceController.Installer
{
    public class Installer : MonoInstaller<Installer>
    {
        [SerializeField]
        private GameObject uiObject;
        [SerializeField]
        private AudioSource aMix;
        [SerializeField]
        private AudioSource bMix;
        [SerializeField]
        private GameObject panel;
        [SerializeField]
        private GameObject aMixJacketPanel;
        [SerializeField]
        private GameObject bMixJacketPanel;
        [SerializeField]
        private AudioMixer masterMixer;
        public override void InstallBindings()
        {
            Container.BindInstance(uiObject).WithId("uiComponent").AsCached();
            Container.BindInstance(aMix).WithId("aMix").AsCached();
            Container.BindInstance(bMix).WithId("bMix").AsCached();
            Container.BindInstance(masterMixer).AsSingle();
            Container.BindInstance(aMixJacketPanel).WithId("aJacket").AsCached();
            Container.BindInstance(bMixJacketPanel).WithId("bJacket").AsCached();
            Container.Bind<ISoundSource>().To<SoundSource>().AsSingle();
            Container.Bind<IInputter>().To<KeyBoardInputter>().AsSingle();
            Container.Bind<IEffecter>().To<Effecter>().AsSingle();
            Container.Bind<IEffectController>().To<EffectController>().AsSingle();
            Container.Bind<ITrackDisplaysRepository>().To<TrackDisplaysRepository>().AsSingle();
            Container.Bind<IAudioLoader>().To<Mp3AudioLoader>().AsSingle();
            Container.BindFactory<TrackDisplay, Panel, Panel.Factory>().FromComponentInNewPrefab(panel);
            Container.Bind<IApplicationController>().To<ApplicationController>().AsSingle();
            Container.Bind<IMixer>().To<Mixer>().AsSingle();
        }
    }
}