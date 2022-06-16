using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Mark Beveridge
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    //when something enters the trigger - triggers the dialogue, then destroys the trigger so it doesnt
    //repeat every time you go in and out of the space
    public void OnTriggerEnter2D(Collider2D collider)
    {
        TriggerDialogue();
        Destroy(this);
    }

    //finds the dialogue manager - and feeds it the attached dialogue, and tells it to Start working.
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

