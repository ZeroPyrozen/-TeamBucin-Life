using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteTrigger : MonoBehaviour
{
    public SpriteDialogueScript sprite;
    private bool hasStart = false;
    void Awake()
    {
        TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<SpriteDialogueManager>().StartDialogue(sprite);
        hasStart = true;
    }

    public void NextDialogue()
    {
        FindObjectOfType<SpriteDialogueManager>().DisplayNextKalimat(sprite);

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && hasStart)
        {
            NextDialogue();
        }
    }
}
