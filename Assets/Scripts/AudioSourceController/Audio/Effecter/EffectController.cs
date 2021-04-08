using AudioSourceController.Inputter;

namespace AudioSourceController.Audio.Effecter
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
            if (inputter.Effect1KeyDown())
            {
                effecter.ApplyTapeStop();
            }
            else if (inputter.Effect1KeyUp())
            {
                effecter.ResetPitch();
            }
        }
    }
}