using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Mark Beveridge
//used to store dialogue for the Dialogue manager to use - attached to the trigger function where you can enter the
//dialogue text directly in Unity


[System.Serializable]
public class Dialogue
{
    //sets the text area to something a little more roomy to enter your text in
    [TextArea(3, 10)]
    //creates a string array of sentences
    // takes a string for name
    public string[] sentences;
    public string name;


}
