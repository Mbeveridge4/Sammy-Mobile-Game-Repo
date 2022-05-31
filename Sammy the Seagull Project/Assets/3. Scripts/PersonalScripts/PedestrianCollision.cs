using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianCollision : MonoBehaviour
{
    public int happy = 0;
  
   //
   // Checks if the object that hits is a trigger, and if so, is it a projectile. If it is - updates the HappyScore with the
   // happy value set in Unity GUI
    private void OnTriggerEnter2D(Collider2D collider)
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
        }
    }
    
}

