using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Coded by Mark Beveridge
/// 
/// This is the script that controls the playback of dialogue in the dialogue box
/// </summary>
public class DialogueManager : MonoBehaviour
{
    public Text nameText; //Unity UI Text variable
    public Text dialogueText; //Unity UI Text variable
    public Animator animator; //allows us to call on a specific animator
    private Queue<string> sentences; // sets up a unity Queue of string value

    //start creates the queue of strings
    void Start()
    {
        sentences = new Queue<string>();
    }

    //when this function is called - triggers the animation to bring down the box, with the values in the sentences
    //which are set in the corresponding trigger
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    //when called checks if there's any more sentences to be played
    //if so calls the end dialogue function
    //otherwise sets up the box for the next dialogue line to display
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();

            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //types out the text one letter at a time - once per frame as currently set
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //puts away the dialogue box using the animator
    void EndDialogue()
    {

        animator.SetBool("IsOpen", false);

    }


}
