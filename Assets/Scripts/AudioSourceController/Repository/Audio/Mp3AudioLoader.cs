using AudioSourceController.Repository.TrackDisplays;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using static AudioSourceController.Constants.PathConstants;

namespace AudioSourceController.Repository.Audio.Loader
{
    public class Mp3AudioLoader : IAudioLoader
    {
        private readonly ITrackDisplaysRepository trackDisplaysRepository;

        public Mp3AudioLoader(ITrackDisplaysRepository trackDisplaysRepository)
        {
            this.trackDisplaysRepository = trackDisplaysRepository;
        }

        public async UniTask<AudioClip> LoadClip(string mp3)
        {
            var audioData = UnityWebRequestMultimedia.GetAudioClip($"file://{MP3_DATA_DIRECTORY + SEPARATOR + mp3}.mp3", AudioType.MPEG);
            await audioData.SendWebRequest();
            return DownloadHandlerAudioClip.GetContent(audioData);
        }
    }
}