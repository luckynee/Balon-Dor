using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public SoundRandomizer soundRandomizer;
    public AudioSource bgm;
    // Start is called before the first frame update

    [SerializeField] 
    Slider sfxSlider;
     [SerializeField] 
    Slider bgmSlider;

    void Start()
    {
        soundRandomizer = GameObject.Find("SFX").GetComponent<SoundRandomizer>();
        if(!PlayerPrefs.HasKey("sfx"))
        {
            PlayerPrefs.SetFloat("sfx", 1);
            Load();
        }
        else
        {
            Load();
        }
        if(!PlayerPrefs.HasKey("bgm"))
        {
            PlayerPrefs.SetFloat("bgm", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Load()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfx");
        bgmSlider.value = PlayerPrefs.GetFloat("bgm");
    }

    public void Save()
    {   
        PlayerPrefs.SetFloat("sfx", sfxSlider.value);
        PlayerPrefs.SetFloat("bgm", bgmSlider.value);
    }

    public void ChangeVolume()
    {
        soundRandomizer.source.volume = sfxSlider.value;
        bgm.volume = bgmSlider.value;
        Save();
    }
}
