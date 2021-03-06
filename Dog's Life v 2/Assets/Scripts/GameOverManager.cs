﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    bool allowEnter;
    public TMP_InputField inputField;
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerName;
    public GameStatus gameStatus; 
    public GameObject lose;
    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {
        playerScore.text = gameStatus.playerScore.ToString();
        if(gameStatus.isWin)
        {
            win.SetActive(true);
            lose.SetActive(false);
        }
        else
        {
            win.SetActive(false);
            lose.SetActive(true);
        }
    }
    public void Submit()
    {
        string score = playerScore.text;
        string name = playerName.text;
        //playerScore.text = playerName.text;
        Debug.Log(name);
        if(name=="")
        {
            return;
        }           
        SaveSystem.SavePlayer(name,score);
        gameStatus.playerScore = 0;
        //Load Main Menu
        SceneManager.LoadScene("Main Menu");
    }
    // Update is called once per frame
    void Update()
    {
        if (allowEnter && (inputField.text.Length > 0) && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            Submit();
            allowEnter = false;
        }
        else
            allowEnter = inputField.isFocused;
    }
}
