using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpriteDialogueManager : MonoBehaviour
{

    public int Counter;
    public int CounterSprite = 0;
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



            Counter = 0;
            DisplayNextKalimat(spriteScript);
            SpriteDialogueCheck = true;
        }
    }

    public void DisplayNextKalimat(SpriteDialogueScript spriteScript)
    {
        Text Kalimat = TextDisplay.GetComponent<Text>();
        if (Counter == spriteScript.kalimat.Length)
        {
            EndDialogue();
            Kalimat.text = "";
            return;
        }
        if (Counter == 1 || Counter == 4 || Counter == 11 || Counter == 15)
        {
            spriteHolder.GetComponent<SpriteRenderer>().sprite = spriteScript.sprites[CounterSprite];
            CounterSprite++;
        }

        //Kalimat.text = spriteScript.kalimat[Counter].ToString();
        StopAllCoroutines();
        StartCoroutine(TypingEffect(Kalimat, spriteScript.kalimat[Counter], spriteScript.delayTiapKatadiKalimat[Counter]));
        //Debug.Log(Kalimat.text);
        Counter++;
    }

    void EndDialogue()
    {

        Debug.Log("End Of Convorsation");
        SceneManager.LoadScene("Park");
        //animator.SetBool("isOpen", false);
        //ini lanjut ke scene berikutnya

    }


    IEnumerator TypingEffect (Text kalimat,string kalimatIE, int Delay)
    {
        kalimat.text = "";
        foreach (char letter in kalimatIE.ToCharArray())
        {
            kalimat.text += letter;
            yield return Delay;
        }
    }
}
