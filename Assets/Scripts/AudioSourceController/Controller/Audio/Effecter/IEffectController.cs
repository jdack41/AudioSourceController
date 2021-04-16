using System;
using System.Collections.Generic;
using static AudioSourceController.Logic.Inputter.IInputter;

namespace AudioSourceController.Controller.Audio.Effecter
{
    public interface IEffectController
    {
        IDisposable StartTapeStop();
        IDisposable StopTapeStop();
        IDisposable StartStutter(Trigger trigger);
        IDisposable StopStutter(Trigger trigger);
        List<IDisposable> SubscribeEffect((Trigger start, Trigger end) trigger, string effect);
    }
}