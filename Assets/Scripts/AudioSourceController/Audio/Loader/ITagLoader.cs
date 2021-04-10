using Cysharp.Threading.Tasks;

namespace AudioSourceController.Audio.Loader
{
    public interface ITagLoader
    {
        UniTask<TagData> ReadTags(string path);
    }
}