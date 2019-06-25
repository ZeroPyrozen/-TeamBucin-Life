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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    void Start()
    {
        score = 0;
        healthPoint = 100;
        health.text = healthPoint.ToString();
        scorePoint.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
