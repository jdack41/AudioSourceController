using System;
using System.Collections;
using System.Collections.Generic;
using AudioSourceController.Domains.Track;
using AudioSourceController.Domains.UI;
using AudioSourceController.Repository.TrackDisplays;
using UnityEngine;
using Zenject;

namespace AudioSourceController.View
{
    public class MusicLoadingPanelBuilder : MonoBehaviour, IPanelBuilder
    {
        private Panel.Factory factory;
        private ITrackDisplaysRepository repository;
        [Inject]
        public void Construct(Panel.Factory factory, ITrackDisplaysRepository repository)
        {
            this.factory = factory;
            this.repository = repository;
        }

        async void Start()
        {
            List<TrackDisplay> trackDisplays = await this.repository.LoadTrackDisplays();
            Debug.Log(trackDisplays.Count);
            trackDisplays.ForEach(x => {
                var panel = this.factory.Create(x);
                panel.GetComponent<RectTransform>().SetParent(transform, false);
                Debug.Log("hoge");
            });
        }
    }
}