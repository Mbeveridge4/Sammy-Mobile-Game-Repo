using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //Declares that the script cant run on an object without a rigidbody2D and gives it one if it doesnt have it
public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f; 

    private Rigidbody2D physicsBody = null; 


    // Start is called before the first frame update
    void Start()
    {
        physicsBody = GetComponent<Rigidbody2D>(); //calls the rigidbody

       // physicsBody.velocity = new Vector2(2,0); //sets the velocity variable of the physicsBody (x,y) per second
    }

    // Update is called once per frame
    void Update()
    {
        // Ask Unity's Input manager for the current value of the horizontal Axis.
        // This will be between -1 and 1
       float axisVal = Input.GetAxis("Horizontal");

        Vector2 newVel = new Vector2(axisVal, 0);
        newVel = newVel * moveSpeed;
        physicsBody.velocity = newVel;
    }
}
