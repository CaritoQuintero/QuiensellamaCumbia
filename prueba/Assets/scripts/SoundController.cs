using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    AudioSource audiosource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audiosource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip audio)
    {
        audiosource.PlayOneShot(audio);
    }  
}
