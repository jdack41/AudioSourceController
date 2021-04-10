using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System;

namespace AudioSourceController.Audio.Loader
{
    public class TagLoader : ITagLoader
    {
        public async UniTask<TagData> ReadTags(string path)
        {
            using (var file = await Task.Run(() => TagLib.File.Create(path)))
            {
                string trackName = ReadTrackName(file);
                trackName = trackName.Equals("") ?
                    System.IO.Path.GetFileNameWithoutExtension(path) : trackName;
                try
                {
                    byte[] jacketImage = await ReadImage(file);
                    Texture2D texture = new Texture2D(128, 128);
                    texture.LoadImage(jacketImage);
                    return new TagData(trackName, texture);
                }
                catch (FileLoadException)
                {
                    return new TagData(trackName, new Texture2D(128, 128));
                }
            }
        }

        private string ReadTrackName(TagLib.File file)
        {
            return file.Tag.Title;
        }

        private async UniTask<byte[]> ReadImage(TagLib.File file)
        {
            try
            {
                TagLib.IPicture pic = file.Tag.Pictures[0];
                MemoryStream stream = await Task.Run(() => new MemoryStream(pic.Data.Data));
                return pic.Data.Data;
            }
            catch (IndexOutOfRangeException)
            {
                throw new FileLoadException("Picture Data Not Found");
            }
            catch (Exception)
            {
                throw new Exception("System Err");
            }
        }
    }
}