using System;
using System.Collections.Generic;
using System.Linq;
using AudioSourceController.Controller.Audio.Effecter;
using AudioSourceController.Domains.Audio;
using AudioSourceController.Logic.Inputter;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private IEffectController effectController;

    private IInputter inputter;

    private ISoundSource soundSource;

    public TextMesh debugText;

    private Dictionary<string, List<IDisposable>> subscribedEffects = new Dictionary<string, List<IDisposable>>();

    [Inject]
    public void Construct(IEffectController effectController, IInputter inputter, ISoundSource soundSource)
    {
        this.effectController = effectController;
        this.inputter = inputter;
        this.soundSource = soundSource;
    }

    // Start is called before the first frame update
    void Start()
    {
        // effectController.StartTapeStop();
        // effectController.StopTapeStop();
        // Trigger trigger = inputter.Effect1Trigger;
        // Trigger endTrigger = inputter.Effect2Trigger;
        // effectController.StartStutter(trigger);
        // effectController.StopStutter(endTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        debugText.text = soundSource.SampleTime.ToString();
        if (inputter.Effect1SetTrigger())
        {
            if (subscribedEffects.ContainsKey("trigger1"))
            {
                subscribedEffects["trigger1"].ForEach(x => x.Dispose());
                subscribedEffects.Remove("trigger1");
            }
            else
            {
                List<IDisposable> subscribed = effectController.SubscribeEffect(inputter.GetEffect1Triggers(), "Stutter");
                subscribedEffects.Add("trigger1", subscribed);
                Debug.Log("Subscribed");
            }
        }
    }
}
