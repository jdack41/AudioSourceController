using AudioSourceController.Controller.Audio.Effecter;
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
        effectController.StartTapeStop();
        effectController.StopTapeStop();
        effectController.StartStutter();
        effectController.StopStutter();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
