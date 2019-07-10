using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string nama;


    [TextArea(4,10)]
    public string[] kalimat;
    public int MaxArr()
    {
        return kalimat.Length;
    }
}
