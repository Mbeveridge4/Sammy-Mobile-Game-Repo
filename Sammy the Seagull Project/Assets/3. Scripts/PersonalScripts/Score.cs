using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    private float happyScore;
    private float hungerScore;
    public double levelTimer = 20;
    public Text happyText;
    public Text hungerText;
    public Text timerText;
    private int currentLevel = 1;

   
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        //updates the level timer
        levelTimer -= Time.deltaTime;
        //calls the hunger script from sammy
        GameObject Sammy = GameObject.FindWithTag("Player");
        Hunger hunger = Sammy.GetComponent<Hunger>();
        //sets the variables to be displayed from the hunger script
        happyScore = hunger.currentHappy;
        hungerScore = hunger.currentHunger;
        //sets what the text to be displayed is
        happyText.text = ("Happiness: "+ happyScore.ToString("0"));
        hungerText.text = ("Hunger: "+ hungerScore.ToString("0"));
        timerText.text = (levelTimer.ToString("0"));
        currentLevel = PlayerPrefs.GetInt("level");
        //when the level timer runs out
        if (levelTimer <= 0)
        {
            //checks if this is 2nd level or not
            if (currentLevel < 2)
            {
                //updates the level saved in player preferences
                PlayerPrefs.SetInt("level", 2);
                PlayerPrefs.SetFloat("happy", happyScore);
                //moves to level 2
                SceneManager.LoadScene("SammyLevel2");

            }
            // if this is level 2
            if (currentLevel >= 2)
            {
                //runs the GameOver Method from sammy
                hunger.GameOver();
                //resets the level to 1
                PlayerPrefs.SetInt("level", 1);
            }
        }
    }
}
