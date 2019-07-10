using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public int Counter; 
    public bool DialogueCheck;
    public GameObject NamaDisplay;
    public GameObject TextDisplay;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        DialogueCheck = false;
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        if (DialogueCheck == false)
        {
            Text Nama = NamaDisplay.GetComponent<Text>();
            Nama.text = dialogue.nama.ToString();
            //Debug.Log(Nama.text);
            Counter = 0;
            DisplayNextKalimat(dialogue,dialogue.MaxArr());
            DialogueCheck = true;
        }
    }

    public void DisplayNextKalimat(Dialogue dialogue, int CounterIN)
    {
        Text Kalimat = TextDisplay.GetComponent<Text>();
        
        if (Counter == CounterIN)
        {
            EndDialogue();
            Kalimat.text = "";
            return;
        }
        Kalimat.text = dialogue.kalimat[Counter].ToString();
        Debug.Log(Kalimat.text);
        Counter++;
    }

    void EndDialogue()
    {
        Debug.Log("End Of Convorsation");
        animator.SetBool("isOpen", false);
        Counter = 0;
        
    }
}
