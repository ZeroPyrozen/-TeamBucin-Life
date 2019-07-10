using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DrawingInput
{
    public Sprite[] gambar;
    public int MaxArr()
    {
        return gambar.Length;
    }
}
