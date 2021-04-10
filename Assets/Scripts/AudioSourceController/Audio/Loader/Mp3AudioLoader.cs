using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace AudioSourceController.Audio.Loader
{
    public class Mp3AudioLoader : IAudioLoader
    {
        private readonly ITagLoader tagLoader;

        public Mp3AudioLoader(ITagLoader tagLoader)
        {
            this.tagLoader = tagLoader;
        }

        public async UniTask<AudioClip> LoadClip(string path)
        {
            var audioData = UnityWebRequestMultimedia.GetAudioClip($"file://{path}", AudioType.MPEG);
            await audioData.SendWebRequest();
            return DownloadHandlerAudioClip.GetContent(audioData);
        }
    }
}