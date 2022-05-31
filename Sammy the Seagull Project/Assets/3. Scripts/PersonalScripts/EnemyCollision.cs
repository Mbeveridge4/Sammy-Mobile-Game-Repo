using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int happy = 10;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite defaultSprite;
    public float angerTimer = 3f;
    public float hitTimer = 1f;
    private bool angry = false;

    // 
    // Checks if the object that hits is a trigger, and if so, is it a projectile. If it is - updates the HappyScore with the
    // happy value set in Unity GUI


    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Projectile"))
        {
            Destroy(GameObject.FindWithTag("Projectile"));

            GameObject Sammy = GameObject.FindWithTag("Player");
            Hunger hunger = Sammy.GetComponent<Hunger>(); // Gets the component from the other object and stores it
     
            if (hunger != null)
            {
                hunger.ChangeHappy(happy);
                
            }
            //changes the sprite to the newsprite set in unity GUI
            spriteRenderer.sprite = newSprite;
            //changes angry value
            angry = true;
        }
    }
    public void Update()
    {
        // if the character has been hit and is now in angry
        if (angry == true)
        {
            //counts down the timer
            angerTimer -= Time.deltaTime;
        }    
        if (angerTimer <= 0)
        {
            //when timer reaches 0 - resets sprite and values to default.
            spriteRenderer.sprite = defaultSprite;
            angry = false;
            angerTimer = 3f;

        }
       
    }
}
