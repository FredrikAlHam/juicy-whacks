using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScripts : MonoBehaviour
{
    
    //Declares that a pair of Controls named "controls" will be used, they are currently nothing.
    Controls controls = null;

    //This bool is used so that holding space cant switch beteen the "pause" and "game" scene endlessly fast - it forces you to repress space.. hopefully
    //public static bool slower = false;

        //used to prevent multiples of the same level.
    private bool loadingLevel;


    //trying to prevent space from opening when game is opening stuffaaaaaaaaa
    private bool slower;


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

        if (controls.UI.Pause.phase == UnityEngine.InputSystem.InputActionPhase.Started )
        {

            #region if game is loaded
            //and the scene "game" is loaded...
            if (SceneManager.GetSceneByName("game").isLoaded)
            {
                //and neither "pause" or "volume" is loaded...
                if (!slower && !SceneManager.GetSceneByName("PauseMenu").isLoaded && !SceneManager.GetSceneByName("VolumeMenu").isLoaded)
                {
                    slower = true;
                    //open the pause scene additionally and waits for the action to be completed.
                    SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive).completed += (x) => { loadingLevel = false; };
                    loadingLevel = true;
                    Invoke("SlowerFunction", 1.0f);
                }

                //and "pause" is loaded...
                if (!slower && SceneManager.GetSceneByName("PauseMenu").isLoaded)
                {
                    slower = true;
                    //close pause.
                    SceneManager.UnloadSceneAsync("PauseMenu");   
                    Invoke("SlowerFunction", 1.0f);
                }
                //and volume is loaded...
                if (SceneManager.GetSceneByName("VolumeMenu").isLoaded)
                {
                    slower = true;

                    //######################## 3 PauseMenue scenes open when this if statement goes through because for two frames there's neither pause or volume scenes up - which triggers the first if statement - and hence opens pause scenes!
                    //open pause additionaly.
                    SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive).completed += (x) => { loadingLevel = false; };
                    //close volume.
                    SceneManager.UnloadSceneAsync("VolumeMenu");
                    loadingLevel = true;
                    Invoke("SlowerFunction", 1.0f);

                }

            }
            #endregion

            #region else
            //and the scene "VolumeMenu" is loaded...
            if (SceneManager.GetSceneByName("VolumeMenu").isLoaded && !SceneManager.GetSceneByName("game").isLoaded)
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


    //This function makes the variable slower false - it is used to prevent the scenes from switching to and fro uncontrollably fast when pressing space;
    public void SlowerFunction()
    {
        slower = false;
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
        SceneManager.LoadSceneAsync("VolumeMenu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("PauseMenu");
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


