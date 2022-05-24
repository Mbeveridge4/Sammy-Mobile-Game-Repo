using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hunger : MonoBehaviour
{

    public int startingHunger;
    private int currentHunger;
    public int startingHappy;
    public int currentHappy;



    private void Awake()
    {
        //initialising current health when the player spawns

        currentHunger = startingHunger;
        currentHappy = startingHappy;
    }




    //Action move to relevant game over screen
    public void GameOver()
    {
        
        if (currentHappy <= 50)
        {
            SceneManager.LoadScene("sadScene");
        }
        if (currentHappy >= 50)
        {
            SceneManager.LoadScene("happyScene");
        }


    }

    //action: Change our current health by a set amount
    public void ChangeHealth(int changeAmount)
    {
        //Condition: has it been long enough since we have been damaged

        currentHunger += changeAmount;
        //Action Clamp health between 0 and starting health to avoid negative health and overhealing
        currentHunger = Mathf.Clamp(currentHunger, 0, 100);

        if (currentHunger <= 0)
        {
            GameOver();
        }
    }
    public void ChangeHappy(int changeAmount)
    {
        //Condition: has it been long enough since we have been damaged

        currentHappy += changeAmount;
        //Action Clamp health between 0 and starting health to avoid negative health and overhealing
        currentHappy = Mathf.Clamp(currentHappy, 0, 100);

    }
}
