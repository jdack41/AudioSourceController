using AudioSourceController.Logic.Audio.Effecter;
using AudioSourceController.Logic.Inputter;

namespace AudioSourceController.Controller.Audio.Effecter
{
    public class EffectController : IEffectController
    {
        private readonly IInputter inputter;
        private readonly IEffecter effecter;

        public EffectController(IInputter inputter, IEffecter effecter)
        {
            this.inputter = inputter;
            this.effecter = effecter;
        }
        public void ControlTapeStop()
        {
            if (inputter.Effect1Trigger())
            {
                effecter.ApplyTapeStop();
            }
            else if (inputter.Effect1TriggerEnd())
            {
                effecter.ResetPitch();
            }
        }
    }
}