using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int happy = 10;
       
      
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject Sammy = GameObject.FindWithTag("Player");
            Hunger hunger = Sammy.GetComponent<Hunger>(); // Gets the component from the other object and stores it
            

            if (hunger != null)
            {
                hunger.ChangeHappy(happy);
            }
        }
    }
}
