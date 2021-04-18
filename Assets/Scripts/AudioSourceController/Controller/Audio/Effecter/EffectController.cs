using System;
using System.Collections.Generic;
using AudioSourceController.Domains.Audio;
using AudioSourceController.Logic.Audio.Effecter;
using AudioSourceController.Logic.Inputter;
using UniRx;
using UnityEngine;
using static AudioSourceController.Logic.Inputter.IInputter;
using static AudioSourceController.Constants.EffectNames;

namespace AudioSourceController.Controller.Audio.Effecter
{
    public class EffectController : IEffectController
    {
        private readonly IInputter inputter;
        private readonly IEffecter effecter;
        private readonly ISoundSource soundSource;
        private bool isStuttering;

        public EffectController(IInputter inputter, IEffecter effecter, ISoundSource soundSource)
        {
            this.inputter = inputter;
            this.effecter = effecter;
            this.soundSource = soundSource;
        }

        public IDisposable StartStutter(Trigger trigger)
        {
            return Observable.EveryUpdate()
            .Where(_ => trigger())
            .Subscribe(_ =>
            {
                if (!isStuttering)
                {
                    effecter.SetStutterStartTime();
                }
                isStuttering = true;
                effecter.ApplyStutter();
            });
        }

        public IDisposable StopStutter(Trigger trigger)
        {
            return Observable.EveryUpdate()
            .Where(_ => trigger())
            .DoOnCancel(() =>
            {
                isStuttering = false;
                effecter.ResetLoopCounter();
            })
            .Subscribe(_ =>
            {
                isStuttering = false;
                effecter.ResetLoopCounter();
            });
        }

        public List<IDisposable> SubscribeEffect((Trigger start, Trigger end) trigger, string effect)
        {
            List<IDisposable> subscribed = new List<IDisposable>();
            switch (effect)
            {
                case STUTTER:
                    var start = StartStutter(trigger.start);
                    var end = StopStutter(trigger.end);
                    subscribed.Add(start);
                    subscribed.Add(end);
                    break;
                case TAPESTOP:
                    break;
            }
            return subscribed;
        }

        public IDisposable StartTapeStop()
        {
            return Observable.EveryUpdate()
            .Where(_ => inputter.Effect2Trigger())
            .Subscribe(_ => effecter.ApplyTapeStop());
        }

        public IDisposable StopTapeStop()
        {
            return Observable.EveryUpdate()
            .Where(_ => inputter.Effect2TriggerEnd())
            .Subscribe(_ => effecter.ResetPitch());
        }

        public IDisposable TogglePlayStop()
        {
            return Observable.EveryUpdate()
            .Where(_ => inputter.MusicPlayTrigger())
            .Subscribe(_ => effecter.TogglePlayStopAudio());
        }

    }
}