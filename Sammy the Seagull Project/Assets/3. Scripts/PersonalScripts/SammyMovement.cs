using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: to get sammy to fly from one lamp post to the other, and to change the orientation of his sprite to match
public class SammyMovement : MonoBehaviour
{
    //public variables that allow us to set speed of Sammy and the 2 lamp locations in unity
    public float moveSpeed = 3.0f;
    public Vector2 leftLamp;
    public Vector2 rightLamp;

    //private variables to control sammys movement
    private Vector2 targetLamp;
    private Vector2 currentPosition;
    //bool used to prevent sprite flipping on first movement
    private bool notFirstMove = true;
    //private Rigidbody2D physicsBody = null;
    //private Animator animator = null;

    void Start()
    {
        //physicsBody = GetComponent<Rigidbody2D>(); //calls the rigidbody
        targetLamp = rightLamp; //sets the default lamp target to the lamp Sammy is on to make him not move strangely
        notFirstMove = false; //sets the first move bool to false to ensure the first movement doesnt flip sammys sprite
        //animator = GetComponent<Animator>(); // calls the attached Animator component
    }

    // Update is called once per frame
    void Update()
    {
        //animator = GetComponent<Animator>(); // calls the attached Animator component
        //moves sammy towards the "targetlamp" position as set in the Fly method
        transform.position = Vector2.MoveTowards(transform.position, targetLamp, moveSpeed * Time.deltaTime);
        //updates the current position location as sammy moves
        currentPosition.x = transform.position.x;
        currentPosition.y = transform.position.y;

        //Vector2 currentVel = physicsBody.velocity;
        //animator.SetFloat("flying", currentVel.y);

    }

    public void Fly()
    {
        //if the stored current position shows sammy is on the left lamp
        if (currentPosition == leftLamp) 
        {
            //sets the target lamp to right lamp so sammy moves there
            targetLamp = rightLamp;
            //checks its not the first movement
            if (notFirstMove)
            {
                //flips the orientation of sammy's sprite
                Flip();
            }
            // if it is the first move
            else
            {
                //doesnt flip the model, but updates the variable so it will flip in future
                notFirstMove = true;
            }
            
            
            
        }
        //if the stored current position shows sammy is on the right lamp
        if (currentPosition == rightLamp)
        {
            //sets the target lamp to right lamp so sammy moves there
            targetLamp = leftLamp;
            //checks its not the first movement
            if (notFirstMove)
            {
                //flips sammys sprite
                Flip();
            }
            // if it is the first move
            else
            {
                //doesnt flip the model, but updates the variable so it will flip in future
                notFirstMove = true;
            }

        }
    }

    //used to flip sammys sprite
    public void Flip()
    {
        // takes the current scale vector from unity for sammy's sprite and stores it in a variable
        Vector3 currentScale = gameObject.transform.localScale;
        // multiplies the x scale value by -1 to flip it
        currentScale.x *= -1;
        // updates the scale vector in unity to the new values
        gameObject.transform.localScale = currentScale;
        
    }

    
}
