﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int healthPoint;
    public int score;
    public TextMeshProUGUI scorePoint;
    public TextMeshProUGUI health;
    public TextMeshProUGUI ballPoint;
    public GameStatus gameStatus;
    private int ballCollected;
    private int ballInLevel;
    public GameObject balls;
    public void AddPlayerScore(int scoreAddition)
    {
        this.score += scoreAddition;
        scorePoint.text = score.ToString();
        ballPoint.text = ballCollected.ToString()+"/"+ballInLevel.ToString();
    }

    public void TakeDamage(int damagePoint)
    {
        this.healthPoint -= damagePoint;
        if(healthPoint<=0)
        {
            Dead();
        }
        health.text = healthPoint.ToString();
    }
    void Dead()
    {
        gameStatus.playerScore = score;
        SceneManager.LoadScene("Ending Sequence");
    }
    void LevelUp()
    {
        gameStatus.playerScore = score;
        if(SceneManager.GetActiveScene().name=="Park 2")
        {
            gameStatus.isWin = true;
            SceneManager.LoadScene("Ending Sequence");
        }
        else if(SceneManager.GetActiveScene().name=="Park")
        {
            SceneManager.LoadScene("Park 2");
        }
        
    }
    void Start()
    {
        score = gameStatus.playerScore;
        healthPoint = 100;
        health.text = healthPoint.ToString();
        scorePoint.text = score.ToString();
        ballCollected = 0;
        ballInLevel = balls.transform.childCount;
        ballPoint.text = ballCollected.ToString()+"/"+ballInLevel.ToString();
        Debug.Log(ballInLevel);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ballCollected++;
            AddPlayerScore(20);
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(ballCollected == ballInLevel)
        {
            LevelUp();
        }
    }
}
