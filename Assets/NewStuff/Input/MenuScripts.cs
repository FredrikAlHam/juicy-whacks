using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScripts : MonoBehaviour
{
    
    //Declares that a pair of Controls named "controls" will be used, they are currently nothing.
    Controls controls = null;

    //This bool is used so that holding space cant switch beteen the "pause" and "game" scene endlessly fast - it forces you to repress space.. hopefully
    public static bool slower = false;




    public void Start() 
    {
        //Enables the controls.
        controls = new Controls();
        controls.UI.Enable();
       
    }

    public void Update()
    {
        //if the player presses space...

        //can also be written as (controls.UI.Pause.triggered)
        //if (controls.UI.Pause.triggered)

        if (controls.UI.Pause.phase == UnityEngine.InputSystem.InputActionPhase.Started)
        {
            //slower is used to slow down the scene swithching
            //slower = !slower;

            #region if game is loaded
            //and the scene "game" is loaded...
            if (SceneManager.GetSceneByName("game").isLoaded)
            {
                //and neither "pause" or "volume" is loaded...
                if (!SceneManager.GetSceneByName("PauseMenu").isLoaded && !SceneManager.GetSceneByName("VolumeMenu").isLoaded)
                {
                    //open the pause scene additionally.
                    SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
                    //changes slwoer
                   // slower = !slower;
                }

                //and "pause" is loaded...
                if (SceneManager.GetSceneByName("PauseMenu").isLoaded && slower)
                {
                    //close pause.
                    SceneManager.UnloadSceneAsync("PauseMenu");
                    //changes slower
                   // slower = !slower;
                }
                //and volume is loaded...
                if (SceneManager.GetSceneByName("VolumeMenu").isLoaded)
                {
                    //open pause additionaly.
                    SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
                    //close volume.
                    SceneManager.UnloadSceneAsync("VolumeMenu");

                }
            }
            #endregion

            #region else
            //and the scene "VolumeMenu" is loaded...
            if (SceneManager.GetSceneByName("VolumeMenu").isLoaded)
            {
                //load MainMenu.
                SceneManager.LoadScene("MainMenu");
            }

            //and the scene "EndCredits" is loaded...
            if (SceneManager.GetSceneByName("EndCredits").isLoaded)
            {
                //load MainMenu.
                SceneManager.LoadScene("MainMenu");
            }
            #endregion
        }
    }

    #region functions for the MainMenu
    //This function loads the "game" scene.
    public void Play()
    {
        SceneManager.LoadSceneAsync("game");
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
            //open pause additionaly.
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
            //unload volume scene.
            SceneManager.UnloadSceneAsync("VolumeMenu");
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
        SceneManager.LoadSceneAsync("VolumeMenu", LoadSceneMode.Additive);
    }
    //This function loads the "PauseMenu" scene additionaly and unloads the "VolumeMenu"
    public void VolumeToPause()
    {
        SceneManager.UnloadSceneAsync("VolumeMenu");
        SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
    }
    //This function loads the "MainMenu" scene.
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    #endregion

}


