using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyPatrol : MonoBehaviour
{
   
    public float forceStrength;     // How fast we move
    public float stopDistance;      // How close we get before moving to next patrol point
    public Vector2[] patrolPoints;  // List of patrol points we will go between

  
    private int currentPoint = 0;       // Index of the current point we're moving towards
    private Rigidbody2D ourRigidbody;   // The rigidbody attached to this object

    void Awake()
    {
        // Get the rigidbody that we'll be using for movement
        ourRigidbody = GetComponent<Rigidbody2D>();
    }


   
    void Update()
    {
        // How far away are we from the target?
        float distance = (patrolPoints[currentPoint] - (Vector2)transform.position).magnitude;

        // If we are closer to our target than our minimum distance...
        if (distance <= stopDistance)
        {
            // Update to the next target
            currentPoint++;

            // If we've gone past the end of our list...
            // (if our current point index is equal or bigger than
            // the length of our list)
            if (currentPoint >= patrolPoints.Length)
            {
                // ...loop back to the start by setting 
                // the current point index to 0
                currentPoint = 0;
            }
        }

        // Now, move in the direction of our target

        // Get the direction
        // Subtract the current position from the target position to get a distance vector
        // Normalise changes it to be length 1, so we can then multiply it by our speed / force
        Vector2 direction = (patrolPoints[currentPoint] - (Vector2)transform.position).normalized;

        // Move in the correct direction with the set force strength
        ourRigidbody.AddForce(direction * forceStrength);
    }
}
