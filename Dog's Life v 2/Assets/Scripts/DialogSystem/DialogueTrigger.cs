using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

        public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);

    }

    public void NextDialogue()
    {
        FindObjectOfType<DialogManager>().DisplayNextKalimat(dialogue, dialogue.MaxArr());

    }
}
