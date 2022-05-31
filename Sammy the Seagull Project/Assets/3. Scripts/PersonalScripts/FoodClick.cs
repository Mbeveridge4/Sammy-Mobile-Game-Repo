using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClick : MonoBehaviour
{
    //time to add to the game timer
    public int addTime = 6;
    //max lifetime of the food item
    public float lifeTime = 7;
    

    public void Update()
    {
        //countdown life time
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            //destroys the object this is attached to.
            Destroy(gameObject);
        }
    }
    //when the object is clicked
    private void OnMouseDown()
    {
        GameObject Sammy = GameObject.FindWithTag("Player");
        Hunger hunger = Sammy.GetComponent<Hunger>(); // Gets the component from the other object and stores it
        //adds the time to the timer
        hunger.ChangeHunger(addTime);
        //destroys the food object
        Destroy(gameObject);
    }
}
