using System.Collections;
using System.Collections.Generic;
using AudioSourceController.Audio.Effecter;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private IEffectController effectController;

    [Inject]
    public void Construct(IEffectController effectController) {
        this.effectController = effectController;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        effectController.ControlTapeStop();
    }
}
