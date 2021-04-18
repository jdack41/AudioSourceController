using System;
using AudioSourceController.Domains.Audio;
using AudioSourceController.Logic.Inputter;
using UniRx;
using UnityEngine;
using Zenject;

namespace AudioSourceController.Controller.App
{
    public class ApplicationController : IApplicationController
    {
        private readonly ISoundSource soundSource;
        private readonly IInputter inputter;
        private readonly GameObject uiObject;

        public ApplicationController(ISoundSource soundSource, IInputter inputter, [Inject(Id = "uiComponent")]GameObject uiObject)
        {
            this.soundSource = soundSource;
            this.inputter = inputter;
            this.uiObject = uiObject;
        }

        public IDisposable ChangeSelector()
        {
            return Observable.EveryUpdate()
            .Where(_ => inputter.SelectorChangeTrigger())
            .Subscribe(_ =>
            {
                if (soundSource.Selector == 0)
                {
                    soundSource.SetSelector(1);
                }
                else
                {
                    soundSource.SetSelector(0);
                }
            });
        }

        public IDisposable OpenCloseMusicLoadingPanel()
        {
            return Observable.EveryUpdate()
            .Where(_ => inputter.MusicLoadingPanelTrigger())
            .Subscribe(_ =>
            {
                if (uiObject.activeSelf)
                {
                    uiObject.SetActive(false);
                }
                else
                {
                    uiObject.SetActive(true);
                }
            });
        }

    }
}