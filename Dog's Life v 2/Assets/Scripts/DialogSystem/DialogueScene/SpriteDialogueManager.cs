using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteDialogueManager : MonoBehaviour
{

    public int Counter;
    public bool SpriteDialogueCheck;
    //public GameObject NamaDisplay;
    public GameObject TextDisplay;
    //public Animator animator;
    public GameObject spriteHolder;

    // Start is called before the first frame update
    void Start()
    {
        SpriteDialogueCheck = false;
    }

    public void StartDialogue(SpriteDialogueScript spriteScript)
    {
        //animator.SetBool("isOpen", true);
        if (SpriteDialogueCheck == false)
        {
            //Text Nama = NamaDisplay.GetComponent<Text>();
            //Nama.text = sprite.nama.ToString();
            //Debug.Log(Nama.text);
            spriteHolder.GetComponent<SpriteRenderer>().sprite = spriteScript.sprites[Counter];
            Counter = 0;
            DisplayNextKalimat(spriteScript, spriteScript.MaxArr());
            SpriteDialogueCheck = true;
        }
    }

    public void DisplayNextKalimat(SpriteDialogueScript spriteScript, int CounterIN)
    {
        Text Kalimat = TextDisplay.GetComponent<Text>();

        if (Counter == CounterIN)
        {
            EndDialogue();
            Kalimat.text = "";
            return;
        }
        spriteHolder.GetComponent<SpriteRenderer>().sprite = spriteScript.sprites[Counter];
        Kalimat.text = spriteScript.kalimat[Counter].ToString();
        Debug.Log(Kalimat.text);
        Counter++;
    }

    void EndDialogue()
    {
        Debug.Log("End Of Convorsation");
        //animator.SetBool("isOpen", false);
        Counter = 0;

    }
}
