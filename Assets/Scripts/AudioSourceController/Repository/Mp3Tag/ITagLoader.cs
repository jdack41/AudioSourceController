using AudioSourceController.Domains.Mp3Tag;
using Cysharp.Threading.Tasks;

namespace AudioSourceController.Repository.Mp3Tag.Loader
{
    public interface ITagLoader
    {
        UniTask<TagData> ReadTags(string path);
    }
}