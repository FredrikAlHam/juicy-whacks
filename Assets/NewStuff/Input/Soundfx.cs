using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Harriets kod.

//playing sounds when buttons are selected through keys uses ISelectHandler
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

    [SerializeField]
    public Slider sliderAmbience;
    [SerializeField]
    public Slider sliderMusic;

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
    }
    public void SetLevelTwo(float sliderValue)
    {
        mixerMusic.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        //saves the sliderValue in playerprefs as "MusicVolume".
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    // Start is called before the first frame update
    void Start()
    {
        //retrieves the playerpref "AmbienceVolume" and sets the value of the slider to that.
        sliderAmbience.value = PlayerPrefs.GetFloat("AmbienceVolume", 0.75f);
        //retrieves the playerpref "MusicVolume" and sets the value of the slider to that.
        sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

}
