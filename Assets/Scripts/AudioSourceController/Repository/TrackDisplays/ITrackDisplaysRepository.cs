using System.Collections;
using AudioSourceController.Domains.Mp3Tag;
using Cysharp.Threading.Tasks;

namespace AudioSourceController.Repository.TrackDisplays
{
    public interface ITrackDisplaysRepository
    {
        UniTask<TagData> ReadTags(string path);
        UniTask<ArrayList> LoadTrackDisplays();
    }
}