using System.Collections;
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
    public GameStatus gameStatus;
    private int ballCollected;
    public int ballInLevel;
    public void AddPlayerScore(int scoreAddition)
    {
        this.score += scoreAddition;
        scorePoint.text = score.ToString();
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
        SceneManager.LoadScene("Game Over");
    }
    void LevelUp()
    {
        gameStatus.playerScore = score;
        SceneManager.LoadScene("Park 2");
    }
    void Start()
    {
        score = gameStatus.playerScore;
        healthPoint = 100;
        health.text = healthPoint.ToString();
        scorePoint.text = score.ToString();
        ballCollected = 0;
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
