using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helloWorld : MonoBehaviour
{

    public string message = "default"; //sets a string and its default value, but can be edited in unity

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message); //outputs the message string into the Console Log.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
