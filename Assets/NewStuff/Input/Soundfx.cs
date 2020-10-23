using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Made by Harriet

public class Soundfx : MonoBehaviour, ISelectHandler
{

    //For playing sounds in menues
    [SerializeField]
    private AudioSource ClickfxAudio;
    [SerializeField]
    private AudioSource SwitchfxAudio;

    //For Volume Options
    public AudioMixer mixerAmbience;
    public AudioMixer mixerMusic;


    public bool controlSliders = false;
    public Slider sliderAmbience;
    public Slider sliderMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (controlSliders)
        {
            //retrieves the playerpref "AmbienceVolume" and sets the value of the slider to that.
            sliderAmbience.value = PlayerPrefs.GetFloat("AmbienceVolume", 0.75f);
            //retrieves the playerpref "MusicVolume" and sets the value of the slider to that.
            sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        }
        SetLevel(PlayerPrefs.GetFloat("MusicVolume", 0.75f));
        SetLevelTwo(PlayerPrefs.GetFloat("AmbienceVolume", 0.75f));
    }

    //when the object this script is on is selected...
    public void OnSelect(BaseEventData eventData)
    {
        //play this audio.
        ClickfxAudio.Play();
    }
    //this function plays an audio. 
    public void OnClick()
    {
        SwitchfxAudio.Play();
    }

    public void SetLevel(float sliderValue)
    {
        mixerAmbience.SetFloat("AmbienceVol", Mathf.Log10(sliderValue) * 20);
        //saves the sliderValue in playerprefs as "AmbienceVolume".
        PlayerPrefs.SetFloat("AmbienceVolume", sliderValue);
        //PlayerPrefs.Save();
    }
    public void SetLevelTwo(float sliderValue)
    {
        mixerMusic.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        //saves the sliderValue in playerprefs as "MusicVolume".
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        //PlayerPrefs.Save();
    }



   /* public void Update()
    {
        if()
    }*/

}
