using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System;
using AudioSourceController.Domains.Mp3Tag;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using AudioSourceController.Domains.Track;
using static AudioSourceController.Constants.PathConstants;

namespace AudioSourceController.Repository.TrackDisplays
{
    public class TrackDisplaysRepository : ITrackDisplaysRepository
    {
        public async UniTask<TagData> ReadTags(string path)
        {
            using (var file = await Task.Run(() => TagLib.File.Create(path)))
            {
                string trackName = readTrackName(file);
                trackName = trackName == null ?
                    System.IO.Path.GetFileNameWithoutExtension(path) : trackName;
                try
                {
                    byte[] jacketImage = await readImage(file);
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

        public async UniTask<List<TrackDisplay>> LoadTrackDisplays()
        {
            if(!Directory.Exists(TRACK_DETAILS_DATA_DIRECTORY)) {
                await Task.Run(() => Directory.CreateDirectory(TRACK_DETAILS_DATA_DIRECTORY));
            }
            List<TrackDisplay> trackDisplays = new List<TrackDisplay>();
            List<string> mp3s = Directory.GetFiles(MP3_DATA_DIRECTORY).Where(fileName => fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)).ToList();
            mp3s.ForEach(async mp3 =>
            {
                TagData tagData = await ReadTags(mp3);
                string dataDir = TRACK_DETAILS_DATA_DIRECTORY + SEPARATOR + tagData.TrackName;
                if (System.IO.File.Exists(dataDir))
                {
                    string bpm = readBpmFromText(dataDir);
                    TrackDisplay trackDisplay = new TrackDisplay(tagData.TrackName, bpm, tagData.JacketImage);
                    trackDisplays.Add(trackDisplay);
                }
                else
                {
                    await writeTrackData(dataDir, tagData.TrackName);
                    TrackDisplay trackDisplay = new TrackDisplay(tagData.TrackName, "120", tagData.JacketImage);
                    trackDisplays.Add(trackDisplay);
                }

            });
            return trackDisplays;
        }

        private async UniTask writeTrackData(string path, string trackName)
        {
            await Task.Run(() => File.WriteAllText(path, $"{trackName}, 120"));
        }
        private string readBpmFromText(string path)
        {
            return System.IO.File.ReadAllText(path).Split(',')[1];
        }
        private string readTrackName(TagLib.File file)
        {
            return file.Tag.Title;
        }

        private async UniTask<byte[]> readImage(TagLib.File file)
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
        }
    }
}