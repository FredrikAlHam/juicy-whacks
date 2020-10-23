using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

//Hej Tobbe, Jag (Harriet) har skrivit på engelska, jag hoppas det är okej :3 Also hela det här scriptet är mitt, yay.
public class MenuScripts : MonoBehaviour
{
    
    //Declares that a pair of Controls named "controls" will be used, they are currently nothing.
    Controls controls = null;

    //Used to prevent multiples of the same level.
    private bool loadingLevel;

    //For Volume Options
    public AudioMixer mixerAmbience;
    public AudioMixer mixerMusic;

    #region not used
    //trying to prevent space from opening when game is opening stuffaaaaaaaaa
    private bool slower;
    #endregion

    public void Start() 
    {
        //Updates the vlume for the music mixer and the ambience mixer.
        mixerAmbience.SetFloat("AmbienceVol", Mathf.Log10(PlayerPrefs.GetFloat("AmbienceVolume", 0.75f)) * 20);
        mixerMusic.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 0.75f)) * 20);

        //Enables the controls.
        controls = new Controls();
        controls.UI.Enable();
        

       
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; //Fungerar inte om musen är utanför gameviewn i editorn när spelet startas - Fredrik
    }

    public void Update()
    {
        #region debug stuff
        /* if(controls.UI.Pause.triggered)
         {
             if (SceneManager.GetSceneByName("PauseMenu").isLoaded)
                Debug.LogError("in PauseMenu phase        " + controls.UI.Pause.phase);

         }*/
        #endregion

        //if the player presses space...
        if (controls.UI.Pause.triggered && controls.UI.Pause.phase == UnityEngine.InputSystem.InputActionPhase.Started )
        {

            #region if game is loaded
            //and the scene "game" is loaded...
            if (SceneManager.GetSceneByName("game").isLoaded)
            {
                //and neither "pause" or "volume" is loaded...
                if ( !SceneManager.GetSceneByName("PauseMenu").isLoaded && !SceneManager.GetSceneByName("VolumeMenu").isLoaded) //(!slower &&
                {
                    //open the pause scene additionally and waits for the action to be completed.
                    SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive).completed += (x) => { loadingLevel = false; };
                    loadingLevel = true;

                }

                //and "pause" is loaded...
                if (SceneManager.GetSceneByName("PauseMenu").isLoaded)//(!slower && 
                {
                    //close pause.
                    SceneManager.UnloadSceneAsync("PauseMenu");
                    //slower = true;
                    //Invoke("SlowerFunction", 1.0f);
                }
                //and volume is loaded...
                if (SceneManager.GetSceneByName("VolumeMenu").isLoaded)
                {;
                    //open pause additionaly.
                    SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive).completed += (x) => { loadingLevel = false; };
                    //close volume.
                    SceneManager.UnloadSceneAsync("VolumeMenu");
                    loadingLevel = true;
                    //slower = true
                    //Invoke("SlowerFunction", 1.0f);

                }

            }
            #endregion

            #region else
            //and the scene "VolumeMenu" is loaded...
            if (SceneManager.GetSceneByName("VolumeMenu").isLoaded && !SceneManager.GetSceneByName("game").isLoaded)
            {
                //load MainMenu.
                SceneManager.LoadSceneAsync("MainMenu");
            }

            //and the scene "EndCredits" is loaded...
            if (SceneManager.GetSceneByName("EndCredits").isLoaded)
            {
                //load MainMenu.
                SceneManager.LoadSceneAsync("MainMenu");
            }

            //and the scene "IntroScene" is loaded...
            if (SceneManager.GetSceneByName("IntroScene").isLoaded)
            {
                //load MainMenu.
                SceneManager.LoadSceneAsync("MainMenu");
            }
            #endregion
        }

        //If the song aka the game is finished then..
        /*if (GameSongPlayer.IsDone == true)
        {
        Score.instance.score
        //load WinMenu scene
        SceneManager.LoadSceneAsync("WinMenu");

        }*/
    }

    #region not used
    //This function makes the variable slower false - it is used to prevent the scenes from switching to and fro uncontrollably fast when pressing space;
    /* public void SlowerFunction() 
     {
         slower = false;
     }*/
    #endregion

    #region functions for the MainMenu
    //This function loads the "game" scene.
    public void Play()
    {
        SceneManager.LoadSceneAsync("SongSelection");
    }
    //This function loads the "VolumeMenu" scene.
    public void Volume()
    {
        SceneManager.LoadSceneAsync("VolumeMenu");
    }
    //This function closes the application when triggered.
    public void Quit()
    {
        Application.Quit();
    }
    //This function loads the "EndCredits" scene.
    public void EndCredits()
    {
        SceneManager.LoadSceneAsync("EndCredits");
    }
    #endregion

    #region functions for the VolumeMenu
    public void VolumeBack()
    {
        //if the "game" scene is loaded
        if (SceneManager.GetSceneByName("game").isLoaded)
        {
            //unload volume scene.
            SceneManager.UnloadSceneAsync("VolumeMenu");
            //open pause additionaly.
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);

        }
        else
        {
            //load main menu scene.
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
    #endregion

    #region functions for the PauseMenu
    //This function unloads the "PauseMenu" scene.
    public void UnPause()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
    }
    //This function loads the "VolumeMenu" scene additionaly.
    public void VolumeAdd()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        SceneManager.LoadSceneAsync("VolumeMenu", LoadSceneMode.Additive);
    }
    //This function loads the "PauseMenu" scene additionaly and unloads the "VolumeMenu"
    public void VolumeToPause()
    {
        SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("VolumeMenu");
    }
    //This function loads the "MainMenu" scene.
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    #endregion

}


