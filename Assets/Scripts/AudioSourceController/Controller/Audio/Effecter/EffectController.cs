using System;
using AudioSourceController.Domains.Audio;
using AudioSourceController.Logic.Audio.Effecter;
using AudioSourceController.Logic.Inputter;
using UniRx;

namespace AudioSourceController.Controller.Audio.Effecter
{
    public class EffectController : IEffectController
    {
        private readonly IInputter inputter;
        private readonly IEffecter effecter;
        private readonly ISoundSource soundSource;
        private bool isStuttering;
        private float triggeredSampleTime = 0;

        public EffectController(IInputter inputter, IEffecter effecter, ISoundSource soundSource)
        {
            this.inputter = inputter;
            this.effecter = effecter;
            this.soundSource = soundSource;
        }

        public IDisposable StartStutter()
        {
            return Observable.EveryUpdate()
            .Where(_ => inputter.Effect2Trigger())
            .Subscribe(_ =>
            {
                if (!isStuttering)
                {
                    triggeredSampleTime = soundSource.SampleTime;
                }
                isStuttering = true;
                effecter.ApplyStutter(ref triggeredSampleTime);
            });
        }

        public IDisposable StopStutter()
        {
            return Observable.EveryUpdate()
            .Where(_ => inputter.Effect2TriggerEnd())
            .Subscribe(_ =>
            {
                isStuttering = false;
                effecter.ResetStutter();
            });
        }

        public IDisposable StartTapeStop()
        {
            return Observable.EveryUpdate()
            .Where(_ => inputter.Effect1Trigger())
            .Subscribe(_ => effecter.ApplyTapeStop());
        }

        public IDisposable StopTapeStop()
        {
            return Observable.EveryUpdate()
            .Where(_ => inputter.Effect1TriggerEnd())
            .Subscribe(_ => effecter.ResetPitch());
        }
        
    }
}