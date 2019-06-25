using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int healthPoint;
    public int score;
    public void AddPlayerScore(int scoreAddition)
    {
        this.score += scoreAddition;
    }
    public void TakeDamage(int damagePoint)
    {
        this.healthPoint -= damagePoint;
        if(healthPoint<=0)
        {
            Dead();
        }
    }
    void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    void Start()
    {
        score = 0;
        healthPoint = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
