using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{

    [SerializeField] private string newGame = "Game";
    [SerializeField] private string Options = "Options";




    public void NewGameButton()
    {
        SceneManager.LoadScene(newGame);
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene(Options);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
       
    }
}
