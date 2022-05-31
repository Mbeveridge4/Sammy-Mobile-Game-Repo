using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    //Array of objects to spawn (can add multiple food items in future in unity GUI)
    public GameObject[] theFood;

    //Time it takes to spawn theFood
    [Space(5)]
    public float waitingForNextSpawn = 3;
    public float theCountdown = 3;

    // the range of X (set in Unity GUI)
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    // the range of y (set in Unity GUI)
    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;


    

    public void Update()
    {
        // timer to spawn the next goodie Object
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnFood();
            theCountdown = waitingForNextSpawn;
        }
    }


    void SpawnFood()
    {
        // Defines the position to spawn randomly from min and max positions
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

        // Choose a new food to spawn from the array
        GameObject Food = theFood[Random.Range(0, theFood.Length+1)];

        // Creates the random food at the random 2D position.
        Instantiate(Food, pos, transform.rotation);


    }
}
