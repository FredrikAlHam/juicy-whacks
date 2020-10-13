﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    //Harriet's Script
    [SerializeField]
    private string levelName;
    [SerializeField]
    private bool unloadScene;
    [SerializeField]
    private string unloadLevelName;
    [SerializeField]
    private bool loadingLevel;

    public static bool playing;

    //public AudioMixer mixerTwo;
    //public AudioMixer mixer;

    Controls controls = null;

    public void Start() //in start playerpref-variables for the volume options are loaded
    {
        controls = new Controls();
        controls.UI.Enable();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //mixer.SetFloat("AudioVol", Mathf.Log10(PlayerPrefs.GetFloat("AudioVolume", 0.75f)) * 20);
        //mixerTwo.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 0.75f)) * 20);
    }

    public void QuitGame() //This function closes the application when triggered
    {
        Application.Quit();
    }

    private void Update()
    {
        //if the player presses escape...
        if (controls.UI.Pause.triggered)
        {
            //then the function "EscMenu" will be started
            EscMenu();
        }

    }

    //this function loads the "Options" scene
    public void GoToOptions()
    {
        SceneManager.LoadScene("OptionsMenu");

    }

    //this function loads the "MainMenu" scene again
    public void BackToMainMenu()
    {
    SceneManager.LoadScene("Menu");

    }

    //This function starts the game by loading the first "Level" scene
    public void PlayGame()
    {
        SceneManager.LoadScene("game");
    }


    public void EscMenu() //prevents the game from unloading WHEN THE ESC MENU IS LOADED
    {
        //if the scene assigned to the variable LevelName is not already loaded then...
        if (!SceneManager.GetSceneByName(levelName).isLoaded)
        {
            //Loads scene as an added scener (so the previous one is still loaded, and active in the background)
            SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
            loadingLevel = true;
            //if unloadscene is true and the level assigned to unloadLevelName is loaded then...
            if (unloadScene && SceneManager.GetSceneByName(unloadLevelName).isLoaded)
            {
                //the level assigned to unloadLevelName will be unloaded
                SceneManager.UnloadSceneAsync(unloadLevelName);
            }
        }
    }
    //Unloads the EscMenu when called
    public void Back()
    {
        SceneManager.UnloadSceneAsync("EscMenu");
    }

}

