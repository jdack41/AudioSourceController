using System;
using AudioSourceController.Domains.Mp3Tag;
using AudioSourceController.Repository.Audio.Loader;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;
using AudioSourceController.Repository.TrackDisplays;

public class MeshController : MonoBehaviour
{
    private ITrackDisplaysRepository trackDisplaysRepository;
    private IAudioLoader audioLoader;
    private AudioSource audioSource;

    [Inject]
    public void Construct(ITrackDisplaysRepository trackDisplaysRepository, IAudioLoader audioLoader, AudioSource audioSource)
    {
        this.trackDisplaysRepository = trackDisplaysRepository;
        this.audioLoader = audioLoader;
        this.audioSource = audioSource;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private async UniTask initialize()
    {
        try
        {
            TagData data = await trackDisplaysRepository.ReadTags("/Users/s-shimada/Temp/DIVE.mp3");
            this.gameObject.GetComponent<Renderer>().material.mainTexture = data.JacketImage;
        }
        catch (Exception e)
        {
            Debug.LogWarning("Sytem Error");
            Debug.LogWarning(e.Message);
        }
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            await initialize();
            AudioClip clip = await audioLoader.LoadClip("DIVE");
            audioSource.clip = clip;
            // audioSource.Play();
            await trackDisplaysRepository.LoadTrackDisplays();
        }
    }
}
