using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
    public string name;
    public int hp;
    [SerializeField]
    public int maxHP;
    public int attack;
    public void setMaxHP(int value)
    {
        maxHP = value;
    }
    public int takeDamage(int damage)
    {
        int finalDamage = damage;
        hp = hp > finalDamage ? hp - finalDamage : 0;
        return finalDamage;
    }
    public float getHpPercent()
    {
        return (float)hp / (float)maxHP;
    }
}
