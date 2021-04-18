using System;
using System.Collections.Generic;
using System.Linq;
using AudioSourceController.Controller.App;
using AudioSourceController.Controller.Audio.Effecter;
using AudioSourceController.Domains.Audio;
using AudioSourceController.Logic.Inputter;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private IEffectController effectController;
    private IApplicationController applicationController;
    private IInputter inputter;

    private ISoundSource soundSource;

    [SerializeField]
    private TextMesh whichSelector;

    private Dictionary<string, List<IDisposable>> subscribedEffects = new Dictionary<string, List<IDisposable>>();

    [Inject]
    public void Construct(IEffectController effectController, IInputter inputter, ISoundSource soundSource, IApplicationController applicationController)
    {
        this.effectController = effectController;
        this.applicationController = applicationController;
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
        applicationController.ChangeSelector();
        applicationController.OpenCloseMusicLoadingPanel();
    }

    // Update is called once per frame
    void Update()
    {
        whichSelector.text = soundSource.Selector == 0 ? "A" : "B";
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
            }
        }
    }
}
