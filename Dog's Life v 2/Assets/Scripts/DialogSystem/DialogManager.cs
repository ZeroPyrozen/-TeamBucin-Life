using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public Queue<string> kalimat;
    // Start is called before the first frame update
    void Start()
    {
        kalimat = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting Conversation with " + dialogue.nama);
        Debug.Log("Kalimat di sebelum Clear : " + kalimat.Count);
        kalimat.Clear();
        Debug.Log("Kalimat di setelah Clear : " + kalimat.Count);
        foreach (string kalimats in dialogue.kalimat)
        {
            kalimat.Enqueue(kalimats);
            Debug.Log("dalam Foreach : " + kalimat.Count);
        }

        DisplayNextKalimat();
        Debug.Log("setelah Hai : " + kalimat.Count);
    }

    public void Test()
    {
        Debug.Log("Current kalimat queue qount: " + kalimat.Count);
    }

    public void DisplayNextKalimat()
    {
        if (kalimat.Count == 0)
        {
            Debug.Log("Kalimat di DisplayNextKalimat : "+kalimat.Count);
            EndDialogue();
            return;
        }
        string kalimatDisplay = kalimat.Dequeue();
        Debug.Log(kalimatDisplay);
    }

    void EndDialogue()
    {
        Debug.Log("End Of Convorsation");
    }
}
