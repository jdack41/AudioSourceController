using Zenject;
using UnityEngine;
using AudioSourceController.Domains.Audio;
using AudioSourceController.Logic.Inputter;
using AudioSourceController.Logic.Audio.Effecter;
using AudioSourceController.Controller.Audio.Effecter;
using AudioSourceController.Repository.Audio.Loader;
using AudioSourceController.Repository.TrackDisplays;

namespace AudioSourceController.Installer
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AudioSource>().FromComponentOn(this.gameObject).AsSingle();
            Container.Bind<ISoundSource>().To<SoundSource>().AsSingle();
            Container.Bind<IInputter>().To<KeyBoardInputter>().AsSingle();
            Container.Bind<IEffecter>().To<Effecter>().AsSingle();
            Container.Bind<IEffectController>().To<EffectController>().AsSingle();
            Container.Bind<ITrackDisplaysRepository>().To<TrackDisplaysRepository>().AsSingle();
            Container.Bind<IAudioLoader>().To<Mp3AudioLoader>().AsSingle();
        }
    }
}