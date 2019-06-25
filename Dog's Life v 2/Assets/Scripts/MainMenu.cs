using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public MainMenu(int menuButtonIndex)
    {
        if(menuButtonIndex==0)
        {
            PlayGame();
        }
        else if(menuButtonIndex==1)
        {
            QuitGame();
        }
    }
    public void PlayGame()
    {
        //Load first level
        Debug.Log("Enter first scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame()
    {
        //Quit game
        Application.Quit();
    }
}
