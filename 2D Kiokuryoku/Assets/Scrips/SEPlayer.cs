using UnityEngine;
using System.Collections;

public class SEPlayer : MonoBehaviour {

    AudioClip audioClip;
    AudioSource audioSource;
    const string PATH = "SE/";

    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }


    void Play(string selectSE)
    {
        Debug.Log("Selected : " + selectSE);
        string sePath = PATH + selectSE;
        this.audioClip = Resources.Load(sePath) as AudioClip;
        this.audioSource.clip = this.audioClip;
        audioSource.PlayOneShot(this.audioClip);
    }
}
