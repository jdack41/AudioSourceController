using UnityEngine.Audio;

namespace AudioSourceController.Logic.Audio.Mixer
{
    public class Mixer : IMixer
    {
        private readonly AudioMixer mixer;

        public Mixer(AudioMixer mixer)
        {
            this.mixer = mixer;
        }

        public void SetVolume(float val)
        {
            if (val > 0)
            {
                this.mixer.SetFloat("B", 0);
                val = val * -1;
                this.mixer.SetFloat("A", val * 80);
            }
            else
            {
                this.mixer.SetFloat("B", val * 80);
                val = val * -1;
                this.mixer.SetFloat("A", 0);
            }
        }
    }
}