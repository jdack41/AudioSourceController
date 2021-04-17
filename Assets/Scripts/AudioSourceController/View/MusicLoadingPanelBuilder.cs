using System;
using System.Collections;
using System.Collections.Generic;
using AudioSourceController.Domains.Track;
using AudioSourceController.Domains.UI;
using AudioSourceController.Repository.TrackDisplays;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AudioSourceController.View
{
    public class MusicLoadingPanelBuilder : MonoBehaviour
    {
        private Panel.Factory factory;
        private ITrackDisplaysRepository repository;
        [Inject]
        public void Construct(Panel.Factory factory, ITrackDisplaysRepository repository)
        {
            this.factory = factory;
            this.repository = repository;
        }

        private async UniTask initialize()
        {
            try
            {
                List<TrackDisplay> trackDisplays = await this.repository.LoadTrackDisplays();
                trackDisplays.ForEach(x =>
                {
                    var panel = this.factory.Create(x);
                    Texture2D texture = panel.Track.Jacket;
                    panel.transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                    Text trackName = panel.transform.GetChild(1).GetComponent<Text>();
                    trackName.text = panel.Track.ClipName;
                    Text bpm = trackName.transform.GetChild(0).GetComponent<Text>();
                    bpm.text = panel.Track.Bpm;
                    panel.GetComponent<RectTransform>().SetParent(transform, false);
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        async void Start()
        {
            await initialize();
        }
    }
}