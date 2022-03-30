using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //the thing we ran into
        GameObject otherObject = collision.gameObject;
        //the name of the other thing
        string otherName = otherObject.name;
        //the tag of the other thing
        string otherTag = otherObject.tag;
        // we can get the LAYER (PHYSICS) of the thing
        int layer = otherObject.layer;
        // we can check if a script is attached to the thing, and get it
        // getting a component (off the other object)
        SpriteRenderer spriteRenderer = otherObject.GetComponent<SpriteRenderer>();

        Debug.Log("You touched me! " + otherName);
        Debug.Log("You have the following tag " + otherTag);
        Debug.Log("Your Physics Layer is " + layer);
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.green;
        }
    }

}
