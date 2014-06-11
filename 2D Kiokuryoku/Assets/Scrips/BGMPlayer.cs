using UnityEngine;
using System.Collections;

public class BGMPlayer : MonoBehaviour {

    AudioClip audioClip;
    AudioSource audioSource;
    const string PATH = "BGM/";

    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }


    void Play(string selectBGM)
    {
        Debug.Log("Selected : " + selectBGM);
        string bgmPath = PATH + selectBGM;
        this.audioClip = Resources.Load(bgmPath) as AudioClip;
        this.audioSource.clip = this.audioClip;
        this.audioSource.loop = true;
        this.audioSource.Play();
    }

    void Stop()
    {
        this.audioSource.Stop();
    }

    void Pause()
    {
        this.audioSource.Pause();
    }

    void SetVolume(float volume)
    {
        Debug.Log("SetVolume : " + volume);
        this.audioSource.volume = volume;
    } 
}
