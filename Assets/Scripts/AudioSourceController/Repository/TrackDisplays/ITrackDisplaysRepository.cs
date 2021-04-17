using System.Collections;
using System.Collections.Generic;
using AudioSourceController.Domains.Mp3Tag;
using AudioSourceController.Domains.Track;
using Cysharp.Threading.Tasks;

namespace AudioSourceController.Repository.TrackDisplays
{
    public interface ITrackDisplaysRepository
    {
        UniTask<TagData> ReadTags(string path);
        UniTask<List<TrackDisplay>> LoadTrackDisplays();
    }
}