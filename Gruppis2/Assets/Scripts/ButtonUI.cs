using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string Menu = "MainMenu";
    [SerializeField] private string Options = "Options";
    [SerializeField] private string newGame = "Station1";
    [SerializeField] private string Credits = "Credits";




    public void NewGameButton()
    {
        SceneManager.LoadScene(newGame);
        PauseMenu.gameIsPaused = false;
        
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene(Options);
    }

    public void BacktoHome()
    {
        SceneManager.LoadScene(Menu);  
    }

    public void SetFullScreen(bool fullScreenValue)
    {
        Screen.fullScreen = fullScreenValue;
        
        if (!fullScreenValue)
        {
            Resolution resolution = Screen.currentResolution;
            resolution.width = 1920;
            Screen.SetResolution(resolution.width, resolution.height, fullScreenValue);
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;


        }

    }
    public void CreditsScreen()
    {
        SceneManager.LoadScene(Credits);
    }


}

 







