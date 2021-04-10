using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AudioSourceController.Repository.Audio.Loader
{
    public interface IAudioLoader
    {
        UniTask<AudioClip> LoadClip(string path);
    }
}