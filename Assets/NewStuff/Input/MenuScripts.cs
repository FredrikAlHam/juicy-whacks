using System.Collections;
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
    public Animator anime;

    public static bool playing;

    //public AudioMixer mixerTwo;
    //public AudioMixer mixer;

    Controls controls = null;

    public void Start() //in start playerpref-variables for the volume options are loaded
    {
        //när bäver kommer upp så ska det här hända. Det här startar animatorn med cirkeln
        //anime.SetBool("on", true);
        //stänger av animatorn, bör hända när yxan nuddar bävern
        //anime.SetBool("on", false);

        controls = new Controls();
        controls.UI.Enable();
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //mixer.SetFloat("AudioVol", Mathf.Log10(PlayerPrefs.GetFloat("AudioVolume", 0.75f)) * 20);
        //mixerTwo.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 0.75f)) * 20);
    }
   
    public void QuitGame() //This function closes the application when triggered
    {
        Application.Quit();
    }

    public void Update()
    {
        //if the player presses escape...
        if (controls.UI.Pause.triggered && !SceneManager.GetSceneByName("EndCredits").isLoaded)
        {
            //then the function "EscMenu" will be started
            EscMenu();

        }
        if (controls.UI.Pause.triggered && SceneManager.GetSceneByName("pauseMenu").isLoaded)
        {
            WhackInput.controls.Disable();
        }
        if (controls.UI.Pause.triggered &&  SceneManager.GetSceneByName("EndCredits").isLoaded)
        {
            SceneManager.LoadSceneAsync("menu");
            //SceneManager.LoadSceneAsync("menu");
        }

    }

    //this function loads the "Options" scene
    public void GoToOptions()
    {

        //if "volumeMenu" is not already loaded
        if(!SceneManager.GetSceneByName("volumeMenu").isLoaded)
        {

            //Loads scene as an added scener (so the previous one is still loaded, and active in the background)
            SceneManager.LoadSceneAsync("volumeMenu", LoadSceneMode.Additive);
        }


    }

    //this function loads the "MainMenu" scene again
    public void BackToMainMenu()
    {
    SceneManager.LoadScene("menu");

    }
    //this function loads the "gameoverDeath" scene
    public void GameOverDeath()
    {
        SceneManager.LoadScene("gameOverDeath");

    }
    //this function loads the "gameoverWin" scene
    public void GameOverWin()
    {
        SceneManager.LoadScene("gameOverWin");

    }
    //this function loads the "EndCredits" scene
    public void CreditsScene()
    {
        SceneManager.LoadSceneAsync("EndCredits");

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
                WhackInput.controls.Enable();
            }
        }
    }
    //Unloads the EscMenu when called
    public void Back()
    {
        //SceneManager.UnloadSceneAsync("pauseMenu");
        SceneManager.UnloadSceneAsync(unloadLevelName);
    }

}


