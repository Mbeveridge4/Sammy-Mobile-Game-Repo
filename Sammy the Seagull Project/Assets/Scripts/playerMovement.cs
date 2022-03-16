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
        // Ask Unity's Input manager for the current value of the horizontal and vertical Axis.
        // These will be between -1 and 1
       float axisValX = Input.GetAxis("Horizontal");
       float axisValY = Input.GetAxis("Vertical");

        //use axes values to set up a new velocity vector
        Vector2 newVel = new Vector2(axisValX, axisValY);

        //Scale our velocity based on a speed
        // Goes from -speet to +speed
        newVel = newVel * moveSpeed;

        // Tell the physics rigidbody to use the new velocity
        // physicsBody.velocity = newVel;

    }

    public void MoveUp()
    {
        Debug.Log("MoveUp button Pressed!!!");

        Vector2 newVel = new Vector2(0, moveSpeed);

        physicsBody.velocity = newVel;
    }

}
