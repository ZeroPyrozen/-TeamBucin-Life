using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatus", menuName = "ScriptableObject/GameStatus")]
public class GameStatus : ScriptableObject
{
    public int playerScore;
    public bool isWin;
}
