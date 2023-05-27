using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource source;
    public AudioClip salahWarna;
    public AudioClip gantiWarnaPrimer;
    public AudioClip gantiWarnaSekunder;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void hitAudio(){
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.Play();
    }

    public void hitAudioSalah(){
            source.clip = salahWarna;
            source.Play();
    }

    public void hitAudioGantiWarnaPrimer(){
            source.clip = gantiWarnaPrimer;
            source.Play();
    }

    public void hitAudioGantiWarnaSekunder(){
            source.clip = gantiWarnaSekunder;
            source.Play();
    }
}
