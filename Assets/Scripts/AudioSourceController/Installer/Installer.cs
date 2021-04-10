using AudioSourceController.Audio;
using AudioSourceController.Audio.Effecter;
using AudioSourceController.Inputter;
using Zenject;
using UnityEngine;
using AudioSourceController.Audio.Loader;

namespace AudioSourceController.Installer
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AudioSource>().FromComponentOn(this.gameObject).AsSingle();
            Container.Bind<IAudio>().To<SoundSource>().AsSingle();
            Container.Bind<IInputter>().To<KeyBoardInputter>().AsSingle();
            Container.Bind<IEffecter>().To<Effecter>().AsSingle();
            Container.Bind<IEffectController>().To<EffectController>().AsSingle();
            Container.Bind<ITagLoader>().To<TagLoader>().AsSingle();
            Container.Bind<IAudioLoader>().To<Mp3AudioLoader>().AsSingle();
        }
    }
}