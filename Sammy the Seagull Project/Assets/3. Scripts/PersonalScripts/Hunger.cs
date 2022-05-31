using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hunger : MonoBehaviour
{
    public float startingHunger;
    public float currentHunger;
    public float startingHappy;
    public float currentHappy;
   

    private void Awake()
    {
        //initialising current happy and hunger ratings
       
        currentHunger = startingHunger;
        currentHappy = startingHappy;

        if (PlayerPrefs.GetInt("level") <= 2)
        {
            currentHappy = PlayerPrefs.GetFloat("happy");
        }
    }
    private void Update()
    {
        // decreases hunger over time
        currentHunger -= Time.deltaTime*1.5f;

        //moves happiness back to neutral over time
        if (currentHappy > 50)
        {
            currentHappy -= Time.deltaTime;
        }
        if (currentHappy < 50)
        {
            currentHappy += Time.deltaTime;
        }

        //if sammy starves, end game
        if ( currentHunger <= 0)
        {
            SceneManager.LoadScene("neutralScene");
        }
    }




    //Action move to relevant game over screen
    public void GameOver()
    {
        
        if (currentHappy <= 48)
        {
            SceneManager.LoadScene("sadScene");
        }

        if (currentHappy >= 49 && currentHappy <= 51)
        {
            SceneManager.LoadScene("neutralScene");
        }

        if (currentHappy > 51)
        {
            SceneManager.LoadScene("happyScene");
        }


    }

    //action: Change our current Hunger by a set amount
    public void ChangeHunger(int changeAmount)
    {
        currentHunger += changeAmount;
        //Action Clamp hunger between 0 and 100
        currentHunger = Mathf.Clamp(currentHunger, 0, 100);

        
    }
    public void ChangeHappy(int changeAmount)
    {
       

        currentHappy -= changeAmount;
        //Action Clamp health between 0 and starting health to avoid negative health and overhealing
        currentHappy = Mathf.Clamp(currentHappy, 0, 100);
        PlayerPrefs.SetFloat("happy", currentHappy);

    }
}
