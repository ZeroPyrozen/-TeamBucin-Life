using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DrawingSliding : MonoBehaviour
{
    public DrawingInput drawingInput;
    public int Counter;
    //private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject go = GameObject.FindWithTag("PenahanGambar");
        //spriteRenderer = go.GetComponent<SpriteRenderer>();
        //drawingInput = new class<Sprite>();
        Counter = 0;
    }

    public void StartDrawing()
    {
        Counter = 0-1;
        Debug.Log("Besar Queue Setelah Foreach : " + Counter);
        //DisplayNextImage();
    }

    public void DisplayNextImage(DrawingInput drawingInput)
    {
        if (Counter == drawingInput.MaxArr()-1)
        {
            Debug.Log("Done");
            return;
        }
        Counter++;
        //spriteRenderer.sprite = sprite;
    }

    public void Test()
    {

        Debug.Log("Masuk");
    }
}
