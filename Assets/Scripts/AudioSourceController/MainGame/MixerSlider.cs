using System.Collections;
using System.Collections.Generic;
using AudioSourceController.Logic.Audio.Mixer;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MixerSlider : MonoBehaviour
{

    private IMixer mixer;

    private Slider slider;

    [Inject]
    public void Construct(IMixer mixer)
    {
        this.mixer = mixer;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.slider = this.gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        this.mixer.SetVolume(this.slider.value);
    }
}
