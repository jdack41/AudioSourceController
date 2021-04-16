using System;
using System.Collections.Generic;
using System.Linq;
using AudioSourceController.Controller.Audio.Effecter;
using AudioSourceController.Logic.Inputter;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private IEffectController effectController;

    private IInputter inputter;

    private Dictionary<string, List<IDisposable>> subscribedEffects = new Dictionary<string, List<IDisposable>>();

    [Inject]
    public void Construct(IEffectController effectController, IInputter inputter)
    {
        this.effectController = effectController;
        this.inputter = inputter;
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
        if (inputter.Effect1SetTrigger())
        {
            if (subscribedEffects.ContainsKey("trigger1"))
            {
                subscribedEffects["trigger1"].ForEach(x => x.Dispose());
                var hoge = subscribedEffects.Keys;
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
