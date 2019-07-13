using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    private List<string> leaderboard;
    public TextMeshProUGUI textTitle;
    public TextMeshProUGUI textLeaderboard;
    private Vector3 titlePost,textPost;
    void Start()
    {
        leaderboard = new List<string>();
        //Dummy data
        //int randomNumber = 100;
        //SaveSystem.SavePlayer("Andi", randomNumber.ToString());
        //randomNumber = 500;
        //SaveSystem.SavePlayer("Budi", randomNumber.ToString());
        //randomNumber = 40;
        //SaveSystem.SavePlayer("Jude", randomNumber.ToString());
        //randomNumber = 120;
        //SaveSystem.SavePlayer("Ryan", randomNumber.ToString());
        //randomNumber = 50;
        //SaveSystem.SavePlayer("Bob", randomNumber.ToString());
        ReadData();
    }

    void ReadData()
    {
        Debug.Log("Load Data");
        leaderboard = SaveSystem.LoadPlayer();

        if (leaderboard.Count > 0)
        {
            leaderboard = SortLeaderboard(leaderboard);
            GenerateHighScore(leaderboard);
        }
    }
    private void Update()
    {

    }
    class InnerClassPlayerLeaderboard
    {
        public string name { get; set; }
        public int score { get; set; }
    }
    private List<string> SortLeaderboard(List<string> leaderboard)
    {
        List<string> newLeaderboard = new List<string>();
        List<InnerClassPlayerLeaderboard> innerClass = new List<InnerClassPlayerLeaderboard>();
        InnerClassPlayerLeaderboard i;
        Debug.Log(leaderboard.Count);
        foreach (var x in leaderboard)
        {
            i = new InnerClassPlayerLeaderboard();
            string[] splits = x.Split('-');
            //i.name = splits[0];
            //i.score = int.Parse(splits[1].TrimStart());
            //Debug.Log(splits.Length);
            for (int y = 0; y < splits.Length; y++)
            {
                if (y == 0)
                    i.name = splits[y];
                else
                    i.score = int.Parse(splits[y].TrimStart());
            }
            innerClass.Add(i);
        }
        innerClass = innerClass.OrderBy(o => o.score).ToList();
        //Debug.Log(innerClass.Count);
        foreach (var f in innerClass)
        {
            string temp;
            if(f.name.Length > 8)
            {
                temp = f.name.Substring(0,8);
            }
            else
            {
                temp = f.name;
            }
            Debug.Log(temp+ " " + f.score.ToString());
            newLeaderboard.Add((temp + "- " + f.score.ToString()));
        }
        //newLeaderboard = leaderboard;
        return newLeaderboard;
    }
    private void GenerateHighScore(List<string> leaderboard)
    {
        string highscore = "",temp="";
        //leaderboard.Sort();
        leaderboard.Reverse();
        var x = (leaderboard.Count>5)?5:leaderboard.Count;
        for(int j = 0; j<x; j++)
        {
            var i = leaderboard[j];
            temp = i+"\n";
            highscore += temp;
            temp = "";
        }
        Debug.Log(highscore);
        textLeaderboard.text = highscore;
    }
}
