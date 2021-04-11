using System;

namespace AudioSourceController.Controller.Audio.Effecter
{
    public interface IEffectController
    {
        IDisposable StartTapeStop();
        IDisposable StopTapeStop();
        IDisposable StartStutter();
        IDisposable StopStutter();
    }
}