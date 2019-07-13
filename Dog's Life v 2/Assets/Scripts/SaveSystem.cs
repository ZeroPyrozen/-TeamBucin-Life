using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    public static void SavePlayer(string name, string score)
    {
        string savePath = Application.persistentDataPath + "/leaderboard.txt";
        Debug.Log("Data Saved in " + savePath);
        string s = name + " - " + score;
        using (StreamWriter sw = File.AppendText(savePath))
        {
            sw.WriteLine(s);
        }
    }

    public static void SavePlayer(string v, object p)
    {
        throw new NotImplementedException();
    }

    public static List<string> LoadPlayer()
    {
        List<string> x = new List<string>();
        string savePath = Application.persistentDataPath + "/leaderboard.txt";
        try
        {
            using (StreamReader sr = File.OpenText(savePath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    x.Add(s);
                    s = "";
                }
            }
        }
        catch(FileNotFoundException e)
        {
            Debug.Log(e.StackTrace);
            x.Add("Empty");
        }
        return x;

    }
}
