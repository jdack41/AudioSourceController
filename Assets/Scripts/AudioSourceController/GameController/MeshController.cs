using System;
using AudioSourceController.Domains.Mp3Tag;
using AudioSourceController.Repository.Audio.Loader;
using AudioSourceController.Repository.Mp3Tag.Loader;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;

public class MeshController : MonoBehaviour
{
    private ITagLoader tagLoader;
    private IAudioLoader audioLoader;
    private AudioSource audioSource;

    [Inject]
    public void Construct(ITagLoader tagLoader, IAudioLoader audioLoader, AudioSource audioSource)
    {
        this.tagLoader = tagLoader;
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
            TagData data = await tagLoader.ReadTags("/Users/s-shimada/Temp/DIVE.mp3");
            this.gameObject.GetComponent<Renderer>().material.mainTexture = data.JacketImage;
        }
        catch (Exception)
        {
            Debug.LogWarning("Sytem Error");
        }
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            await initialize();
            AudioClip clip = await audioLoader.LoadClip("/Users/s-shimada/Temp/DIVE.mp3");
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
