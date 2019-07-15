using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameStatus gameStatus;
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
    private void Start()
    {
       gameStatus.playerScore = 0;
       gameStatus.isWin = false;
    }
    public void PlayGame()
    {
        //Load first level
        Debug.Log("Enter first scene");
        SceneManager.LoadScene("Opening Sequence");
    }
    public void QuitGame()
    {
        //Quit game
        Application.Quit();
    }
}
