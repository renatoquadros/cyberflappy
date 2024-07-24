using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioClip mus1, mus2, mus3;

    // Start is called before the first frame update
    void Start()
    {
        PlayInitialMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayInitialMusic()
    {
        backgroundMusicSource.clip = mus1;
        backgroundMusicSource.Play();
    }

    public void PlayMusic2()
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.clip = mus2;              
        backgroundMusicSource.Play();
    }

    public void PlayMusic3()
    {
        backgroundMusicSource.clip = mus3;
        backgroundMusicSource.Play();
    }
}
