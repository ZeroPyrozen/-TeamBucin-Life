using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteTrigger : MonoBehaviour
{
    public SpriteDialogueScript sprite;
    void Awake()
    {
        TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<SpriteDialogueManager>().StartDialogue(sprite);

    }

    public void NextDialogue()
    {
        FindObjectOfType<SpriteDialogueManager>().DisplayNextKalimat(sprite);

    }
}
